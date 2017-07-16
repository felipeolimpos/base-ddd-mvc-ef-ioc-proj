using AutoMapper;
using Newtonsoft.Json;
using NLog;
using NLog.Common;
using POS.Domain.Interfaces.Services;
using POS.Infra.Cross.IoC;
using POS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace POS.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(HttpContext.Session["Categories"] == null)
            {
                HttpContext.Session.Add("Categories", GetCachedCategories());
            }

            var cart = GetCart();
            ViewBag.CartQuantity = cart.Quantity;
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            InternalLogger.LogLevel = LogLevel.Error;
            var logger = LogManager.GetCurrentClassLogger();
            logger.Error(filterContext.Exception);

            filterContext.ExceptionHandled = true;
            filterContext.Result = RedirectToAction("Error", "Home");
        }

        protected CartViewModel GetCart()
        {
            var cart = new CartViewModel();
            var cookie = HttpContext.Request.Cookies["Cart"];

            if (cookie != null)
            {
                cart = (CartViewModel)JsonConvert.DeserializeObject(cookie.Value, typeof(CartViewModel));
            }
            else
            {
                cart.Items = new List<CartItemViewModel>();
                SetCart(cart);
            }

            return cart;
        }

        protected void SetCart(CartViewModel cart)
        {
            var cookie = new HttpCookie("Cart");
            cookie.Value = new JavaScriptSerializer().Serialize(cart);
            cookie.Expires = DateTime.Now.AddDays(2);
            HttpContext.Response.Cookies.Add(cookie);
        }

        protected List<CategoryViewModel> GetCachedCategories()
        {
            var categories = MemoryCache.Default["Categories"] as List<CategoryViewModel>;
            if (categories == null)
            {
                categories = UpdateCategoriesCache();
            }
            return categories;
        }

        protected List<CategoryViewModel> UpdateCategoriesCache()
        {   
            var categoryService = DIContainer.container.GetInstance<ICategoryService>();
            var categoriesDTO = categoryService.GetAllActive();
            var categories = Mapper.Map<List<CategoryViewModel>>(categoriesDTO);

            MemoryCache.Default["Categories"] = categories;

            UpdateCategoriesSession();

            return categories;
        }

        protected void UpdateCategoriesSession()
        {
            var categories = GetCachedCategories();

            HttpContext.Session.Remove("Categories");
            HttpContext.Session.Add("Categories", categories);
        }
    }
}
