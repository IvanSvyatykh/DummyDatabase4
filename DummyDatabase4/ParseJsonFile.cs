using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyDatabase4
{
    public class ParseJsonFile
    {
        static string NameProject = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

        public static string NameParser(string line)
        {
            string[] splitted = line.Split(new char[] { ':', ',' });
            return splitted[1].Trim();
        }
        public static int TypeParser(string line)
        {
            string[] splitted = line.Split(new char[] { ':', ',' });
            if(int.TryParse(splitted[1].Trim() , out int num)) return num;
            else
            {
                throw new ArgumentException("");
            }
        }
        public static Schema ReadJson(string fileName)
        {
            Schema schema = new Schema();
            int countName = 0;
            foreach (string line in File.ReadLines(NameProject + fileName))
            {
                if (line.Contains("name") && countName == 0)
                {
                    schema.Name = NameParser(line);
                    countName++;
                }
                else if (line.Contains("name"))
                {
                    Column column = new Column();
                    column.Name = NameParser(line);
                }
            }
            return schema;
        }
        public static void PutData()
        {

        }
    }
}
