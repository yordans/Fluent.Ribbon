namespace FluentTest.AddLogicalChildRepro
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Data;

    public static class ThemesManager
    {
        /// <summary>
        /// Enables the application theme mechanism for a root element.
        /// This should be set to true in the Style of every Window that uses application themes.
        /// </summary>
        public static readonly DependencyProperty IsApplicationThemesEnabledProperty =
            DependencyProperty.RegisterAttached(
                "IsApplicationThemesEnabled",
                typeof(bool),
                typeof(ThemesManager),
                new PropertyMetadata(false, OnIsApplicationThemesEnabledChanged));

        public static bool GetIsApplicationThemesEnabled(DependencyObject obj) => (bool)obj.GetValue(IsApplicationThemesEnabledProperty);

        public static void SetIsApplicationThemesEnabled(DependencyObject obj, bool value) => obj.SetValue(IsApplicationThemesEnabledProperty, value);

        /// <summary>
        /// Called when IsApplicationThemeEnabled changes. Initializes the ApplicationCurrentTheme on the Window.
        /// </summary>
        private static void OnIsApplicationThemesEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not Window window)
            {
                throw new InvalidOperationException("The IsApplicationThemeEnabled property can only be set on a Window.");
            }

            if ((bool)e.NewValue)
            {
                window.SetValue(ApplicationCurrentThemePropertyKey, ApplicationThemeManager.ApplicationTheme);
            }
        }

        /// <summary>
        /// The private key for the read-only ApplicationCurrentThemeProperty.
        /// </summary>
        private static readonly DependencyPropertyKey ApplicationCurrentThemePropertyKey =
            DependencyProperty.RegisterAttachedReadOnly(
                "ApplicationCurrentTheme",
                typeof(ApplicationTheme),
                typeof(ThemesManager),
                new FrameworkPropertyMetadata(ApplicationTheme.None, FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// Identifies the read-only attached property for the current application theme.
        /// This property is inherited, so any element in the visual tree can access it.
        /// </summary>
        public static readonly DependencyProperty ApplicationCurrentThemeProperty = ApplicationCurrentThemePropertyKey.DependencyProperty;

        public static ApplicationTheme GetApplicationCurrentTheme(DependencyObject obj) => (ApplicationTheme)obj.GetValue(ApplicationCurrentThemeProperty);

        /// <summary>
        /// Initiates an application theme change across the entire application.
        /// </summary>
        /// <param name="newTheme">The new application theme to apply.</param>
        public static void NotifyApplicationThemeChanged(ApplicationTheme newTheme)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (GetIsApplicationThemesEnabled(window))
                {
                    window.SetValue(ApplicationCurrentThemePropertyKey, newTheme);
                }
            }
        }

        /// <summary>
        /// Attaches an IThemeChangeHandler to an element to react to ApplicationTheme changes.
        /// </summary>
        public static readonly DependencyProperty ApplicationThemeChangeHandlerProperty =
            DependencyProperty.RegisterAttached(
                "ApplicationThemeChangeHandler",
                typeof(IThemeChangeHandler),
                typeof(ThemesManager),
                new PropertyMetadata(null, OnApplicationThemeChangeHandlerChanged));

        public static IThemeChangeHandler? GetApplicationThemeChangeHandler(DependencyObject obj) => (IThemeChangeHandler?)obj.GetValue(ApplicationThemeChangeHandlerProperty);

        public static void SetApplicationThemeChangeHandler(DependencyObject obj, IThemeChangeHandler? value) => obj.SetValue(ApplicationThemeChangeHandlerProperty, value);

        /// <summary>
        /// Called when ApplicationThemeChangeHandler changes. Sets up or tears down the application theme binding.
        /// </summary>
        private static void OnApplicationThemeChangeHandlerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not FrameworkElement frameworkElement)
            {
                return;
            }

            if (e.NewValue is IThemeChangeHandler newHandler)
            {
                var binding = new Binding { Path = new PropertyPath(ApplicationCurrentThemeProperty), Source = frameworkElement };
                bool manualInvokeRequired = frameworkElement.GetValue(ApplicationCurrentThemeProperty) == frameworkElement.GetValue(BoundApplicationThemeMonitorProperty);
                BindingOperations.SetBinding(frameworkElement, BoundApplicationThemeMonitorProperty, binding);
                if (manualInvokeRequired)
                {
                    newHandler.OnThemeChanged(frameworkElement);
                }
            }
            else
            {
                BindingOperations.ClearBinding(frameworkElement, BoundApplicationThemeMonitorProperty);
            }
        }

        /// <summary>
        /// Internal monitor for the application theme. Its callback triggers the handler.
        /// </summary>
        private static readonly DependencyProperty BoundApplicationThemeMonitorProperty =
            DependencyProperty.RegisterAttached("BoundApplicationThemeMonitor", typeof(ApplicationTheme), typeof(ThemesManager), new PropertyMetadata(ApplicationTheme.None, OnBoundApplicationThemeMonitorChanged));

        /// <summary>
        /// Notification trigger for application theme changes.
        /// </summary>
        private static void OnBoundApplicationThemeMonitorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var themeChangeHandler = GetApplicationThemeChangeHandler(d);
            if (themeChangeHandler != null && d is FrameworkElement frameworkElement)
            {
                themeChangeHandler.OnThemeChanged(frameworkElement);
            }
        }
    }
}
