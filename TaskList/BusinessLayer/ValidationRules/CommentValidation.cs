using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CommentValidation: AbstractValidator<TaskComment>
    {
        public CommentValidation()
        {
            RuleFor(x => x.comment).NotEmpty().WithMessage("Yorum Boş Geçilemez");
        }
    }
}
