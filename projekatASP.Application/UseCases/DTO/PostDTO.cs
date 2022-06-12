using projekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace projekatASP.Application.UseCases.DTO
{
    public class PostDTO : MainDTO
    {
        public string Title { get; set; }
        public string Caption { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<LikeDislikeDTO> LikesDislakes { get; set; }
        public IEnumerable<CommentDTO> Comments { get; set; }

        public IEnumerable<PostTagDTO> Tags { get; set; }
        public IEnumerable<PostImageDTO> Images { get; set; }
    }

    public class LikeDislikeDTO
    {
        public int UserId { get; set; }
        public bool Like { get; set; }
    }

    public class CommentDTO : MainDTO
    {
        public int UserId { get; set; }
        public string Comment { get; set; }
    }

    public class PostTagDTO : MainDTO
    {
        public string Name { get; set; }
    }

    public class PostImageDTO : MainDTO
    {
        public string Path { get; set; }
    }

    public class CreatePostDTO : MainDTO
    {
        public string FileImageName { get; set; }
        public string Title { get; set; }
        public string Caption { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public IEnumerable<int> TagId { get; set; }
    }
}
