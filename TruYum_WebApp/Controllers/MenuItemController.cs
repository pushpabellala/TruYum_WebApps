using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TruYum_WebApp.Models;
namespace TruYumWeb.Controllers
{
    public class MenuItemController : Controller
    {

        TruYumContext cdx = new TruYumContext();
        public ActionResult Index()
        {
            var list = cdx.MenuItems.Where(e => e.Active == true&&e.dateOfLaunch<DateTime.Now).ToList();
            return View(list);
        }

        public ActionResult AddToCart(int id)
        {
            try
            {

                int userId = 2;
                Cart cart = new Cart();
                cart.UserId = userId;
                cart.MenuItemId = id;
                cart.Quantity = 1;
                cdx.Carts.Add(cart);
                cdx.SaveChanges();
                return RedirectToAction("Index", "Cart");

            }
            catch (Exception e)
            {
                return View("Error", (object)e.Message.ToString());
            }
        }



    }







}

