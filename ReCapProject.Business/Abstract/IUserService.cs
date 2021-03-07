using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Core.Entities.Concrete;
using ReCapProject.Entities.concrete;

namespace ReCapProject.Business.Abstract
{
   public interface IUserService
   {
       List<OperationClaim> GetClaims(User user);
       void Add(User user);
       User GetByMail(string email);
    }
}
