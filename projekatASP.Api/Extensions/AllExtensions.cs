using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using projekatASP.Api.Core;
using projekatASP.Application.UseCases.Commands;
using projekatASP.Application.UseCases.Queries;
using projekatASP.DataAccess;
using projekatASP.Domain;
using projekatASP.Implementation.UseCases.Commands.Ef;
using projekatASP.Implementation.UseCases.Queries.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.Api.Extensions
{
    public static class AllExtensions
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<IFindCategoryQuery, EfFindCategoryQuery>();
            services.AddTransient<IGetCategoriesQuery, EfGetCategoriesQuery>();
            services.AddTransient<ICreateCategoryCommand, EfCreateCategoryCommand>();
            services.AddTransient<IDeleteCategoryCommand, EfDeleteCategoryCommand>();
            services.AddTransient<IEditCategoryCommand, EfEditCategoryCommand>();
            services.AddTransient<IGetTagsQuery, EfGetTagsQuery>();
            services.AddTransient<IFindTagQuery, EfFindTagQuery>();
            services.AddTransient<ICreateTagCommand, EfCreateTagCommand>();
            services.AddTransient<IEditTagCommand, EfEditTagCommand>();
            services.AddTransient<IDeleteTagCommand, EfDeleteTagCommand>();
            services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();
            services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();
            services.AddTransient<IFindUserQuery, EfFindUserQuery>();
            services.AddTransient<IEditUserCommand, EfEditUserCommand>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
            services.AddTransient<IGetPostsQuery, EfGetPostsQuery>();
            services.AddTransient<IFindPostQuery, EfFindPostQuery>();
            services.AddTransient<IDeletePostCommand, EfDeletePostCommand>();
            services.AddTransient<ICreatePostCommand, EfCreatePostCommand>();
            services.AddTransient<IEditPostCommand, EfEditPostCommand>();
            services.AddTransient<IEditPostCommand, EfEditPostCommand>();
            services.AddTransient<IEditUserCaseCommand, EfEditUseCaseCommand>();
            services.AddTransient<IGetUseCaseLogsQuery, EfGetUseCaseLogsQuery>();
            services.AddTransient<ICreateCommentCommand, EfCreateCommentComand>();
            services.AddTransient<IDeleteCommentCommand, EfDeleteCommentCommand>();
            services.AddTransient<IEditCommentCommand, EfEditCommentCommand>();
            services.AddTransient<ICreateLikeDislikeCommand, EfCreateLikeDislikeCommand>();
            services.AddTransient<IDeleteLikeDislikeCommand, EfDeleteLikeDislikeCommand>();
            services.AddTransient<IEditLikeDislikeCommand, EfEditLikeDislikeCommand>();
        }

        public static void AddJwt(this IServiceCollection services, AppSettings settings)
        {
            services.AddTransient(x =>
            {
                var context = x.GetService<ProjekatDbContext>();
                var settings = x.GetService<AppSettings>();

                return new JWTManager(context, settings.JwtSettings);
            });


            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = settings.JwtSettings.User,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.JwtSettings.SecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        public static void AddApplicationUser(this IServiceCollection services)
        {
            services.AddTransient<IApplicationUser>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var header = accessor.HttpContext.Request.Headers["Authorization"];

                var claims = accessor.HttpContext.User;

                if (claims == null || claims.FindFirst("UserId") == null)
                {
                    return new AnonimousUser();
                }

                var userA = new JwtUser
                {
                    Email = claims.FindFirst("Email").Value,
                    Id = Int32.Parse(claims.FindFirst("UserId").Value),
                    Identity = claims.FindFirst("Email").Value,
                    UseCaseIds = JsonConvert.DeserializeObject<List<int>>(claims.FindFirst("UseCases").Value)
                };

                return userA;
            });
        }
    }
}
