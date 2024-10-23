using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Firma_Transport.Model.Entities;

[Table("Client")]
public partial class Client
{
    [Key]
    [Column("ClientID")]
    public int ClientId { get; set; }

    [StringLength(10)]
    public string Code { get; set; } = null!;

    [StringLength(30)]
    public string Name { get; set; } = null!;

    [StringLength(15)]
    public string? Surname { get; set; }

    [StringLength(30)]
    public string? Nip { get; set; }

    [StringLength(15)]
    public string? Pesel { get; set; }

    public int Address { get; set; }

    [ForeignKey("Address")]
    [InverseProperty("Clients")]
    public virtual Address AddressNavigation { get; set; } = null!;

    [InverseProperty("ClientNavigation")]
    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
