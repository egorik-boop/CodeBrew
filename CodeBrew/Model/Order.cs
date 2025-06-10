using System;
using System.Collections.Generic;

namespace CodeBrew.Model;

public partial class Order
{
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public int? CoffeeshopId { get; set; }

    public decimal TotalAmount { get; set; }

    public int? PointsUsed { get; set; }

    public DateTime? Date { get; set; }

    public int? StaffId { get; set; }

    public int? DiscountId { get; set; }

    public virtual Coffeeshop? Coffeeshop { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Discount? Discount { get; set; }

    public virtual ICollection<ProductsInOrder> ProductsInOrders { get; set; } = new List<ProductsInOrder>();

    public virtual Staff? Staff { get; set; }
}
