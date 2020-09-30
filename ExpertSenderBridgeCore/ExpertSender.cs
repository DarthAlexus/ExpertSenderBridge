using ExpertSenderBridge.DataModel.Enums.DataTables;
using ExpertSenderBridge.Models;
using ExpertSenderBridge.Models.APIModels;
using ExpertSenderBridge.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ExpertSenderBridge
{
    public class ExpertSender
    {
        //pre install objects
        private static string APIadress2 = "Api/";
        private static ESXmlSerializer eSXmlSerializer = new ESXmlSerializer();

        //объявляемые поля
        public string apiKey { get; set; }
        public string serverAdress { get; set; }

        public ExpertSender(string serverURL, string apiKey)
        {
            serverAdress = serverURL + APIadress2;
            this.apiKey = apiKey;
        }

        public async void InsertRows(string table, string[] columnsName, IEnumerable<object[]> values)
        {
            var rows = new List<Row>();
            foreach (var value in values)
            {
                List<Column> columns = new List<Column>();
                for (int i = 0; i < columnsName.Length; i++)
                {
                    columns.Add(new Column { Name = columnsName[i], Value = value[i].ToString() });
                }
                rows.Add(new Row { Columns= columns.ToArray() });
            }
            var request = new ApiRequest { ApiKey = apiKey, TableName = table, Data = rows.ToArray() };
            var body = eSXmlSerializer.Serialize(request);
            await APISenderService.SendPostAPIAsync(serverAdress + "DataTablesAddMultipleRows/", body);
        }

        public static List<IDictionary<string, object>> GetRows(string table, int? top, IEnumerable<string> columns, IEnumerable<Filter.Filter> filters)
        {
            var rows = new List<IDictionary<string, object>>();

            return rows;
        }

        public static void DeleteRows(string table, Column[] PrimaryKeyColumns)
        {
            new Filter.Filter("test", WhereOperator.EQ, 123);
        }
    }
}
