using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DAeMarket.ViewModels;

namespace DAeMarket.Models {
    public class Users {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int? Credit { get; set; }

        [Required]
        public Store Store { get; set; }

        public Users(Store store) {
            Store = store;
        }

        public Users() {
        }

        public Users(int storeid) {
            Store.Id = storeid;
        }

        public Users(UsersViewModel user) {
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

    }
}