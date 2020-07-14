using brewjournal.Application.Common.Mappings;
using brewjournal.Domain.Entities;

namespace brewjournal.Application.Recipes.Common
{
    public class RecipeIngredientDto : IMapFrom<RecipeIngredients>
    {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public float Quantity { get; set; }
    }
}
