using Expenses.Db;
using ExpensesCore.DTO;
using Microsoft.EntityFrameworkCore;
using ExpensesCore.CustomException;
using Microsoft.AspNet.Identity;
using ExpensesCore.Utilities;

namespace ExpensesCore

{   //we must hash userpassword to store in db!!!!, so we use password hasher microsoft identity core library
    //implement dependency injection
    //we need to generate jwt token from our secret been set on our local environment at appsetting.cs
    // after 
    public class UserServices : IUserServices
    {    
        private readonly AppDbContext _dbcontext;
        private readonly IPasswordHasher _passwordHasher;

        public UserServices(AppDbContext dbcontext, IPasswordHasher passwordHasher)
        {
            _dbcontext = dbcontext;
            _passwordHasher = passwordHasher;
        }


        public async Task<AuthenticatedUser> SignUp(User user)
        {
            var checkUser = await _dbcontext.Users.FirstOrDefaultAsync(u => u.Username == user.Username);

            if (checkUser is not null)
            {
                throw new UsernameAlreadyExistException("Username already exist");
            }

            user.Password = _passwordHasher.HashPassword(user.Password);
            await _dbcontext.AddAsync(user);
            await _dbcontext.SaveChangesAsync();

            return new AuthenticatedUser
            {

                UserName = user.Username,
                Token = JwtGenerator.GenerateUserToken(user.Username)

            };

        }


        public async Task<AuthenticatedUser> SignIn(User user)
        {
            var dbUser = await _dbcontext.Users.FirstOrDefaultAsync(x => x.Username == user.Username);

            if (dbUser is null || _passwordHasher.VerifyHashedPassword(dbUser.Password, user.Password) == PasswordVerificationResult.Failed)
            {
                throw new InvalidUsernamePasswordException("Invalid username and password");

            }

            return new AuthenticatedUser {
                UserName = user.Username,
                Token = JwtGenerator.GenerateUserToken(user.Username)
            };
        }
    }
}
