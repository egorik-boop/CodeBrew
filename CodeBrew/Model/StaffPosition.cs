using System;
using System.Collections.Generic;

namespace CodeBrew.Model;

public partial class StaffPosition
{
    public int PositionId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
