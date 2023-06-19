using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Forsaj.Classes
{
    public class RegexValidationRule : ValidationRule
    {
        public string ValidationExpression { get; set; }
        public string ErrorMessage { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = (value ?? string.Empty).ToString();

            if (!Regex.IsMatch(input, ValidationExpression))
                return new ValidationResult(false, ErrorMessage);

            return ValidationResult.ValidResult;
        }
    }

}
