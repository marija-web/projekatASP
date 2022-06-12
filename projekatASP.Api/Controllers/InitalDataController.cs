using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projekatASP.DataAccess;
using projekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projekatASP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class InitalDataController : ControllerBase
    {

        /// <summary>
        /// Creates initial data for database.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/InitialData
        ///     {
        ///        
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Successfull creation.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Unexpected server error.</response>
        // POST api/<InitalDataController>
        [HttpPost]
        public IActionResult Post()
        {
            var context = new ProjekatDbContext();

            var password = "password123";

            var users = new List<User>
            {
                new User {FirstName="Maki", LastName="Makic", Email="maki@gmail.com", Username="makiM", Password= BCrypt.Net.BCrypt.HashPassword(password) },
                new User {FirstName="Mici", LastName="Micic", Email="mici@gmail.com", Username="miciM", Password= BCrypt.Net.BCrypt.HashPassword(password) }
            };

            var categories = new List<Category>
            {
                new Category {Name="Fun"},
                new Category {Name="News"}
            };

            var tags = new List<Tag>
            {
                new Tag {Name="Riality"},
                new Tag {Name="Baskteball"}
            };

            var images = new List<Image>
            {
                new Image {Path="something.png"},
                new Image {Path="something2.jpg"},
            };

            var posts = new List<Post>
            {
                new Post {Title="Title1", Caprtion="Lorem ipsum1", User=users.First(), Category=categories.First()},
                new Post {Title="Title2", Caprtion="Lorem ipsum2", User=users.ElementAt(1), Category=categories.ElementAt(1)}
            };

            var likesDislakes = new List<LikeDislike>
            {
                new LikeDislike{Post=posts.First(), User=users.First(), Like=true},
                new LikeDislike{Post=posts.ElementAt(1), User=users.ElementAt(1), Like=false},
            };

            var comments = new List<Comment>
            {
                new Comment {Content="Comment1", Post=posts.First(), User=users.First()},
                new Comment {Content="Comment2", Post=posts.ElementAt(1), User=users.ElementAt(1)}
            };

            var postsImages = new List<PostImage>
            {
                new PostImage{Post=posts.ElementAt(1), Image=images.ElementAt(1)},
                new PostImage{Post=posts.ElementAt(0), Image=images.ElementAt(0)}
            };

            var postsTags = new List<PostTag>
            {
                new PostTag{Post=posts.ElementAt(0), Tag=tags.ElementAt(0)},
                new PostTag{Post=posts.ElementAt(1), Tag=tags.ElementAt(1)}
            };


            context.User.AddRange(users);
            context.Category.AddRange(categories);
            context.Tag.AddRange(tags);
            context.Image.AddRange(images);
            context.Post.AddRange(posts);
            context.LikeDislike.AddRange(likesDislakes);
            context.Comment.AddRange(comments);
            context.PostImage.AddRange(postsImages);
            context.PostTag.AddRange(postsTags);

            context.SaveChanges();
            return StatusCode(201);
        }
    }
}
