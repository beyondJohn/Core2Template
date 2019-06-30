using System.Linq;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using WebApplication5.Models;

namespace WebApplication5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new ModelDbContext())
            {
                var data = db.Users.Select(x => x.First_Name).Take(50).ToList();// (from a in db.Users select a.First_Name).Take(50);
                var moredata = db.Cases.Select(x => x.Case_Title).Take(50).ToList();
                var mycheck = data;
            }
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
