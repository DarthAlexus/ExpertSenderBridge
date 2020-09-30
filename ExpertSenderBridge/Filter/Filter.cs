using System;
using System.Collections.Generic;
using System.Text;

namespace ExpertSenderBridge.Models
{
    public class Filter
    {
        internal string Name { get; }
        int modifier;
        internal object Value { get; }
        public Filter(string name, WhereOperator modif, object value)
        {
            Name = name;
            modifier = (int) modif;
            Value = value;
        }
    }
}
