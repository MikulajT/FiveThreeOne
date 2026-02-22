using MediatR;

namespace FiveThreeOne.Application.Features.Templates.DeleteTemplate
{
    public record DeleteTemplateCommand(Guid Id) : IRequest;
}
