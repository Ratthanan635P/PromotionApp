﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Promotion.Models
{
	public class MyPromotionViewModel
	{
		public int Id { get; set; }
		public string Image { get; set; }
		public string Title { get; set; }
		public string Detail { get; set; }
		public string Expire { get; set; }
		public bool History { get; set; }
	}
}
