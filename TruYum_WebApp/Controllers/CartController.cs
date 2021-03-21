using TruYum_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TruYumWeb.Controllers
{
    public class CartController : Controller
    {
        int userId = 2;
        public decimal total = 0;

        TruYumContext cdx = new TruYumContext();
        public ActionResult Index()
        {
            try
            {
                total = 0;
                List<MenuItem> lstResult = new List<MenuItem>();
                List<Cart> lstCarts = cdx.Carts.Where(e => e.UserId == userId).ToList();
                List<MenuItem> lstMenuItems = cdx.MenuItems.Where(e => e.Active == true&& e.dateOfLaunch<DateTime.Now).ToList();
                if (lstCarts != null && lstCarts.Count > 0 && lstMenuItems != null && lstMenuItems.Count > 0)
                {
                    MenuItem obj = null;
                    foreach (Cart cart in lstCarts)
                    {
                        obj = lstMenuItems.Where(e => e.Id == cart.MenuItemId).SingleOrDefault();
                        if (obj != null)
                        {
                            total = total + obj.price;
                            lstResult.Add(obj);
                        }
                    }


                    var list = lstResult;
                    ViewData["total"] = total;
                    return View(list);
                }
                else
                {
                    return View("Empty");
                }
            }
            catch (Exception e)
            {
                return View("Error", (object)e.Message.ToString());
            }
        }


        public ActionResult Delete(int id)

        {
            try
            {
                List<Cart> cart = cdx.Carts.Where(e => e.UserId == userId && e.MenuItemId == id).ToList();
                foreach (var x in cart)
                {
                    if (cart != null)
                    {
                        cdx.Carts.Remove(x);
                        cdx.SaveChanges();
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("Error", (object)e.Message.ToString());
            }
        }


    }
}
