using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Firma_Transport.Model.Entities;

[Table("CargoType")]
public partial class CargoType
{
    [Key]
    [Column("CargoTypeID")]
    public int CargoTypeId { get; set; }

    [StringLength(15)]
    public string Code { get; set; } = null!;

    public double? WeightMin { get; set; }

    public double? WeightMax { get; set; }

    public int CargoNature { get; set; }

    [Column(TypeName = "money")]
    public decimal Price { get; set; }

    [InverseProperty("CargoTypeNavigation")]
    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();

    [ForeignKey("CargoTypeId")]
    [InverseProperty("CargoTypes")]
    public virtual ICollection<CargoNature> CargoNatures { get; set; } = new List<CargoNature>();
}
