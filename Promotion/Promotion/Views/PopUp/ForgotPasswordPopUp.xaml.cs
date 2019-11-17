using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
	}
}