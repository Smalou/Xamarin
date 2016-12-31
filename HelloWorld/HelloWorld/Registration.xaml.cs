using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HelloWorld
{
    public partial class Registration : ContentPage
    {
        public Registration()
        {
            InitializeComponent();  

                var email = new Entry
                {
                    Placeholder = "e-mail"
                };

                var nickname = new Entry
                {
                    Placeholder = "nickname"
                };

                var password = new Entry
                {
                    Placeholder = "hasło",
                    IsPassword = true
                };

                var password2 = new Entry
                {
                    Placeholder = "potwórz hasło",
                    IsPassword = true
                };

                var signupButton = new Button
                {
                    Text = "Utwórz konto"
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
                    new Label { Text = "Zarejestruj się w treasureSFInd", FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)), HorizontalOptions = LayoutOptions.Center },
                        email,
                        nickname,
                        password,
                        password2,
                        signupButton
                    }
                };
            }

        }
    }
    

