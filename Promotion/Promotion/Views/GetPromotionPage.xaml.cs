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
	public partial class GetPromotionPage : ContentPage
	{
		public GetPromotionPage()
		{
			InitializeComponent();
		}

		private async void backButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}

		private void CmdViewPromotions_Clicked(object sender, EventArgs e)
		{

		}
	}
}