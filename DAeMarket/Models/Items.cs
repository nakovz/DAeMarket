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

        public Items() {

        }
        internal static Items NewItemFromViewModel(ItemsInStoreViewModel viewModel) {
            return new Items {
                Id = viewModel.SelectedItem.Id,
                Name = viewModel.SelectedItem.Name,
                Description = viewModel.SelectedItem.Description,
                Price = viewModel.SelectedItem.Price,
                SalePrice = viewModel.SelectedItem.SalePrice,
                ItemTypeId = ItemType.Virtual,
                StoreId = viewModel.Store.Id
            };
        }

        public static void MapValuesFromViewModel(Items itemInDB, ItemsInStoreViewModel viewModel) {
            itemInDB.Name = viewModel.SelectedItem.Name;
            itemInDB.Description = viewModel.SelectedItem.Description;
            itemInDB.Price = viewModel.SelectedItem.Price;
            itemInDB.SalePrice = viewModel.SelectedItem.SalePrice;
            itemInDB.StoreId = viewModel.Store.Id;
        }
    }
}