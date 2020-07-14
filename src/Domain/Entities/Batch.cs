﻿using System;
using System.Collections.Generic;

namespace brewjournal.Domain.Entities
{
    public  class Batch
    {
        public int Id { get; set; }
        public Recipe? Recipe { get; set; }
        public int RecipeId { get; set; }
        public DateTime BrewDay { get; set; }
        public DateTime? BottleOrKegDate { get; set; }
        public long PitchTemp { get; set; }
        public float OG { get; set; }
        public float? FG { get; set; }
        public ICollection<BatchHopAdditions>? HopAdditions { get; set; }
        public string Notes { get; set; }
        public DateTime? ServingDate { get; set; }
        public List<BatchSample>? Samples { get; set; }
    }
}
