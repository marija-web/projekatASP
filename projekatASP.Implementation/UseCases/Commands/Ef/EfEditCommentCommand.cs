using FluentValidation;
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
    public class EfEditCommentCommand : EfUseCase, IEditCommentCommand
    {
        private EditCommentValidator _validator;
        public EfEditCommentCommand(ProjekatDbContext context, EditCommentValidator validator) :base(context)
        {
            _validator = validator;
        }
        public int Id => 23;

        public string Name => "Ef edit comment";

        public string Description => "This Ef is editing one comment through requested id.";

        public void Execute(CreateCommentForPostDTO sentRequest)
        {
            _validator.ValidateAndThrow(sentRequest);

            var comment = Context.Comment.Find(sentRequest.Id);

            if (comment == null)
            {
                throw new EntityNotFoundE(nameof(Comment), sentRequest.Id);
            }

            comment.Content = sentRequest.Comment;
            comment.UserId = sentRequest.UserId;
            comment.PostId = sentRequest.PostId;
            Context.SaveChanges();
        }
    }
}
