using DummyDatabase4;
using System;

namespace DummyDatabase
{
    public class Programm
    {  
        static void Main()
        {
            List<Schema> schemas = new List<Schema>();

            string footballMatchJson = "\\FootballMatch.Json";

           schemas.Add(ParseJsonFile.ReadJson(footballMatchJson));
        }

    }

}
