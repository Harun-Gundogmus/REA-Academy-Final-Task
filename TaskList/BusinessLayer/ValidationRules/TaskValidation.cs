using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class TaskValidation: AbstractValidator<TaskOwner>
    {
        public TaskValidation()
        {
            RuleFor(x => x.owner_status).NotEmpty().WithMessage("Durum Boş Geçilemez").
                MinimumLength(3).WithMessage("En Az Üç Karakter Giriniz");
            RuleFor(x => x.owner_explanation).NotEmpty().WithMessage("Açıklama Boş Geçilemez").
                MinimumLength(3).WithMessage("En Az Üç Karakter Giriniz");
            RuleFor(x => x.owner_task_title).NotEmpty().WithMessage("Başlık Boş Geçilemez").
                MinimumLength(3).WithMessage("En Az Üç Karakter Giriniz"); 
        }
    }
}
