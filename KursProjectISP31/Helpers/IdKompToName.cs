using KursProjectISP31.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace KursProjectISP31.Helpers
{
    internal class IdKompToName : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture )
        {
            int id = int.Parse( value.ToString()!);
            using (GgContext db = new GgContext())
            {
                return db.Komponents.Where(p => p.Idkomp == id).FirstOrDefault()!.Namekomp!;
            }
        }

        public object ConvertBack(object value, Type TargetType, object parametr, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
