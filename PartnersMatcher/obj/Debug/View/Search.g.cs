﻿#pragma checksum "..\..\..\View\Search.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5C93D35E65718BB4E87D446715428EFA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PartnersMatcher.View;
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


namespace PartnersMatcher.View {
    
    
    /// <summary>
    /// Search
    /// </summary>
    public partial class Search : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\View\Search.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox categories;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\View\Search.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox city;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\View\Search.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button start;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\View\Search.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox results;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\View\Search.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tb_hello;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\View\Search.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button request;
        
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
            System.Uri resourceLocater = new System.Uri("/PartnersMatcher;component/view/search.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\Search.xaml"
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
            this.categories = ((System.Windows.Controls.ComboBox)(target));
            
            #line 27 "..\..\..\View\Search.xaml"
            this.categories.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.category_changed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.city = ((System.Windows.Controls.ComboBox)(target));
            
            #line 29 "..\..\..\View\Search.xaml"
            this.city.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.category_changed);
            
            #line default
            #line hidden
            return;
            case 3:
            this.start = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\View\Search.xaml"
            this.start.Click += new System.Windows.RoutedEventHandler(this.search);
            
            #line default
            #line hidden
            return;
            case 4:
            this.results = ((System.Windows.Controls.ListBox)(target));
            return;
            case 5:
            this.tb_hello = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.request = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\View\Search.xaml"
            this.request.Click += new System.Windows.RoutedEventHandler(this.request_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

