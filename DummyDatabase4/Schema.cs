using DummyDatabase4;


namespace DummyDatabase4
{
    public class Schema
    {
        public string Name { get; set; }

        public List<Column> Columns { get; set;} = new List<Column>();  
        
    }
}
