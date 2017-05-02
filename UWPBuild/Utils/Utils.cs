using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace UWPBuild.Utils
{
    public class Utility
    {
        public static class DataTemplateSelector
        {
            public static DataTemplate GetTemplate(ViewModelBase param)
            {
                Type t = param.GetType();
                return App.Current.Resources[t.Name] as DataTemplate;
            }
        }
    }
}
