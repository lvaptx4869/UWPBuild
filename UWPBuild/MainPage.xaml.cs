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
using UWPBuild.Utils;
using System.ComponentModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPBuild
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = new ChatWindowViewModel();
        }
        //public ViewModelBase currentViewModel = new ViewModelBase();

        //public event PropertyChangedEventHandler PropertyChanged;

        //public void RaisePropertyChanged(string propertyName)
        //{
        //    if (this.PropertyChanged != null)
        //    {
        //        this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}

        //public ViewModelBase CurrentViewModel
        //{
        //    get
        //    {
        //        return currentViewModel;
        //    }
        //    set
        //    {
        //        if (currentViewModel == value)
        //        {
        //            return;

        //        }
        //        currentViewModel = value;
        //        RaisePropertyChanged(() => CurrentViewModel);
        //        RaisePropertyChanged(() => CurrentTemplate);
        //    }
        //}


        //public DataTemplate CurrentTemplate
        //{
        //    get
        //    {
        //        if (CurrentViewModel == null)
        //        {
        //            return null;
        //        }

        //        return Utility.DataTemplateSelector.GetTemplate(CurrentViewModel);
        //    }
        //}

        //public static class DataTemplateSelector
        //{
        //    public static DataTemplate GetTemplate(ViewModelBase param)
        //    {
        //        Type t = param.GetType();
        //        return App.Current.Resources[t.Name] as DataTemplate;
        //    }
        //}
    }
}
