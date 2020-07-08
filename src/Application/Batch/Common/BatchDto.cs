using brewjournal.Application.Common.Mappings;
using System;
using System.Collections.Generic;

namespace brewjournal.Application.Batch.Common
{
    public class BatchDto : IMapFrom<brewjournal.Domain.Entities.Batch>
    {
        public int Id { get; set; }
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
    }
}
