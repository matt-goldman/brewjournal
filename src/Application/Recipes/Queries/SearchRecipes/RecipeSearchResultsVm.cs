using brewjournal.Application.Recipes.Common;
using System.Collections.Generic;

namespace brewjournal.Application.Recipes.Queries.SearchRecipes
{
    public class RecipeSearchResultsVm
    {
        public IList<RecipeDto> Recipes { get; set; }

        public RecipeSearchResultsVm()
        {
            Recipes = new List<RecipeDto>();
        }
    }
}
