using Promotion.Views;
using Promotion.Views.PopUp;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Promotion.ViewModels
{
	public class LoginPageViewModel
	{
		public string Email { get; set; }
		public string Password { get; set; }
		public Command LoginCommand { get; set; }
	    public Command SignUpPageCommand { get; set; }
	    public Command ForgotPageCommand { get; set; }
		public LoginPageViewModel()
		{
			LoginCommand = new Command(Login);
			SignUpPageCommand = new Command(SignUp);
			ForgotPageCommand = new Command(ForgotPassword);
		}
		public void Login()
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
		public void SignUp()
		{
			App.Current.MainPage.Navigation.PushAsync(new RegisterPage());
		}
		public void ForgotPassword()
		{
		//	App.Current.MainPage.PopupNavigation.Instance.PushAsync(new ForgotPasswordPopUp());
		}
	}
}
