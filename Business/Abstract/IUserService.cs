using Core.Utilities.Results.Abstract;
using Entities.DTOs.UserDTOs;
using Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService   
    {
        IResult Register(RegisterDTO registerDTO);
        IResult Login(LoginDTO loginDTO);
        IResult VerifyEmail(string email, string verifyToken);
        IDataResult<User> GetUser(int userId);
    }
}
