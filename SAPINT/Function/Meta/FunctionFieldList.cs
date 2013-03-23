using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace SAPINT.Function.Meta
{
    class FunctionFieldList:DictionaryBase
    {
        public FunctionField this[String key]
        {
            get { 
                return (FunctionField)this.Dictionary[key];
            }
            set 
            {
                this.Dictionary[key] = value;      
            }
        }
        public void Add(string key, FunctionField functionField)
        {
            this.Dictionary.Add(key, functionField);
        }
        public bool Contains(string key)
        {
            return this.Dictionary.Contains(key);
        }
        //we will get to this later
        public ICollection Keys
        {
            get { return this.Dictionary.Keys; }
        }
    }
}
