using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Firma_Transport.Model.Entities;

[Table("PaymentMethod")]
public partial class PaymentMethod
{
    [Key]
    [Column("PaymentMethodID")]
    public int PaymentMethodId { get; set; }

    [StringLength(10)]
    public string Name { get; set; } = null!;

    [Column(TypeName = "ntext")]
    public string? Description { get; set; }

    [InverseProperty("PaymentMethodNavigation")]
    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
