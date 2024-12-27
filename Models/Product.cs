using System;
using System.Collections.Generic;

namespace VtOdev.Models;

public partial class Product : BaseEntity
{

    public string Ad { get; set; } = null!;

    public int Fiyat { get; set; }

    public int Stok { get; set; }

    public virtual ICollection<Sipari> Siparis { get; set; } = new List<Sipari>();
}
