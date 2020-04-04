using System;
using DIPS.Xamarin.UI;
using LightInject;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Coffee.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            Library.Initialize();
            InitializeComponent();

            var container = new ServiceContainer(new ContainerOptions { EnablePropertyInjection = false });
            container.RegisterFrom<CompositionRoot>();

            MainPage = new NavigationPage(container.GetInstance<MainPage>());
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
