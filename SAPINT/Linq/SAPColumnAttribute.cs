namespace SAPINT.Linq
{
    using System;
    using System.Runtime.CompilerServices;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple=false)]
    public class SAPColumnAttribute : Attribute
    {
        public SAPColumnAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}

