// Updated by XamlIntelliSenseFileGenerator 14.06.2020 4:30:27
#pragma checksum "..\..\..\ManagementCompanyWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7E950C71647E997F9BAA6500A36D44E35D77EF2F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ServiceForWorkingWithApartmentBuildingClient;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace ServiceForWorkingWithApartmentBuildingClient
{


    /// <summary>
    /// ManagementCompanyWindow
    /// </summary>
    public partial class ManagementCompanyWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ServiceForWorkingWithApartmentBuildingClient;V1.0.0.0;component/managementcompan" +
                    "ywindow.xaml", System.UriKind.Relative);

#line 1 "..\..\..\ManagementCompanyWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.TextBlock lblName;
        internal System.Windows.Controls.TextBlock lblInfo;
        internal System.Windows.Controls.StackPanel stpPolls;
        internal System.Windows.Controls.StackPanel stpPool0;
        internal System.Windows.Controls.StackPanel stpGetPoll0;
        internal System.Windows.Controls.TextBlock tblNameOfPool0;
        internal System.Windows.Controls.Button btnGetPoll0;
        internal System.Windows.Controls.Grid grAnswerOptionsOfPool0;
        internal System.Windows.Controls.ComboBox cmbBuildingAddressesForCreaatePoll;
        internal System.Windows.Controls.TextBox tbPollQuestionForCreatePoll;
        internal System.Windows.Controls.Button btnDelAnswerOption;
        internal System.Windows.Controls.Button btnAddAnswerOption;
        internal System.Windows.Controls.StackPanel stpAnswerOptions;
        internal System.Windows.Controls.TextBox answer0;
        internal System.Windows.Controls.Button btnCreatePoll;
        internal System.Windows.Controls.Label lblCreatePollState;
        internal System.Windows.Controls.ComboBox cmbBuildingAddressesForCreateAnnouncement;
        internal System.Windows.Controls.TextBox tbAnnouncementTitleForCreateAnnouncement;
        internal System.Windows.Controls.TextBox tbAnnouncementContentForCreateAnnouncement;
        internal System.Windows.Controls.Button btnCreateNewAnnouncement;
        internal System.Windows.Controls.Label lblCreateAnnouncementState;
        internal System.Windows.Controls.TextBox tbBuildingAddressForCreateBuildin;
        internal System.Windows.Controls.Button btnCreateBuilding;
        internal System.Windows.Controls.Label lblCreateBuildingState;
    }
}

