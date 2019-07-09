using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication5.Areas.Identity.Data;

[assembly: HostingStartup(typeof(WebApplication5.Areas.Identity.IdentityHostingStartup))]
namespace WebApplication5.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            //builder.ConfigureServices((context, services) => {
            //    services.AddDbContext<WebApplication5IdentityDbContext>(options =>
            //        options.UseSqlServer(
            //            context.Configuration.GetConnectionString("WebApplication5IdentityDbContextConnection")));

            //    services.AddDefaultIdentity<IdentityUser>()
            //        .AddEntityFrameworkStores<WebApplication5IdentityDbContext>();
            //});
        }
    }
}