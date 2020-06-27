using brewjournal.Application.Common.Interfaces;
using brewjournal.Application.Recipes.Common;
using brewjournal.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace brewjournal.Application.Recipes.Commands.AddRecipe
{
    public class AddRecipeCommand : IRequest<int>
    {
        public RecipeVmDto viewModel { get; set; }  
    }

    public class AddRecipeCommandHandler : IRequestHandler<AddRecipeCommand, int>
    {
        public IApplicationDbContext _context;

        public AddRecipeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddRecipeCommand request, CancellationToken cancellationToken)
        {
            var entity = new Recipe
            {
                Name = request.viewModel.Name,
                Style = request.viewModel.Style,
                MassUnits = request.viewModel.MassUnits,
                TemperatureUnit = request.viewModel.TemperatureUnits,
                LiquidUnits = request.viewModel.LiquidUnits
            };

            await _context.Recipes.AddAsync(entity, cancellationToken);

            request.viewModel.Ingredients.ForEach(async i =>
            {
                await _context.RecipeIngredients.AddAsync(new RecipeIngredients
                {
                    Recipe = entity,
                    IngredientId = i.Ingredient.Id,
                    Quantity = i.Quantity
                }, cancellationToken);
            });

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
