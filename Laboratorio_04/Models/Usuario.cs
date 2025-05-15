using System;
using System.Collections.Generic;

namespace Laboratorio_04.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public virtual ICollection<Egreso> Egresos { get; set; } = new List<Egreso>();
}
