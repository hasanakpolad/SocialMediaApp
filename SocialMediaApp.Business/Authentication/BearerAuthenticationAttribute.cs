using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Business.Authentication
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class BearerAuthenticationAttribute : Attribute
    {

    }
}
