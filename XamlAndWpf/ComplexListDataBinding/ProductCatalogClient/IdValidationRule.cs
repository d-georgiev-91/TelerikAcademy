namespace ProductCatalogClient
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows.Controls;

    public class IdValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string pattern = @"0-9";
            if (Regex.IsMatch((string)value, pattern))
            {
                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false,
                    "EGN should be a number.");
            }
        }
    }
}
