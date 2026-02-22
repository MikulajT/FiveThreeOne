using FluentValidation;

namespace FiveThreeOne.Application.Features.Templates
{
    public static class TemplateValidatorExtensions
    {
        public static void AddTemplateRules<T>(this AbstractValidator<T> validator) where T : ITemplateCommand
        {
            validator.RuleFor(x => x.Name).NotEmpty();
            validator.RuleFor(x => x.Type).IsInEnum();
        }
    }
}
