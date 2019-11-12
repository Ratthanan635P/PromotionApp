using Newtonsoft.Json;
using Promotion.Models;
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
	public partial class HomePage : ContentPage
	{
		public List<MyPromotionViewModel> myPromotion;
		public List<MyPromotionViewModel> listMyPromotion =new List<MyPromotionViewModel>();
		public HomePage()
		{
			InitializeComponent();
			myPromotion = new List<MyPromotionViewModel>();

			myPromotion.Add(new MyPromotionViewModel()
			{
				Id = 1,
				Title = "sadasd",
				Expire = DateTime.Today,
				Image = "https://cdn.pixabay.com/photo/2017/01/28/19/06/label-2016248_960_720.png",
				//History=false

			});
			myPromotion.Add(new MyPromotionViewModel()
			{
				Id = 2,
				Title = "sadasdgfgfgfg",
				Expire = DateTime.Today,
				Image = "https://cdn.pixabay.com/photo/2017/01/28/19/06/label-2016248_960_720.png",
				//History = false
			});
			MyPromotion.ItemsSource = myPromotion;
		}
		public HomePage(int userId)
		{
			InitializeComponent();
			GetMyPromotion(userId);
			//MyPromotion /? id = 2 & history = false
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
		}
		         
		public async void GetMyPromotion(int userId)
		{
			Uri url = new Uri(App.BaseUri, "api/Promotion/MyPromotion/?id=" + userId + "&history=false");

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
					listMyPromotion = JsonConvert.DeserializeObject<List<MyPromotionViewModel>>(stringContent);
					MyPromotion.ItemsSource = listMyPromotion;
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
		private async void historyButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new HistoryPage(App.UserId));
		}

		private async void backButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}

		private async void CmdViewPromotions_Clicked(object sender, EventArgs e)
		{




			await Navigation.PushAsync(new PromotionsPage(App.UserId));
		}

		private async void FrameGetCode_Tapped(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new GetCodePage());
		}

		private async void MyPromotion_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var dataSelect = e.SelectedItem as MyPromotionViewModel;
			UpdateCommand data = new UpdateCommand()
			{
				UserId = App.UserId,
				PromotionId = dataSelect.Id
			};
			await Navigation.PushAsync(new GetCodePage(data));
		}
	}
}