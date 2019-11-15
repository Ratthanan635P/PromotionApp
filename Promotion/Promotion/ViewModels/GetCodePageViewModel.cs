using Newtonsoft.Json;
using Promotion.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace Promotion.ViewModels
{
	public class GetCodePageViewModel:INotifyPropertyChanged
	{
		private DetailPromotionViewModel detailpromotion;
		public DetailPromotionViewModel DetailPromotion
		{
			get
			{
				return detailpromotion;
			}
			set
			{
				if (value != detailpromotion)
				{
					detailpromotion = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DetailPromotion"));
				}
			}
		}
		public Command SelectCommand { get; set; }
		public Command BackPageCommand { get; set; }
		public Command GetCodeCommand { get; set; }
		//public Command HistoryCommand { get; set; }
		//public int UserId { get; set; }
		//private int countlist;
		//public int Countlist
		//{
		//	get
		//	{
		//		return countlist;
		//	}
		//	set
		//	{
		//		if (value != countlist)
		//		{
		//			countlist = value;
		//			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyListPromotion"));
		//		}
		//	}
		//}
		public GetCodePageViewModel(UpdateCommand data)
		{
			//UserId = userId;
			//GetMyPromotion(data.UserId);
			GetDetailPromotion(data);
			//SelectCommand = new Command<MyPromotionViewModel>(OnSelectedListView);
			BackPageCommand = new Command(BackPage);
		//	GetCodeCommand = new Command();
			//HistoryCommand = new Command(HistoryPage);
			//PromotionPageCommand = new Command(PromotionsPage);
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
					result = await client.PostAsync(url, content);
				}
				if (result.IsSuccessStatusCode)
				{
					//Navigate to Home page
					var stringContent = await result.Content.ReadAsStringAsync();
					//App.UserId = 1;
					 DetailPromotion = JsonConvert.DeserializeObject<DetailPromotionViewModel>(stringContent);
					//LogoImage.Source = detailPromotion.Image;
					//Lb_Title.Text = detailPromotion.Title;
					//Lb_Detail.Text = detailPromotion.Detail;
					//Lb_Expire.Text = detailPromotion.Expire.ToString("dd/MM/yyyy");
					if (DetailPromotion.History == true)
					{
						//CmdGetCodePromotion.IsEnabled = false;
						//CmdGetCodePromotion.BackgroundColor = Color.Gray;
					}
					else
					{
						//CmdGetCodePromotion.IsEnabled = true;
					//	CmdGetCodePromotion.BackgroundColor = Color.FromHex("#009829");
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

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnSelectedListView(MyPromotionViewModel promotion)
		{
		//	UpdateCommand Data = new UpdateCommand()
		//	{
		//		UserId = UserId,
		//		PromotionId = promotion.Id
		//	};
		//	App.Current.MainPage.Navigation.PushAsync(new GetCodePage(Data));
		}
		public void BackPage()
		{
			App.Current.MainPage.Navigation.PopAsync();
		}
		//public void HistoryPage()
		//{
		//	App.Current.MainPage.Navigation.PushAsync(new HistoryPage(UserId));
		//}
		//public void PromotionsPage()
		//{
		//	App.Current.MainPage.Navigation.PushAsync(new PromotionsPage(UserId));
		//}
		//public async void GetMyPromotion(int userId)
		//{
		//	Uri url = new Uri(App.BaseUri, "api/Promotion/MyPromotion/?id=" + userId + "&history=false");

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
		//			MyListPromotion = JsonConvert.DeserializeObject<List<MyPromotionViewModel>>(stringContent);
		//			Countlist = MyListPromotion.Count;
		//			for (int i = 0; i < MyListPromotion.Count; i++)
		//			{
		//				MyListPromotion[i].ExpireDate = MyListPromotion[i].Expire.ToString("dd/MM/yyyy");
		//			}
		//		}
		//		else
		//		{
		//			//errormessage= await result.Content.ReadAsStringAsync();

		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		//errormessage= await result.Content.ReadAsStringAsync();
		//	}
		//}

	}
}
