using System;
using System.Collections.Generic;

namespace Parcial_2w2.ModelsDatabase;

public partial class Usuario
{
    public Guid Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string? Apellido { get; set; }

    public Guid IdRol { get; set; }

    public bool Activo { get; set; }

    public DateTime? FechaAlta { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? Telefono { get; set; }

    public string? Calle { get; set; }

    public string? Numero { get; set; }

    public string? CodPost { get; set; }

    public string? Provincia { get; set; }

    public string? Ciudad { get; set; }

    public virtual Role IdRolNavigation { get; set; } = null!;
}
