
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
 
namespace RandomPasscode.Controllers
{
    public class PasscodeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        
        
        [HttpGet]
        [Route("result")]
        public JsonResult Result()
        {
            // Generate a string of Random Characters
            string CharacterChoice = "AB1CD2EF3GH4IJ5KL6MN7OP8QR9ST0UVWXYZ";
            string Code = "";
            Random rand = new Random();
            for (int i = 0; i<= 14; i++)
            {
                Code += CharacterChoice[rand.Next(0, CharacterChoice.Length)];
            }

            // Setting the session to store the count number
            int? Count = HttpContext.Session.GetInt32("Count");
            if (Count == null)
            {
                Count = 0;
            }
            Count += 1;

            HttpContext.Session.SetInt32("Count", (int)Count);
            
            // Saving the count and the generated code in viewbag variables
            // ViewBag.Code = Code;
            // ViewBag.Count = Count;
            var result = new 
            {
                Count = Count,
                Code = Code
            };
            return Json(result);
        }
    }
}