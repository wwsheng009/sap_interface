using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

using MiniSqlQuery.Core;
using System.Threading;
using MiniSqlQuery.PlugIns;
using MiniSqlQuery.Core.DbModel;
using MiniSqlQuery.Core.Template;
using MiniSqlQuery.PlugIns.TemplateViewer;
using MiniSqlQuery.Core.Forms;
using MiniSqlQuery.PlugIns.ConnectionStringsManager;
using MiniSqlQuery.PlugIns.DatabaseInspector;
using MiniSqlQuery.PlugIns.ViewTable;
using MiniSqlQuery.PlugIns.TextGenerator;
using MiniSqlQuery.PlugIns.SearchTools;
using MiniSqlQuery.Properties;
using Autofac;
using Autofac.Core;

namespace MiniSqlQuery
{
   public static class Program
    {

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
         static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //log4net.Config.XmlConfigurator.Configure(new FileInfo("log4net.config"));
            //log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            //log.Info("程序开始，加载SAP配置！！");

            //SAPINT.SapConfig.SAPConfigFromFile.LoadSAPAllConfig();
            //SAPINT.SapConfig.SAPConfigFromFile.LoadSAPClientConfig();


            //IOC入口，获取主程序的实例
            IApplicationServices services = ApplicationServices.Instance;

            //加载程序内部服务
            ConfigureContainer(services);

            //跟上面不同，以下加载内部插件
            services.LoadPlugIn(new CoreApplicationPlugIn());
            services.LoadPlugIn(new ConnectionStringsManagerLoader());
            services.LoadPlugIn(new DatabaseInspectorLoader());
            services.LoadPlugIn(new ViewTableLoader());
            services.LoadPlugIn(new TemplateViewerLoader());
            services.LoadPlugIn(new SearchToolsLoader());
            services.LoadPlugIn(new TextGeneratorLoader());

            //加载外部插件
            if (services.Settings.LoadExternalPlugins)
            {
                var plugins = PlugInUtility.GetInstances<IPlugIn>(Environment.CurrentDirectory, Settings.Default.PlugInFileFilter);
                Array.Sort(plugins, new PlugInComparer());
                foreach (var plugin in plugins)
                {
                    services.LoadPlugIn(plugin);
                }
            }

            //插件加载完！！！

            //services.HostWindow = services.Container.Resolve<IHostWindow>();
            //services.HostWindow.SetArguments(args);
            MainForm mainform = (MainForm)services.HostWindow;
            // mainform.Serivices = services;
            //  mainform.Settings = services.Settings;
            mainform.SetArguments(args);

            Application.Run(mainform);

        }
        public static void LoadForm(string[] args)
        {
            //IOC入口，获取主程序的实例
            IApplicationServices services = ApplicationServices.Instance;

            //加载程序内部服务
            ConfigureContainer(services);

            //跟上面不同，以下加载内部插件
            services.LoadPlugIn(new CoreApplicationPlugIn());
            services.LoadPlugIn(new ConnectionStringsManagerLoader());
            services.LoadPlugIn(new DatabaseInspectorLoader());
            services.LoadPlugIn(new ViewTableLoader());
            services.LoadPlugIn(new TemplateViewerLoader());
            services.LoadPlugIn(new SearchToolsLoader());
            services.LoadPlugIn(new TextGeneratorLoader());

            //加载外部插件
            if (services.Settings.LoadExternalPlugins)
            {
                var plugins = PlugInUtility.GetInstances<IPlugIn>(Environment.CurrentDirectory, Settings.Default.PlugInFileFilter);
                Array.Sort(plugins, new PlugInComparer());
                foreach (var plugin in plugins)
                {
                    services.LoadPlugIn(plugin);
                }
            }

            //插件加载完！！！

            //services.HostWindow = services.Container.Resolve<IHostWindow>();
            //services.HostWindow.SetArguments(args);
            MainForm mainform = (MainForm)services.HostWindow;
            // mainform.Serivices = services;
            //  mainform.Settings = services.Settings;
            mainform.SetArguments(args);
            mainform.Show();
        }
       
