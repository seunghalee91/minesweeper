using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Controls;

namespace Minesweeper.WPF
{
    [ValueConversion(typeof(Button),typeof(MineMap))]
    public class Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {




            return 0;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Data -> Button  change statue
            var minemap = parameter as MineMap;
            string btnContent = value as string;
            //btnContent = System.Convert.ToString(minemap.MineItems[,].NearBombsCount);

            //minemap.MineItems[0, 0].IsBomb;
            //minemap.MineItems[0, 0].IsCovered;
            //minemap.MineItems[0, 0].NearBombsCount;
            return btnContent;
        }
    }
}
