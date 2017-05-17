using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Edi.UWP.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Location
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ReportView : Page
    {
        public ReportView()
        {
            this.InitializeComponent();
        }
    }

    public class ReportErrorViewModel : ViewModelBase
    {
        private bool _includeDeviceInfo;
        private string _viewName;
        private string _pageSummary;
        private string _message;

        public bool IncludeDeviceInfo
        {
            get { return _includeDeviceInfo; }
            set { _includeDeviceInfo = value; RaisePropertyChanged(); }
        }

        public string ViewName
        {
            get { return _viewName; }
            set { _viewName = value; RaisePropertyChanged(); }
        }

        public string PageSummary
        {
            get { return _pageSummary; }
            set { _pageSummary = value; RaisePropertyChanged(); }
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; RaisePropertyChanged(); }
        }

        public RelayCommand CommandReportError { get; set; }

        public ReportErrorViewModel()
        {
            IncludeDeviceInfo = true;
            CommandReportError = new RelayCommand(async () => await ReportError());
        }

        public void InitData(ReportErrorModel model)
        {
            ViewName = model.ViewName;
            PageSummary = model.PageSummary;
        }

        private async Task ReportError()
        {
            await Helper.ReportError(ViewName, Message, PageSummary, IncludeDeviceInfo);
        }
    }
}
