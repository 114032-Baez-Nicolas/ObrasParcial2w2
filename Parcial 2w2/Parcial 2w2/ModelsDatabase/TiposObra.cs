﻿using System;
using System.Collections.Generic;

namespace Parcial_2w2.ModelsDatabase;

public partial class TiposObra
{
    public Guid Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Obra> Obras { get; set; } = new List<Obra>();
}