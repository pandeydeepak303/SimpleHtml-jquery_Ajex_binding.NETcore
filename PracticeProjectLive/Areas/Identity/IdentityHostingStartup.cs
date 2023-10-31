using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PracticeProjectLive.Areas.Identity.Data;
using PracticeProjectLive.Data;

[assembly: HostingStartup(typeof(PracticeProjectLive.Areas.Identity.IdentityHostingStartup))]
namespace PracticeProjectLive.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<PracticeProjectLiveContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("PracticeProjectLiveContextConnection")));

                services.AddDefaultIdentity<PracticeProjectLiveUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<PracticeProjectLiveContext>();
            });
        }
    }
}