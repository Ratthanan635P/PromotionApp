using Newtonsoft.Json;
using Promotion.Commands;
using Promotion.Models;
using Promotion.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace Promotion.ViewModels
{
	
	public class HomePageViewModel : INotifyPropertyChanged
	{
		public List<MyPromotionModel> MyListPromotion { get; set; }
		public Command SelectCommand { get; set; }
		public Command BackPageCommand { get; set; }
		public Command PromotionPageCommand { get; set; }
		public Command HistoryCommand { get; set; }
		public int UserId { get; set; }
		private int countlist;
		public int Countlist
		{
			get
			{
				return countlist;
			}
			set
			{
				if (value != countlist)
				{
					countlist = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyListPromotion"));
				}
			}
		}
		public HomePageViewModel(int userId)
		{
			UserId = userId;
			GetMyPromotion(userId);
			SelectCommand = new Command<MyPromotionModel>(OnSelectedListView);
			BackPageCommand = new Command(BackPage);
			HistoryCommand = new Command(HistoryPage);
			PromotionPageCommand = new Command(PromotionsPage);
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private async void OnSelectedListView(MyPromotionModel promotion)
		{
			UpdateCommand Data = new UpdateCommand()
			{
				UserId = UserId,
				PromotionId = promotion.Id
            };
			await App.Current.MainPage.Navigation.PushAsync(new GetCodePage(Data));
		}
		public async void BackPage()
		{
			await App.Current.MainPage.Navigation.PopAsync();
		}
		public async void HistoryPage()
		{
		  await App.Current.MainPage.Navigation.PushAsync( new HistoryPage(UserId));
		}
		public async void PromotionsPage()
		{
		  await App.Current.MainPage.Navigation.PushAsync(new PromotionsPage(UserId));
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
					MyListPromotion = JsonConvert.DeserializeObject<List<MyPromotionModel>>(stringContent);
					Countlist = MyListPromotion.Count;
					for (int i = 0; i < MyListPromotion.Count; i++)
					{
						MyListPromotion[i].ExpireDate = MyListPromotion[i].Expire.ToString("dd/MM/yyyy");
					}					
				}
				else
				{
					//errormessage= await result.Content.ReadAsStringAsync();
				
				}
			}
			catch (Exception ex)
			{
				//errormessage= await result.Content.ReadAsStringAsync();
			}
		}


	}
}
