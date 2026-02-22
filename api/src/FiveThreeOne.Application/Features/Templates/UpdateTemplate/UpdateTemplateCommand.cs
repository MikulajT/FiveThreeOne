using FiveThreeOne.Domain.Enums;
using MediatR;

namespace FiveThreeOne.Application.Features.Templates.UpdateTemplate
{
    public record UpdateTemplateCommand(Guid Id, string Name, TemplateType Type) : IRequest, ITemplateCommand;
}
