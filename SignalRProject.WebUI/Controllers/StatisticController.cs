﻿using Microsoft.AspNetCore.Mvc;

namespace SignalRProject.WebUI.Controllers
{
    public class StatisticController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
