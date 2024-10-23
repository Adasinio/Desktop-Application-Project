using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Firma_Transport.Model.Entities;

[Table("VehicleType")]
public partial class VehicleType
{
    [Key]
    [Column("VehicleTypeID")]
    public int VehicleTypeId { get; set; }

    [StringLength(10)]
    public string Name { get; set; } = null!;

    [Column(TypeName = "ntext")]
    public string? Description { get; set; }

    [InverseProperty("VehicleTypeNavigation")]
    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
