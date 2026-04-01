using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Identity
{
    //A child class of IdentityRole class
    public class ApplicationRole:IdentityRole<Guid>
    {
    }
}
