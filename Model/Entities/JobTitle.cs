using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Firma_Transport.Model.Entities;

[Table("JobTitle")]
public partial class JobTitle
{
    [Key]
    [Column("JobTitleID")]
    public int JobTitleId { get; set; }

    [StringLength(10)]
    public string Name { get; set; } = null!;

    [Column(TypeName = "ntext")]
    public string? Description { get; set; }

    [InverseProperty("JobTitleNavigation")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
