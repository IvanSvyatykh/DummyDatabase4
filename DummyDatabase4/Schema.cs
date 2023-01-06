using DummyDatabase4;
using Newtonsoft.Json;

namespace DummyDatabase4
{
    public class Schema 
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }//Имя схемы

        [JsonProperty(PropertyName = "columns")]
        public List<Column> Columns { get; private set; } = new List<Column>();

        public Dictionary<string, List<object>> Data = new Dictionary<string, List<object>>();
        //Словарь для хранения данных, ключом является имя колонки

        public Dictionary<string, int> MaxLengthOfColumn = new Dictionary<string, int>();
        //Словарь для хранения длины данных, чтобы выравнивать колонки
    }
}
