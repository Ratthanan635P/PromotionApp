using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace Promotion.ViewModels
{
    public class ForgotPasswordPopUpViewModel
	{
		public string Email { get; set; }
		public string Password { get; set; }
		//public string ErrorMessage { get; set; }
		public Command ForgotPaaswordCommand { get; set; }
		public Command BackPageCommand { get; set; }

		public ForgotPasswordPopUpViewModel()
		{
			BackPageCommand = new Command(BackPage);
			ForgotPaaswordCommand = new Command(ForgotPassword);
		}
		private async void ForgotPassword()
		{
			//var email = EmailEntry.Text;
			if (!string.IsNullOrEmpty(Email))//&& IsValidate Email Format
			{
				Uri url = new Uri(App.BaseUri, "api/User?email=" + Email);

				//LoginCommand loginCommand = new LoginCommand()
				//{
				//	Email = email,
				//	Password = password
				//};

				//string json = JsonConvert.SerializeObject(loginCommand);

				try
				{
					HttpResponseMessage result;
					//HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
					using (HttpClient client = new HttpClient())
					{
						result = await client.GetAsync(url);
					}
					if (result.IsSuccessStatusCode)
					{
						//Navigate to Home page
						var stringContent = await result.Content.ReadAsStringAsync();
						//App.UserId = 1;
						string password = JsonConvert.DeserializeObject<string>(stringContent);
						await App.Current.MainPage.DisplayAlert("", password, "OK");
						await PopupNavigation.Instance.PopAsync();
					}
					else
					{
						//errorLabel.Text = "Email or Password is wrong!";
						//errorLabel.IsVisible = true;
					}
				}
				catch (Exception ex)
				{
					//errorLabel.Text = ex.Message;
					//errorLabel.IsVisible = true;
				}
			}
		}

		private async void BackPage()
		{
			await PopupNavigation.Instance.PopAsync();
		}
	}
}
