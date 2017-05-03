using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWPBuild
{
    public sealed class DataTemplateLvmc : DataTemplateSelector
    {
        public DataTemplate CollectionTemplate { get; set; }
        public DataTemplate ThreadTemplate { get; set; }
        public DataTemplate MuscicTemplate { get; set; }
        public DataTemplate VideoTemplate { get; set; }
        public DataTemplate TcTemplate { get; set; }
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            RecList list = item as RecList;
            if (list != null)
            {
                switch (list.type)
                {
                    case RecList.Type.collection:
                        return CollectionTemplate;
                    case RecList.Type.music:
                        return MuscicTemplate;
                    case RecList.Type.video:
                        return VideoTemplate;
                    case RecList.Type.movelines:
                        return TcTemplate;
                    default:
                        return ThreadTemplate;
                }
            }
            return null;
        }
    }

    public class RecList
    {
        public Type type;
        public enum Type
        {
            collection,
            video,
            music,
            movelines
        }
    }

}
