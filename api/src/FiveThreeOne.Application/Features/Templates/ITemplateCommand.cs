using FiveThreeOne.Domain.Enums;

namespace FiveThreeOne.Application.Features.Templates
{
    public interface ITemplateCommand
    {
        string Name { get; }
        TemplateType Type { get; }
    }
}
