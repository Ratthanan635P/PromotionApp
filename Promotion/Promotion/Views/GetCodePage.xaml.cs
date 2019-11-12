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
	public partial class GetCodePage : ContentPage
	{
		public GetCodePage()
		{
			InitializeComponent();
		}
		public GetCodePage(UpdateCommand data)
		{
			InitializeComponent();
			GetDetailPromotion(data);
		}
		public async void GetDetailPromotion(UpdateCommand data)
		{
			Uri url = new Uri(App.BaseUri, "api/Promotion/DetailPromotion");

			try
			{
				HttpResponseMessage result;
				var json = JsonConvert.SerializeObject(data);
				HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
				using (HttpClient client = new HttpClient())
				{
					result = await client.PostAsync(url,content);
				}
				if (result.IsSuccessStatusCode)
				{
					//Navigate to Home page
					var stringContent = await result.Content.ReadAsStringAsync();
					//App.UserId = 1;
					var detailPromotion = JsonConvert.DeserializeObject<DetailPromotionViewModel>(stringContent);
					LogoImage.Source = detailPromotion.Image;
					Lb_Title.Text = detailPromotion.Title;
					Lb_Detail.Text = detailPromotion.Detail;
					Lb_Expire.Text = detailPromotion.Expire.ToString();
					if (detailPromotion.History == true)
					{
						CmdGetCodePromotion.IsEnabled = false;
						CmdGetCodePromotion.BackgroundColor = Color.Gray;
					}
					else
					{
						CmdGetCodePromotion.IsEnabled = true;
						CmdGetCodePromotion.BackgroundColor = Color.FromHex("#009829");
					}

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
		private async void backButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}

		private async void CmdGetCodePromotion_Clicked(object sender, EventArgs e)
		{
			await PopupNavigation.Instance.PushAsync(new GetCodePromotionPopUp());
		}

	}
}