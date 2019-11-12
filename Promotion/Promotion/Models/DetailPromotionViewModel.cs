using System;
using System.Collections.Generic;
using System.Text;

namespace Promotion.Models
{
	public class DetailPromotionViewModel
	{
		public int Id { get; set; }
		public string Image { get; set; }
		public string Title { get; set; }
		public string Detail { get; set; }
		public DateTime Expire { get; set; }
		public bool History { get; set; }
	}
}
