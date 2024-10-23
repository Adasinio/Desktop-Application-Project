using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Firma_Transport.Model.Entities;

[Table("Employee")]
public partial class Employee
{
    [Key]
    [Column("EmployeeID")]
    public int EmployeeId { get; set; }

    [StringLength(15)]
    public string Name { get; set; } = null!;

    [StringLength(15)]
    public string Surname { get; set; } = null!;

    [StringLength(24)]
    public string? Phone { get; set; }

    public int JobTitle { get; set; }

    public int EmploymentForm { get; set; }

    public int Address { get; set; }

    public int Availability { get; set; }

    [ForeignKey("Address")]
    [InverseProperty("Employees")]
    public virtual Address AddressNavigation { get; set; } = null!;

    [ForeignKey("Availability")]
    [InverseProperty("Employees")]
    public virtual Availability AvailabilityNavigation { get; set; } = null!;

    [ForeignKey("EmploymentForm")]
    [InverseProperty("Employees")]
    public virtual EmploymentForm EmploymentFormNavigation { get; set; } = null!;

    [ForeignKey("JobTitle")]
    [InverseProperty("Employees")]
    public virtual JobTitle JobTitleNavigation { get; set; } = null!;

    [InverseProperty("JobDriverNavigation")]
    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}
