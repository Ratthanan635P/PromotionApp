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
	public class PromotionsPageViewModel:INotifyPropertyChanged
	{
		private List<PromotionProductViewModel> listPromotionsAll;
		public List<PromotionProductViewModel> ListPromotionsAll 
        {
			get
			{
				return listPromotionsAll;
			}
			set
			{
				if (value != listPromotionsAll)
				{
					listPromotionsAll = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListPromotionsAll"));
				}
			}
		}
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
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListPromotionsAll"));
				}
			}
		}
		public PromotionsPageViewModel()
		{ }
		public PromotionsPageViewModel(int userId)
		{
			UserId = userId;
			GetPromotion(userId);
			SelectCommand = new Command<PromotionProductViewModel>(OnSelectedListView);
			BackPageCommand = new Command(BackPage);
		}
		public event PropertyChangedEventHandler PropertyChanged;

		private void OnSelectedListView(PromotionProductViewModel promotion)
		{
			UpdateCommand Data = new UpdateCommand()
			{
				UserId = UserId,
				PromotionId = promotion.Id
			};
			App.Current.MainPage.Navigation.PushAsync(new GetPromotionPage(Data));
		}
		public void BackPage()
		{
			App.Current.MainPage.Navigation.PopAsync();
		}

		public async void GetPromotion(int userId)
		{
			Uri url = new Uri(App.BaseUri, "api/Promotion?userId=" + userId);

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
					ListPromotionsAll = JsonConvert.DeserializeObject<List<PromotionProductViewModel>>(stringContent);
					
					for (int i = 0; i < ListPromotionsAll.Count; i++)
					{
						ListPromotionsAll[i].ExpireDate = ListPromotionsAll[i].Expire.ToString("dd/MM/yyyy");
					}
					Countlist = ListPromotionsAll.Count;

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
