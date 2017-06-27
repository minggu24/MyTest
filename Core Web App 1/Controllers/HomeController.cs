using Microsoft.AspNetCore.Mvc;
using MingGuApps.Models;
using Newtonsoft.Json;
using System.Text;

namespace Core_Web_App_1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            byte[] value;
            HttpContext.Session.TryGetValue("UserName", out value);
            if (value == null)
                HttpContext.Session.Set("UserName", Encoding.ASCII.GetBytes(""));

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User loginUser)
        {
            if (ModelState.IsValid)
            {
                User obj = LoadJson();
                if (loginUser.username.Equals(obj.username)&&loginUser.password.Equals(obj.password) && obj.isActive.Equals(false))
                {
                    HttpContext.Session.Set("UserName", Encoding.ASCII.GetBytes(obj.username));
                    return RedirectToAction("Index");
                }

            }
            return View(loginUser);
        }
        public User LoadJson()
        {
            //using (StreamReader r = new StreamReader((".\\data\\user.json"))
            {
                string json = System.IO.File.ReadAllText(".\\wwwroot\\data\\user.json");// r.ReadToEnd();
                return JsonConvert.DeserializeObject<User>(json);
            }
        }
    }
}
