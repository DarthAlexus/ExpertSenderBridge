using ExpertSenderBridgeCore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ExpertSenderBridgeCore
{
    class ESXmlSerializer
    {
        public string Serialize(ApiRequest apiRequestObj)
        {
            var serializer = new XmlSerializer(typeof(ApiRequest));
            var sw = new StringWriter();
            serializer.Serialize(sw, apiRequestObj);
            return sw.ToString();
        }
        /*
        public string RareSerialize(Models.RareModels.ApiRequest apiRequestObj)
        {
            var serializer = new XmlSerializer(typeof(Models.RareModels.ApiRequest));
            var sw = new StringWriter();
            serializer.Serialize(sw, apiRequestObj);
            return sw.ToString();
        }
        */
        public T Deserialize<T>(Stream stream)
        {
            var serializer = new XmlSerializer(typeof(T));
            var apiResponse = (T)serializer.Deserialize(stream);
            return apiResponse;
        }
    }
}
