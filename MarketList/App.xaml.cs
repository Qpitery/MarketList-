using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Services;
using MarketList.Tools;

namespace MarketList
{

    public partial class App : Application
    {

        private static DataBase dB;

        public static DataBase DB
        {
            get
            {
                if (dB == null)
                {
                    dB = new DataBase();
                }
                return dB;
            }
        }
        public App()
        {
            InitializeComponent();
          //  DependencyService.Register<DataBase>();
            MainPage  = new AppShell();
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
