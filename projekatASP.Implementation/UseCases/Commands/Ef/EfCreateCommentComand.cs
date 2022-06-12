using FluentValidation;
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
    public class EfCreateCommentComand : EfUseCase, ICreateCommentCommand
    {
        private CreateCommentValidator _validator;
        public EfCreateCommentComand(ProjekatDbContext context, CreateCommentValidator validator) :base(context)
        {
            _validator = validator;
        }
        public int Id => 21;

        public string Name => "Ef create comment";

        public string Description => "This Ef is creating comment";

        public void Execute(CreateCommentForPostDTO sentRequest)
        {
            _validator.ValidateAndThrow(sentRequest);

            var comment = new Comment
            {
                Content=sentRequest.Comment,
                PostId=sentRequest.PostId,
                UserId=sentRequest.UserId
            };

            Context.Comment.Add(comment);
            Context.SaveChanges();
        }
    }
}
