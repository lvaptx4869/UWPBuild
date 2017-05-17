using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI.Notifications;

namespace Location
{
    ////
    //// Summary:
    ////     指定要在消息通知中使用的模版。
    //[ContractVersion(typeof(UniversalApiContract), 65536)]
    //public enum ToastTemplateType
    //{
    //    //
    //    // Summary:
    //    //     在三行文本中被包装的大型图像和单个字符串。
    //    ToastImageAndText01 = 0,
    //    //
    //    // Summary:
    //    //     大图像、加粗文本的一个字符串在第一行、常规文本的一个字符串包装在第二、三行中。
    //    ToastImageAndText02 = 1,
    //    //
    //    // Summary:
    //    //     大图像、加粗文本的一个字符串被包装在开头两行中、常规文本的一个字符串包装在第三行中。
    //    ToastImageAndText03 = 2,
    //    //
    //    // Summary:
    //    //     大图像、加粗文本的一个字符串在第一行、常规文本的一个字符串在第二行中、常规文本的一个字符串在第三行中。
    //    ToastImageAndText04 = 3,
    //    //
    //    // Summary:
    //    //     包装在三行文本中的单个字符串。
    //    ToastText01 = 4,
    //    //
    //    // Summary:
    //    //     第一行中加粗文本的一个字符串、覆盖第二行和第三行的常规文本的一个字符串。
    //    ToastText02 = 5,
    //    //
    //    // Summary:
    //    //     覆盖第一行和第二行的加粗文本的一个字符串。第三行中常规文本的一个字符串。
    //    ToastText03 = 6,
    //    //
    //    // Summary:
    //    //     第一行中加粗文本的一个字符串、第二行中常规文本的一个字符串、第三行中常规文本的一个字符串。
    //    ToastText04 = 7
    //}

    public enum NotificationAudioNames
    {
        Default,
        IM,
        Mail,
        Reminder,
        SMS,
        Looping_Alarm,
        Looping_Alarm2,
        Looping_Alarm3,
        Looping_Alarm4,
        Looping_Alarm5,
        Looping_Alarm6,
        Looping_Alarm7,
        Looping_Alarm8,
        Looping_Alarm9,
        Looping_Alarm10,
        Looping_Call,
        Looping_Call2,
        Looping_Call3,
        Looping_Call4,
        Looping_Call5,
        Looping_Call6,
        Looping_Call7,
        Looping_Call8,
        Looping_Call9,
        Looping_Call10,
    }

    public class ToastNotify
    {
        public static void ShowToastNotification(string assetsImageFileName, string text, NotificationAudioNames audioName)
        {
            // 1. create element
            ToastTemplateType toastTemplate = ToastTemplateType.ToastImageAndText01;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);

            // 2. provide text
            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");
            toastTextElements[0].AppendChild(toastXml.CreateTextNode(text));

            // 3. provide image
            XmlNodeList toastImageAttributes = toastXml.GetElementsByTagName("image");
            ((XmlElement)toastImageAttributes[0]).SetAttribute("src", $"ms-appx:///assets/{assetsImageFileName}");
            ((XmlElement)toastImageAttributes[0]).SetAttribute("alt", "logo");

            // 4. duration
            IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            ((XmlElement)toastNode).SetAttribute("duration", "short");

            // 5. audio
            XmlElement audio = toastXml.CreateElement("audio");
            audio.SetAttribute("src", $"ms-winsoundevent:Notification.{audioName.ToString().Replace("_", ".")}");
            toastNode.AppendChild(audio);

            // 6. app launch parameter
            //((XmlElement)toastNode).SetAttribute("launch", "{\"type\":\"toast\",\"param1\":\"12345\",\"param2\":\"67890\"}");

            // 7. send toast
            ToastNotification toast = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
    }
}
