using System;
using System.Collections.Generic;

namespace CodeBrew.Model;

public partial class Recipe
{
    public int RecipeId { get; set; }

    public int? ProductId { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<IngredientsInRecipe> IngredientsInRecipes { get; set; } = new List<IngredientsInRecipe>();

    public virtual Product? Product { get; set; }
}
