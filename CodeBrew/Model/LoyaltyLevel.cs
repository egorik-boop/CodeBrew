using System;
using System.Collections.Generic;

namespace CodeBrew.Model;

public partial class LoyaltyLevel
{
    public int LoyaltyLevelId { get; set; }

    public decimal RansomAmount { get; set; }

    public decimal CashbackPercent { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
