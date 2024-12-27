using System;
using System.Collections.Generic;

namespace VtOdev.Models;

public partial class Musteri : BaseEntity
{
    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;
    public virtual ICollection<Sipari> Siparis { get; set; } = new List<Sipari>();
}
