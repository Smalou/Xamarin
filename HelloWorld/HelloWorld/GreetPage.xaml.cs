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
            InitializeComponent();
        }
        void Handle_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Title","Hello World","ok");
        }
    }
}
