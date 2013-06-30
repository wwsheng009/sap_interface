#region License

// Copyright 2005-2009 Paul Kohler (http://pksoftware.net/MiniSqlQuery/). All rights reserved.
// This source code is made available under the terms of the Microsoft Public License (Ms-PL)
// http://minisqlquery.codeplex.com/license

#endregion

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Autofac;
using Autofac.Core;
//using Castle.Core;
//using Castle.MicroKernel;

namespace MiniSqlQuery.Core
{
    /// <summary>
    /// 	The core services of the application (singleton).
    /// </summary>
    public class ApplicationServices : IApplicationServices
    {
        /// <summary>
        /// 	The _configuration objects.
        /// </summary>
        private static readonly List<Type> _configurationObjects = new List<Type>();

        /// <summary>
        /// 	The _container.
        /// </summary>
        //private static readonly IKernel _container;
        private static readonly IContainer _container;


        //private static readonly ContainerBuilder _builder;
        /// <summary>
        /// 	The _plugins.
        /// </summary>
        private readonly Dictionary<Type, IPlugIn> _plugins = new Dictionary<Type, IPlugIn>();

        /// <summary>
        /// 	Initializes static members of the <see cref = "ApplicationServices" /> class.
        /// </summary>
        static ApplicationServices()
        {
            //_container = new DefaultKernel();
            var _builder = new ContainerBuilder();

            // add self
            // _container.AddComponent("ApplicationServices", typeof(IApplicationServices), typeof(ApplicationServices), LifestyleType.Singleton);
            _builder.RegisterType<ApplicationServices>().As<IApplicationServices>().InstancePerLifetimeScope();
            _container = _builder.Build();

        }

        /// <summary>
        /// 	Occurs when a system message is posted.
        /// </summary>
        public event EventHandler<SystemMessageEventArgs> SystemMessagePosted;

        /// <summary>
        /// 	Gets a reference to the singleton instance of the services for this application.
        /// </summary>
        /// <value>The singleton instance of <see cref = "IApplicationServices" />.</value>
        public static IApplicationServices Instance
        {
            get
            {
                //  return _container.GetService<IApplicationServices>();
                return _container.Resolve<IApplicationServices>();
            }
        }

        /// <summary>
        /// 	Gets the Dependency Injection container.
        /// </summary>
        /// <value>The container.</value>
        //public IKernel Container
        public IContainer Container
        {
            get { return _container; }
        }

        private IHostWindow _hostWindow;
        /// <summary>
        /// 	Gets the application host window.
        /// </summary>
        /// <value>The host window - a <see cref = "Form" />.</value>
        public IHostWindow HostWindow
        {
            get
            {
                //return _container.GetService<IHostWindow>();
                return _container.Resolve<IHostWindow>();
                //  return _hostWindow;
                // return _container.ResolveKeyed<IHostWindow>("HostWindow");
            }
            //set
            //{
            //    _hostWindow = value;
            //}
        }

        /// <summary>
        /// 	Gets a dictionary of the current plugins for this application.
        /// </summary>
        /// <value>A reference to the plugin dictionary.</value>
        public Dictionary<Type, IPlugIn> Plugins
        {
            get { return _plugins; }
        }

        /// <summary>
        /// 	Gets the application settings instance.
        /// </summary>
        /// <value>A reference to the settings handler.</value>
        public IApplicationSettings Settings
        {
            get
            {
                //return _container.GetService<IApplicationSettings>();
                return _container.Resolve<IApplicationSettings>();
                // return _container.ResolveKeyed<IApplicationSettings>("ApplicationSettings");
            }
        }

        /// <summary>
        /// 	The get configuration object types.
        /// </summary>
        /// <returns>An array of configuration objects.</returns>
        public Type[] GetConfigurationObjectTypes()
        {
            return _configurationObjects.ToArray();
        }

