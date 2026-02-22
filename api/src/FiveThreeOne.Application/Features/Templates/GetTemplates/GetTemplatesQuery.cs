using FiveThreeOne.Application.Common.Models;
using MediatR;

namespace FiveThreeOne.Application.Features.Templates.GetTemplates
{
    public record GetTemplatesQuery(PaginationParams Params) : IRequest<PagedList<TemplateDto>>;
}
