using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceSupply.Models {
    public class Results {
        public string Message { get; set; }
        public IEnumerable<Item> Items { get; set; }
        //public override string ToString() {}
    }
}
