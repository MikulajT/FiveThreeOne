using MediatR;

namespace FiveThreeOne.Application.Features.Templates.GetTemplate
{
    public record GetTemplateQuery(Guid Id) : IRequest<TemplateDto?>;
}
