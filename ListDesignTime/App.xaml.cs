using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFThemes;

namespace ListDesignTime
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            ThemeManager.LoadTheme();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
