using Newtonsoft.Json;
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
	public partial class PromotionsPage : ContentPage
	{
		
		//public List<PromotionProductViewModel> listPromotions = new List<PromotionProductViewModel>();
		public PromotionsPage(int userId)
		{
			InitializeComponent();
			BindingContext = new PromotionsPageViewModel(userId);
		}
		//public PromotionsPage(int userId)
		//{
		//	InitializeComponent();
		//	GetPromotions(userId);
		//	//MyPromotion /? id = 2 & history = false

		//}
		//public async void GetPromotions(int userId)
		//{
		//	Uri url = new Uri(App.BaseUri, "api/Promotion?userId=" + userId);

		//	try
		//	{
		//		HttpResponseMessage result;
		//		//HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
		//		using (HttpClient client = new HttpClient())
		//		{
		//			result = await client.GetAsync(url);
		//		}
		//		if (result.IsSuccessStatusCode)
		//		{
		//			//Navigate to Home page
		//			var stringContent = await result.Content.ReadAsStringAsync();
		//			//App.UserId = 1;
		//			listPromotions = JsonConvert.DeserializeObject<List<PromotionProductViewModel>>(stringContent);
		//			for (int i = 0; i < listPromotions.Count; i++)
		//			{
		//				listPromotions[i].ExpireDate = listPromotions[i].Expire.ToString("dd/MM/yyyy");
		//			}

		//			ListPromotion.ItemsSource = listPromotions;
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

		//private async void DetailPromotion_Tapped(object sender, EventArgs e)
		//{
		//   await Navigation.PushAsync(new GetPromotionPage());
		//}

		//private async void ListPromotion_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		//{
		//	var dataSelect = e.SelectedItem as PromotionProductViewModel;
		//	UpdateCommand data = new UpdateCommand()
		//	{
		//		UserId = App.UserId,
		//		PromotionId = dataSelect.Id
		//	};
		//	//ListPromotion.SelectedItem = 0;
		//	await Navigation.PushAsync(new GetPromotionPage(data));
		//}
		//protected override void OnAppearing()
		//{
		//	//ListPromotion.SelectedItem = 0;
		//	base.OnAppearing();
		//}
	}
}