using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Promotion.Views.PopUp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GetCodePromotionPopUp : Rg.Plugins.Popup.Pages.PopupPage
	{
		public GetCodePromotionPopUp()
		{
			InitializeComponent();
		}
		public GetCodePromotionPopUp(string code)
		{
			InitializeComponent();

		}
		private async void BackButton_Clicked(object sender, EventArgs e)
		{
			await PopupNavigation.Instance.PopAsync();

		}
	}
}