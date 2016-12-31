using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HelloWorld
{
    public partial class GreetPage : ContentPage
    {

        public GreetPage()
        {
            BackgroundColor = Color.White;
            InitializeComponent();
        }
        void LoginPageClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new LoginPage());
        }
        void RegistrationClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Registration());
        }
    }
}
