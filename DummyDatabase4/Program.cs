using DummyDatabase4;
using System;

namespace DummyDatabase
{
    public class Programm
    {

        static void Main()
        {
            

            List<Schema> schemas = new List<Schema>();

            string[] path = new string[] { "\\FootballMatch.", "\\BookShop.", "\\AutoShop." };
            while (true)
            {
                int Y = 0;
                Console.Clear();
                Console.SetCursorPosition(0, 0);

                Dictionary<string, int> MaxLengthOfColumn = new Dictionary<string, int>();
                string FullPath = ChooseFile.WriteTableWithFile(path);

                schemas.Add(ParseJsonFile.ReadJson(FullPath + "json"));
                schemas[0] = CsvParser.ReadFile(FullPath + "csv", schemas[0], ref MaxLengthOfColumn);
                WriterData.WriteData(schemas[0], MaxLengthOfColumn, ref Y);

                Console.WriteLine();
                Console.Write("Введите stop чтобы закончить или нажмите людую клавишу чтобы продолжить: ");
                if (Console.ReadLine().Trim() == "stop") break;
                else schemas.Clear();
            }
        }

    }
}