using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reforco_Escolar.Data;

[assembly: HostingStartup(typeof(Reforco_Escolar.Areas.Identity.IdentityHostingStartup))]
namespace Reforco_Escolar.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            

            builder.ConfigureServices((context, services) => {
                
            });
        }
    }
}