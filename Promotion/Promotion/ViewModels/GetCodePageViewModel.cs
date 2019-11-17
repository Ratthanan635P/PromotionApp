using Newtonsoft.Json;
using Promotion.Commands;
using Promotion.Models;
using Promotion.Views;
using Promotion.Views.PopUp;
using Rg.Plugins.Popup.Services;
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
		private DetailPromotionModel detailpromotion;
		public DetailPromotionModel DetailPromotion
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
		private string expireDate;
		public string ExpireDate
		{
			get
			{
				return expireDate;
			}
			set
			{
				if (value != expireDate)
				{
					expireDate = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DetailPromotion"));
				}
			}
		}
		private bool history;
		public bool History
		{
			get
			{
				return history;
			}
			set
			{
				if (value != history)
				{
					history = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DetailPromotion"));
				}
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;

		public Command SelectCommand { get; set; }
		public Command BackPageCommand { get; set; }
		public Command GetCodeCommand { get; set; }
		private UpdateCommand UpdateData { get; set; }
		public GetCodePageViewModel(UpdateCommand data)
		{
			UpdateData = data;

			  GetDetailPromotion(data);			
			BackPageCommand = new Command(BackPage);
			GetCodeCommand = new Command(GetCodePopUp);
		}


		public async void GetCodePopUp()
		{
			History = true;
			await PopupNavigation.Instance.PushAsync(new GetCodePromotionPopUp(UpdateData));
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
					 DetailPromotion = JsonConvert.DeserializeObject<DetailPromotionModel>(stringContent);
					DetailPromotion.ExpireDate = DetailPromotion.Expire.ToString("dd/MM/yyyy");
					ExpireDate = DetailPromotion.ExpireDate;
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
		public async void BackPage()
		{
			//App.Current.MainPage.Navigation.PushAsync( new HomePage(UpdateData.UserId));
			await App.Current.MainPage.Navigation.PopAsync();
		}	
	}
}
