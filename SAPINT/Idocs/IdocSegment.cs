namespace SAPINT.Idocs
{
    using SAPINT;
    using System;
    public class IdocSegment
    {
        private IdocSegmentCollection _ChildSegments = new IdocSegmentCollection();
        private string _DataBuffer = new string(" ".ToCharArray()[0], 0x3e8);
        private string _Description = "";
        private IdocSegmentFieldCollection _Fields = new IdocSegmentFieldCollection();
        private int _MaxOccur = 1;
        private string _SegmentName = "";
        private string _SegmentType = "";
        internal string SegmentNumberForPlainLoad = "";
        public IdocSegment Clone()
        {
            IdocSegment segment = new IdocSegment {
                _DataBuffer = this._DataBuffer,
                _Description = this._Description,
                _SegmentName = this._SegmentName,
                _SegmentType = this._SegmentType,
                _MaxOccur = this._MaxOccur
            };
            for (int i = 0; i < this._Fields.Count; i++)
            {
                IdocSegmentField newParameter = this._Fields[i].Clone();
                segment.Fields.Add(newParameter);
            }
            return segment;
        }
        public string ReadDataBuffer(int Offset, int Length)
        {
            if (((Offset < 0) || (Offset > 0x3e8)) || ((Offset + Length) > 0x3e8))
            {
                throw new Exception(Messages.TheIdocdatabufferswidthis1000bytes);
            }
            for (int i = 0; i < this._Fields.Count; i++)
            {
                IdocSegmentField field = this._Fields[i];
                string content = "";
                if (field.FieldName != null)
                {
                    content = field.FieldValue.ToString();
                }
                if (field.DataType == "NUMC")
                {
                    content = content.PadLeft(field.ExternalLength, "0".ToCharArray()[0]);
                }
                this.WriteDataBuffer(content, field.OffsetInBuffer, field.ExternalLength);
            }
            return this._DataBuffer.Substring(Offset, Length);
        }
        public override string ToString()
        {
            return ((this._Description + " (" + this.SegmentName + ") \r\n") + this._DataBuffer + "\r\n");
        }
        public void WriteDataBuffer(string Content, int Offset, int Length)
        {
            if (((Offset < 0) || (Offset > 0x3e8)) || ((Offset + Length) > 0x3e8))
            {
                throw new SAPException(Messages.TheIdocdatabufferswidthis1000bytes);
            }
            Content = Content.PadRight(0x3e8, " ".ToCharArray()[0]).Substring(0, Length);
            this._DataBuffer = this._DataBuffer.Substring(0, Offset) + Content + this._DataBuffer.Substring(Offset + Length, (0x3e8 - Length) - Offset);
        }
        public IdocSegmentCollection ChildSegments
        {
            get
            {
                return this._ChildSegments;
            }
            set
            {
                this._ChildSegments = value;
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
        public IdocSegmentFieldCollection Fields
        {
            get
            {
                return this._Fields;
            }
            set
            {
                this._Fields = value;
            }
        }
        public bool HasChildren
        {
            get
            {
                return (this._ChildSegments.Count > 0);
            }
        }
        public int MaxOccur
        {
            get
            {
                return this._MaxOccur;
            }
            set
            {
                this._MaxOccur = value;
            }
        }
        public string SegmentName
        {
            get
            {
                return this._SegmentName;
            }
            set
            {
                this._SegmentName = value.ToUpper().Trim();
            }
        }
        public string SegmentType
        {
            get
            {
                return this._SegmentType;
            }
            set
            {
                this._SegmentType = value.ToUpper().Trim();
            }
        }

        public string SegmentNumber { get; set; }
    }
}
