using FiveThreeOne.Domain.Enums;
using MediatR;

namespace FiveThreeOne.Application.Features.Templates.CreateTemplate
{
    public record CreateTemplateCommand(string Name, TemplateType Type) : IRequest<Guid>, ITemplateCommand;
}
