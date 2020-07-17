using brewjournal.Application.Common.Mappings;
using brewjournal.Domain.Entities;
using brewjournal.Domain.Enums;
using System.Collections.Generic;

namespace brewjournal.Application.Recipes.Common
{
    public class RecipeDto : IMapFrom<Recipe>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Style { get; set; }
        public List<RecipeIngredientDto> Ingredients { get; set; }
        public MassUnit MassUnits { get; set; }
        public TemperatureUnit TemperatureUnits { get; set; }
        public LiquidVolumeUnit LiquidUnits { get; set; }
        public string Notes { get; set; }
    }
}
