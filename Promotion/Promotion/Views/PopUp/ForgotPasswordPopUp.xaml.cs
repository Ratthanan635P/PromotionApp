using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Promotion.Views.PopUp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ForgotPasswordPopUp : Rg.Plugins.Popup.Pages.PopupPage
	{
		public ForgotPasswordPopUp()
		{
			InitializeComponent();
		}
		private async void ForgotPasswordButton_Clicked(object sender, EventArgs e)
		{
			var email = EmailEntry.Text;
			if (!string.IsNullOrEmpty(email))//&& IsValidate Email Format
			{
				Uri url = new Uri(App.BaseUri, "api/User?email="+email);
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
						string password= JsonConvert.DeserializeObject<string>(stringContent);
						await DisplayAlert("",password,"OK");
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

		private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
		{
			await PopupNavigation.Instance.PopAsync();
		}
	}
}