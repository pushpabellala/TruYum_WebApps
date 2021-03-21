using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TruYum_WebApp.Models;

namespace TruYum_WebApp.Controllers
{
    public class MenuItemAdminController : Controller
    {

        TruYumContext cdx = new TruYumContext();
        
        bool isAdmin = false;
        [Route("MenuItemAdmin/Index/{isAdmin}")]
        public ActionResult Index(bool isAdmin)
        {
            try
            {
                if (isAdmin == true)
                {
                    var list = cdx.MenuItems.ToList();
                    return View(list);
                }
                else
                {
                    return RedirectToAction("Index", "MenuItem");
                }
            }
            catch (Exception e)
            {
                return View("Error", (object)e.Message.ToString());
            }

        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(MenuItem menuItem)
        {
            try
            {

                MenuItem obj = new MenuItem();
                bool check = cdx.MenuItems.Any(ab => ab.Name.ToLower() == menuItem.Name.ToLower() ||ab.Id == menuItem.Id);
                if (check == true)
                {
                   
                    obj = cdx.MenuItems.Where(ab => ab.Id == menuItem.Id).SingleOrDefault();
                    if (obj != null)
                    {
                        obj.Name = menuItem.Name;
                        obj.price = menuItem.price;
                        obj.freeDelivery = menuItem.freeDelivery;
                        obj.dateOfLaunch = menuItem.dateOfLaunch;
                        obj.category = menuItem.category;
                        obj.Active = menuItem.Active;
                    }
                }
                else
                {
                    
                    obj.Name = menuItem.Name;
                    obj.price = menuItem.price;
                    obj.freeDelivery = menuItem.freeDelivery;
                    obj.dateOfLaunch = menuItem.dateOfLaunch;
                    obj.category = menuItem.category;
                    obj.Active = menuItem.Active;
                    cdx.MenuItems.Add(obj);

                }
                cdx.SaveChanges();
                return RedirectToAction("Index/true");
            }
            catch(Exception e)
            {
                return View("Error",(object)e.Message.ToString());
            }
        }


        public ActionResult Edit(int id)
        {
            var menuItem = GetMenuItem(id);
            return View(menuItem);
        }


        [HttpPost]
        public ActionResult Edit(MenuItem menuItem)
        {
            try
            {

                MenuItem obj = new MenuItem();
                bool check = cdx.MenuItems.Any(ab => ab.Name.ToLower() == menuItem.Name.ToLower() || ab.Id == menuItem.Id);
                if (check == true)
                {
                    obj = GetMenuItem(menuItem.Id);
                    if (obj != null)
                    {
                        obj.Name = menuItem.Name;
                        obj.price = menuItem.price;
                        obj.freeDelivery = menuItem.freeDelivery;
                        obj.dateOfLaunch = menuItem.dateOfLaunch;
                        obj.category = menuItem.category;
                        obj.Active = menuItem.Active;
                    }
                }
                else
                {
                    obj.Name = menuItem.Name;
                    obj.price = menuItem.price;
                    obj.freeDelivery = menuItem.freeDelivery;
                    obj.dateOfLaunch = menuItem.dateOfLaunch;
                    obj.category = menuItem.category;
                    obj.Active = menuItem.Active;
                    cdx.MenuItems.Add(obj);

                }
                cdx.SaveChanges();
                return RedirectToAction("Index/true");
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
                MenuItem obj = GetMenuItem(id);
                if (obj != null)
                {
                    cdx.MenuItems.Remove(obj);
                    cdx.SaveChanges();
                }
                return RedirectToAction("Index/true");
            }
            catch (Exception e)
            {
                string message = "Cannot Remove Item.Since it is in User Cart";
                return View("Error", (object)message);
            }

        }


        public  MenuItem GetMenuItem(int menuItemId)
        {
            return cdx.MenuItems.Where(ab => ab.Id == menuItemId).SingleOrDefault();
        }
    }
}
