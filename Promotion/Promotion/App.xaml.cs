using Promotion.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Promotion
{
	public partial class App : Application
	{
		public static Uri BaseUri { get; private set; }
		public static int UserId { get; set; }
		public App()
		{
              
			//#if DEBUG
			//#else
			//#endif
			//BaseUri = new Uri ("http://192.168.1.29:30000/");
			BaseUri = new Uri ("http://192.168.43.250:30000/");
			InitializeComponent();

			MainPage = new NavigationPage( new LoginPage());
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
