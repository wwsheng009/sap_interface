namespace SAPINT.Idocs
{
    using System;
    public class IdocStatus
    {
        private string _CreationDateTime = string.Empty;
        private string _Description = "";
        private string _Status = "";
        private string _StatusVar1 = "";
        private string _StatusVar2 = "";
        private string _StatusVar3 = "";
        private string _StatusVar4 = "";
        private string _UserName = "";
        public string CreationDateTime
        {
            get
            {
                return this._CreationDateTime;
            }
            set
            {
                this._CreationDateTime = value;
            }
        }
        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this._Description = value;
            }
        }
        public string Status
        {
            get
            {
                return this._Status;
            }
            set
            {
                this._Status = value;
            }
        }
        public string StatusVar1
        {
            get
            {
                return this._StatusVar1;
            }
            set
            {
                this._StatusVar1 = value;
            }
        }
        public string StatusVar2
        {
            get
            {
                return this._StatusVar2;
            }
            set
            {
                this._StatusVar2 = value;
            }
        }
        public string StatusVar3
        {
            get
            {
                return this._StatusVar3;
            }
            set
            {
                this._StatusVar3 = value;
            }
        }
        public string StatusVar4
        {
            get
            {
                return this._StatusVar4;
            }
            set
            {
                this._StatusVar4 = value;
            }
        }
        public string UserName
        {
            get
            {
                return this._UserName;
            }
            set
            {
                this._UserName = value;
            }
        }

        public string CreationDate { get; set; }

        public string CreationTime { get; set; }
    }
}
