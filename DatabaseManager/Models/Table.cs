using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager.Models {
    internal class Table {
        public string Name { get; set; }
        public IEnumerable<Column> Columns { get; set; }
        public IEnumerable<object> Rows { get; set; }
    }
}
