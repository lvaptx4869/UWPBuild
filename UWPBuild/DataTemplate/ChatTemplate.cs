using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWPBuild
{
    //ViewModel message
    public abstract class MessageBase
    {
        public string Name { get; set; }

        public DateTime Published { get; set; }
    }

    public class Message : MessageBase
    {
        public string Comment { get; set; }

        public bool IsSelf { get; set; }
    }

    public class Gift : Message
    {
        public int Amount { get; set; }
    }

    //DataTemplate in xaml

    public class MessageItemDataTemplateSelector: DataTemplateSelector
    {
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item is Gift)
            {
                return App.Current.Resources["GiftDataTemplate"] as DataTemplate;
            }
            else if (item is Message)
            {
                if ((item as Message).IsSelf)
                {
                    return App.Current.Resources["SelfMessageDataTemplate"] as DataTemplate;
                }
                else
                {
                    return App.Current.Resources["MessageDataTemplate"] as DataTemplate;
                }
            }
            return base.SelectTemplateCore(item);
        }
    }

    //window
    public class ChatWindowViewModel
    {
        public List<MessageBase> MessageList { get; set; }

        public ChatWindowViewModel()
        {
            InitSampleData();
        }

        private void InitSampleData()
        {
            MessageList = new List<MessageBase>
            {
                new Message
                {
                    Comment = "Hello this is UWP test", Name="Lvmc" ,Published = DateTime.Now
                },
                new Message
                {
                    Comment = "How about the Windows 10?", IsSelf = true, Name="Myself",Published = DateTime.Now
                },
                new Gift
                {
                    Amount = 100, Comment = "Happy birthday", Name="Lvmc",Published = DateTime.Now
                },
                new Message
                {
                    Comment = "Thanks!", IsSelf = true, Name="Myself",Published = DateTime.Now
                }
            };
        }
    }

}
