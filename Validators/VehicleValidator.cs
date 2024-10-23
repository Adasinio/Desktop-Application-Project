using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Transport.Validators
{
    public static class VehicleValidator
    {
        public static bool ValidateFormatName(string value, out string message)
        {
            message = string.Empty;
            var result = false;
            if (IsNameEmpty(value))
            {
                message = "Nazwa nie może być pusta";
                result = true;
            }
            else if (value.Length > 15)
            {
                message = "Nazwa pojazdu jest zbyt długa";
                result = true;
            }
            return result;
        }

        private static bool IsNameEmpty(string value)
        {
            return value.IsNullOrEmpty();
        }
    }
}
