﻿using Newtonsoft.Json;
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
	public partial class PromotionsPage : ContentPage
	{			
		public PromotionsPage(int userId)
		{
			InitializeComponent();
		    BindingContext = new PromotionsPageViewModel(userId);
		}		
	}
}