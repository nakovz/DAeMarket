using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAeMarket.Models;
using System.ComponentModel.DataAnnotations;

namespace DAeMarket.ViewModels {
    public class UsersViewModel {
        public int Id { get; set; }

        [Required(ErrorMessage ="Email is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassword { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int? Credit { get; set; }

        public Store Store { get; set; }

        public UsersViewModel(Store store) {
            Store = store;
        }

        public UsersViewModel(Users user) {
            Id = user.Id;
            Email = user.Email;
            Password = user.Password;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Phone = user.Phone;
            DateOfBirth = user.DateOfBirth;
            Credit = user.Credit;
            Store = user.Store;
        }

        public UsersViewModel() {
        }

        public UsersViewModel(int storeid) {
            Store.Id = storeid;
        }

    }
}