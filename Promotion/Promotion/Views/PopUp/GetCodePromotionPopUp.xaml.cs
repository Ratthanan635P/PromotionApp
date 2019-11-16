using Newtonsoft.Json;
using Promotion.Commands;
using Promotion.Models;
using Promotion.ViewModels;
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
	public partial class GetCodePromotionPopUp : Rg.Plugins.Popup.Pages.PopupPage
	{

		public GetCodePromotionPopUp(UpdateCommand data)
		{
			InitializeComponent();
			BindingContext = new GetCodePromotionPopUpViewModel(data);
		}
	}
}