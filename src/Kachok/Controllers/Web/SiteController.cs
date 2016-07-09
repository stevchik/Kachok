using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kachok.Controllers
{

    public class SiteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StyleSample()
        {
            return View();
        }

        public IActionResult Exercise()
        {
            return View(@"Views/Exercise/Exercise.cshtml");
        }
    }
}