using System;
using System.Collections.Generic;

namespace CodeBrew.Model;

public partial class ProductSize
{
    public int SizeId { get; set; }

    public int? ProductId { get; set; }

    public string Size { get; set; } = null!;

    public decimal PriceModifier { get; set; }

    public virtual Product? Product { get; set; }

    public virtual ICollection<ProductsInOrder> ProductsInOrders { get; set; } = new List<ProductsInOrder>();
}
