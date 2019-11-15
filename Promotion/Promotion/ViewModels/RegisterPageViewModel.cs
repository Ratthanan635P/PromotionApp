using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Promotion.ViewModels
{
	public class RegisterPageViewModel
	{
		public string Email { get; set; }
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }
		public Command LoginPageCommand { get; set; }
		public Command RegisterCommand { get; set; }
		public Command BackPageCommand { get; set; }
		public RegisterPageViewModel()
		{
			LoginPageCommand = new Command(Login);
			RegisterCommand = new Command(Register);
			BackPageCommand = new Command(BackPage);

		}
		public void Register()
		{
			var email = Email;
			var password = Password;

			if (Email == "Test@test.test" && password == "12345678")
			{
				Application.Current.MainPage.DisplayAlert("", "log in successed", "Ok");
			}
			else
			{
				Application.Current.MainPage.DisplayAlert("", "Log in fail", "Ok");
			}

		}
		public void Login()
		{
			 App.Current.MainPage.Navigation.PopAsync();
		}
		public void BackPage()
		{
			App.Current.MainPage.Navigation.PopAsync();
		}
	}
}
