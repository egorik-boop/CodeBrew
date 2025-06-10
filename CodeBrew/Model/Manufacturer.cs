using System;
using System.Collections.Generic;

namespace CodeBrew.Model;

public partial class Manufacturer
{
    public int ManufacturerId { get; set; }

    public string? Description { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<ManufacturersIngredient> ManufacturersIngredients { get; set; } = new List<ManufacturersIngredient>();

    public virtual ICollection<Supply> Supplies { get; set; } = new List<Supply>();
}
