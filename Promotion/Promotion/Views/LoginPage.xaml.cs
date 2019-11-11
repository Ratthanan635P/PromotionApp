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
			if (string.IsNullOrEmpty(email))//&& IsValidate Email Format
			{
				errorLabel.Text = "Please Enter your email";
				errorLabel.IsVisible = true;
			}
			//if (string.IsNullOrEmpty(email))//&& IsValidate Email Format
			//{
			//	errorLabel.Text = "Invalid Email Error";
			//	errorLabel.IsVisible = true;
			//}
			HttpClient client = new HttpClient();
			try
			{
				Uri url = new Uri( App.BaseUri, "/api/LogIn");
				
				LoginCommand logincommand = new LoginCommand()
				{
					Email = "test@test.com", //email,
					Password = "12345678"//password
				};
				var json = JsonConvert.SerializeObject(logincommand);
				HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
				var result = await client.PostAsync(url, content);
				if (result.IsSuccessStatusCode)
				{
					//Navigation HomePage
					var stringContent = await result.Content.ReadAsStringAsync();
					var data = JsonConvert.DeserializeObject(stringContent);
				}
				else
				{
					errorLabel.Text = "";
					errorLabel.IsVisible = true;
				}
			}
			catch (Exception ex)
			{
				errorLabel.Text = "";
				errorLabel.IsVisible = true;
				// DisplayAlert("Error",ex.Message,"OK");
			}
			finally
			{
				//
				client.Dispose();
			}

		}

		private void RegisterTap_Tapped(object sender, EventArgs e)
		{
			//Navigation page Register
			//Task.Delay(5000);
			string data = Task.Run(MyFunction).Result;
			DisplayAlert("","Done","Ok");
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