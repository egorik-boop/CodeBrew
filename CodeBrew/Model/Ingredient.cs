using System;
using System.Collections.Generic;

namespace CodeBrew.Model;

public partial class Ingredient
{
    public int IngredientId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<IngredientsInCoffeeshop> IngredientsInCoffeeshops { get; set; } = new List<IngredientsInCoffeeshop>();

    public virtual ICollection<IngredientsInRecipe> IngredientsInRecipes { get; set; } = new List<IngredientsInRecipe>();

    public virtual ICollection<ManufacturersIngredient> ManufacturersIngredients { get; set; } = new List<ManufacturersIngredient>();

    public virtual ICollection<Supply> Supplies { get; set; } = new List<Supply>();
}
