using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HelloWorld
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            var email = new Entry
            {
                Placeholder = "e-mail"
            };

            var password = new Entry
            {
                Placeholder = "hasło",
                IsPassword = true
            };

            var signupButton = new Button
            {
                Text = "Zaloguj się"
            };

            signupButton.Clicked += (object sender, EventArgs e) =>
            {

            };
            Content = new StackLayout
            {
                Padding = 30,
                Spacing = 10,
                Children =
                {
                    new Label { Text = "Zaloguj się do treasureSFInd", FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)), HorizontalOptions = LayoutOptions.Center },
                        email,
                        password,
                        signupButton
                    }
                };
            }

        }
    }

