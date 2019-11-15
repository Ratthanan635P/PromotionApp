using Newtonsoft.Json;
using Promotion.Models;
using Promotion.ViewModels;
using Promotion.Views.PopUp;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Promotion.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GetCodePage : ContentPage
	{
		public GetCodePage(UpdateCommand data)
		{
			InitializeComponent();
			BindingContext = new GetCodePageViewModel(data);
		}		
	}
}