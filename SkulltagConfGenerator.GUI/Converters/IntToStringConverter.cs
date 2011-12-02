using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace SkulltagConfGenerator.GUI.Converters {
	public class IntToStringConverter : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
			return value.ToString();
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
			int intValue = 0;

			if(int.TryParse(value.ToString(), out intValue)) {
				return intValue;
			}

			return value.ToString();
		}
	}
}
