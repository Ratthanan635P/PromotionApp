using Newtonsoft.Json;
using Promotion.Commands;
using Promotion.Models;
using Promotion.ViewModels;
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
	public partial class GetPromotionPage : ContentPage
	{
		//private DetailPromotionModel promotionDetail = new DetailPromotionModel();

		//public GetPromotionPage()
		//{
		//	InitializeComponent();
		//}
		public GetPromotionPage(UpdateCommand data)
		{
			InitializeComponent();
			BindingContext = new GetPromotionPageViewModel(data);	
		}
		//public async void GetDetailPromotion(UpdateCommand data)
		//{
		//	Uri url = new Uri(App.BaseUri, "api/Promotion/DetailPromotion");
		//	try
		//	{
		//		HttpResponseMessage result;
		//		var json = JsonConvert.SerializeObject(data);
		//		HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
		//		using (HttpClient client = new HttpClient())
		//		{
		//			result = await client.PostAsync(url, content);
		//		}
		//		if (result.IsSuccessStatusCode)
		//		{
		//			//Navigate to Home page
		//			var stringContent = await result.Content.ReadAsStringAsync();
		//			//App.UserId = 1;
		//			var detailPromotion = JsonConvert.DeserializeObject<DetailPromotionModel>(stringContent);
		//			promotionDetail = detailPromotion;
		//			LogoImage.Source = detailPromotion.Image;
		//			Lb_Title.Text = detailPromotion.Title;
		//			Lb_Detail.Text = detailPromotion.Detail;
		//			Lb_Expire.Text = detailPromotion.Expire.ToString("dd/MM/yyyy");
		//			if (detailPromotion.History == true)
		//			{
		//				CmdAddMyPromotions.IsEnabled = false;
		//				CmdAddMyPromotions.BackgroundColor = Color.Gray;
		//			}
		//			else
		//			{
		//				CmdAddMyPromotions.IsEnabled = true;
		//				CmdAddMyPromotions.BackgroundColor = Color.FromHex("#009829");
		//			}

		//		}
		//		else
		//		{
		//			//errorLabel.Text = "Email or Password is wrong!";
		//			//errorLabel.IsVisible = true;
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		//errorLabel.Text = ex.Message;
		//		//errorLabel.IsVisible = true;
		//	}
		//}

		//private async void backButton_Clicked(object sender, EventArgs e)
		//{
		//	await Navigation.PopAsync();
		//}

		//private void CmdAddMyPromotions_Clicked(object sender, EventArgs e)
		//{
		//	// call api add mypromotion
		//				UpdateCommand data = new UpdateCommand()
		//				{
		//					UserId = App.UserId,
		//					PromotionId = promotionDetail.Id
		//				};
		//	AddMyPromotion(data);	
			
		//}
		//public async void AddMyPromotion(UpdateCommand data)
		//{
		//	Uri url = new Uri(App.BaseUri, "api/UserPromotion/AddMyPromotion");
		//	try
		//	{
		//		HttpResponseMessage result;
		//		var json = JsonConvert.SerializeObject(data);
		//		HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
		//		using (HttpClient client = new HttpClient())
		//		{
		//			result = await client.PostAsync(url, content);
		//		}
		//		if (result.IsSuccessStatusCode)
		//		{
		//			await Navigation.PushAsync(new HomePage(App.UserId));
		//		}
		//		else
		//		{
		//			//errorLabel.Text = "Email or Password is wrong!";
		//			//errorLabel.IsVisible = true;
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		//errorLabel.Text = ex.Message;
		//		//errorLabel.IsVisible = true;
		//	}
		//}



	}
}