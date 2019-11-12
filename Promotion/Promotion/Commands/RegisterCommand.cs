using System;
using System.Collections.Generic;
using System.Text;

namespace Promotion.Commands
{
	public class RegisterCommand
	{

		public string Email { get; set; }
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }
	}
}
