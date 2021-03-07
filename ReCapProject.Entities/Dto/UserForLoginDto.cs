using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Core.Entities;

namespace ReCapProject.Entities.Dto
{
    public class UserForLoginDto : IDto // giriş yapmak isteyen
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
