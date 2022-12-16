using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyDatabase4
{
    public class ParseJsonFile
    {
        static string NameProject = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        private static string DataParse(string line)
        {
            var charsToRemove = new string[] { ",", "\\", "; ", "\"" };
            foreach (var c in charsToRemove)
            {
                line = line.Replace(c, string.Empty);
            }
            string[] splitted = line.Split(new char[] { ':', ',' });
            return splitted[1].Trim();
        }
        public static Schema ReadJson(string fileName)
        {
            Schema schema = new Schema();
            Column column = new Column();
            Element element = new Element();

            bool countName = true;
            int count = 0;

            string name = null;

            foreach (string line in File.ReadLines(NameProject + fileName))
            {
                MakeSchema(line, ref countName, count, schema, column, ref element, ref name, fileName);
                count++;
            }

            schema.Columns.Add(column);
            return schema;
        }
        private static void MakeSchema(string line, ref bool countName, int count, Schema schema, Column column, ref Element element, ref string name, string fileName)
        {
            if (line.Contains("name") && countName)
            {
                schema.Name = DataParse(line);
                countName = false;
            }
            else if (line.Contains("name"))
            {
                if (DataParse(line).Equals(null)) throw new ArgumentException($"В файле {NameProject + fileName}, в {count} строке содержится значение null");
                column.Line.Add(DataParse(line), null);
                name = DataParse(line);
            }
            if (line.Contains("type"))
            {
                if (DataParse(line).Equals(null)) throw new ArgumentException($"В файле {NameProject + fileName}, в {count} строке содержится значение null");
                element.Type = DataParse(line);
                element.Data = null;
                column.Line[name] = element;
                element = new Element();
            }
        }
    }
}