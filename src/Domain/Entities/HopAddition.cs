﻿using System;

namespace brewjournal.Domain.Entities
{
    public class HopAddition
    {
        public int Id { get; set; }
        public int? IngredientId { get; set; }
        public int? Minutes { get; set; }
        public DateTime? DateAdded { get; set; }
        public int? Temperature { get; set; }
    }
}