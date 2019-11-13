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
	public partial class HistoryPage : ContentPage
	{

		public List<MyPromotionViewModel> listMyHistory = new List<MyPromotionViewModel>();
		public HistoryPage()
		{
			InitializeComponent();
		}
		public HistoryPage(int userId)
		{
			InitializeComponent();
			GetMyHistory(userId);
			//MyPromotion /? id = 2 & history = false

		}
		public async void GetMyHistory(int userId)
		{
			Uri url = new Uri(App.BaseUri, "api/Promotion/MyPromotion/?id=" + userId + "&history=true");

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
					listMyHistory = JsonConvert.DeserializeObject<List<MyPromotionViewModel>>(stringContent);
					for (int i = 0; i < listMyHistory.Count; i++)
					{
						listMyHistory[i].ExpireDate = listMyHistory[i].Expire.ToString("dd/MM/yyyy");
					}
					MyHistory.ItemsSource = listMyHistory;
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

		private async void MyHistory_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var dataSelect = e.SelectedItem as MyPromotionViewModel;
			UpdateCommand data = new UpdateCommand() {
				UserId = App.UserId,
              PromotionId=dataSelect.Id
             };
			//MyHistory.SelectedItem = 0;
			await Navigation.PushAsync(new GetCodePage(data));
		}
		protected override void OnAppearing()
		{
			//MyHistory.SelectedItem;
			base.OnAppearing();
		}

	}
}