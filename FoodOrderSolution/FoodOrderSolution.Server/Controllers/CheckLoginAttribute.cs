using FoodOrderSolution.Data.ViewModels;
using FoodOrderSolution.Helper.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodOrderSolution.Server.Controllers
{
    public class CheckLoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Controller controller = filterContext.Controller as Controller;
            HttpCookie reqCookies = HttpContext.Current.Request.Cookies["VendorLoginCookie"];
            if (reqCookies != null)
            {
                ResponseVendorLogin login = JsonConvert.DeserializeObject<ResponseVendorLogin>(reqCookies.Value.ToString().UrlDecode());
                if (login == null)
                {
                    controller.Response.Redirect("/System/login");
                }

                if (login.ID <= 0)
                {
                    controller.Response.Redirect("/System/login");
                }
            }
            else
            {
                controller.Response.Redirect("/System/login");
            }

        }
    }
}