using Promotion.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Promotion.ViewModels
{
	public class HomePageViewModel
	{
		public List<MyPromotionViewModel> MyListPromotion { get; set; }
		public Command SelectCommand { get; set; }
		public Command BackPageCommand { get; set; }
		public Command PromotionPageCommand { get; set; }
		public Command HistoryCommand { get; set; }

		public HomePageViewModel()
		{
			SelectCommand = new Command<MyPromotionViewModel>(OnSelectedListView);
			BackPageCommand = new Command(BackPage);
			HistoryCommand = new Command(HistoryPage);
			PromotionPageCommand = new Command(PromotionsPage);
		}
		private void OnSelectedListView(MyPromotionViewModel promotion)
		{
            //
		}
		public void BackPage()
		{
			App.Current.MainPage.Navigation.PopAsync();
		}
		public void HistoryPage()
		{
		//	App.Current.MainPage.Navigation.PopAsync();
		}
		public void PromotionsPage()
		{
			//	App.Current.MainPage.Navigation.PopAsync();
		}


	}
}
