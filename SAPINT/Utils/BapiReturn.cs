using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SAPINT
{
    public class BapiReturn
    {
        private string _Code = "";
        private string _LogMessageNumber = "";
        private string _LogNumber = "";
        private string _Message = "";
        private string _MessageVariable1 = "";
        private string _MessageVariable2 = "";
        private string _MessageVariable3 = "";
        private string _MessageVariable4 = "";
        private string _Type = "";
        public string Code
        {
            get
            {
                return this._Code;
            }
            set
            {
                this._Code = value;
            }
        }
        public string LogMessageNumber
        {
            get
            {
                return this._LogMessageNumber;
            }
            set
            {
                this._LogMessageNumber = value;
            }
        }
        public string LogNumber
        {
            get
            {
                return this._LogNumber;
            }
            set
            {
                this._LogNumber = value;
            }
        }
        public string Message
        {
            get
            {
                return this._Message;
            }
            set
            {
                this._Message = value;
            }
        }
        public string MessageVariable1
        {
            get
            {
                return this._MessageVariable1;
            }
            set
            {
                this._MessageVariable1 = value;
            }
        }
        public string MessageVariable2
        {
            get
            {
                return this._MessageVariable2;
            }
            set
            {
                this._MessageVariable2 = value;
            }
        }
        public string MessageVariable3
        {
            get
            {
                return this._MessageVariable3;
            }
            set
            {
                this._MessageVariable3 = value;
            }
        }
        public string MessageVariable4
        {
            get
            {
                return this._MessageVariable4;
            }
            set
            {
                this._MessageVariable4 = value;
            }
        }
        public string Type
        {
            get
            {
                return this._Type;
            }
            set
            {
                this._Type = value;
            }
        }
    }
}
