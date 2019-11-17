using Newtonsoft.Json;
using Promotion.Commands;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace Promotion.ViewModels
{
	public class GetCodePromotionPopUpViewModel:INotifyPropertyChanged
	{
		public Command BackPageCommand { get; set; }
		public Command GetPromotionCommand { get; set; }
		private UpdateCommand UpdateData { get; set; }
		private string codePromotion;

		public event PropertyChangedEventHandler PropertyChanged;

		public string CodePromotion
		{
			get 
            {
				return codePromotion;

			}
			set
			{
				if (value != codePromotion)
				{
					codePromotion = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CodePromotion"));
				}
			}
        }
		public GetCodePromotionPopUpViewModel(UpdateCommand data)
		{
			UpdateData = data;
			GetCode(data);
			BackPageCommand = new Command(BackPage);
			//GetPromotionCommand = new Command(AddMyPromotion);
		}
		public async void GetCode(UpdateCommand data)
		{
			Uri url = new Uri(App.BaseUri, "api/UserPromotion/GetCode");

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

					CodePromotion = await result.Content.ReadAsStringAsync();
					//App.UserId = 1;
					//string code = JsonConvert.DeserializeObject<string>(stringContent);
					//Lb_Code.Text = stringContent;
					//await Navigation.PushAsync(new HomePage(App.UserId));
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

		await PopupNavigation.Instance.PopAsync();
		}
	}
}
