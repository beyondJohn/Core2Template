using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;
using static WebApplication5.Models.ModelDbContext;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }
        public void Set(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();
            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddMilliseconds(10);
            Response.Cookies.Append(key, value, option);
        }
        public void Remove(string key)
        {
            Response.Cookies.Delete(key);
        }
        public ActionResult Main()
        {
            return View();
        }
        public ActionResult Modules()
        {
            return View();
        }
        public ActionResult CEData(string id)
        {
            int myId = 422;
            if (id != null)
            {
                myId = int.Parse(id.ToString());
            }
            List<asimCEData> myCEData = new List<asimCEData>();
            using (var db = new ModelDbContext())
            {
                myCEData = db.Cases
                    .Where(x => x.Case_Id == myId)
                    .Select(x => new asimCEData { case_id = x.Case_Id, ce_data = x.CE_Data })
                    .ToList();
            }
            asimViewModel objViewModel = new asimViewModel() { myCEData = myCEData };
            return View(objViewModel);
        }
        public IActionResult Index()
        {
            ////read cookie from IHttpContextAccessor  
            ////
            //string cookieValueFromContext = _httpContextAccessor.HttpContext.Request.Cookies[".AspNetCore.Identity.Application"];
            ////read cookie from Request object  
            //string cookieValueFromReq = Request.Cookies[".AspNetCore.Identity.Application"];
            ////set the key value in Cookie  
            //Set("kay", "Hello from cookie", 10);
            ////Delete the cookie object  
            //Remove("Key");
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
