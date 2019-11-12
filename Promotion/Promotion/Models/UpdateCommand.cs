using System;
using System.Collections.Generic;
using System.Text;

namespace Promotion.Models
{
	public class UpdateCommand
	{
		public int UserId { get; set; }
		public int PromotionId { get; set; }
	}
}
