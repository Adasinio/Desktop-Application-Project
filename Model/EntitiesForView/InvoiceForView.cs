using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Transport.Model.EntitiesForView
{
    class InvoiceForView
    {
        #region Data

        public int InvoiceID { get; set; }
        public string? ClientName { get; set;}
        public string? ClientNumber { get; set;}
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public string? PaymentMethod { get; set; }
        #endregion
    }
}
