using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Globomantics.Conventions;
using Microsoft.AspNetCore.Mvc;

namespace Globomantics.Controllers
{
    public class PromotionController : Controller
    {
        [HttpGet]
        [Route("promotion/{token:tokenCheck}")]
        //public IActionResult Index([BindName(Name = "token")] string promoCode)
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("promotion")]
        public IActionResult Submit()
        {
            // TODO: Sweepstakes entry logic
            return View();
        }
    }
}