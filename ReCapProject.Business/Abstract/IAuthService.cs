using ReCapProject.Core.Entities.Concrete;
using ReCapProject.Core.Utilities.Result.Abstract;
using ReCapProject.Core.Utilities.Security.JWT;
using ReCapProject.Entities.concrete;
using ReCapProject.Entities.Dto;

namespace ReCapProject.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}