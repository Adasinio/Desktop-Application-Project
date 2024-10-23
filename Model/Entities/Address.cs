using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Firma_Transport.Model.Entities;

[Table("Address")]
public partial class Address
{
    [Key]
    [Column("AddressID")]
    public int AddressId { get; set; }

    [StringLength(15)]
    public string City { get; set; } = null!;

    [StringLength(15)]
    public string? Street { get; set; }

    [StringLength(5)]
    public string Building { get; set; } = null!;

    [StringLength(5)]
    public string? Flat { get; set; }

    [StringLength(10)]
    public string PostalCode { get; set; } = null!;

    [InverseProperty("AddressNavigation")]
    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    [InverseProperty("AddressNavigation")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    [InverseProperty("Address")]
    public virtual ICollection<RouteStop> RouteStops { get; set; } = new List<RouteStop>();
}
