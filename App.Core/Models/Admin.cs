using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Models
{
    public class Admin:BaseEntity
    {
        public string userName { get; set; }
        public string userPassword { get; set; }
        public string Role { get; set; }
    }
}
