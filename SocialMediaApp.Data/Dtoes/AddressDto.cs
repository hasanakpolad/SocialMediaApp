using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SocialMediaApp.Data.Dtoes
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string AdressName { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }

    }
}
