﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            FileServerOptions defaultFilesOptions = new FileServerOptions();
            defaultFilesOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            defaultFilesOptions.DefaultFilesOptions.DefaultFileNames.Add("foo.html");

            app.UseFileServer(defaultFilesOptions);
            

            app.Run(async (context) => {
                await context.Response.WriteAsync("Hello World!");
            });
            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        //Console.WriteLine(System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToString());
            //        await context.Response.WriteAsync(_config["MyKey"]);
            //    });
            //});
        }
    }
}

