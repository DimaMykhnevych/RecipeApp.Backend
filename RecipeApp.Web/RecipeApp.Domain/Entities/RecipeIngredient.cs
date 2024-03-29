﻿namespace RecipeApp.Domain.Entities
{
    public class RecipeIngredient
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }

        public Recipe Recipe { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
