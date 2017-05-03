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
        public static class CustomDataTemplateSelector
        {
            public static DataTemplate GetTemplate(ViewModelBase param)
            {
                Type t = param.GetType();
                return App.Current.Resources[t.Name] as DataTemplate;
            }
        }

        public static class DeviceIdentification
        {
            public static string GetDeviceFamily()
            {
                // if(deviceString.Equals("Windows.Desktop"))

                //else if(deviceString.Equals("Windows.Mobile")
                return Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily;
            }
        }
    }
}
