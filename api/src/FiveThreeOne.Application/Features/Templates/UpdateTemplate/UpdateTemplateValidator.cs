using FluentValidation;

namespace FiveThreeOne.Application.Features.Templates.UpdateTemplate
{
    public class UpdateTemplateValidator : AbstractValidator<UpdateTemplateCommand>
    {
        public UpdateTemplateValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            this.AddTemplateRules();
        }
    }
}
