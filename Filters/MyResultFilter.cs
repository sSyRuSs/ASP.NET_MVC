using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Filters
{
    public class MyResultFilter : FilterAttribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            
        }
    }
}