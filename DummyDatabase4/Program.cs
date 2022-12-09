using DummyDatabase4;
using System;

namespace DummyDatabase
{
    public class Programm
    {
        static void Main()
        {
            List<Schema> schemas = new List<Schema>();

            string[] path = new string[] { "\\FootballMatch." };

            for (int i = 0; i < path.Length; i++)
            {
                schemas.Add(ParseJsonFile.ReadJson(path[i] + "json"));
                schemas[i] = CsvParser.ReadFile(path[i] + "csv", schemas[i]);
            }
        }

    }

}
