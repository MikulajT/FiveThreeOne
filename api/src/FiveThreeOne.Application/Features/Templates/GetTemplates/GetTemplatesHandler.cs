using FiveThreeOne.Application.Common.Extensions;
using FiveThreeOne.Application.Common.Models;
using FiveThreeOne.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FiveThreeOne.Application.Features.Templates.GetTemplates
{
    public class GetTemplatesHandler : IRequestHandler<GetTemplatesQuery, PagedList<TemplateDto>>
    {
        private readonly ApplicationDbContext _context;

        public GetTemplatesHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedList<TemplateDto>> Handle(GetTemplatesQuery request, CancellationToken cancellationToken)
        {
            var templatesQuery = _context.Templates
                .AsNoTracking()
                .OrderBy(x => x.Name)
                .Select(x => new TemplateDto(
                    x.Id,
                    x.Name,
                    x.Type));

            return await templatesQuery.ToPagedListAsync(
                request.Params.PageNumber,
                request.Params.PageSize,
                cancellationToken);
        }
    }
}
