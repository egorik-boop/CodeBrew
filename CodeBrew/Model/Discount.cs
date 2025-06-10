using System;
using System.Collections.Generic;

namespace CodeBrew.Model;

public partial class Discount
{
    public int DiscountId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Percent { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
