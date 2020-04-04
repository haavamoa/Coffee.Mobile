using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coffee.Mobile.ViewModels;
using Xamarin.Forms;

namespace Coffee.Mobile
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel mainViewModel)
        {
            InitializeComponent();
            BindingContext = mainViewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ((MainViewModel)BindingContext).Initialize();
        }
    }
}
