using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Firma_Transport.Model.Entities;

[Table("EmploymentForm")]
public partial class EmploymentForm
{
    [Key]
    [Column("EmploymentFormID")]
    public int EmploymentFormId { get; set; }

    [StringLength(20)]
    public string Name { get; set; } = null!;

    [Column(TypeName = "ntext")]
    public string? Description { get; set; }

    [InverseProperty("EmploymentFormNavigation")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
