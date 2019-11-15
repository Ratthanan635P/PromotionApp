using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Promotion.Commands
{
	public class LoginCommand
	{
		public string Email { get; set; }
		public string Password { get; set; }

		public string ToString2()
		{
			//return base.ToString();
			return JsonConvert.SerializeObject(this);
		}
	}
}
