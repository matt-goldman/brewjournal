using AutoMapper;
using brewjournal.Application.Common.Mappings;
using brewjournal.Application.Ingredients.Queries.Common;
using brewjournal.Domain.Entities;

namespace brewjournal.Application.Recipes.Common
{
    public class RecipeIngredientDto : IMapFrom<RecipeIngredients>
    {
        public IngredientDto Ingredient { get; set; }
        public float Quantity { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RecipeIngredients, RecipeIngredientDto>()
                .ForMember(d => d.Ingredient.Name, opt => opt.MapFrom(src => src.Ingredient.Name))
                .ForMember(d => d.Ingredient.Name, opt => opt.MapFrom(src => src.Ingredient.Id))
                .ForMember(d => d.Quantity, opt => opt.MapFrom(src => src.Quantity));
        }
    }
}
