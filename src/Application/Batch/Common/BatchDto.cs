using AutoMapper;
using brewjournal.Application.Common.Mappings;
using brewjournal.Domain.Entities;
using System;
using System.Collections.Generic;

namespace brewjournal.Application.Batch.Common
{
    public class BatchDto : IMapFrom<brewjournal.Domain.Entities.Batch>
    {
        public int? Id { get; set; }
        public int RecipeId { get; set; }
        public DateTime BrewDay { get; set; }
        public DateTime? BottleOrKegDate { get; set; }
        public long PitchTemp { get; set; }
        public long OG { get; set; }
        public long? FG { get; set; }
        public List<HopAdditionDto> HopAdditions { get; set; }
        public string Notes { get; set; }
        public DateTime? ServingDate { get; set; }
        public List<SampleDto> Samples { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<brewjournal.Domain.Entities.Batch, BatchDto>()
                .ForMember(dst => dst.HopAdditions, opt => opt.MapFrom(src => src.HopAdditions));

            profile.CreateMap<BatchHopAdditions, HopAdditionDto>()
                .ForMember(dst => dst.IngredientId, opt => opt.MapFrom(src => src.HopAddition.IngredientId))
                .ForMember(dst => dst.IngredientName, opt => opt.MapFrom(src => src.HopAddition.Ingredient.Name))
                .ForMember(dst => dst.Minutes, opt => opt.MapFrom(src => src.HopAddition.Minutes))
                .ForMember(dst => dst.Temperature, opt => opt.MapFrom(src => src.HopAddition.Temperature));

        }
    }
}
