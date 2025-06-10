using System;
using System.Collections.Generic;

namespace CodeBrew.Model;

public partial class Supply
{
    public int SupplyId { get; set; }

    public int? CoffeeshopId { get; set; }

    public int? IngredientId { get; set; }

    public int? ManufacturerId { get; set; }

    public int Quantity { get; set; }

    public DateTime? SupplyDate { get; set; }

    public virtual Coffeeshop? Coffeeshop { get; set; }

    public virtual Ingredient? Ingredient { get; set; }

    public virtual Manufacturer? Manufacturer { get; set; }
}
