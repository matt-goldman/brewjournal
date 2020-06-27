using brewjournal.Application.Common.Interfaces;
using brewjournal.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace brewjournal.Application.Ingredients.Commands.AddIngredient
{
    public class AddIngredientCommand : IRequest<int>
    {
        public string Name { get; set; }
    }

    public class AddIngredientCommandHandler : IRequestHandler<AddIngredientCommand, int>
    {
        private IApplicationDbContext _context;

        public AddIngredientCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddIngredientCommand request, CancellationToken cancellationToken)
        {
            var ingredient = await _context.Ingredients.Where(i => i.Name.ToLower() == request.Name.ToLower()).SingleOrDefaultAsync();

            if(ingredient == null)
            {
                var entity = new Ingredient
                {
                    Name = request.Name
                };

                await _context.Ingredients.AddAsync(entity, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
            else
            {
                return ingredient.Id;
            }
        }
    }
}
