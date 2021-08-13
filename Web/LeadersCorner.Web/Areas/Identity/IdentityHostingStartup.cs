using System;
using LeadersCorner.Web.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(LeadersCorner.Web.Areas.Identity.IdentityHostingStartup))]
namespace LeadersCorner.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<LeadersCornerWebContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("LeadersCornerWebContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<LeadersCornerWebContext>();
            });
        }
    }
}