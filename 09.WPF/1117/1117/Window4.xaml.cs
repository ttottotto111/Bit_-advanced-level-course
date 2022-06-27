using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _1117
{
    /// <summary>
    /// Window4.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Window4 : Window
    {
        //People people = new People();  //Xaml의 Windows.Resource 이동(1/2)

        public Window4()
        {
            InitializeComponent();

            //Binding처리[컬렉션 데이터와 컨트롤과의 바인딩]
            //- 컬렉션의 첫번째 Person객체와 컨트롤의 속성이 연결된다.
            //  cur 개념이 있다....
            //panel.DataContext = people;   //Xaml의 Panel로 이동(2/2)
        }
        private void eraseButton_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view =
                    CollectionViewSource.GetDefaultView(FindResource("people"));
            Person person = (Person)view.CurrentItem;
            
            person.Name = "";
            person.Phone = "";
            person.Male = null;            person.Age = null;
        }

        private void prev_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view =
                CollectionViewSource.GetDefaultView(FindResource("people"));
            view.MoveCurrentToPrevious();
            if (view.IsCurrentBeforeFirst)
            {
                view.MoveCurrentToFirst();
            }
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view =
                 CollectionViewSource.GetDefaultView(FindResource("people"));
            view.MoveCurrentToNext();
            if (view.IsCurrentAfterLast)
            {
                view.MoveCurrentToLast();
            }
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            People people = (People)FindResource("people");

            //컬렉션 데이터를 삭제 -> ListBox 화면 갱신
            //ListBox갱신을 위해서 컬렉션 클래스 부모를 변경 처리 함
            if (listbox.SelectedIndex >= 0)
                people.RemoveAt(listbox.SelectedIndex);
        }
    }
}
