﻿#pragma checksum "..\..\..\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5C385DA54BED69121A9D012A3601B1D9"
//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.239
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WPF그림판 {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 5 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Grid MainGrid;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Button OpenBtn;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Button SaveBtn;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Label label2;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Label label_Shape;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Label label_Color;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.GroupBox groupBox1;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.RadioButton radioBtn_Circle;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.RadioButton radioBtn_Rect;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.RadioButton radioBtn_Free;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.RadioButton radioBtn_Erase;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Border border1;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.InkCanvas inkCanvas;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Label label_Point;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Button btn_Clear;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Button btn_Select;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WPF그림판;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.MainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.OpenBtn = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\MainWindow.xaml"
            this.OpenBtn.Click += new System.Windows.RoutedEventHandler(this.OpenBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.SaveBtn = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\MainWindow.xaml"
            this.SaveBtn.Click += new System.Windows.RoutedEventHandler(this.SaveBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.label2 = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.label_Shape = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.label_Color = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.groupBox1 = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 9:
            this.radioBtn_Circle = ((System.Windows.Controls.RadioButton)(target));
            
            #line 30 "..\..\..\MainWindow.xaml"
            this.radioBtn_Circle.Click += new System.Windows.RoutedEventHandler(this.radioButton_Click);
            
            #line default
            #line hidden
            
            #line 30 "..\..\..\MainWindow.xaml"
            this.radioBtn_Circle.Checked += new System.Windows.RoutedEventHandler(this.radioBtn_Circle_Checked);
            
            #line default
            #line hidden
            return;
            case 10:
            this.radioBtn_Rect = ((System.Windows.Controls.RadioButton)(target));
            
            #line 31 "..\..\..\MainWindow.xaml"
            this.radioBtn_Rect.Click += new System.Windows.RoutedEventHandler(this.radioButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.radioBtn_Free = ((System.Windows.Controls.RadioButton)(target));
            
            #line 32 "..\..\..\MainWindow.xaml"
            this.radioBtn_Free.Click += new System.Windows.RoutedEventHandler(this.radioButton_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.radioBtn_Erase = ((System.Windows.Controls.RadioButton)(target));
            
            #line 33 "..\..\..\MainWindow.xaml"
            this.radioBtn_Erase.Click += new System.Windows.RoutedEventHandler(this.radioButton_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.border1 = ((System.Windows.Controls.Border)(target));
            return;
            case 14:
            this.inkCanvas = ((System.Windows.Controls.InkCanvas)(target));
            return;
            case 15:
            this.label_Point = ((System.Windows.Controls.Label)(target));
            return;
            case 16:
            this.btn_Clear = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\MainWindow.xaml"
            this.btn_Clear.Click += new System.Windows.RoutedEventHandler(this.btn_Clear_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            this.btn_Select = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

