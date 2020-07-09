using brewjournal.Application.Recipes.Commands.AddRecipe;
using brewjournal.Application.Recipes.Common;
using brewjournal.Application.Recipes.Queries.GetRecipe;
using brewjournal.Application.Recipes.Queries.SearchRecipes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace brewjournal.WebUI.Controllers
{
    public class RecipesController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(RecipeDto recipe)
        {
            return await Mediator.Send(new AddRecipeCommand { viewModel = recipe });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeDto>> Get(int id)
        {
            return await Mediator.Send(new GetRecipeQuery { Id = id });
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<RecipeSearchResultsVm>> Search(SearchRecipeQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
