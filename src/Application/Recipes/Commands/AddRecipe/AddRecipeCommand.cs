using brewjournal.Application.Common.Interfaces;
using brewjournal.Application.Recipes.Common;
using brewjournal.Domain.Entities;
using brewjournal.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace brewjournal.Application.Recipes.Commands.AddRecipe
{
    public class AddRecipeCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Style { get; set; }
        public List<RecipeIngredientDto> Ingredients { get; set; }
        public MassUnit MassUnits { get; set; }
        public TemperatureUnit TemperatureUnits { get; set; }
        public LiquidVolumeUnit LiquidUnits { get; set; }
        public string Notes { get; set; }        
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
                Name = request.Name,
                Style = request.Style,
                MassUnits = request.MassUnits,
                TemperatureUnit = request.TemperatureUnits,
                LiquidUnits = request.LiquidUnits
            };

            await _context.Recipes.AddAsync(entity, cancellationToken);

            request.Ingredients.ForEach(i =>
            {
                
            });

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
