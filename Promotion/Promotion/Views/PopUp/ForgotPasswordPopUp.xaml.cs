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
	public partial class ForgotPasswordPopUp : Rg.Plugins.Popup.Pages.PopupPage
	{
		public ForgotPasswordPopUp()
		{
			InitializeComponent();
		}
		private void LoginButton_Clicked(object sender, EventArgs e)
		{

		}

		private void ForgotPasswordButton_Clicked(object sender, EventArgs e)
		{

		}

		private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
		{
			await PopupNavigation.Instance.PopAsync();
		}
	}
}