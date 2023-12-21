using AutoMapper;
using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concreate.ErrorResults;
using Core.Utilities.Results.Concreate.SuccessResults;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataaAccess.Abstract;
using Entities.DTOs.UserDTOs;
using Entities.SharedModels;
using Entities.Users;
using MassTransit;
using System.ComponentModel.DataAnnotations;

// ctrl + R + G unnecessary using
namespace Business.Concreate
{
    public class UserManager : IUserService
    {
        private readonly IUserDAL _userDAL;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public UserManager(IUserDAL userDAL, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _userDAL = userDAL;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        public IResult Login(LoginDTO loginDTO)
        {
            var result = BusinessRoles.CheckLogic(LoginCheckUserEmailNotExists(loginDTO.Email), CheckUserLoginAttempt(loginDTO.Email),
               CheckUserPassword(loginDTO.Email, loginDTO.Password));
            var user = _userDAL.Get(x => x.Email == loginDTO.Email);

            if (!result.Success)
            {
                user.LoginAttempt += 1;
                _userDAL.Update(user);
                return new ErrorResult();
            }

            var token = Token.TokenGenerator(user, "User");
            return new SuccessResult(token);
        }

        public IResult Register(RegisterDTO registerDTO)
        {
            var result = BusinessRoles.CheckLogic(CheckUserEmailExsis(registerDTO.Email),
                CheckUserPasswordConfirm(registerDTO.Password, registerDTO.ConfirmPassword));

            if (!result.Success)
                return new ErrorResult("There is a mistake");

            var map = _mapper.Map<User>(registerDTO);
            HashingHelper.HashPassword(registerDTO.Password, out byte[] passwordHash, out byte[] passwordSalt);
            map.PasswordSalt = passwordSalt;
            map.PasswordHash = passwordHash;
            map.Token = Guid.NewGuid().ToString();
            map.TokenExpiredDate = DateTime.Now.AddMinutes(30);

            _userDAL.Add(map);

            SendEmailCommand sendEmailCommand = new()
            {
                FirstName = map.Firstname,
                LastName = map.Lastname,
                Email = map.Email,
                Token = map.Token
            };

             _publishEndpoint.Publish<SendEmailCommand>(sendEmailCommand);
            return new SuccessResult("Registerid SuccessFully");


        }

        public IResult VerifyEmail(string email, string verifyToken)
        {
            var user = _userDAL.Get(x => email == x.Email);
            if (user.Token == verifyToken)
            {
                if (DateTime.Compare(user.TokenExpiredDate, DateTime.Now) < 0)
                {
                    return new ErrorResult("Your token has expired!");
                }
                user.EmailConfirmed = true;
                _userDAL.Update(user);
                return new SuccessResult();
            }
            return new ErrorResult("Try again"); ;
        }

        private IResult CheckUserEmailExsis(string email)
        {
            var checkEmail = _userDAL.Get(x => x.Email == email);
            if (checkEmail != null)
            {
                return new ErrorResult("Error");
            }
            return new SuccessResult("Success");
        }

        private IResult LoginCheckUserEmailNotExists(string email)
        {
            var checkEmail = _userDAL.Get(x => x.Email == email);
            if (checkEmail == null)
                return new ErrorResult();

            return new SuccessResult();
        }

        private IResult CheckUserPassword(string email, string password)
        {
            var checkEmail = _userDAL.Get(x => x.Email == email);
            bool checkPassword = HashingHelper.VerifyPassword(password, checkEmail.PasswordHash, checkEmail.PasswordSalt);
            if (!checkPassword)
                return new ErrorResult("Error!");

            return new SuccessResult(message:"SuccessFully");
        }

        private IResult CheckUserLoginAttempt(string email)
        {
            var user = _userDAL.Get(x => x.Email == email);

            if (user.LoginAttempt >= 3)
            {
                if (user.loginAttemptExpired <= DateTime.Now)
                {
                    user.loginAttemptExpired = DateTime.Now.AddMinutes(30);
                    _userDAL.Update(user);
                    return new ErrorResult();
                }
                return new ErrorResult();
            }

            return new SuccessResult(message:"SuccessFully");
        }

         
        private IResult CheckUserPasswordConfirm(string password, string confirmPassword)
        {
            if (password != confirmPassword)
                return new ErrorResult();
            return new SuccessResult();
        }

        public IDataResult<User> GetUser(int userId)
        {
            var result = _userDAL.GetUserOrders(userId);
            return new SuccessDataResult<User>(result);
        }
    }
}
