﻿using Microsoft.AspNetCore.Mvc;

namespace VelvetLeaves.Web.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Categories()
        {
            throw new NotImplementedException();
        }
    }
}
