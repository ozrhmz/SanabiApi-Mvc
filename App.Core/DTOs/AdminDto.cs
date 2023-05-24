using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.DTOs
{
    public class AdminDto:BaseDto
    {
        public string userName { get; set; }
        public string userPassword { get; set; }
		public string Role { get; set; }
	}
}
