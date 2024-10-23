using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Firma_Transport.Model.Entities;

[Table("Reccurency")]
public partial class Reccurency
{
    [Key]
    [Column("ReccurencyID")]
    public int ReccurencyId { get; set; }

    [StringLength(15)]
    public string Name { get; set; } = null!;

    [Column(TypeName = "ntext")]
    public string? Description { get; set; }

    [InverseProperty("ReccurencyNavigation")]
    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}
