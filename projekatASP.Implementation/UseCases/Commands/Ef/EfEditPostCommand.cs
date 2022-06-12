using FluentValidation;
using Microsoft.EntityFrameworkCore;
using projekatASP.Application.Exceptions;
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
    public class EfEditPostCommand : EfUseCase, IEditPostCommand
    {
        private EditPostValidator _validator;

        public EfEditPostCommand(ProjekatDbContext context, EditPostValidator validator) : base(context)
        {
            _validator = validator;
        }
        public int Id => 19;

        public string Name => "Ef edit tag";

        public string Description => "This Ef is editing one post through requested id.";

        public void Execute(CreatePostDTO sentRequest)
        {
            _validator.ValidateAndThrow(sentRequest);

            var post = Context.Post.Include(x => x.User).Where(x => x.IsActive).Include(x => x.LikeDislikes).Include(x => x.Comments)
                                     .Include(x => x.Category).Include(x => x.PostImages).ThenInclude(x => x.Image)
                                     .Include(x => x.PostTags).ThenInclude(x => x.Tag).Where(x => x.IsActive).FirstOrDefault(x=>x.Id == sentRequest.Id && x.IsActive);

            if (post == null)
            {
                throw new EntityNotFoundE(nameof(Post), sentRequest.Id);
            };

            if (sentRequest.TagId != null )
            {
                Context.PostTag.RemoveRange(post.PostTags);

                foreach (int tag in sentRequest.TagId)
                {
                    Context.PostTag.Add(new PostTag
                    {
                        PostId = post.Id,
                        TagId = tag
                    });
                }
            }

            if (!string.IsNullOrEmpty(sentRequest.FileImageName))
            {
                Context.PostImage.RemoveRange(post.PostImages);

                var image = new Image
                {
                    Path = sentRequest.FileImageName
                };

                Context.Image.Add(image);

                var PostImage = new PostImage
                {
                    PostId = post.Id,
                    Image = image
                };

                    Context.PostImage.AddRange(PostImage);
            }

            if (sentRequest.Title != null)
            {
                post.Title = sentRequest.Title;
            }

            if (sentRequest.Caption != null)
            {
                post.Caprtion = sentRequest.Caption;
            }

            if (sentRequest.CategoryId != 0)
            {
                post.CategoryId = sentRequest.CategoryId;
            }

            Context.SaveChanges();
        }
    }
}
