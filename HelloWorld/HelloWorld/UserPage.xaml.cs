using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HelloWorld
{
    public partial class UserPage : ContentPage
    {
        public UserPage()
        {
            InitializeComponent();
            User user = new User
            {
                Email = Application.Current.Properties["email"] as string,
                avatar = Application.Current.Properties["picture"] as string,
                username = Application.Current.Properties["nickname"] as string
            };
            Grid grid = new Grid
            {
                Padding = 30
            };

            grid.Children.Add(new Image
            {
                Aspect = Aspect.AspectFit,
                WidthRequest = 60,
                HeightRequest = 60,
                Source = ImageSource.FromUri(new Uri(user.avatar)),
            },
                0, 0);

            grid.Children.Add(new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                Text = user.username,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }
                ,1, 0);
            grid.Children.Add(new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                Text = user.Email,
                VerticalOptions = LayoutOptions.CenterAndExpand
            }
                , 0, 1);
            Content = grid;
        }
    }
    

    public class User
    {
        public string Email { get; set; }
        public string username { get; set; }
        public string avatar { get; set; }
    }
}
