using brewjournal.Application.Ingredients.Queries.Common;

namespace brewjournal.Application.Recipes.Common
{
    public class RecipeIngredientDto
    {
        public IngredientDto Ingredient { get; set; }
        public float Quantity { get; set; }
    }
}
