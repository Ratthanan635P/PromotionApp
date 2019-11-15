using Newtonsoft.Json;
using Promotion.Commands;
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
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage()
		{
			InitializeComponent();
		}
/*
		private async void LogInTap_Tapped(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}
		private async void RegisterButton_Clicked(object sender, EventArgs e)
		{
			//LogIn
			var email = EmailEntry.Text;
			var password = PasswordEntry.Text;
			var confirmPassword = ConfirmPasswordEntry.Text;

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

			if (password != confirmPassword)
			{
				errorLabel.Text = "password and confirmpassword not same!";
				errorLabel.IsVisible = true;
			}

			if (errorLabel.IsVisible ==false)
			{

				Uri url = new Uri(App.BaseUri, "api/User/Register");
				RegisterCommand registerCommand = new RegisterCommand()
				{
					Email = email,
					Password = password,
					ConfirmPassword=confirmPassword
				};

				string json = JsonConvert.SerializeObject(registerCommand);

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
						//MyClass data = JsonConvert.DeserializeObject<MyClass>(stringContent);
						//await Navigation.PushAsync(new HomePage());
						await Navigation.PopAsync();
					}
					else
					{
						string dataerror = result.ReasonPhrase;
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

		private async void backButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}*/
	}
}