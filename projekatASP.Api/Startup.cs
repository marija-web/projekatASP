using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using projekatASP.Api.Core;
using projekatASP.Api.Emails;
using projekatASP.Api.Extensions;
using projekatASP.Application.Emails;
using projekatASP.Application.Logging;
using projekatASP.Application.UseCases;
using projekatASP.Application.UseCases.Queries;
using projekatASP.DataAccess;
using projekatASP.Implementation;
using projekatASP.Implementation.Emails;
using projekatASP.Implementation.Logging;
using projekatASP.Implementation.UseCases;
using projekatASP.Implementation.UseCases.Queries.Ef;
using projekatASP.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace projekatASP.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var settings = new AppSettings();
            Configuration.Bind(settings);
            services.AddSingleton(settings);
            services.AddDbContext<ProjekatDbContext>();
            services.AddApplicationUser();
            services.AddJwt(settings);
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddUseCases();
            services.AddTransient<IExceptionLogger, ConsoleExceptionLogger>();
            services.AddTransient<IUseCaseLogger, ConsoleUseCaseLogger>();
            services.AddTransient<UseCaseHandler>();
            services.AddTransient<CreateCategoryValidator>();
            services.AddTransient<CreateTagValidator>();
            services.AddTransient<RegisterUserValidator>();
            services.AddTransient<EditUserValidator>();
            services.AddTransient<CreatePostValidator>();
            services.AddTransient<EditPostValidator>();
            services.AddTransient<EditUseCaseValidator>();
            services.AddTransient<CreateCommentValidator>();
            services.AddTransient<EditCommentValidator>();
            services.AddTransient<CreateLikeDislikeValidator>();
            services.AddTransient<IEmail>(x => 
                                   new SmptEmail(settings.ForEmail.Email, settings.ForEmail.Password, settings.ForEmail.Port, settings.ForEmail.Host));
            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "projekatASP.Api", Version = "v1" });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "projekatASP.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseMiddleware<GlobalExceptionHandler>();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
