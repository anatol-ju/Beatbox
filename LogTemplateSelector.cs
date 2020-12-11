using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Beatbox
{
    class LogTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            //var myObj = item as MyObject;
            FrameworkElement element = container as FrameworkElement;
            if (item != null && container != null)
            {
                if (item is string || item is int)
                {
                    return element.FindResource("StringTemplate") as DataTemplate;
                }
                if (item is Image)
                {
                    return element.FindResource("ImageTemplate") as DataTemplate;
                }
                if (item is Milestone)
                {
                    return element.FindResource("MilestoneTemplate") as DataTemplate;
                }
                else
                {
                    return item as DataTemplate;
                }
            }

            return null;
        }
    }
}
