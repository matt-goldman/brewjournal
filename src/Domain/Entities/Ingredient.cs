﻿using System.Collections;
using System.Collections.Generic;

namespace brewjournal.Domain.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IngredientCategory Category { get; set; }
        public int CategoryId { get; set; }
        public ICollection<RecipeIngredients> Recipes { get; set; }
    }
}
