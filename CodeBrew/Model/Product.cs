using System;
using System.Collections.Generic;

namespace CodeBrew.Model;

public partial class Product
{
    public int ProductId { get; set; }

    public int? CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public string? Image { get; set; }

    public virtual ProductCategory? Category { get; set; }

    public virtual ICollection<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();

    public virtual ICollection<ProductsInOrder> ProductsInOrders { get; set; } = new List<ProductsInOrder>();

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}
