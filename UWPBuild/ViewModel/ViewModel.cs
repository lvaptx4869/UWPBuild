﻿using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Pickers;
using Windows.Storage.Provider;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Imaging;

namespace UWPBuild.Views
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public List<string> EccModes
        {
            get
            {
                return Enum.GetValues(typeof(QRCodeGenerator.ECCLevel)).Cast<Enum>().Select(x => x.ToString()).ToList();
            }
        }

        //private string _selectedEcc;
        //public string SelectedEcc
        //{
        //    get { return _selectedEcc; }
        //    set
        //    {
        //        _selectedEcc = value;
        //        RaisePropertyChanged();
        //    }
        //}

        //private string _sourceText;
        //public string SourceText
        //{
        //    get { return _sourceText; }
        //    set
        //    {
        //        _sourceText = value;
        //        RaisePropertyChanged();
        //    }
        //}
        //private WriteableBitmap _bitmap;
        //public WriteableBitmap Bitmap
        //{
        //    get { return _bitmap; }
        //    set
        //    {
        //        _bitmap = value;
        //        RaisePropertyChanged();
        //    }
        //}

        //public async Task GetQrCode()
        //{
        //    var level = SelectedEcc;
        //    var eccLevel = (QRCodeGenerator.ECCLevel)(level == "L" ? 0 : level == "M" ? 1 : level == "Q" ? 2 : 3);
        //    var qrGenerator = new QRCodeGenerator();
        //    var qrCodeData = qrGenerator.CreateQrCode(SourceText, eccLevel);
        //    var qrCode = new BitmapByteQRCode(qrCodeData);
        //    var qrCodeImage = qrCode.GetGraphic(20);

        //    using (var stream = new InMemoryRandomAccessStream())
        //    {
        //        using (var writer = new DataWriter(stream.GetOutputStreamAt(0)))
        //        {
        //            writer.WriteBytes(qrCodeImage);
        //            await writer.StoreAsync();
        //        }
        //        Bitmap = new WriteableBitmap(1024, 1024);
        //        await Bitmap.SetSourceAsync(stream);
        //    }
        //}



        //public async Task SaveToPic()
        //{
        //    try
        //    {
        //        var fileName = $"QRCODE_{DateTime.Now:yyyy-MM-dd-HHmmss}";
        //        var result = await Bitmap.SaveToPngImage(PickerLocationId.PicturesLibrary, fileName);
        //        if (result != FileUpdateStatus.Complete)
        //        {
        //            var dig = new MessageDialog($"{result}", "FAIL");
        //            await dig.ShowAsync();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        var dig = new MessageDialog($"{ex.Message}", "FAIL");
        //        await dig.ShowAsync();
        //    }
        //}
    }


}
