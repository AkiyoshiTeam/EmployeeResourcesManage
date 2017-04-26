using System.Globalization;
using System.Windows.Controls;

namespace Employee_Resources_Manage.Domain
{
	public class NotEmptyValidationRule : ValidationRule
	{
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			return string.IsNullOrWhiteSpace((value ?? "").ToString())
				? new ValidationResult(false, "Không được bỏ trống.")
				: ValidationResult.ValidResult;
		}
	}
}