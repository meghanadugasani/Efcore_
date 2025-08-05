using System;
using System.Collections.Generic;

namespace plantdbfirst_console.Models;

public partial class Plant
{
    public int PlantId { get; set; }

    public string PlantName { get; set; } = null!;

    public decimal Price { get; set; }

    public int Quantity { get; set; }
}
