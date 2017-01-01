using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

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
                //TODO pass validation
                Signup(email.Text, password.Text,nickname.Text);
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
            public void Signup(string username,string password, string nickname)
        {
            var client = new RestClient("https://treasuresfind.auth0.com");
            var request = new RestRequest("dbconnections/signup", Method.POST);

            request.AddParameter("email", username);
            request.AddParameter("password", password);
            request.AddParameter("nickname", nickname);
            request.AddParameter("connection", "Username-Password-Authentication");

            IRestResponse response = client.Execute(request);

            UserSignup user = JsonConvert.DeserializeObject<UserSignup>(response.Content);
            if (user.user_id != null)
            {
                DisplayAlert("Konto utworzone", "Bla Bla", "OK");
                Navigation.PushAsync(new UserPage());
            } else
            {
                DisplayAlert("Błąd!", "Konto nie mogło zostać utworzone", "OK");
                Navigation.PushAsync(new UserPage());
            }
        }
        public class UserSignup
        {
            public string user_id { get; set; }
        }
            }

        }
    
    

