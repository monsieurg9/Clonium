﻿#pragma checksum "..\..\Сhip.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8B0A85E2A6941510D3493D54C426BA1876AF21EB"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Clonium.UI;
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
using System.Windows.Shell;


namespace Clonium.UI {
    
    
    /// <summary>
    /// Сhip
    /// </summary>
    public partial class Сhip : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\Сhip.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Clonium.UI.Сhip ChipControl;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\Сhip.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ChipBack;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Сhip.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse Point1;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Сhip.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse Point2;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Сhip.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse Point3;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Clonium.UI;component/%d0%a1hip.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Сhip.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ChipControl = ((Clonium.UI.Сhip)(target));
            
            #line 8 "..\..\Сhip.xaml"
            this.ChipControl.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ChipControl_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ChipBack = ((System.Windows.Controls.Grid)(target));
            
            #line 11 "..\..\Сhip.xaml"
            this.ChipBack.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ChipBack_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Point1 = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 4:
            this.Point2 = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 5:
            this.Point3 = ((System.Windows.Shapes.Ellipse)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

