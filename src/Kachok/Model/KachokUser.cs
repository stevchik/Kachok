using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace Kachok.Model
{
    public class KachokUser : IdentityUser
    {
        public DateTime CreatedDate { get; set; }
    }
}
