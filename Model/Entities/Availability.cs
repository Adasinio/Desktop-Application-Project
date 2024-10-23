using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Firma_Transport.Model.Entities;

[Table("Availability")]
public partial class Availability
{
    [Key]
    [Column("AvailabilityID")]
    public int AvailabilityId { get; set; }

    [StringLength(7)]
    public string Code { get; set; } = null!;

    public bool Monday { get; set; }

    public bool Tuesday { get; set; }

    public bool Wednesday { get; set; }

    public bool Thursday { get; set; }

    public bool Friday { get; set; }

    public bool Saturday { get; set; }

    public bool Sunday { get; set; }

    [InverseProperty("AvailabilityNavigation")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
