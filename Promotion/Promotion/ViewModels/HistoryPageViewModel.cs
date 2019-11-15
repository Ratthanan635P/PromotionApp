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
	public class HistoryPageViewModel:INotifyPropertyChanged
	{
		public List<MyPromotionViewModel> ListHistoryPromotion { get; set; }
		public Command SelectCommand { get; set; }
		public Command BackPageCommand { get; set; }
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
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListHistoryPromotion"));
				}
			}
		}
		public HistoryPageViewModel(int userId)
		{
			UserId = userId;
			GetHistoryPromotion(userId);
			SelectCommand = new Command<MyPromotionViewModel>(OnSelectedListView);
			BackPageCommand = new Command(BackPage);
		}
		public event PropertyChangedEventHandler PropertyChanged;

		private void OnSelectedListView(MyPromotionViewModel promotion)
		{
			UpdateCommand Data = new UpdateCommand()
			{
				UserId = UserId,
				PromotionId = promotion.Id
			};
			App.Current.MainPage.Navigation.PushAsync(new GetCodePage(Data));
		}
		public void BackPage()
		{
			App.Current.MainPage.Navigation.PopAsync();
		}
		
		public async void GetHistoryPromotion(int userId)
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
					ListHistoryPromotion = JsonConvert.DeserializeObject<List<MyPromotionViewModel>>(stringContent);
					Countlist = ListHistoryPromotion.Count;
					for (int i = 0; i < ListHistoryPromotion.Count; i++)
					{
						ListHistoryPromotion[i].ExpireDate = ListHistoryPromotion[i].Expire.ToString("dd/MM/yyyy");
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
