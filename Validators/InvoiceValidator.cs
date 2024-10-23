using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Transport.Validators
{
    class InvoiceValidator
    {
        public static bool ValidateInvoiceDueDate(DateTime invoiceDate, DateTime dueDate, out string message)
        {
            message = string.Empty;
            var result = false;
            if (invoiceDate > dueDate)
            {
                message = "Data do opłacenia nie może być wcześniejsza niż data wystawienia";
                result = true;  
            }
            return result;

        }

        public static bool ValidateInvoicePaidDate(DateTime? paidDate, DateTime dueDate, DateTime invoiceDate, out string message)
        {
            message = string.Empty;
            var result = false;
            if (paidDate < dueDate && paidDate < invoiceDate)
            {
                message = "Data opłacenia nie może być wcześniejsza niż daty wystawienia i do opłacenia";
                result = true;
            }

            else if (paidDate < dueDate)
            {
                message = "Data opłacenia nie może być wcześniejsza niż data do opłacenia";
                result = true;
            }
            return result;

        }
    }
}
