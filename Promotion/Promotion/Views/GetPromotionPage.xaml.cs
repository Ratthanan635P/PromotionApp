using Newtonsoft.Json;
using Promotion.Commands;
using Promotion.Models;
using Promotion.ViewModels;
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
	public partial class GetPromotionPage : ContentPage
	{
		public GetPromotionPage(UpdateCommand data)
		{
			BindingContext = new GetPromotionPageViewModel(data);
			InitializeComponent();				
		}
		
	}
}