using FiveThreeOne.Domain.Enums;

namespace FiveThreeOne.Application.Features.Templates
{
    public record TemplateDto(Guid Id, string Name, TemplateType Type);
}
