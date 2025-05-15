using System;
using System.Collections.Generic;

namespace Laboratorio_04.Models;

public partial class Egreso
{
    public int Id { get; set; }

    public int Valor { get; set; }

    public string Descripcion { get; set; } = null!;

    public int UsuarioId { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
