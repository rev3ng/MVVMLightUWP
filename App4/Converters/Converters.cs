using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace App4.Converters
{

	public class SalaryConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value != null)
			{
				return value.ToString();
			}

			return String.Empty;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			if (Decimal.TryParse(value.ToString(), out decimal result))
			{
				return result;
			}

			return null;
		}
	}

	public class IsHiredConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value == null)
			{
				return null;
			}
			else if ((bool) value == true && parameter.Equals("false"))
			{
				return false;
			}

			return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{

			if (value != null)
			{

				if (parameter.Equals("true"))
				{
					return true;
				}
				else if (parameter.Equals("false"))
				{
					return false;
				}
			}

			return null;
		}
	}
}
