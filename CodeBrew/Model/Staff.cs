using System;
using System.Collections.Generic;

namespace CodeBrew.Model;

public partial class Staff
{
    public int StaffId { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int? PositionId { get; set; }

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual StaffPosition? Position { get; set; }
}
