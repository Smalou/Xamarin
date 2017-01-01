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
                Login(email.Text, password.Text);

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
        public void Login(string username, string password)
        {
            var client = new RestClient("https://treasuresfind.auth0.com");
            var request = new RestRequest("oauth/ro", Method.POST);
            request.AddParameter("client_id", "RJVHxrsep5wYvIh4cboht1uqFoCuBTsy");
            request.AddParameter("username", username);
            request.AddParameter("password", password);
            request.AddParameter("connection", "Username-Password-Authentication");
            request.AddParameter("grant_type", "password");
            request.AddParameter("scope", "openid");

            IRestResponse response = client.Execute(request);

            LoginToken token = JsonConvert.DeserializeObject<LoginToken>(response.Content);

            if (token.id_token != null)
            {
                Application.Current.Properties["id_token"] = token.id_token;
                Application.Current.Properties["access_token"] = token.access_token;

                GetUserData(token.id_token);
            } else
            {
                DisplayAlert("Błąd!", "Błędne dane logowania!", "OK");
            };
            }
            public void GetUserData(string token)
        {
            var client = new RestClient("https://treasuresfind.auth0.com");
            var request = new RestRequest("tokeninfo", Method.GET);
            request.AddParameter("id_token", token);

            IRestResponse response = client.Execute(request);

            User user = JsonConvert.DeserializeObject<User>(response.Content);

            Application.Current.Properties["email"] = user.email;
            Application.Current.Properties["picture"] = user.picture;
            Application.Current.Properties["nickname"] = user.nickname;
            Navigation.PushAsync(new UserPage());
        }
            public class LoginToken
        {
            public string id_token { get; set; }
            public string access_token { get; set; }
            public string token_type { get; set; }
        }
        public class User
        {
            public string nickname { get; set; }
            public string picture { get; set; }
            public string email { get; set; }
        }
        }
            }

        
    

