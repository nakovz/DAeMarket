using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAeMarket.Models;

namespace DAeMarket.ViewModels {
    public class ItemsInStoreViewModel {
        public Store Store { get; set; }
        public IEnumerable<Items> Items { get; set; }

        public Items SelectedItem { get; set; }
    }
}