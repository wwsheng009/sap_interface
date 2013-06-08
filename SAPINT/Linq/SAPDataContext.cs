namespace SAPINT.Linq
{
    using SAPINT;
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;
    using SAP.Middleware.Connector;

    public class SAPDataContext : IDisposable
    {
        //private RfcDestination _des;
        private String connection;
        private bool _disposed;

        public SAPDataContext()
        {
            this.AutoCloseConnection = true;
        }

        public SAPDataContext(string sysName)
            : this()
        {
            if (string.IsNullOrEmpty(sysName))
            {
                throw new ArgumentNullException("SystemName");
            }
            //this._des = SAPDestination.GetDesByName(sysName);
            this.connection = sysName;
        }

        //public SAPDataContext(string httpUrl, string username, string password, string language, string client) : this()
        //{
        //    this.Connection = new R3Connection(httpUrl, username, password, language, client);
        //}

        //public SAPDataContext(string host, int system, string username, string password, string language, string client) : this()
        //{
        //    this.Connection = new R3Connection(host, system, username, password, language, client);
        //}

        protected void CheckDispose()
        {
            if (this._disposed)
            {
                throw new SAPException("SAPDataContext cannot be used after dispose");
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // this._des = null;
            //if ((this.AutoCloseConnection && !this._disposed) && ((this.Connection != null) && this.Connection.Ping()))
            //{
            //    this.Connection.Close();
            //}
            this._disposed = true;
        }

        ~SAPDataContext()
        {
            this.Dispose(false);
        }

        public SAPTable<TEntity> GetTable<TEntity>() where TEntity : class
        {
            return this.GetTable<TEntity>(false);
        }

        public SAPTable<TEntity> GetTable<TEntity>(bool useMultibyteExtraction) where TEntity : class
        {
            return new SAPTable<TEntity>(this, useMultibyteExtraction);
        }
        public SAPTable<TEntity> GetTable<TEntity>(TextWriter log, bool useMultibyteExtraction) where TEntity : class
        {
            return new SAPTable<TEntity>(this.connection, log, useMultibyteExtraction);
        }
        public bool AutoCloseConnection { get; set; }

        //public RfcDestination Destination
        //{
        //    get
        //    {
        //        this.CheckDispose();
        //        return this._des;
        //    }
        //    set
        //    {
        //        this._des = value;
        //    }
        //}
        public String Connection
        {
            get { return this.connection; }
            set { this.connection = value; }
        }
        public TextWriter Log { get; set; }
    }
}

