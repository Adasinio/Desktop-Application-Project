using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Firma_Transport.Model.Entities;

[Table("Invoice")]
public partial class Invoice
{
    [Key]
    [Column("InvoiceID")]
    public int InvoiceId { get; set; }

    public int Client { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime InvoiceDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DueDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PaidDate { get; set; }

    public int? PaymentMethod { get; set; }

    [ForeignKey("Client")]
    [InverseProperty("Invoices")]
    public virtual Client ClientNavigation { get; set; } = null!;

    [ForeignKey("PaymentMethod")]
    [InverseProperty("Invoices")]
    public virtual PaymentMethod? PaymentMethodNavigation { get; set; }

    [ForeignKey("InvoiceId")]
    [InverseProperty("Invoices")]
    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}
