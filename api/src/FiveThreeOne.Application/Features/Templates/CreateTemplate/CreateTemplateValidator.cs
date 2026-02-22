using FluentValidation;

namespace FiveThreeOne.Application.Features.Templates.CreateTemplate
{
    public class CreateTemplateValidator : AbstractValidator<CreateTemplateCommand>
    {
        public CreateTemplateValidator()
        {
            this.AddTemplateRules();
        }
    }
}
