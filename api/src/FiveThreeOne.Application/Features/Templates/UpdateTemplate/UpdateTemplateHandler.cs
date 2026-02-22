using FiveThreeOne.Domain.Entities;
using FiveThreeOne.Infrastructure.Persistence;
using MediatR;

namespace FiveThreeOne.Application.Features.Templates.UpdateTemplate
{
    public class UpdateTemplateHandler : IRequestHandler<UpdateTemplateCommand>
    {
        private readonly ApplicationDbContext _context;

        public UpdateTemplateHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateTemplateCommand request, CancellationToken cancellationToken)
        {
            Template template = await _context.Templates.FindAsync([request.Id]);

            if (template == null)
            {
                throw new Exception("Template not found");
            }

            template.Name = request.Name;
            template.Type = request.Type;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
