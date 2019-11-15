using Newtonsoft.Json;
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
		public List<MyPromotionViewModel> MyListPromotion { get; set; }
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
			SelectCommand = new Command<MyPromotionViewModel>(OnSelectedListView);
			BackPageCommand = new Command(BackPage);
			HistoryCommand = new Command(HistoryPage);
			PromotionPageCommand = new Command(PromotionsPage);
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnSelectedListView(MyPromotionViewModel promotion)
		{
			UpdateCommand Data = new UpdateCommand()
			{
				UserId = UserId,
				PromotionId = promotion.Id
            };
		}
		public void BackPage()
		{
			App.Current.MainPage.Navigation.PopAsync();
		}
		public void HistoryPage()
		{
		  App.Current.MainPage.Navigation.PushAsync( new HistoryPage(UserId));
		}
		public void PromotionsPage()
		{
		  App.Current.MainPage.Navigation.PushAsync(new PromotionsPage());
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
					MyListPromotion = JsonConvert.DeserializeObject<List<MyPromotionViewModel>>(stringContent);
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
