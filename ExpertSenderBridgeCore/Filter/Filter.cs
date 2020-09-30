using ExpertSenderBridge.DataModel.Enums.DataTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSenderBridge.Filter
{
    public class Filter
    {
        internal string Name { get; }
        int modifier;
        internal object Value { get; }
        public Filter(string name, WhereOperator modif, object value)
        {
            Name = name;
            modifier = (int)modif;
            Value = value;
        }
    }
}
