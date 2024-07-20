using System;
using System.Collections.Generic;

namespace Parcial_2w2.ModelsDatabase;

public partial class Role
{
    public Guid Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int KeyRol { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
