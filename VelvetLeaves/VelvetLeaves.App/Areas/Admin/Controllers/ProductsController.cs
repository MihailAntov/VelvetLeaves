﻿using Microsoft.AspNetCore.Mvc;

namespace VelvetLeaves.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
