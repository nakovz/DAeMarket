using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DAeMarket.Models {
    public class ItemType {
        public byte Id { get; set; }
        [Required]
        public string Name { get; set; }

        public static readonly byte Virtual = 1;
        public static readonly byte Physical = 2;

    }
}