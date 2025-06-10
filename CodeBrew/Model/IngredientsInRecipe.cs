using System;
using System.Collections.Generic;

namespace CodeBrew.Model;

public partial class IngredientsInRecipe
{
    public int RecipeId { get; set; }

    public int IngredientId { get; set; }

    public string Quantity { get; set; } = null!;

    public virtual Ingredient Ingredient { get; set; } = null!;

    public virtual Recipe Recipe { get; set; } = null!;
}
