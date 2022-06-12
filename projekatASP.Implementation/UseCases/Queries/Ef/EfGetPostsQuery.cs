using Microsoft.EntityFrameworkCore;
using projekatASP.Application.UseCases.DTO;
using projekatASP.Application.UseCases.DTO.Searches;
using projekatASP.Application.UseCases.Queries;
using projekatASP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.Implementation.UseCases.Queries.Ef
{
    public class EfGetPostsQuery : EfUseCase ,IGetPostsQuery
    {

        public EfGetPostsQuery(ProjekatDbContext context) : base(context)
        {

        }

        public int Id => 16;

        public string Name => "Ef serach posts";

        public string Description => "This Ef is searching through all posts.";

        public PaginationShow<PostDTO> Execute(MainPaginationSearch sentRequest)
        {
            var keyword = sentRequest.Keyword;
            var page = sentRequest.Page;
            var perPage = sentRequest.PerPage;
            var query = Context.Post.Include(x => x.User).Where(x=>x.IsActive).Include(x => x.LikeDislikes).Include(x => x.Comments)
                                     .Include(x => x.Category).Include(x => x.PostImages).ThenInclude(x => x.Image)
                                     .Include(x => x.PostTags).ThenInclude(x => x.Tag).Where(x=>x.IsActive).AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Title.Contains(keyword) || x.Caprtion.Contains(keyword) || x.Category.Name.Contains(keyword));
            }

            if (perPage == null || perPage < 1)
            {
                perPage = 1;
            }

            if (page == null || page < 1)
            {
                perPage = 1;
            }

            var toSkip = (page.Value - 1) * perPage.Value;

            var pagination = new PaginationShow<PostDTO>();

            pagination.CountAll = query.Count();

            pagination.Data = query.Skip(toSkip).Take(perPage.Value).Select(x => new PostDTO
            {
               Id=x.Id,
               Caption=x.Caprtion,
               Title=x.Title,
               UserId=x.UserId,
               CategoryId=x.CategoryId,
               LikesDislakes=x.LikeDislikes.Select(x=> new LikeDislikeDTO 
               {    
                   UserId=x.UserId,
                   Like=x.Like
               }),
               Comments=x.Comments.Select(x=> new CommentDTO
               {
                   Id = x.Id,
                   UserId=x.UserId,
                   Comment=x.Content
               }),
               Tags=x.PostTags.Select(x=> new PostTagDTO
               {
                   Id=x.Tag.Id,
                   Name=x.Tag.Name
               }),
               Images=x.PostImages.Select(x=> new PostImageDTO
               {
                   Id=x.Image.Id,
                   Path=x.Image.Path
               })
            }).ToList();

            pagination.CurrentPage = page.Value;
            pagination.ItemsPerPage = perPage.Value;

            return pagination;


        }
    }
}
