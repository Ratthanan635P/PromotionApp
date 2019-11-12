using Promotion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
		private async void historyButton_Clicked(object sender, EventArgs e)
		{
			 await Navigation.PushAsync(new HistoryPage());
		}

		private async void backButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}

		private async void CmdViewPromotions_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new PromotionsPage());
		}

		private async void FrameGetCode_Tapped(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new GetCodePage());
		}
	}
}