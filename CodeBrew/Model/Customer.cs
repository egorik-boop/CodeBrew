using System;
using System.Collections.Generic;

namespace CodeBrew.Model;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string Phone { get; set; } = null!;

    public int? LoyaltyLevelId { get; set; }

    public string? Email { get; set; }

    public int? Points { get; set; }

    public string? Name { get; set; }

    public string? PasswordHash { get; set; }

    public virtual LoyaltyLevel? LoyaltyLevel { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
