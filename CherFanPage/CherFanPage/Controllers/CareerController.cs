using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CherFanPage.Models;
using System.Diagnostics;

namespace CherFanPage.Controllers
{
    public class CareerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Albums()
        {
            return View();
        }

        public IActionResult Awards()
        {
            return View();
        }

        public IActionResult Film()
        {
            return View();
        }

        public IActionResult Tours()
        {
            return View();
        }

        public IActionResult TV()
        {
            return View();
        }


    }
}
