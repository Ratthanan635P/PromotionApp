using Newtonsoft.Json;
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
	public partial class HomePage : ContentPage
	{
		private HomePageViewModel HomePageView;
		public int UserId { get; set; }
		public HomePage(int userId)
		{
			InitializeComponent();
			UserId = userId;
			HomePageView = new HomePageViewModel(userId);
			BindingContext = HomePageView;
		}
		protected override void OnAppearing() 
        {
			base.OnAppearing();
			HomePageView.GetMyPromotion(UserId);
		 }
	}
}