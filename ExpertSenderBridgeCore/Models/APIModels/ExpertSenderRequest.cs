using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ExpertSenderBridgeCore.Models
{
    public class ApiRequest
    {
        public string ApiKey { get; set; }
        public string TableName { get; set; }

        public Subscriber[] MultiData { get; set; }

        public Row[] Data { get; set; }

        public Column[] Columns { get; set; }
        public Column[] PrimaryKeyColumns { get; set; }

        public Where[] WhereConditions { get; set; }
        public OrderBy[] OrderByColumns { get; set; }
        public ApiFilter[] Filters { get; set; }


    }

    public class Row
    {
        public Column[] Columns { get; set; }
    }

    public class Columns1
    {
        public string[] Column { get; set; }
    }

    public class ApiFilter
    {
        public Column Column { get; set; }
    }

    public class Column
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Operator { get; set; }

    }


    public class Where
    {
        public string ColumnName { get; set; }
        public string Operator { get; set; }
        public string Value { get; set; }
    }

    public class OrderBy
    {
        public string ColumnName { get; set; }
        public string Direction { get; set; }
    }

    public class Subscriber
    {
        public string Mode { get; set; }
        public string Force { get; set; }
        public string ListId { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public Property[] Properties { get; set; }
    }

    public class Property
    {
        public string Id { get; set; }

        [XmlAttribute("Type")]
        public bool Values { get; set; }
    }
}
