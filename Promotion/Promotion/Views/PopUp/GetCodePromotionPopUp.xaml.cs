using Newtonsoft.Json;
using Promotion.Commands;
using Promotion.Models;
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
	public partial class GetCodePromotionPopUp : Rg.Plugins.Popup.Pages.PopupPage
	{
		public GetCodePromotionPopUp()
		{
			InitializeComponent();
			Lb_Code.Text = App.CodePro;

		}
		public GetCodePromotionPopUp(UpdateCommand data)
		{
			InitializeComponent();
			GetCode(data);
		}
		private async void BackButton_Clicked(object sender, EventArgs e)
		{
			await PopupNavigation.Instance.PopAsync();

		}
		public async void GetCode(UpdateCommand data)
		{
			Uri url = new Uri(App.BaseUri, "api/UserPromotion/GetCode");

			try
			{
				HttpResponseMessage result;
				var json = JsonConvert.SerializeObject(data);
				HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
				using (HttpClient client = new HttpClient())
				{
					result = await client.PostAsync(url, content);
				}
				if (result.IsSuccessStatusCode)
				{

					var stringContent = await result.Content.ReadAsStringAsync();
					//App.UserId = 1;
					//string code = JsonConvert.DeserializeObject<string>(stringContent);
					Lb_Code.Text = stringContent;
					//await Navigation.PushAsync(new HomePage(App.UserId));
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
}

/*
Uri url = new Uri(App.BaseUri, "api/UserPromotion/GetCode");

			try
			{
				HttpResponseMessage result;
var json = JsonConvert.SerializeObject(dataGetCode);
HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
				using (HttpClient client = new HttpClient())
				{
					result = await client.PostAsync(url, content);
				}
				if (result.IsSuccessStatusCode)
				{

					var stringContent = await result.Content.ReadAsStringAsync();
//App.UserId = 1;
string code = JsonConvert.DeserializeObject<string>(stringContent);
App.CodePro = code;
					//codePromotion = code;
					await PopupNavigation.Instance.PushAsync(new GetCodePromotionPopUp());
					//await Navigation.PushAsync(new HomePage(App.UserId));
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
*/