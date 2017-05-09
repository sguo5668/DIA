﻿using System;

using Microsoft.AspNetCore.Builder;

using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.Configuration;

using Microsoft.Extensions.DependencyInjection;

using Microsoft.Extensions.Logging;

using Microsoft.EntityFrameworkCore;  //need it, otherwise, inmemory db does not work

using Microsoft.Extensions.Caching.Memory;

using System.Collections.Generic;

using System.Linq;

using System.Threading.Tasks;

using AutoMapper;







namespace DIA.Web

{

    public class Startup

    {

        public Startup(IHostingEnvironment env)

        {

            var builder = new ConfigurationBuilder()

                .SetBasePath(env.ContentRootPath)

                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)

               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)

                .AddEnvironmentVariables();

            Configuration = builder.Build();

        }



        public IConfigurationRoot Configuration { get; }



        // This method gets called by the runtime. Use this method to add services to the container.

        public void ConfigureServices(IServiceCollection services)

        {

            // Add framework services.

            services.AddDbContext<DIAContext>(opt => opt.UseInMemoryDatabase());

            services.AddMvc();

            services.AddMemoryCache();

            services.AddSession(o =>

            {

                o.IdleTimeout = TimeSpan.FromSeconds(10);

                o.CookieName = "DIA";

            });



            var config = new AutoMapper.MapperConfiguration(cfg =>

            {

                cfg.AddProfile(new MappingProfile());

            });



            var mapper = config.CreateMapper();

            services.AddSingleton(mapper);



            //services.AddSingleton<ICachingService>(new CachingService());



            services.AddScoped<IClaimRepository, ClaimRepository>();



        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IMemoryCache cache)

        {



            string _datekey = "referencetablevalue";

            //List<ReferenceTableValue> _message;



            app.UseSession();

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));

            loggerFactory.AddDebug();



            loggerFactory.AddFile("Logs/myapp-{Date}.txt");





            //_message = new List<string> { "1000", "2000", "3000" };















            var startupLogger = loggerFactory.CreateLogger<Startup>();





            startupLogger.LogInformation($">{_datekey} generated and set in cache.");





            if (env.IsDevelopment())

            {

                app.UseDeveloperExceptionPage();

                app.UseBrowserLink();

            }

            else

            {

                app.UseExceptionHandler("/Home/Error");

            }



            app.UseStaticFiles();





            var context = app.ApplicationServices.GetService<DIAContext>();

            AddTestData(context);



            //_message = context.ReferenceTableValue.ToList();

            //cache.Set(_datekey, _message);



            app.UseMvc(



   //    routes =>

   //{

   //    routes.MapRoute(

   //        name: "default",

   //        template: "{controller=Claim}/{action=Index}/{id?}");

   //}



   );

        }



        private static void AddTestData(DIAContext context)

        {

            var testUser1 = new Claim

            {

                ClaimIDNumber = "DI1000000001",

                ClaimTypeCode = 1,

                ClaimantID = 1,



                EffectiveDate = Convert.ToDateTime("1/25/2017")

            };

            context.Claims.Add(testUser1);



            var testUser2 = new Claim

            {

                ClaimIDNumber = "DI1000000002",

                ClaimTypeCode = 1,

                ClaimantID = 2,



                EffectiveDate = Convert.ToDateTime("2/25/2017")

            };

            context.Claims.Add(testUser2);



            var testUser3 = new Claim

            {

                ClaimIDNumber = "DI1000000003",

                ClaimTypeCode = 1,

                ClaimantID = 2,

                Id = 4,

                EffectiveDate = Convert.ToDateTime("3/25/2017")

            };

            context.Claims.Add(testUser3);



            var testUser4 = new Claimant

            {



                Id = 1,

                DOB = Convert.ToDateTime("3/25/1997"),

                FirstName = "John",

                LastName = "Doe",

                SSN = "111-22-3333"

            };



            context.Claimants.Add(testUser4);

            context.SaveChanges();



            //var reftable = new ReferenceTable

            //{



            //    TableName = "Claim_Type"

            //};



            //context.ReferenceTable.Add(reftable);



            //context.SaveChanges();



            //int refid = reftable.Id;





            //var reftablevalue = new ReferenceTableValue

            //{



            //    TableName = "Claim_Type",

            //    SystemValue = "Disability Claim"



            //};



            //context.ReferenceTableValue.Add(reftablevalue);



            //var reftablevalue2 = new ReferenceTableValue

            //{



            //    TableName = "Claim_Type",

            //    SystemValue = "PFL Claim"



            //};



            //context.ReferenceTableValue.Add(reftablevalue2);





            //context.SaveChanges();











        }

    }

}