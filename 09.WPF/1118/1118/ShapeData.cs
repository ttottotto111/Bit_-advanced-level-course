using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace _1118
{
    class ShapeData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Property
        private Point pt;
        public Point Pt
        {
            get { return pt; }
            set
            {
                pt = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Pt"));
            }
        }
        private int type;
        public int Type
        {
            get { return type; }
            set
            {
                type = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Type"));
            }
        }
        private Color col;
        public Color Col
        {
            get { return col; }
            set
            {
                col = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Col"));
            }
        }
        private int size;
        public int Size
        {
            get { return size; }
            set
            {
                size = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Size"));
            }
        }
        #endregion

        public override string ToString()
        {
            return Pt.ToString() + " : " + Type + " , " + Col + " : " + Size;
        }
    }

    [ValueConversion(/* 원본 형식 */ typeof(int), /* 대상 형식 */ typeof(bool))]
    public class TypeToboolConverter : IValueConverter
    {
        // 데이터 속성을 UI 속성으로 변경할 때
        public object Convert(object value, Type targetType, object parameter,
       System.Globalization.CultureInfo culture)
        {
            //value : 데이터의 속성값
            int male = (int)value;
            if (male == 1)
                return true;
            else
                return false;
        }
        // UI 속성을 데이터 속성으로 변경할 때
        public object ConvertBack(object value, Type targetType, object
       parameter, System.Globalization.CultureInfo culture)
        {
            //value : UI의 bool)value;
            bool male = (bool)value;
            if (male == true)
                return 1;
            else
                return 2;

        }
    }

    [ValueConversion(/* 원본 형식 */ typeof(int), /* 대상 형식 */ typeof(bool))]
    public class TypeTobool1Converter : IValueConverter
    {
        // 데이터 속성을 UI 속성으로 변경할 때
        public object Convert(object value, Type targetType, object parameter,
       System.Globalization.CultureInfo culture)
        {
            //value : 데이터의 속성값
            int male = (int)value;
            if (male == 1)
                return false;
            else
                return true;
        }
        // UI 속성을 데이터 속성으로 변경할 때
        public object ConvertBack(object value, Type targetType, object
       parameter, System.Globalization.CultureInfo culture)
        {
            //value : UI의 bool)value;
            bool male = (bool)value;
            if (male == true)
                return 2;
            else
                return 1;

        }
    }

    [ValueConversion(/* 원본 형식 */ typeof(int), /* 대상 형식 */ typeof(int))]
    public class SizeToIdxConverter : IValueConverter
    {
        // 데이터 속성을 UI 속성으로 변경할 때
        public object Convert(object value, Type targetType, object parameter,
       System.Globalization.CultureInfo culture)
        {
            //value : 데이터의 속성값
            int male = (int)value;  //25 50 100 150 200

            if (male == 25) return 0;//[UI속성으로 전달]
            else if (male == 50) return 1;
            else if (male == 100) return 2;
            else if (male == 150) return 3;
            else if (male == 200) return 4;
            else return -1;
        }
        // UI 속성을 데이터 속성으로 변경할 때
        public object ConvertBack(object value, Type targetType, object
       parameter, System.Globalization.CultureInfo culture)
        {
            //value : 데이터의 속성값
            int male = (int)value;  //25 50 100 150 200

            if (male == 0) return 25;//[UI속성으로 전달]
            else if (male == 1) return 50;
            else if (male == 2) return 100;
            else if (male == 3) return 150;
            else if (male == 4) return 200;
            else return -1;
        }
    }

    [ValueConversion(/* 원본 형식 */ typeof(Color), /* 대상 형식 */ typeof(int))]


    //콤보박스(색상)
    //형식 변환기 : data(Color) #XXXXXXX->"idx" 콤보박스 선택인덱스(int)
    [ValueConversion(/* 원본 형식 */ typeof(Color), /* 대상 형식 */ typeof(int))]
    public class ColorToIdxConverter : IValueConverter
    {
        // 데이터 속성을 UI 속성으로 변경할 때
        public object Convert(object value, Type targetType, object parameter,
       System.Globalization.CultureInfo culture)
        {
            //value : 데이터의 속성값
            Color male = (Color)value;  //25 50 100 150 200

            //List<ColorInfo> color_query;
            var color_query =
                   from PropertyInfo property in typeof(Colors).GetProperties()
                   orderby property.Name
                   //orderby ((Color)property.GetValue(null, null)).ToString()
                   select new ColorInfo(property.Name, (Color)property.GetValue(null, null));

            List<ColorInfo> colorlist = color_query.ToList<ColorInfo>();
            int i;
            for (i = 0; i < colorlist.Count; i++)
            {
                ColorInfo c = colorlist[i];
                if (male.ToString().Equals(c.Color.ToString()) == true)
                {
                    break;
                }
            }
            return i;
        }
        // UI 속성을 데이터 속성으로 변경할 때
        public object ConvertBack(object value, Type targetType, object
       parameter, System.Globalization.CultureInfo culture)
        {
            //value : UI의 value[라디오버튼의 IsChecked]
            int male = (int)value;

            //List<ColorInfo> color_query;
            var color_query =
                   from PropertyInfo property in typeof(Colors).GetProperties()
                   orderby property.Name
               //orderby ((Color)property.GetValue(null, null)).ToString()
               select new ColorInfo(property.Name, (Color)property.GetValue(null, null));

            List<ColorInfo> colorlist = color_query.ToList<ColorInfo>();

            return colorlist[male].Color;
        }
    }
}
