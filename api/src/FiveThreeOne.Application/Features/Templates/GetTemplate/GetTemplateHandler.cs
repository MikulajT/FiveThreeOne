using FiveThreeOne.Domain.Entities;
using FiveThreeOne.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FiveThreeOne.Application.Features.Templates.GetTemplate
{
    public class GetTemplateHandler : IRequestHandler<GetTemplateQuery, TemplateDto?>
    {
        private readonly ApplicationDbContext _context;

        public GetTemplateHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TemplateDto?> Handle(GetTemplateQuery request, CancellationToken cancellationToken)
        {
            Template template = await _context.Templates
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (template == null) return null;

            return new TemplateDto(template.Id, template.Name, template.Type);
        }
    }
}
