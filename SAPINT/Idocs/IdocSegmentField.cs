namespace SAPINT.Idocs
{
    using SAPINT;
    using System;
    public class IdocSegmentField
    {
        private string _DataType;
        private string _Description;
        private int _ExternalLength;
        private string _FieldName;
        private object _FieldValue;
        private int _OffsetInBuffer;
        public IdocSegmentField()
        {
        }
        public IdocSegmentField(string Name)
        {
            this._FieldName = Name.ToUpper();
        }
        public IdocSegmentField(string Name, string Description, int Length, int Offset, string DataType, object FieldValue)
        {
            this._FieldName = Name.ToUpper().Trim();
            this._Description = Description.Trim();
            this._ExternalLength = Length;
            this._OffsetInBuffer = Offset;
            this._FieldValue = FieldValue;
            this._DataType = DataType.Trim();
        }
        public IdocSegmentField Clone()
        {
            return new IdocSegmentField { DataType = this.DataType, Description = this.Description, ExternalLength = this.ExternalLength, FieldName = this.FieldName, FieldValue = this.FieldValue, OffsetInBuffer = this.OffsetInBuffer };
        }
        public string DataType
        {
            get
            {
                return this._DataType;
            }
            set
            {
                this._DataType = value;
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
        public int ExternalLength
        {
            get
            {
                return this._ExternalLength;
            }
            set
            {
                this._ExternalLength = value;
            }
        }
        public string FieldName
        {
            get
            {
                return this._FieldName;
            }
            set
            {
                this._FieldName = value.ToUpper();
            }
        }
        public object FieldValue
        {
            get
            {
                return this._FieldValue;
            }
            set
            {
                if (value == null)
                {
                    throw new SAPException("Please do not assign a NULL value to the FieldValue property");
                }
                this._FieldValue = value;
            }
        }
        public int OffsetInBuffer
        {
            get
            {
                return this._OffsetInBuffer;
            }
            set
            {
                this._OffsetInBuffer = value;
            }
        }
    }
}
