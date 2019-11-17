using Newtonsoft.Json;
using Promotion.Commands;
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
		private GetCodePageViewModel getCodePageView;
		public UpdateCommand Data { get; set; }
		public GetCodePage(UpdateCommand data)
		{
			Data = data;
			getCodePageView = new GetCodePageViewModel(data);
			BindingContext = getCodePageView;
			InitializeComponent();			
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
		    getCodePageView.GetDetailPromotion(Data);
		}
	}
}