        /// <summary>
        /// 	Initializes the plugins that have been loaded during application startup.
        /// </summary>
        public void InitializePlugIns()
        {
            foreach (IPlugIn plugIn in _plugins.Values)
            {
                try
                {
                    if (HostWindow != null)
                    {
                        HostWindow.SetStatus(null, "Initializing " + plugIn.PluginName);
                    }

                    plugIn.InitializePlugIn();
                }
                catch (Exception exp)
                {
                    if (HostWindow == null)
                    {
                        throw;
                    }

                    HostWindow.DisplayMessageBox(
                        null,
                        string.Format("Error Initializing {0}:{1}{2}", plugIn.PluginName, Environment.NewLine, exp),
                        "Plugin Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1,
                        0,
                        null,
                        null);
                }
            }
        }

        /// <summary>
        /// 	Loads the <paramref name = "plugIn" /> (calling its <see cref = "IPlugIn.LoadPlugIn" /> method) and
        /// 	adds it to the <see cref = "Plugins" /> dictionary for access by other services.
        /// </summary>
        /// <param name = "plugIn">The plugin to load.</param>
        /// <exception cref = "ArgumentNullException">If <paramref name = "plugIn" /> is null.</exception>
        public void LoadPlugIn(IPlugIn plugIn)
        {
            if (plugIn == null)
            {
                throw new ArgumentNullException("plugIn");
            }

            plugIn.LoadPlugIn(this);
            _plugins.Add(plugIn.GetType(), plugIn);
            //_container.AddComponent(plugIn.GetType().FullName, typeof(IPlugIn), plugIn.GetType());

            var _builder = new ContainerBuilder();
            //_builder.Register();
            _builder.RegisterType(plugIn.GetType()).As<IPlugIn>();
            _builder.Update(_container);
            //  _builder.Update(_container);
        }

        /// <summary>
        /// 	Posts a system message for listeners.
        /// </summary>
        /// <param name = "message">A system message type.</param>
        /// <param name = "data">The asssociated data.</param>
        public void PostMessage(SystemMessage message, object data)
        {
            OnSystemMessagePosted(new SystemMessageEventArgs(message, data));
        }

        /// <summary>
        /// 	Registers the component service type <typeparamref name = "TService" /> with and implemetation of type <typeparamref name = "TImp" />.
        /// </summary>
        /// <typeparam name = "TService">The contract type.</typeparam>
        /// <typeparam name = "TImp">The implementing type.</typeparam>
        /// <param name = "key">The key or name of the service.</param>
        public void RegisterComponent<TService, TImp>(string key)
        {
            //_container.AddComponent(key, typeof(TService), typeof(TImp), LifestyleType.Transient);
            var _builder = new ContainerBuilder();
            _builder.RegisterType<TImp>().Keyed<TService>(key);
            _builder.Update(_container);

            // var a = _container.Resolve<IApplicationSettings>();
            //  _builder.Update(_container);
        }
        public void RegisterComponent<TService, TImp>()
        {
            //_container.AddComponent(key, typeof(TService), typeof(TImp), LifestyleType.Transient);
            var _builder = new ContainerBuilder();
            //_builder.RegisterType<TImp>().As<TService>();


            _builder.RegisterType<TImp>().As<TService>().WithParameters(
            new[] { new ResolvedParameter((p,c)=>p.ParameterType == typeof(IApplicationServices),(p,c)=>c.Resolve<IApplicationServices>()),
                    new ResolvedParameter((p,c)=>p.ParameterType == typeof(IHostWindow),(p,c)=>c.Resolve<IHostWindow>()),
                    new ResolvedParameter((p,c)=>p.ParameterType == typeof(IApplicationSettings),(p,c)=>c.Resolve<IApplicationSettings>())
                });

            _builder.Update(_container);

        }
        /// <summary>
        /// 	Registers the component implemetation of type <typeparamref name = "TImp" />.
        /// </summary>
        /// <typeparam name = "TImp">The implementing type.</typeparam>
        /// <param name = "key">The key or name of the service.</param>
        public void RegisterComponent<TImp>(string key)
        {
            //_container.AddComponent(key, typeof(TImp), LifestyleType.Transient);
            var _builder = new ContainerBuilder();
            _builder.RegisterType<TImp>().Keyed(key, typeof(TImp));
            _builder.Update(_container);
        }
        public void RegisterComponent<Timp>()
        {
            //_container.AddComponent(key, typeof(TImp), LifestyleType.Transient);
            var _builder = new ContainerBuilder();
           // _builder.RegisterType<Timp>();
            _builder.RegisterType<Timp>().WithParameters(
            new[] { new ResolvedParameter((p,c)=>p.ParameterType == typeof(IApplicationServices),(p,c)=>c.Resolve<IApplicationServices>()),
                new ResolvedParameter((p,c)=>p.ParameterType == typeof(IHostWindow),(p,c)=>c.Resolve<IHostWindow>()),
                new ResolvedParameter((p,c)=>p.ParameterType == typeof(IApplicationSettings),(p,c)=>c.Resolve<IApplicationSettings>())
                    
                });
            _builder.Update(_container);
        }
        /// <summary>
        /// 	The register configuration object.
        /// </summary>
        /// <typeparam name = "TConfig">A configuration class.</typeparam>
        public void RegisterConfigurationObject<TConfig>() where TConfig : IConfigurationObject
        {
            // RegisterComponent<IConfigurationObject, TConfig>(typeof(TConfig).FullName);
            RegisterComponent<IConfigurationObject, TConfig>();
            // haven't successfully been able to query this into out of castle container (yet)
            _configurationObjects.Add(typeof(TConfig));
        }

