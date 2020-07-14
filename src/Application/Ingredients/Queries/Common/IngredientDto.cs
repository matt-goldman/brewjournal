using brewjournal.Application.Common.Mappings;
using brewjournal.Domain.Entities;

namespace brewjournal.Application.Ingredients.Queries.Common
{
    public class IngredientDto : IMapFrom<Ingredient>
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public int? CategoryId { get; set; }
    }
}
