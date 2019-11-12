using Promotion.Views.PopUp;
using Rg.Plugins.Popup.Services;
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
	public partial class GetCodePage : ContentPage
	{
		public GetCodePage()
		{
			InitializeComponent();
		}

		private async void backButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}

		private async void CmdGetCodePromotion_Clicked(object sender, EventArgs e)
		{
			await PopupNavigation.Instance.PushAsync(new GetCodePromotionPopUp());
		}

	}
}