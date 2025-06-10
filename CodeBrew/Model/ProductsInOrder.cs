using System;
using System.Collections.Generic;

namespace CodeBrew.Model;

public partial class ProductsInOrder
{
    public int ProductId { get; set; }

    public int SizeId { get; set; }

    public int OrderId { get; set; }

    public int Quantity { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual ProductSize Size { get; set; } = null!;
}
