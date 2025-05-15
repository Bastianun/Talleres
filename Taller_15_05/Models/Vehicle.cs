using System;
using System.Collections.Generic;

namespace Taller_15_05.Models;

public partial class Vehicle
{
    public int Id { get; set; }

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public DateOnly? AñoDeFabricacion { get; set; }

    public string? Color { get; set; }

    public int? Precio { get; set; }

    public string? Patente { get; set; }
}
