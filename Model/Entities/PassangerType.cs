using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Firma_Transport.Model.Entities;

[Table("PassangerType")]
public partial class PassangerType
{
    [Key]
    [Column("PassangerTypeID")]
    public int PassangerTypeId { get; set; }

    [StringLength(10)]
    public string Code { get; set; } = null!;

    public int NumberMin { get; set; }

    public int NumberMax { get; set; }

    public double LuggageWeightMin { get; set; }

    public double LuggageWeightMax { get; set; }

    public bool Accessibility { get; set; }

    [Column(TypeName = "money")]
    public decimal Price { get; set; }

    [InverseProperty("PassangerTypeNavigation")]
    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}
