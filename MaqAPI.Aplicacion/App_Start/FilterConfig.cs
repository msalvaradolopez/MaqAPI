﻿using System.Web;
using System.Web.Mvc;

namespace MaqAPI.Aplicacion
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
