using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using random_passcode_generator.Models;
using Microsoft.AspNetCore.Http;

namespace random_passcode_generator.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            Random rand = new Random();
            string random_word = "";
            string[] random_list = new string[]{"A","B","C","D","E","F","G", "H", "I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z","1","2","3","4","5","6","7","8","9","O"};
            for (var i=0; i < 15; i++)
            {
                random_word += random_list[rand.Next(0, random_list.Length)];
            }
            HttpContext.Session.SetString("generate", random_word);
            string get = HttpContext.Session.GetString("generate");
            ViewBag.word = get;
            
            return View();
        }
        [HttpPost("generate")]
        public RedirectToActionResult generate()
        {
            return RedirectToAction("Index");
        }
    }
}
