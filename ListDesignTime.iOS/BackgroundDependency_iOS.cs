using ProjectNamespace.iOS;
using UIKit;
using Xamarin.Forms;
using static XFThemes.ThemeManager;

[assembly: Dependency(typeof(BackgroundDependency_iOS))]
namespace ProjectNamespace.iOS
{
    public class BackgroundDependency_iOS : IBackgroundDependency
    {
        public BackgroundDependency_iOS()
        {
        }

        public void SetStatusBarTheme(Themes theme)
        {
            UIApplication.SharedApplication.StatusBarStyle = theme == Themes.Dark ? UIStatusBarStyle.LightContent : UIStatusBarStyle.DarkContent;
        }


    }
}