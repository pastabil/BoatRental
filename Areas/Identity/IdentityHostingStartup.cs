using System;
using BoatRental.Areas.Identity.Data;
using BoatRental.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(BoatRental.Areas.Identity.IdentityHostingStartup))]
namespace BoatRental.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<LoginDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("LoginDbContextConnection")));

                services.AddDefaultIdentity<BoatRentalAdmin>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<LoginDbContext>();
            });
        }
    }
}