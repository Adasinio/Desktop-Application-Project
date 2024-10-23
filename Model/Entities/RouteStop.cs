using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Firma_Transport.Model.Entities;

[PrimaryKey("RouteId", "AddressId")]
[Table("RouteStop")]
public partial class RouteStop
{
    [Key]
    [Column("RouteID")]
    public int RouteId { get; set; }

    [Key]
    [Column("AddressID")]
    public int AddressId { get; set; }

    public bool? StartLocation { get; set; }

    public bool? EndLocation { get; set; }

    [ForeignKey("AddressId")]
    [InverseProperty("RouteStops")]
    public virtual Address Address { get; set; } = null!;

    [ForeignKey("RouteId")]
    [InverseProperty("RouteStops")]
    public virtual Route Route { get; set; } = null!;
}
