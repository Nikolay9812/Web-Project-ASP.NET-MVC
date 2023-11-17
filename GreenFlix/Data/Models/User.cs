using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static GreenFlix.Data.DataConstants.User;

namespace GreenFlix.Data.Models
{
    public class User : IdentityUser
    {
        [MaxLength(FullNameMaxLenght)]
        public string FullName { get; set; }
    }
}
