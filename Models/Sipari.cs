using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VtOdev.Models;

public partial class Sipari : BaseEntity
{
    public int ProductId { get; set; }

    public int Adet { get; set; }

    public string Tarih { get; set; } = null!;

    public int MusteriId { get; set; }

    [NotMapped]
    public int? Tutar { get; set; }

    public virtual Product? Product { get; set; } = null!;
    public virtual Musteri? Musteri { get; set; } = null!;
}
