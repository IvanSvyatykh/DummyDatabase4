using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DummyDatabase4
{
    public class Column
    {
        public Dictionary<string, Element> Line { get; set; } = new Dictionary<string, Element>();
    }
}
