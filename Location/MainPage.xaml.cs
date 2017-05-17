using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.System;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Location
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            EnableBackButtonOnTitleBar((sender, args) =>
            {
                TxtMessage.Text += DateTime.Now + Environment.NewLine;
                ToastNotify.ShowToastNotification("MSFT.jpg","You have a message",NotificationAudioNames.Default);
            });
            CustomTitleBar();
        }


        void EnableBackButtonOnTitleBar(EventHandler<BackRequestedEventArgs> onBackRequested)
        {
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            currentView.BackRequested += onBackRequested;
        }

        void ApplyColorToTitleBar()
        {
            var view = ApplicationView.GetForCurrentView();

            // active
            view.TitleBar.BackgroundColor = Colors.DarkBlue;
            view.TitleBar.ForegroundColor = Colors.White;

            // inactive
            view.TitleBar.InactiveBackgroundColor = Colors.LightGray;
            view.TitleBar.InactiveForegroundColor = Colors.Gray;

            // button
            view.TitleBar.ButtonBackgroundColor = Colors.DodgerBlue;
            view.TitleBar.ButtonForegroundColor = Colors.White;

            view.TitleBar.ButtonHoverBackgroundColor = Colors.LightSkyBlue;
            view.TitleBar.ButtonHoverForegroundColor = Colors.White;

            view.TitleBar.ButtonPressedBackgroundColor = Color.FromArgb(255, 0, 0, 120);
            view.TitleBar.ButtonPressedForegroundColor = Colors.White;

            view.TitleBar.ButtonInactiveBackgroundColor = Colors.DarkGray;
            view.TitleBar.ButtonInactiveForegroundColor = Colors.Gray;
        }

        void CustomTitleBar()
        {
            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
            Window.Current.SetTitleBar(GridTitleBar);

            var view = ApplicationView.GetForCurrentView();
            view.TitleBar.ButtonBackgroundColor = Colors.SteelBlue;
            view.TitleBar.ButtonForegroundColor = Colors.White;

            view.TitleBar.ButtonHoverBackgroundColor = Color.FromArgb(255, 92, 157, 211);
            view.TitleBar.ButtonHoverForegroundColor = Colors.White;

            view.TitleBar.ButtonPressedBackgroundColor = Color.FromArgb(255, 92, 157, 211);
            view.TitleBar.ButtonPressedForegroundColor = Colors.White;

            view.TitleBar.ButtonInactiveBackgroundColor = Color.FromArgb(129, 70, 130, 180);
            view.TitleBar.ButtonInactiveForegroundColor = Colors.WhiteSmoke;

            Window.Current.Activated += (sender, args) =>
            {
                if (args.WindowActivationState != CoreWindowActivationState.Deactivated)
                {
                    GridTitleBar.Opacity = 1;
                    TxtSearchBox.Opacity = 1;
                }
                else
                {
                    GridTitleBar.Opacity = 0.5;
                    TxtSearchBox.Opacity = 0.5;
                }
            };
        }

        private  async void Button_Click(object sender, RoutedEventArgs e)
        {
            var rmbp = await ImageOperation.LoadWriteableBitmap("Assets/MSFT.jpg");
            await rmbp.SaveToPngImage(PickerLocationId.PicturesLibrary, "testSaveMethod");
        }

        private async void Button_Click_PDF(object sender, RoutedEventArgs e)
        {

            //var optionsL = new LauncherOptions() { ContentType = "application/pdf", DisplayApplicationPicker = true };

            //await Launcher.LaunchUriAsync(new Uri("http://bitcoin.org/bitcoin.pdf"), optionsL);


            FileOpenPicker folderfile = new FileOpenPicker();
            folderfile.SuggestedStartLocation = PickerLocationId.Downloads;
            folderfile.FileTypeFilter.Add(".pdf");
            StorageFile file = await folderfile.PickSingleFileAsync();
            // Path to the file in the app package to launch
            //string imageFile = @"Files\Readme.pdf";

            // Get the image file from the package's image directory
            //var file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(imageFile);

            if (file != null)
            {
                // Set the recommended app
                var options = new Windows.System.LauncherOptions();
                options.PreferredApplicationPackageFamilyName = "Contoso.FileApp_8wknc82po1e";
                options.PreferredApplicationDisplayName = "Contoso File App";

                //file or uri

                // Launch the retrieved file pass in the recommended app 
                // in case the user has no apps installed to handle the file
                bool success = await Windows.System.Launcher.LaunchFileAsync(file, options);
                if (success)
                {
                    // File launched
                }
                else
                {
                    // File launch failed
                }
            }
            else
            {
                // Could not find file
            }

            //StorageFile file = await Package.Current.InstalledLocation.GetFileAsync("Assets\\Readme.pdf");
            //var storageFile = await Package.Current.InstalledLocation.GetFileAsync("Assets//MSFT.jpg");

            //string path = storageFile.Path;
            //string slash = path.Replace("\\", "//");
            //// The URI to launch
            ////var uriBing = new Uri(@"http://www.bing.com");
            //string httpString = "http:" + path;
            //var uriBing = new Uri(slash);
            ////var uriBing = new Uri(@"mailto:lvmcinsight@hotmail.com");
            //// Launch the URI
            ////ms-appx:///images/icon.png
            //Windows.System.LauncherOptions options = new Windows.System.LauncherOptions();
            //options.ContentType = "application/pdf";
            //var success = await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-appx:///Assets\\Readme.pdf"), options);
            ////var success = await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-appx:///Assets/MSFT.jpg"));
            //if (success)
            //{
            //    // URI launched
            //}
            //else
            //{
            //    // URI launch failed
            //}



        }
    }

    // webclient to obtain the location and weather information
    // structure to store the current information
    // time-elpsed graph about the weather for the selected location
    //      graph lib
    // adptive UI
}
