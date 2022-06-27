using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _1116
{
    class MyApp : Application
    {
        public void MyApp_StartingUp(object sender,StartupEventArgs e)
        {
            Window window = new Window();
            window.Show();
        }
    }
}
