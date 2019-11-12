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
		public HomePage()
		{
			InitializeComponent();
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