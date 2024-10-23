using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Firma_Transport.Validators
{
    public static class AddressValidator
    {
        public static bool ValidatePostalCodeFormat (string value, out string message)
        {
            message = string.Empty;
            var result = false;
            var pattern = new Regex("^[0-9]{2}-[0-9]{3}$");
            if (!(value==null) && !pattern.IsMatch(value))
            {
                message = "Niepoprawny format kodu pocztowego";
                result = true;
            }
            return result;
        }

    }
}
