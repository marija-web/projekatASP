using FluentValidation;
using Microsoft.EntityFrameworkCore;
using projekatASP.Application.UseCases.Commands;
using projekatASP.Application.UseCases.DTO;
using projekatASP.DataAccess;
using projekatASP.Domain;
using projekatASP.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.Implementation.UseCases.Commands.Ef
{
    public class EfCreatePostCommand : EfUseCase, ICreatePostCommand
    {
        private CreatePostValidator _validator;
        public EfCreatePostCommand(ProjekatDbContext context, CreatePostValidator validator) : base(context)
        {
            _validator = validator;
        }
        public int Id => 18;

        public string Name => "Ef create post";

        public string Description => "This Ef is creating post";

        public void Execute(CreatePostDTO sentRequest)
        {
            _validator.ValidateAndThrow(sentRequest);

            var post = new Post
            {
               Title=sentRequest.Title,
               Caprtion=sentRequest.Caption,
               CategoryId=sentRequest.CategoryId,
               UserId=sentRequest.UserId
            };

            if (!string.IsNullOrEmpty(sentRequest.FileImageName))
            {
                var image = new Image
                {
                    Path = sentRequest.FileImageName
                };

                Context.Post.Add(post);
                Context.Image.Add(image);

                var PostImage = new PostImage
                {
                    Post = post,
                    Image = image
                };

                Context.PostImage.AddRange(PostImage);

                foreach (int tagId in sentRequest.TagId)
                {
                    Context.PostTag.Add(new PostTag
                    {
                        Post = post,
                        TagId = tagId
                    });
                }
            }
            Context.SaveChanges();
        }
    }
}
