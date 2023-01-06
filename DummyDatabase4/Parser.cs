using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyDatabase4
{
    public static class Parser
    {
        public static Schema ParseJson(string path)
        {
            //Метод именует поля в классах как в json файле
            string fileInfo = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Schema>(fileInfo);
        }

        public static Dictionary<string, List<object>> ParseCsv(string path, Schema schema)
        {
            Dictionary<string, List<object>> data = new Dictionary<string, List<object>>();
            //Метод заполняет данные из csv в словарь
            foreach (string line in File.ReadLines(path))
            {
                if (line.Contains("id"))
                {
                    //Ветка для первой строки, где храниться имена колонок
                    CsvChecker(line, schema);
                    continue;
                }
                else
                {
                    string[] splitted = line.Split(';');
                    for (int i = 0; i < splitted.Length; i++)
                    {
                        if (data.Count < splitted.Length)
                        {
                            //Ветка для заполнения словаря в первый раз
                            data.Add(schema.Columns[i].Name, new List<object>());

                            data[schema.Columns[i].Name].Add(splitted[i]);
                            schema.MaxLengthOfColumn[schema.Columns[i].Name] = Math.Max(splitted[i].Length, schema.MaxLengthOfColumn[schema.Columns[i].Name]);
                        }
                        else
                        {
                            data[schema.Columns[i].Name].Add(splitted[i]);
                            schema.MaxLengthOfColumn[schema.Columns[i].Name] = Math.Max(splitted[i].Length, schema.MaxLengthOfColumn[schema.Columns[i].Name]);
                        }
                    }
                }
            }
            return data;
        }
        private static void CsvChecker(string line, Schema schema)
        {
            //Метод для того чтобы проверить совпадают ли имена колонок в json и csv
            string[] splitted = line.Split(';');
            if (splitted.Length != schema.Columns.Count)
            {
                throw new ArgumentException("Количестов колонок в json схеме не равно количеству колонок в csv файле");
            }
            for (int i = 0; i < splitted.Length; i++)
            {

                if (splitted[i] != schema.Columns[i].Name)
                {
                    throw new ArgumentException($"Именование колонок в json файле и в csv не совпадает, имено {splitted[i]} и {schema.Columns[i].Name}");
                }
                schema.MaxLengthOfColumn.Add(splitted[i], splitted[i].Length);//Первый раз длина иницилизируется длиной имени колонки
            }
        }
    }
}
