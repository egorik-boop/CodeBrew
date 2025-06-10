using System;
using System.Collections.Generic;

namespace CodeBrew.Model;

public partial class IngredientsInCoffeeshop
{
    public int IngredientId { get; set; }

    public int CoffeeshopId { get; set; }

    public int Quantity { get; set; }

    public DateOnly? BestBeforeDate { get; set; }

    public virtual Coffeeshop Coffeeshop { get; set; } = null!;

    public virtual Ingredient Ingredient { get; set; } = null!;
}
