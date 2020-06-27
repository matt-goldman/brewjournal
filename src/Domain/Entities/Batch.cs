using System;
using System.Collections.Generic;

namespace brewjournal.Domain.Entities
{
    public  class Batch
    {
        public int Id { get; set; }
        public Recipe Recipe { get; set; }
        public int RecipeId { get; set; }
        public DateTime BrewDay { get; set; }
        public DateTime? BottleOrKegDate { get; set; }
        public long PitchTemp { get; set; }
        public long OG { get; set; }
        public long? FG { get; set; }
        public List<BatchHopAdditions> HopAdditions { get; set; }
        public string Notes { get; set; }
        public DateTime? ServingDate { get; set; }
        public List<BatchSample> Samples { get; set; }
    }
}
