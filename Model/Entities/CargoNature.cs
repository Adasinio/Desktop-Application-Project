using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Firma_Transport.Model.Entities;

[Table("CargoNature")]
public partial class CargoNature
{
    [Key]
    [Column("CargoNatureID")]
    public int CargoNatureId { get; set; }

    [StringLength(15)]
    public string Name { get; set; } = null!;

    [Column(TypeName = "ntext")]
    public string? Description { get; set; }

    [ForeignKey("CargoNatureId")]
    [InverseProperty("CargoNatures")]
    public virtual ICollection<CargoType> CargoTypes { get; set; } = new List<CargoType>();
}
