﻿#pragma checksum "..\..\DatePicker.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "701CA2416D0F9961E0BD4BC586EDE098"
//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.225
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Globalization;
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


namespace Petzold.CreateDatePicker {
    
    
    /// <summary>
    /// DatePicker
    /// </summary>
    public partial class DatePicker : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 85 "..\..\DatePicker.xaml"
        internal System.Windows.Controls.TextBlock txtblkMonthYear;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\DatePicker.xaml"
        internal System.Windows.Controls.ListBox lstboxMonth;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\DatePicker.xaml"
        internal System.Windows.Controls.CheckBox chkboxNull;
        
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
            System.Uri resourceLocater = new System.Uri("/DataEntryWithNavigation;component/datepicker.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\DatePicker.xaml"
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
            
            #line 84 "..\..\DatePicker.xaml"
            ((System.Windows.Controls.Primitives.RepeatButton)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonBackOnClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtblkMonthYear = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            
            #line 89 "..\..\DatePicker.xaml"
            ((System.Windows.Controls.Primitives.RepeatButton)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonForwardOnClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lstboxMonth = ((System.Windows.Controls.ListBox)(target));
            
            #line 110 "..\..\DatePicker.xaml"
            this.lstboxMonth.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListBoxOnSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.chkboxNull = ((System.Windows.Controls.CheckBox)(target));
            
            #line 128 "..\..\DatePicker.xaml"
            this.chkboxNull.Checked += new System.Windows.RoutedEventHandler(this.CheckBoxNullOnChecked);
            
            #line default
            #line hidden
            
            #line 129 "..\..\DatePicker.xaml"
            this.chkboxNull.Unchecked += new System.Windows.RoutedEventHandler(this.CheckBoxNullOnUnchecked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

