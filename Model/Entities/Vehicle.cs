using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Firma_Transport.Model.Entities;

[Table("Vehicle")]
public partial class Vehicle
{
    [Key]
    [Column("VehicleID")]
    public int VehicleId { get; set; }

    [StringLength(15)]
    public string Name { get; set; } = null!;

    [StringLength(15)]
    public string Registration { get; set; } = null!;

    public short Year { get; set; }

    [StringLength(10)]
    public string Make { get; set; } = null!;

    [StringLength(10)]
    public string Model { get; set; } = null!;

    [StringLength(17)]
    public string ChassisNumber { get; set; } = null!;

    public int VehicleType { get; set; }

    public bool Repair { get; set; }

    [InverseProperty("JobVehicleNavigation")]
    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();

    [ForeignKey("VehicleType")]
    [InverseProperty("Vehicles")]
    public virtual VehicleType VehicleTypeNavigation { get; set; } = null!;
}
