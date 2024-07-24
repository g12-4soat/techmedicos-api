using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TechMedicos.Domain.ValueObjects;
using static TechMedicos.Adapter.DynamoDB.Models.MedicoDbModel;

namespace TechMedicos.Adapter.DynamoDB.Models.Converter
{
    public class AgendaConverter : IPropertyConverter
    {
        public DynamoDBEntry ToEntry(object value)
        {
            return new Primitive(System.Text.Json.JsonSerializer.Serialize(value));
        }

        public object FromEntry(DynamoDBEntry entry)
        {
            var response = JsonConvert.DeserializeObject<List<AgendaMedica>>(entry.AsString().ToString());
            //var response = JsonSerializer.Deserialize(entry.AsString(), typeof(List<AgendaMedica>));
            return response;
        }
    }
}
