using System;
using System.Collections.Generic;

namespace CodeBrew.Model;

public partial class Coffeeshop
{
    public int CoffeeshopId { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<IngredientsInCoffeeshop> IngredientsInCoffeeshops { get; set; } = new List<IngredientsInCoffeeshop>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Supply> Supplies { get; set; } = new List<Supply>();
}
