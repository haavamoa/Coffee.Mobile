using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Coffee.Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MethodCard : ContentView
    {
        public MethodCard()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            if (!(sender is Grid grid)) return;
            grid.ScaleTo(10);
        }
    }
}