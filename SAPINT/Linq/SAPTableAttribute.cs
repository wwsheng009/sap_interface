namespace SAPINT.Linq
{
    using System;
    using System.Runtime.CompilerServices;

    [AttributeUsage(AttributeTargets.Class, AllowMultiple=false)]
    public class SAPTableAttribute : Attribute
    {
        public SAPTableAttribute()
        {
        }

        public SAPTableAttribute(string name)
        {
            this.Name = name;
        }

        public string CustomFunctionName { get; set; }

        public string Name { get; set; }
    }
}

