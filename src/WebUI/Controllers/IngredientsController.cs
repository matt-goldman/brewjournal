using brewjournal.Application.Ingredients.Commands.AddIngredient;
using brewjournal.Application.Ingredients.Queries.Common;
using brewjournal.Application.Ingredients.Queries.GetAllIngredients;
using brewjournal.Application.Ingredients.Queries.SearchIngredients;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace brewjournal.WebUI.Controllers
{
    public class IngredientsController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(IngredientDto ingredient)
        {
            return await Mediator.Send(new AddIngredientCommand { Ingredient = ingredient });
        }

        [HttpGet]
        public async Task<ActionResult<IngredientsVm>> Get()
        {
            return await Mediator.Send(new GetAllIngredientsQuery());
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IngredientsVm>> Search(string searchTerm)
        {
            return await Mediator.Send(new SearchIngredientsQuery { SearchTerm = searchTerm });
        }
    }
}
