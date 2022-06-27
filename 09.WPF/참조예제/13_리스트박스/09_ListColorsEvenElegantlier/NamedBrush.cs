using System;
using System.Reflection;
using System.Windows.Media;

namespace Petzold.ListNamedBrushes
{
    public class NamedBrush
    {
        static NamedBrush[] nbrushes;
        Brush brush;
        string str;

        //static ������..
        static NamedBrush()
        {
            PropertyInfo[] props = typeof(Brushes).GetProperties();
            nbrushes = new NamedBrush[props.Length];

            for (int i = 0; i < props.Length; i++)
                nbrushes[i] = new NamedBrush(props[i].Name, (Brush)props[i].GetValue(null, null));
        }

        //Praivate ������..
        private NamedBrush(string str, Brush brush)
        {
            this.str = str;
            this.brush = brush;
        }
        //static �б� ���� ������Ƽ....
        public static NamedBrush[] All
        {
            get { return nbrushes; }
        }

        //�б� ���� ������Ƣ...
        public Brush Brush
        {
            get { return brush; }
        }
        public string Name
        {
            get
            {
                string strSpaced = str[0].ToString();

                for (int i = 1; i < str.Length; i++)
                    strSpaced += (char.IsUpper(str[i]) ? " " : "") +
                                            str[i].ToString();
                return strSpaced;
            }
        }

        //ToString �޼ҵ� �������̵�...
        public override string ToString()
        {
            return str;
        }
    }
}
