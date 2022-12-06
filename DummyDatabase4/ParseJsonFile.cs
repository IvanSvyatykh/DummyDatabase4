using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyDatabase4
{
    public class ParseJsonFile
    {
        static string NameProject = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

        public static string DataParse(string line)
        {
            var charsToRemove = new string[] { ",", "\\", "; ", "\"" };
            foreach (var c in charsToRemove)
            {
                line = line.Replace(c, string.Empty);
            }
            string[] splitted = line.Split(new char[] { ':', ',' });
            return splitted[1].Trim();
        }
        public static string TypeDetermine(string str, int count)
        {
            switch (str)
            {
                case "int":
                    return "int";
                case "float":
                    return "float";
                case "double":
                    return "double";
                case "string":
                    return "string";
                case "long":
                    return "long";
                default: throw new ArgumentException($"Неизвестный тип данных в json схеме.Ошибка в {count} строке");

            }
        }
        public static Schema ReadJson(string fileName)
        {
            Schema schema = new Schema();
            Column column = new Column();

            int countName = 0;
            int count = 0;

            foreach (string line in File.ReadLines(NameProject + fileName))
            {
                MakeSchema(line, ref countName, count, schema, ref column);
                count++;
            }

            schema.Columns.Add(column);
            return schema;
        }
        public static void MakeSchema(string line, ref int countName, int count, Schema schema, ref Column column)
        {
            if (line.Contains("name") && countName == 0)
            {
                schema.Name = DataParse(line);
                countName++;
            }
            else if (line.Contains("name"))
            {
                if (column.Name != null)
                {
                    schema.Columns.Add(column);
                    column = new Column();
                }
                column.Name = DataParse(line);
            }
            if (line.Contains("type"))
            {
                string str = DataParse(line);
                column.Type = TypeDetermine(str, count);
            }
        }
    }
}
