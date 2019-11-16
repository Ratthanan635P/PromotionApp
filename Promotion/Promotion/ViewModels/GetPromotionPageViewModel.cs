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
	public class GetPromotionPageViewModel : INotifyPropertyChanged
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
		public event PropertyChangedEventHandler PropertyChanged;

		//public Command SelectCommand { get; set; }
		public Command BackPageCommand { get; set; }
		public Command	GetPromotionCommand { get; set; }
		private UpdateCommand UpdateData { get; set; }
		public GetPromotionPageViewModel(UpdateCommand data)
		{
			UpdateData = data;
			GetDetailPromotion(data);
			BackPageCommand = new Command(BackPage);
			GetPromotionCommand = new Command(AddMyPromotion);
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
		public void BackPage()
		{
			App.Current.MainPage.Navigation.PopAsync();
		}
		public async void AddMyPromotion()
		{
			Uri url = new Uri(App.BaseUri, "api/UserPromotion/AddMyPromotion");
			try
			{
				HttpResponseMessage result;
				var json = JsonConvert.SerializeObject(UpdateData);
				HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
				using (HttpClient client = new HttpClient())
				{
					result = await client.PostAsync(url, content);
				}
				if (result.IsSuccessStatusCode)
				{
					await App.Current.MainPage.Navigation.PushAsync(new HomePage(App.UserId));
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
