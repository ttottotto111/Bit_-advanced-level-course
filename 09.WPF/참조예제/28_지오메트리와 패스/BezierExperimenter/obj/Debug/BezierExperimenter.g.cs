﻿#pragma checksum "..\..\BezierExperimenter.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "58CE946924BE55A4784C8602753068E9"
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


namespace Petzold.BezierExperimenter {
    
    
    /// <summary>
    /// BezierExperimenter
    /// </summary>
    public partial class BezierExperimenter : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\BezierExperimenter.xaml"
        internal System.Windows.Controls.Canvas canvas;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\BezierExperimenter.xaml"
        internal System.Windows.Media.EllipseGeometry ptStart;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\BezierExperimenter.xaml"
        internal System.Windows.Media.EllipseGeometry ptCtrl1;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\BezierExperimenter.xaml"
        internal System.Windows.Media.EllipseGeometry ptCtrl2;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\BezierExperimenter.xaml"
        internal System.Windows.Media.EllipseGeometry ptEnd;
        
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
            System.Uri resourceLocater = new System.Uri("/BezierExperimenter;component/bezierexperimenter.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\BezierExperimenter.xaml"
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
            this.canvas = ((System.Windows.Controls.Canvas)(target));
            return;
            case 2:
            this.ptStart = ((System.Windows.Media.EllipseGeometry)(target));
            return;
            case 3:
            this.ptCtrl1 = ((System.Windows.Media.EllipseGeometry)(target));
            return;
            case 4:
            this.ptCtrl2 = ((System.Windows.Media.EllipseGeometry)(target));
            return;
            case 5:
            this.ptEnd = ((System.Windows.Media.EllipseGeometry)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

