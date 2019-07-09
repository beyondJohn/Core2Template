using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;
using static WebApplication5.Models.ModelDbContext;

namespace WebApplication5.Controllers
{
    public class UserController : Controller
    {
        public TestModel testModel = new TestModel();
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserController(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }
        public ModelDbContext db = new ModelDbContext();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult account()
        {
            int userID = int.Parse("23");
            List<User_Table> getUserData = (from u in db.Users where u.User_Id == userID select u).ToList();
            var user = new UserModel()
            {
                firstName = getUserData[0].First_Name,
                lastName = getUserData[0].Last_Name,
                email = getUserData[0].Email,
                password = getUserData[0].Password,
                phone = getUserData[0].phone,
                address = getUserData[0].Address,
                address2 = getUserData[0].Adress2,
                city = getUserData[0].City,
                state = getUserData[0].State,
                zipCode = getUserData[0].Zip,
                specialty = getUserData[0].Specialty,
                designation = getUserData[0].Degree
            };

            return View(user);
        }
        [HttpPost]
        public ActionResult account(Models.UserModel user)
        {
            if (ModelState.IsValid)
            {
                int userID = int.Parse(Request.Cookies["uID"].ToString());
                List<User_Table> getUserData = (from u in db.Users where u.User_Id == userID select u).ToList();
                foreach (User_Table updateUser in getUserData)
                {
                    updateUser.First_Name = user.firstName;
                    updateUser.Last_Name = user.lastName;
                    updateUser.Email = user.email;
                    updateUser.Password = user.password;
                    updateUser.phone = user.phone;
                    updateUser.Address = user.address;
                    updateUser.Adress2 = user.address2;
                    updateUser.City = user.city;
                    updateUser.State = user.state;
                    updateUser.Zip = user.zipCode;
                    updateUser.Specialty = user.specialty;
                    updateUser.Degree = user.designation;
                    db.Attach(updateUser);
                    db.Entry(updateUser);
                }
                
                db.SaveChanges();
                ViewData.Add("userId", userID);
            }
            
            return View(user);
        }
        //public ActionResult trafficSource(Models.sources sources)
        //{
        //    var serializer = new JavaScriptSerializer();
        //    var json = System.IO.File.ReadAllText(Server.MapPath("~/views/home/findMyJSON.txt"));
        //    var deserialize = serializer.Deserialize<List<NutritionCE.Models.userModel.sourceRecord>>(json.ToString());
        //    var uniqueSource = from u in deserialize
        //                       group u by u.sourceSelection
        //                           into grp
        //                       select new
        //                       {
        //                           Source = grp.Key,
        //                           Count = grp.Select(x => x.sourceSelection).Count()
        //                       };
        //    string viewStringName = "";
        //    string viewStringCount = "";
        //    foreach (var source in uniqueSource)
        //    {
        //        viewStringName += source.Source + ": <br />";
        //        viewStringCount += source.Count + "<br />";
        //    }
        //    sources.sourceName = viewStringName;
        //    sources.sourceCount = viewStringCount;
        //    return View(sources);
        //}

    }
}