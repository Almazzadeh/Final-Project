﻿using System.Web.Mvc;

namespace Final_Project_V2.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "Product", action = "Index", id = UrlParameter.Optional },
                new string[] {"Final_Project_V2.Areas.Admin.Controllers"}
            );
        }
    }
}