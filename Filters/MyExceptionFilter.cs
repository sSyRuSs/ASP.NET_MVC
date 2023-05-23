using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace WebApplication1.Filters
{
    public class MyExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            string s = "Message: " + filterContext.Exception.Message;
            StreamWriter stream = File.AppendText(filterContext.RequestContext.HttpContext.Request.PhysicalApplicationPath + "\\erorlog.txt");
            stream.WriteLine(s);
            stream.Close();

            filterContext.ExceptionHandled = true;
            filterContext.Result = new RedirectResult("/Home/Error");
        }
    }
}