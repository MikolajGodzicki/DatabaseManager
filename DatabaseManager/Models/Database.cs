using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager.Models {
    internal class Database { 
        public string Name { get; set; }
        public IEnumerable<Table> Tables { get; set; }

        public Database(string name) {
            Name = name;
        }
    }
}
