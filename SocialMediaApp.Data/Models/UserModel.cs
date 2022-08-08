using SocialMediaApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Data.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public RoleEnum Role { get; set; }
        public int FollowCount { get; set; }
        public int FollowerCount { get; set; }

        public List<AddressModel> Addresses { get; set; }
    }
}
