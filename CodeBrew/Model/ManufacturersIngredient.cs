using System;
using System.Collections.Generic;

namespace CodeBrew.Model;

public partial class ManufacturersIngredient
{
    public int ManufacturerId { get; set; }

    public int IngredientId { get; set; }

    public decimal Price { get; set; }

    public virtual Ingredient Ingredient { get; set; } = null!;

    public virtual Manufacturer Manufacturer { get; set; } = null!;
}
