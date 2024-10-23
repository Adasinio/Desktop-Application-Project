using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Firma_Transport.Model.Entities;

[Table("Route")]
public partial class Route
{
    [Key]
    [Column("RouteID")]
    public int RouteId { get; set; }

    [StringLength(15)]
    public string Lenght { get; set; } = null!;

    [StringLength(15)]
    public string EstimatedDuration { get; set; } = null!;

    [Column(TypeName = "ntext")]
    public string? Description { get; set; }

    [InverseProperty("JobRouteNavigation")]
    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();

    [InverseProperty("Route")]
    public virtual ICollection<RouteStop> RouteStops { get; set; } = new List<RouteStop>();
}
