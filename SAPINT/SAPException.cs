using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SAPINT
{
    using System;
    using System.Runtime.Serialization;
    using System.Security.Permissions;
    [Serializable]
    public class SAPException : Exception, ISerializable
    {
        log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string abapexception;
        
        public string ABAPException
        {
            get {
                return abapexception;
            }
            set
            {
                abapexception = value;
                log.Error(value);
            }
        }
        public SAPException()
        {
            this.ABAPException = "";
        }
        public SAPException(string message)
            : base(message)
        {
            this.ABAPException = message;
        }
        protected SAPException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.ABAPException = "";
            if (info == null)
            {
                throw new ArgumentNullException("No SerializationInfo");
            }
            this.ABAPException = info.GetString("AbapException");
        }
        public SAPException(string message, Exception InnerException)
            : base(message, InnerException)
        {
            this.ABAPException = "";
        }
        public SAPException(string message, string AbapException)
            : base(message)
        {
            this.ABAPException = "";
            this.ABAPException = AbapException;
        }
        public SAPException(string message, Exception InnerException, string AbapException)
            : base(message, InnerException)
        {
            this.ABAPException = "";
            this.ABAPException = AbapException;
        }
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
            info.AddValue("AbapException", this.ABAPException);
        }
    }
}
