#pragma checksum "..\..\MultiRecordDataEntry.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EDB194ED78655268F9B627D39FBABFB1"
//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.239
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

using Petzold.SingleRecordDataEntry;
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


namespace Petzold.MultiRecordDataEntry {
    
    
    /// <summary>
    /// MultiRecordDataEntry
    /// </summary>
    public partial class MultiRecordDataEntry : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\MultiRecordDataEntry.xaml"
        internal System.Windows.Controls.DockPanel dock;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\MultiRecordDataEntry.xaml"
        internal Petzold.SingleRecordDataEntry.PersonPanel pnlPerson;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\MultiRecordDataEntry.xaml"
        internal System.Windows.Controls.Button btnFirst;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\MultiRecordDataEntry.xaml"
        internal System.Windows.Controls.Button btnPrev;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\MultiRecordDataEntry.xaml"
        internal System.Windows.Controls.Button btnNext;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\MultiRecordDataEntry.xaml"
        internal System.Windows.Controls.Button btnLast;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\MultiRecordDataEntry.xaml"
        internal System.Windows.Controls.Button btnAdd;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\MultiRecordDataEntry.xaml"
        internal System.Windows.Controls.Button btnDel;
        
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
            System.Uri resourceLocater = new System.Uri("/MultiRecordDataEntry;component/multirecorddataentry.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MultiRecordDataEntry.xaml"
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
            this.dock = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 2:
            this.pnlPerson = ((Petzold.SingleRecordDataEntry.PersonPanel)(target));
            return;
            case 3:
            this.btnFirst = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\MultiRecordDataEntry.xaml"
            this.btnFirst.Click += new System.Windows.RoutedEventHandler(this.FirstOnClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnPrev = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\MultiRecordDataEntry.xaml"
            this.btnPrev.Click += new System.Windows.RoutedEventHandler(this.PrevOnClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnNext = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\MultiRecordDataEntry.xaml"
            this.btnNext.Click += new System.Windows.RoutedEventHandler(this.NextOnClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnLast = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\MultiRecordDataEntry.xaml"
            this.btnLast.Click += new System.Windows.RoutedEventHandler(this.LastOnClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\MultiRecordDataEntry.xaml"
            this.btnAdd.Click += new System.Windows.RoutedEventHandler(this.AddOnClick);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnDel = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\MultiRecordDataEntry.xaml"
            this.btnDel.Click += new System.Windows.RoutedEventHandler(this.DelOnClick);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 42 "..\..\MultiRecordDataEntry.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.NewOnExecuted);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 43 "..\..\MultiRecordDataEntry.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.OpenOnExecuted);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 44 "..\..\MultiRecordDataEntry.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.SaveOnExecuted);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

