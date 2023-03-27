using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DAeMarket.ViewModels;

namespace DAeMarket.Models {
    public class Items {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public float Price { get; set; }
        
        public float SalePrice { get; set; }
        public float Rating { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }

        public ItemType ItemType { get; set; }

        [Required]
        public byte ItemTypeId { get; set; }

        public Store Store { get; set; }

        [Required]
        public int StoreId { get; set; }

        internal static Items NewItemFromViewModel(ItemsInStoreViewModel viewModel) {
            return new Items {
                Id = viewModel.selectedItem.Id,
                Name = viewModel.selectedItem.Name,
                Description = viewModel.selectedItem.Description,
                Price = viewModel.selectedItem.Price,
                SalePrice = viewModel.selectedItem.SalePrice,
                ItemTypeId = ItemType.Virtual,
                StoreId = viewModel.Store.Id
            };
        }

        public static void MapValuesFromViewModel(Items itemInDB, ItemsInStoreViewModel viewModel) {
            itemInDB.Name = viewModel.selectedItem.Name;
            itemInDB.Description = viewModel.selectedItem.Description;
            itemInDB.Price = viewModel.selectedItem.Price;
            itemInDB.SalePrice = viewModel.selectedItem.SalePrice;
            itemInDB.StoreId = viewModel.Store.Id;
        }
    }
}