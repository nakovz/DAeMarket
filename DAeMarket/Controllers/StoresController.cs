using DAeMarket.Models;
using DAeMarket.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DAeMarket.Controllers
{
    public class StoresController : Controller {
        private readonly DAeMarketContext _context;

        public StoresController() {
            _context = new DAeMarketContext();
            TempData["shortMessage"] = null;
        }

        protected override void Dispose(bool disposing) {
            _context.Dispose();
        }

        // GET: Stores
        public ActionResult Index() {

            var users = _context.Stores.ToList().Select(store => new UsersViewModel(store)).ToList();
            return View(users);
        }

        public ActionResult RenderMenu() {
            var users = _context.Stores.ToList().Select(store => new UsersViewModel(store)).ToList();

            return PartialView("_NavBar",users);
        }

        public ActionResult LogIn(int Id) {
            var store = _context.Stores.SingleOrDefault(s => s.Id == Id);

            if (store == null) {
                return HttpNotFound();
            }

            return View(new UsersViewModel(store));
        }

        [HttpPost]
        public ActionResult LogInUser(UsersViewModel user) {
            var isAdmin = _context.Stores.FirstOrDefault(s => s.SuperUser == user.Email && s.SuperPassword == user.Password);
            if (isAdmin == null) {
                var isUser = _context.Users.FirstOrDefault(u => u.Store.Id == user.Store.Id && u.Email == user.Email && u.Password == user.Password);
                if (isUser == null) {
                    return Content("Email or Password are incorect!");
                } else {
                    return Content($"Wellcome { user.FirstName } ({ user.Email })");
                }
            }
            return Content("Wellcome MASTER!");
        }


        public ActionResult SignUpUser(int Id) {
            var store = _context.Stores.SingleOrDefault(s => s.Id == Id);

            if (store == null) {
                return HttpNotFound();
            }

            return View(new UsersViewModel(store));
        }

        public ActionResult Configure() {
            var stores = _context.Stores.ToList();
            return View(stores);
        }

        public ActionResult EditStore(int StoreId, int selectedItemId = 0) {
            var store = _context.Stores.SingleOrDefault(s => s.Id == StoreId);
            if (store == null) {
                return HttpNotFound();
            }

            IEnumerable<Items> items = _context.Items.Where(i => i.StoreId == store.Id).AsEnumerable();

            var viewModel = new ItemsInStoreViewModel() {
                Store = store,
                Items = items,
                SelectedItem = _context.Items.FirstOrDefault(i => i.StoreId == store.Id && i.Id == selectedItemId)
            };

            if (TempData["shortMessage"] != null) {
                ViewBag.Message = TempData["shortMessage"].ToString();
            }
            TempData["shortMessage"] = null;
            return View("StoreForm", viewModel);
        }

        public ActionResult NewStore() {
            var viewModel = new ItemsInStoreViewModel() {
                Store = new Store(),
                Items = new List<Items>().AsEnumerable(),
                SelectedItem = new Items()
            };

            return View("StoreForm", viewModel);
        }

        public ActionResult DeleteItem(int StoreId, int ItemId) {
            var item = _context.Items.FirstOrDefault(i => i.StoreId == StoreId && i.Id == ItemId);
            if (item != null) {
                _context.Items.Remove(item);
                _context.SaveChanges();
                TempData["shortMessage"] = "Item successfully deleted!";
            }

            return RedirectToAction("EditStore", new { StoreId });
        }

        [HttpPost]
        public ActionResult SaveStoreInfo(ItemsInStoreViewModel viewModel) {
            var storeInDB = _context.Stores.SingleOrDefault(s => s.Id == viewModel.Store.Id);
            if (storeInDB == null) {
                var store = viewModel.Store;
                _context.Stores.Add(store);
            } else {
                storeInDB.Name = viewModel.Store.Name;
                storeInDB.Slogan = viewModel.Store.Slogan;
                storeInDB.SuperPassword = viewModel.Store.SuperPassword;
                storeInDB.SuperUser = viewModel.Store.SuperUser;
            }
            _context.SaveChanges();

            IEnumerable<Items> items = _context.Items.Where(i => i.StoreId == viewModel.Store.Id).AsEnumerable();
            viewModel.Items = items;

            TempData["shortMessage"] = "Store Info successfully saved!";
            return RedirectToAction("EditStore", new { StoreId = viewModel.Store.Id });
        }

        [HttpPost]
        public ActionResult SaveItem(ItemsInStoreViewModel viewModel) {
            var itemInDB = _context.Items.SingleOrDefault(s => s.StoreId == viewModel.Store.Id && s.Id == viewModel.SelectedItem.Id);
            var item = new Items();

            if (itemInDB == null) {
                item = Items.NewItemFromViewModel(viewModel);
                _context.Items.Add(item);
            } else {
                Items.MapValuesFromViewModel(itemInDB, viewModel);
            }
            _context.SaveChanges();
            viewModel.SelectedItem = itemInDB ?? item;

            TempData["shortMessage"] = "Item successfully saved!";
            return RedirectToAction("EditStore", new { StoreId = viewModel.Store.Id, selectedItemId = viewModel.SelectedItem.Id });
        }
    }
}