using ReCapProject.Core.Entities;

namespace ReCapProject.Entities.Dto
{
    public class UserForRegisterDto : IDto // kayıt olmak isteyen kişinin enttysi
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}