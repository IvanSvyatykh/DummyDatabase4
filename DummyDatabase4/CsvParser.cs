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
        private static void PutData(string line, ref int countLine, List<string> names, Schema schema, string path, ref Dictionary<string, int> MaxLengthOfColumn)
        {
            string[] splitted = line.Split(';');

            if (countLine == 0)
            {
                countLine++;
                foreach (var name in splitted)
                {
                    names.Add(name.Trim());
                    MaxLengthOfColumn.Add(name.Trim(), name.Trim().Length);
                }
                return;
            }

            int index = 0;

            Column column = new Column();

            foreach(var e in schema.Columns[0].Line) 
            {
                Element element= new Element();
                element.Data = null;
                element.Type = e.Value.Type;
                column.Line.Add(e.Key, element);
            }

            foreach (var name in names)
            {
                if (!schema.Columns[countLine - 1].Line.ContainsKey(name)) throw new ArgumentException($"Ошибка в именовании данных в {NameProject + path}, не содержит столбец {name}");
                else
                {
                    column.Line[name].Data = splitted[index];
                    MaxLengthOfColumn[name] = Math.Max(MaxLengthOfColumn[name], splitted[index].Length);
                }

                index++;
            }
            schema.Columns.Add(column);
            countLine++;
        }
        public static Schema ReadFile(string path, Schema schema, ref Dictionary<string, int> MaxLengthOfColumn)
        {
            int countLine = 0;
            List<string> names = new List<string>();
            foreach (var line in File.ReadAllLines(NameProject + path))
            {
                PutData(line, ref countLine, names, schema, path, ref MaxLengthOfColumn);
            }
            schema.Columns.RemoveAt(0);
            return schema;
        }
    }
}