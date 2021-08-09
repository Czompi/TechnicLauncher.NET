using Avalonia.Data.Converters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicLauncher.Language
{
	public class Translate : IValueConverter
	{
		//public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) => TranslationHandler.Get((string)parameter);
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			Debug.WriteLine(value);
			Debug.WriteLine(parameter);
			return TranslationHandler.Get((string)parameter);
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
