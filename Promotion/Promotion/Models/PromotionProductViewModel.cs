using System;
using System.Collections.Generic;
using System.Text;

namespace Promotion.Models
{
	public class PromotionProductViewModel
	{
		public int Id { get; set; }
		public string Image { get; set; }
		public string Title { get; set; }
		public DateTime Expire { get; set; }
		public string ExpireDate { get; set; }
		public bool Like { get; set; }
		//public int IsUsed { get; set; }
	}
}
