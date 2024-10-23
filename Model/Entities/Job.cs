using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Firma_Transport.Model.Entities;

[Table("Job")]
public partial class Job
{
    [Key]
    [Column("JobID")]
    public int JobId { get; set; }

    public int? CargoType { get; set; }

    public int? PassangerType { get; set; }

    public int? JobDriver { get; set; }

    public int? JobVehicle { get; set; }

    public int? JobRoute { get; set; }

    public int? Reccurency { get; set; }

    [Column(TypeName = "money")]
    public decimal? Price { get; set; }

    public float? Discount { get; set; }

    [ForeignKey("CargoType")]
    [InverseProperty("Jobs")]
    public virtual CargoType? CargoTypeNavigation { get; set; }

    [ForeignKey("JobDriver")]
    [InverseProperty("Jobs")]
    public virtual Employee? JobDriverNavigation { get; set; }

    [ForeignKey("JobRoute")]
    [InverseProperty("Jobs")]
    public virtual Route? JobRouteNavigation { get; set; }

    [ForeignKey("JobVehicle")]
    [InverseProperty("Jobs")]
    public virtual Vehicle? JobVehicleNavigation { get; set; }

    [ForeignKey("PassangerType")]
    [InverseProperty("Jobs")]
    public virtual PassangerType? PassangerTypeNavigation { get; set; }

    [ForeignKey("Reccurency")]
    [InverseProperty("Jobs")]
    public virtual Reccurency? ReccurencyNavigation { get; set; }

    [ForeignKey("JobId")]
    [InverseProperty("Jobs")]
    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
