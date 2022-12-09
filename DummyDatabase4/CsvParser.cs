using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyDatabase4
{
    public class CsvParser
    {
        static string NameProject = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        static void CheckData()
        {

        }
        private static void PutData(string line, ref int countLine, List<string> names, Schema schema, string path)
        {
            string[] splitted = line.Split(';');

            if (countLine == 0)
            {
                countLine++;
                foreach (var name in splitted)
                {
                    names.Add(name.Trim());
                }
                return;
            }

            int index = 0;

            foreach (var name in names)
            {
                if (!schema.Columns[countLine - 1].Line.ContainsKey(name)) throw new ArgumentException($"Ошибка в именовании данных в {NameProject + path}, не содержит столбец {name}");
                else schema.Columns[countLine - 1].Line[name].Data = splitted[countLine - 1+index];
                index++;
            }

            if(schema.Columns.Count == countLine) schema.Columns.Add(schema.Columns[countLine - 1]);
        }
        public static Schema ReadFile(string path, Schema schema)
        {
            int countLine = 0;
            List<string> names = new List<string>();
            foreach (var line in File.ReadAllLines(NameProject + path))
            {
                PutData(line, ref countLine, names, schema, path);
            }

            return schema;
        }
    }
}
