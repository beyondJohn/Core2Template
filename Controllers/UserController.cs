using Microsoft.Extensions.Options;
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
        private readonly AppSettings connections;

        public TestModel testModel = new TestModel();
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserController(IHttpContextAccessor httpContextAccessor, IOptions<AppSettings> appsettings)
        {
            connections = appsettings.Value;
            this._httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult account()
        {
            int userID = int.Parse(Request.Cookies["uID"]);
            List<User_Table> userData = new List<User_Table>();
            using(var db = new ModelDbContext())
            {
                userData = db.Users
                    .Where(x => x.User_Id == userID)
                    .ToList();
            }
            
            var user = new UserModel()
            {
                firstName = userData[0].First_Name,
                lastName = userData[0].Last_Name,
                email = userData[0].Email,
                password = userData[0].Password,
                phone = userData[0].phone,
                address = userData[0].Address,
                address2 = userData[0].Adress2,
                city = userData[0].City,
                state = userData[0].State,
                zipCode = userData[0].Zip,
                specialty = userData[0].Specialty,
                designation = userData[0].Degree,
                UserId = userID
            };

            return View(user);
        }
        [HttpPost]
        public ActionResult account(Models.UserModel user)
        {
            if (ModelState.IsValid)
            {
                List<User_Table> getUserData = new List<User_Table>();
                int userID = int.Parse(Request.Cookies["uID"].ToString());
                using(var db = new ModelDbContext())
                {
                    db.Users
                        .Where(x => x.User_Id == userID)
                        .ToList();
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
                }
                
                
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