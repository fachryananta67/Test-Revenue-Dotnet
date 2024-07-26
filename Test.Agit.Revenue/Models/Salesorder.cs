using System;
using System.Collections.Generic;

namespace WebApplication2.Migrations;

public partial class Salesorder
{
    public string? Region { get; set; }

    public string? Country { get; set; }

    public string? ItemType { get; set; }

    public string? SalesChannel { get; set; }

    public string? Priority { get; set; }

    public DateOnly? OrderDate { get; set; }

    public string Id { get; set; } = null!;

    public DateOnly? ShipDate { get; set; }

    public long? UnitsSold { get; set; }

    public decimal? UnitPrice { get; set; }

    public decimal? UnitCost { get; set; }
}
