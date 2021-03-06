using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CherFanPage.Models;

namespace CherFanPage.Controllers
{
    public class FashionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sixties()
        {
            return View();
        }

        public IActionResult Seventies()
        {
            return View();
        }

        public IActionResult Eighties()
        {
            return View();
        }

        public IActionResult Ninties()
        {
            return View();
        }


        /*************Favorites methods*/

        [HttpGet]
        public ViewResult Favorite()
        {
            var session = new OutfitSession(HttpContext.Session);
            var model = new OutfitListViewModel
            {
                ActiveDecade = session.GetActiveOutfitYear(),
                Outfits = session.GetMyOutfits()
            };

            return View(model);
        }
        
        [HttpPost]
        public RedirectToActionResult Delete()
        {
            var session = new OutfitSession(HttpContext.Session);
            var cookies = new CherCookies(HttpContext.Response.Cookies);

            session.RemoveMyOutfits();
            cookies.RemoveMyOutfitIds();

            TempData["message"] = "Favorite outfits cleared";

            return RedirectToAction("Index", "Home",
                new
                {
                    ActiveConf = session.GetActiveOutfitYear()
                    
                }) ;
        } 
    }
}
