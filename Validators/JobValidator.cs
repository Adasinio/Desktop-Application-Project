using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Transport.Validators
{
    public static class JobValidator
    {

        public static bool ValidateDiscountFormat (float? value, out string message)
        {
            message = string.Empty;
            var result = false;
            if (value <0)
            {
                message = "Zniżka nie może być mniejsza niż 0%";
                result = true;
            }
            else if (value > 100)
            {
                message = "Zniżka nie może być większa niż 100%";
                result = true;  
            }
            return result;

        }

        public static bool ValidatePricePresence (decimal? value,  out string message)
        {
            message = string.Empty;
            var result = false;
            if (value == null)
            {
                message = "Proszę obliczyć cenę";
                result = true;
            }
            return result;
        }


    }
}
