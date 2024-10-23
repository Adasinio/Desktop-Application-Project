using Microsoft.IdentityModel.Tokens;

namespace Firma_Transport.Validators
{
    public static class StringValidator
    {
        public static string ValidateIsFirstLetterUpper(this string value, out bool error)
        {
            error = false;
            var result = string.Empty;
            if (!value.IsNullOrEmpty() && !char.IsUpper(value, 0)) 
            {
                error = true;
                result = "Pierwsza litera powinna być duża.";
            }
            return result;
        }

    }
}
