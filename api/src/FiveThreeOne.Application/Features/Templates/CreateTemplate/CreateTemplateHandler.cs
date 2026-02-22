using FiveThreeOne.Domain.Entities;
using FiveThreeOne.Infrastructure.Persistence;
using MediatR;

namespace FiveThreeOne.Application.Features.Templates.CreateTemplate
{
    public class CreateTemplateHandler : IRequestHandler<CreateTemplateCommand, Guid>
    {
        private readonly ApplicationDbContext _context;

        public CreateTemplateHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateTemplateCommand request, CancellationToken cancellationToken)
        {
            var template = new Template()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Type = request.Type,
                CreatedAt = DateTime.UtcNow
            };

            _context.Templates.Add(template);
            await _context.SaveChangesAsync(cancellationToken);

            return template.Id;
        }
    }
}
