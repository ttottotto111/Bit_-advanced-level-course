using _1125_Client.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1125_Client
{
    public partial class Form1 : Form, ICalculatorDuplexCallback
    {
        private CalculatorDuplexClient proxy;

        public Form1()
        {
            InitializeComponent();

            //이중계약 계약 객체 생성
            proxy = new CalculatorDuplexClient(new InstanceContext(this));
        }

        #region 서비스에 의해 호출되는 콜백 함수들
        public IAsyncResult BeginEquation(string eqn, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginResult(double result, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndEquation(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public void EndResult(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public void Equation(string eqn)
        {
            label2.Text = eqn;
        }

        public void Result([MessageParameter(Name = "result")] double result1)
        {
            textBox2.Text = result1.ToString();
        }
        #endregion

        //동기
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double num1 = double.Parse(textBox1.Text);

                switch (comboBox1.SelectedIndex)
                {
                    case 0: proxy.AddTo(num1);          break;
                    case 1: proxy.SubtractFrom(num1);   break;
                    case 2: proxy.MultiplyBy(num1);     break;
                    case 3: proxy.DivideBy(num1);       break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //초기화
        private void button3_Click(object sender, EventArgs e)
        {
            proxy.Clear();
        }
    }
}
