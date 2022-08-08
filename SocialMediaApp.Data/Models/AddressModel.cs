using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Data.Models
{
    public class AddressModel
    {
        public int Id { get; set; }
        public string AdressName { get; set; }
        public string Description { get; set; }

        public int UserId { get; set; }
        public UserModel User { get; set; }
    }
}
