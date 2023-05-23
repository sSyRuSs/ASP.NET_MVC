using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
namespace WebApplication1.Filters
{
    public class MyActionFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext) // thuc hien sau khi action dien ra va trc khi return view
        {

        }

        public void OnActionExecuting(ActionExecutingContext filterContext) // thuc hien trc khi action dien ra
        {
            Debug.WriteLine("Action Excuting");
            filterContext.Controller.ViewBag.Number = 5;
        }
    }
}