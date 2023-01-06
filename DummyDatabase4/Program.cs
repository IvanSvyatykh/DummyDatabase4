using DummyDatabase4;
using Newtonsoft.Json;
using System;

namespace DummyDatabase
{
    public class Programm
    {
        static void Main()
        {
            string NameProject = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            List<Schema> schemas = new List<Schema>();

            string[] path = new string[] { "\\BookShop.", "\\FootballMatch.", "\\AutoShop." };
            for (int i = 0; i < path.Length; i++)
            {
                string FullPath = NameProject + path[i];
                schemas.Add(Parser.ParseJson(FullPath + "json"));
                schemas[i].Data = Parser.ParseCsv(FullPath + "csv", schemas[i]);

            }
            int Y = 0;

            foreach (Schema schema in schemas)
            {
                Y = WriterData.WriteData(schema, schema.MaxLengthOfColumn, Y);
                Y += 3;
            }
        }

    }
}