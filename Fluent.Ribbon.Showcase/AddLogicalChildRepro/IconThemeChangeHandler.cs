namespace FluentTest.AddLogicalChildRepro
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Shapes;

    public class IconThemeChangeHandler : IThemeChangeHandler
    {
        public void OnThemeChanged(FrameworkElement frameworkElement)
        {
            if (frameworkElement is Fluent.Button button)
            {
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("pack://application:,,,/Fluent.Ribbon.Showcase;component/AddLogicalChildRepro/TestResources.xaml") });
            }
        }
    }
}
