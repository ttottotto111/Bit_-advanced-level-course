using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace _1117
{
    class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Name"));
            }
        }

        private string phone;
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Phone"));
            }
        }

        private int? age;
        public int? Age
        {
            get { return age; }
            set
            {
                age = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Age"));
            }
        }

        private bool? male;
        public bool? Male
        {
            get { return male; }
            set
            {
                male = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Male"));
            }
        }

        public override string ToString()
        {
            string sex;
            if (Male == null)                sex = "남/여";
            else if (Male == true)           sex = "남";
            else                             sex = "여";

            return string.Format("이름:{0}, 전화:{1}, 성별:{2}, 나이:{3}",
                    Name, Phone, sex, Age);
        }
    }

    //형식 변환기 : data [T -> F]  여자 라디오버튼
    [ValueConversion(/* 원본 형식 */ typeof(bool), /* 대상 형식 */ typeof(bool))]
    public class MaleToFemaleConverter : IValueConverter
    {
        // 데이터 속성을 UI 속성으로 변경할 때
        public object Convert(object value, Type targetType, object parameter,
       System.Globalization.CultureInfo culture)
        {
            //타입 체크 
            if (targetType != typeof(bool?))
                return null;

            //value : 데이터의 속성값
            bool? male = (bool?)value;
            if (male == null)
                return null;
            else
                return !(bool?)value;  //토글리턴[UI속성으로 전달]
        }
       
        // UI 속성을 데이터 속성으로 변경할 때
        public object ConvertBack(object value, Type targetType, object
       parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(bool?))
                return null;

            //value : UI의 value[라디오버튼의 IsChecked]
            bool? male = (bool?)value;
            if (male == null)
                return null;
            else
                return !(bool?)value;  //토글후 리턴(Data의 Male속성전달)
        }
    }


    //형식 변환기 : data(bool) True->"남자" 라벨컨트롤(string)
    [ValueConversion(/* 원본 형식 */ typeof(bool), /* 대상 형식 */ typeof(string))]
    public class MaleToStringConverter : IValueConverter
    {
        // 데이터 속성을 UI 속성으로 변경할 때
        public object Convert(object value, Type targetType, object parameter,
       System.Globalization.CultureInfo culture)
        {
            //value : 데이터의 속성값
            bool? male = (bool?)value;
            if (male == null)
                return null;
            else
            {
                if (male == true)
                    return "남자";
                else
                    return "여자";//토글리턴[UI속성으로 전달]
            }
        }

        // UI 속성을 데이터 속성으로 변경할 때
        public object ConvertBack(object value, Type targetType, object
       parameter, System.Globalization.CultureInfo culture)
        {
            //value : UI의 value[라디오버튼의 IsChecked]
            string male = (string)value;
            if (male == null)
                return null;
            else
            {
                if (male.Equals("남자"))
                    return true;
                else
                    return false;
            }
        }
    }


    //예외처리 클래스
    public class AgeValidationRule : ValidationRule
    {
        public int Min { get; set; }
        public int Max { get; set; }
       
        public override ValidationResult Validate(object value,
                    System.Globalization.CultureInfo cultureInfo)
        {
            int number;
            if (!int.TryParse((string)value, out number))
            {
                return new ValidationResult(false, "정수를 입력하세요.");
            }
            if (Min <= number && number <= Max)
            {
                // new ValidationResult(true, null) 같다
                return ValidationResult.ValidResult;
            }
            else
            {
                string msg =
               string.Format("나이는 {0}에서 {1}까지 입력 가능합니다.", Min, Max);
                return new ValidationResult(false, msg);
            }
        }
    }
    
    class People : ObservableCollection<Person>
    {
        public People()
        {
            Add(new Person() { Name = "홍길동", Phone = "010-1111-1111", Age = 10, Male=true });
            Add(new Person() { Name = "일지매", Phone = "010-2222-2222", Age = 20, Male=false });
            Add(new Person() { Name = "임꺽정", Phone = "010-3333-3333", Age = 30, Male=true });
        }  
    }

}
