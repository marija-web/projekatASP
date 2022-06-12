using Microsoft.EntityFrameworkCore;
using projekatASP.Application.Exceptions;
using projekatASP.Application.UseCases.DTO;
using projekatASP.Application.UseCases.Queries;
using projekatASP.DataAccess;
using projekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.Implementation.UseCases.Queries.Ef
{
    public class EfFindPostQuery : EfUseCase, IFindPostQuery
    {
        public EfFindPostQuery(ProjekatDbContext context) : base(context)
        {

        }
        public int Id => 16;

        public string Name => "Ef find post";

        public string Description => "This Ef is finding one post through requested id.";

        public PostDTO Execute(int sentRequest)
        {
            var id = sentRequest;
            var post = Context.Post.Include(x => x.User).Include(x => x.LikeDislikes).Include(x => x.Comments)
                                    .Include(x => x.Category).Include(x => x.PostImages).ThenInclude(x => x.Image)
                                    .Include(x => x.PostTags).ThenInclude(x => x.Tag).FirstOrDefault(x=>x.Id == id && x.IsActive);

            if (post == null)
            {
                throw new EntityNotFoundE(nameof(Post), id);
            }

            return new PostDTO
            {
                Id = post.Id,
                Caption = post.Caprtion,
                Title = post.Title,
                UserId = post.UserId,
                CategoryId = post.CategoryId,
                LikesDislakes = post.LikeDislikes.Select(x => new LikeDislikeDTO
                {
                    UserId = x.UserId,
                    Like = x.Like
                }),
                Comments = post.Comments.Select(x => new CommentDTO
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    Comment = x.Content
                }),
                Tags = post.PostTags.Select(x => new PostTagDTO
                {
                    Id = x.Tag.Id,
                    Name = x.Tag.Name
                }),
                Images = post.PostImages.Select(x => new PostImageDTO
                {
                    Id = x.Image.Id,
                    Path = x.Image.Path
                })
            };
        }
    }
}