        /// <summary>
        /// 配置主服务，加载必要的插件
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureContainer(IApplicationServices services)
        {


            // services.RegisterSingletonComponent<IApplicationSettings, ApplicationSettings>("ApplicationSettings");
            // services.RegisterSingletonComponent<IApplicationSettings, ApplicationSettings>(");
            //services.RegisterSingletonComponent<IHostWindow, MainForm>("HostWindow");

            //services.RegisterSingletonComponent<IFileEditorResolver, FileEditorResolverService>("FileEditorResolver");
            //
            //services.RegisterComponent<AboutForm>("AboutForm");
            //services.RegisterComponent<ITextFindService, BasicTextFindService>("DefaultTextFindService");
            //services.RegisterComponent<IQueryEditor, QueryForm>("QueryForm");
            //services.RegisterComponent<ISqlWriter, SqlWriter>("DefaultSqlWriter");
            //services.RegisterComponent<ITextFormatter, NVelocityWrapper>("TextFormatter");
            //services.RegisterComponent<TemplateModel>("TemplateModel");
            //services.RegisterComponent<BatchQuerySelectForm>("BatchQuerySelectForm");
            //services.RegisterComponent<IApplicationSettings, ApplicationSettings>();
            //services.RegisterComponent<IHostWindow, MainForm>();


            //services.RegisterComponent<IFileEditorResolver, FileEditorResolverService>();
            //services.RegisterComponent<AboutForm>();
            //services.RegisterComponent<ITextFindService, BasicTextFindService>();

            // services.RegisterComponent<IQueryEditor, QueryForm>();
            // services.RegisterComponent<ISqlWriter, SqlWriter>();
            // services.RegisterComponent<TemplateModel>();
            // services.RegisterComponent<BatchQuerySelectForm>();

            //批量更新时，不使用services.RegisterComponent,
            var builder = new ContainerBuilder();

            //首先注册设置服务
            builder.RegisterType<ApplicationSettings>().As<IApplicationSettings>().InstancePerLifetimeScope();

            //
            builder.RegisterType<MainForm>().As<IHostWindow>().InstancePerLifetimeScope().WithParameters(
             new[] { new ResolvedParameter((p,c)=>p.ParameterType == typeof(IApplicationServices),(p,c)=>c.Resolve<IApplicationServices>()),
                    new ResolvedParameter((p,c)=>p.ParameterType == typeof(IHostWindow),(p,c)=>c.Resolve<IHostWindow>())
                });

            builder.RegisterType<FileEditorResolverService>().As<IFileEditorResolver>().InstancePerLifetimeScope().WithParameter(
                new ResolvedParameter((p, c) => p.ParameterType == typeof(IApplicationServices), (p, c) => c.Resolve<IApplicationServices>())
            );

            builder.RegisterType<AboutForm>().WithParameter(
                new ResolvedParameter((p, c) => p.ParameterType == typeof(IApplicationServices), (p, c) => c.Resolve<IApplicationServices>())
            );

            builder.RegisterType<BasicTextFindService>().As<ITextFindService>().WithParameter(
               new ResolvedParameter((p, c) => p.ParameterType == typeof(IApplicationServices), (p, c) => c.Resolve<IApplicationServices>())
           );

            builder.RegisterType<QueryForm>().As<IQueryEditor>().WithParameters(
                new[] { new ResolvedParameter((p,c)=>p.ParameterType == typeof(IApplicationServices),(p,c)=>c.Resolve<IApplicationServices>()),
                    new ResolvedParameter((p,c)=>p.ParameterType == typeof(IApplicationSettings),(p,c)=>c.Resolve<IApplicationSettings>()),
                    new ResolvedParameter((p,c)=>p.ParameterType == typeof(IHostWindow),(p,c)=>c.Resolve<IHostWindow>())
                });



            builder.RegisterType<SqlWriter>().As<ISqlWriter>();
            builder.RegisterType<NVelocityWrapper>().As<ITextFormatter>();

            // services.RegisterComponent<ITextFormatter, NVelocityWrapper>();

            builder.RegisterType<TemplateModel>().WithParameters(
            new[] { new ResolvedParameter((p,c)=>p.ParameterType == typeof(IApplicationServices),(p,c)=>c.Resolve<IApplicationServices>()),
                    new ResolvedParameter((p,c)=>p.ParameterType == typeof(ITextFormatter),(p,c)=>c.Resolve<ITextFormatter>()),
                    new ResolvedParameter((p,c)=>p.ParameterType == typeof(TemplateData),(p,c)=>c.Resolve<TemplateData>())
                });
            builder.RegisterType<BatchQuerySelectForm>();
            builder.Update(services.Container);





        }

        /// <summary>
        /// 	The application thread exception.
        /// </summary>
        /// <param name = "sender">The sender.</param>
        /// <param name = "e">The e.</param>
        private static void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
        {
            if (!(e.Exception is ThreadAbortException))
            {
                HandleException(e.Exception);
            }
        }
        /// <summary>
        /// 	The current domain unhandled exception.
        /// </summary>
        /// <param name = "sender">The sender.</param>
        /// <param name = "e">The e.</param>
        private static void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (!(e.ExceptionObject is ThreadAbortException))
            {
                HandleException((Exception)e.ExceptionObject);
            }
        }
        /// <summary>
        /// 	The handle exception.
        /// </summary>
        /// <param name = "e">The e.</param>
        private static void HandleException(Exception e)
        {
            ErrorForm errorForm = new ErrorForm();
            errorForm.SetException(e);
            errorForm.ShowDialog();
            errorForm.Dispose();
        }
    }
}
