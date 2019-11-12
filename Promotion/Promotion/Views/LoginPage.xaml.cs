using Newtonsoft.Json;
using Promotion.Models;
using Promotion.Views.PopUp;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Promotion.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
		}
		private async void LoginButton_Clicked(object sender, EventArgs e)
		{
			//LogIn
			var email = EmailEntry.Text;
			var password = PasswordEntry.Text;
			errorLabel.IsVisible = false;
			if (string.IsNullOrEmpty(email))//&& IsValidate Email Format
			{
				errorLabel.Text = "Please Enter your email";
				errorLabel.IsVisible = true;
			}

			if (string.IsNullOrEmpty(password))//&& IsValidate Email Format
			{
				errorLabel.Text = "Please Enter your password";
				errorLabel.IsVisible = true;
			}
			if (errorLabel.IsVisible == false)
			{
				Uri url = new Uri(App.BaseUri, "api/User/Login");
				LoginCommand loginCommand = new LoginCommand()
				{
					Email = email,
					Password = password
				};

				string json = JsonConvert.SerializeObject(loginCommand);

				try
				{
					HttpResponseMessage result;
					HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
					using (HttpClient client = new HttpClient())
					{
						result = await client.PostAsync(url, content);
					}
					if (result.IsSuccessStatusCode)
					{
						//Navigate to Home page
						var stringContent = await result.Content.ReadAsStringAsync();
						//App.UserId = 1;
						App.UserId = JsonConvert.DeserializeObject<int>(stringContent);
						await Navigation.PushAsync(new HomePage(App.UserId));
					}
					else
					{
						errorLabel.Text = "Email or Password is wrong!";
						errorLabel.IsVisible = true;
					}
				}
				catch (Exception ex)
				{
					errorLabel.Text = ex.Message;
					errorLabel.IsVisible = true;
				}
			}
		}

		private async void RegisterTap_Tapped(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new RegisterPage());
		}
		private string MyFunction()
		{
			Task.Delay(5000);
			return "test";
        }
		private async void ForgotTap_Tapped(object sender, EventArgs e)
		{
			// Pop up forgot password
			await PopupNavigation.Instance.PushAsync(new ForgotPasswordPopUp());
		}
	}
}