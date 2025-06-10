using System;
using System.Collections.Generic;

namespace CodeBrew.Model;

public partial class Event
{
    public int EventId { get; set; }

    public int? CoffeeshopId { get; set; }

    public DateTime? EventDate { get; set; }

    public string Description { get; set; } = null!;

    public virtual Coffeeshop? Coffeeshop { get; set; }
}
