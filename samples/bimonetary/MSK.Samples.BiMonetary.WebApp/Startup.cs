using System;
using AspNetCore.RouteAnalyzer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MSK.Samples.BiMonetary.WebApp.Extensions;

namespace MSK.Samples.BiMonetary.WebApp
{
    public class Startup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            return services
                .AddCryptoCurrency()
                .AddRouteAnalyzer()
                .BuildServiceProvider();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCryptoCurrency(preRouteAction: routes => {
                routes.MapRouteAnalyzer("/routes");
            });
        }
    }
}