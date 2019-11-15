using Newtonsoft.Json;
using Promotion.Commands;
using Promotion.Models;
using Promotion.Views;
using Promotion.Views.PopUp;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Promotion.ViewModels
{
	public class LoginPageViewModel : INotifyPropertyChanged
	{
		public string Email { get; set; }
		public string Password { get; set; }
		//public string ErrorMessage { get; set; }
        public Command LoginCommand { get; set; }
	    public Command SignUpPageCommand { get; set; }
	    public Command ForgotPageCommand { get; set; }
		public LoginPageViewModel()
		{
			LoginCommand = new Command(Login);
			SignUpPageCommand = new Command(SignUp);
			ForgotPageCommand = new Command(ForgotPassword);
		}

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
		public async void Login()
		{
			ErrorMessage = null;
			Email = "test@test.test";
			Password = "12345678";
			if (string.IsNullOrEmpty(Email))//&& IsValidate Email Format
			{
				ErrorMessage = "Please Enter your email";				
			}

			if (string.IsNullOrEmpty(Password))//&& IsValidate Email Format
			{
				ErrorMessage = "Please Enter your password";				
			}
			if (ErrorMessage == null)
			{
				Uri url = new Uri(App.BaseUri, "api/User/Login");
				LoginCommand loginCommand = new LoginCommand()
				{
						Email = Email,
					    Password = Password
				};

				string json = loginCommand.ToString2();//JsonConvert.SerializeObject(loginCommand);

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
						await App.Current.MainPage.Navigation.PushAsync(new HomePage(App.UserId));
						ErrorMessage = null;

					}
					else
					{
					//	ErrorMessage= await result.Content.ReadAsStringAsync();
						ErrorMessage = "Email or Password is wrong!";
					}
				}
				catch (Exception ex)
				{
					ErrorMessage = ex.Message;
				}
			}
		}
		public void SignUp()
		{
			App.Current.MainPage.Navigation.PushAsync(new RegisterPage());
		}
		public void ForgotPassword()
		{
			PopupNavigation.Instance.PushAsync(new ForgotPasswordPopUp());
		}
	}
}
