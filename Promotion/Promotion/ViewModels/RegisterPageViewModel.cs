using Newtonsoft.Json;
using Promotion.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace Promotion.ViewModels
{
	public class RegisterPageViewModel : INotifyPropertyChanged
	{
		public string Email { get; set; }
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }
		public Command LoginPageCommand { get; set; }
		public Command RegisterCommand { get; set; }
		public Command BackPageCommand { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;
		private string errorMessage;
		public string ErrorMessage
		{
			get
			{
				return errorMessage;
			}
			set
			{
				if (value != errorMessage)
				{
					errorMessage = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ErrorMessage"));
				}
			}
		}
		public RegisterPageViewModel()
		{
			LoginPageCommand = new Command(Login);
			RegisterCommand = new Command(Register);
			BackPageCommand = new Command(BackPage);

		}
		public async void Register()
		{
			
			ErrorMessage = null;
			if (string.IsNullOrEmpty(Email))//&& IsValidate Email Format
			{
				ErrorMessage = "Please Enter your email";
			}

			if (string.IsNullOrEmpty(Password))//&& IsValidate Email Format
			{
				ErrorMessage = "Please Enter your password";
			}

			if (Password != ConfirmPassword)
			{
				ErrorMessage = "password and confirmpassword not same!";			
			}

			if (ErrorMessage == null)
			{

				Uri url = new Uri(App.BaseUri, "api/User/Register");
				RegisterCommand registerCommand = new RegisterCommand()
				{
					Email = Email,
					Password = Password,
					ConfirmPassword = ConfirmPassword
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
						await App.Current.MainPage.Navigation.PopAsync();
					}
					else
					{
						string dataerror = result.ReasonPhrase;
						ErrorMessage = "Email or Password is wrong!";
						
					}
				}
				catch (Exception ex)
				{
					ErrorMessage = ex.Message;
				}

			}

		}
		public async void Login()
		{
			await App.Current.MainPage.Navigation.PopAsync();
		}
		public async void BackPage()
		{
			await App.Current.MainPage.Navigation.PopAsync();
		}
	}
}