        /// <summary>
        /// 	Registers the editor of type <typeparamref name = "TEditor" /> using the <see cref = "FileEditorDescriptor.EditorKeyName" />.
        /// </summary>
        /// <typeparam name = "TEditor">The editor type (e.g. "BasicXmlEditor").</typeparam>
        /// <param name = "fileEditorDescriptor">The file extension descriiptor for this type.</param>
        public void RegisterEditor<TEditor>(FileEditorDescriptor fileEditorDescriptor) where TEditor : IEditor
        {
            //RegisterComponent<IEditor, TEditor>(fileEditorDescriptor.EditorKeyName);
            RegisterComponent<IEditor, TEditor>();
            // push the ext reg into the resolver....
            IFileEditorResolver resolver = Resolve<IFileEditorResolver>();
            resolver.Register(fileEditorDescriptor);
        }

        /// <summary>
        /// 	Registers the component service type <typeparamref name = "TService" /> with and implemetation of type <typeparamref name = "TImp" /> as a singleton.
        /// </summary>
        /// <typeparam name = "TService">The contract type.</typeparam>
        /// <typeparam name = "TImp">The implementing type.</typeparam>
        /// <param name = "key">The key or name of the service.</param>
        public void RegisterSingletonComponent<TService, TImp>(string key)
        {
            // _container.AddComponent(key, typeof(TService), typeof(TImp), LifestyleType.Singleton);
            var _builder = new ContainerBuilder();
            _builder.RegisterType<TImp>().Keyed<TService>(key).InstancePerLifetimeScope();
            _builder.Update(_container);
        }
        public void RegisterSingletonComponent<TService, TImp>()
        {
            // _container.AddComponent(key, typeof(TService), typeof(TImp), LifestyleType.Singleton);
            var _builder = new ContainerBuilder();
            _builder.RegisterType<TImp>().InstancePerLifetimeScope();
            _builder.Update(_container);
        }
        /// <summary>
        /// 	Resolves an instance of <typeparamref name = "T" /> from the container.
        /// </summary>
        /// <typeparam name = "T">The type of object to resolve, can be an interface or class.</typeparam>
        /// <param name = "key">The key (can be null if not applicable).</param>
        /// <returns>An instance of the type depending on the containters configuration.</returns>
        public T Resolve<T>(string key)
        {
            if (key == null)
            {
                return _container.Resolve<T>();
            }

           // return _container.Resolve<T>();
            return _container.ResolveKeyed<T>(key);
          
        }
        /// <summary>
        /// 	The resolve.
        /// </summary>
        /// <typeparam name = "T">The type of object to resolve, can be an interface or class.</typeparam>
        /// <returns>An instance of the type depending on the containters configuration.</returns>
        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        /// <summary>
        /// 	The on system message posted.
        /// </summary>
        /// <param name = "eventArgs">The event args.</param>
        protected void OnSystemMessagePosted(SystemMessageEventArgs eventArgs)
        {
            EventHandler<SystemMessageEventArgs> handler = SystemMessagePosted;
            if (handler != null)
            {
                handler(this, eventArgs);
            }
        }



    }
}