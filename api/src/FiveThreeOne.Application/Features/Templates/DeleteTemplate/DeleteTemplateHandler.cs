using FiveThreeOne.Domain.Entities;
using FiveThreeOne.Infrastructure.Persistence;
using MediatR;

namespace FiveThreeOne.Application.Features.Templates.DeleteTemplate
{
    public class DeleteTemplateHandler : IRequestHandler<DeleteTemplateCommand>
    {
        private readonly ApplicationDbContext _context;

        public DeleteTemplateHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteTemplateCommand request, CancellationToken cancellationToken)
        {
            Template template = await _context.Templates.FindAsync([request.Id]);

            if (template == null)
            {
                throw new Exception("Template not found");
            }

            _context.Templates.Remove(template);
            _context.SaveChangesAsync(cancellationToken);
        }
    }
}
