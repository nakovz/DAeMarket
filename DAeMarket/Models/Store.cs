using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAeMarket.Models {
    public class Store {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slogan { get; set; }
        public string SuperUser { get; set; }
        public string SuperPassword { get; set; }

    }
}