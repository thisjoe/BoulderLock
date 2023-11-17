using BoulderLock.Data;
using BoulderLock.Data.Entities;
using BoulderLock.Models;
using BoulderLock.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BoulderLock.Services.User
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly ApplicationDbContext _dbContext;
        public UserService(ApplicationDbContext context)
        {
            _context = context;            
        }
        public async Task<bool> RegisterUserAsync(UserRegister model)
        {
            if (await GetUserByEmailAsync(model.Email) != null || await GetUserByUsernameAsync(model.Username) != null)
            { return false; }

            var userentity = new UserEntity
            {
                Email = model.Email,
                Username = model.Username,        
                //Role = model.Role
                DateCreated = DateTime.UtcNow,
                IsActive = true,
            };

            var passwordHasher = new PasswordHasher<UserEntity>();

            userentity.loginPass = passwordHasher.HashPassword(userentity, model.Password);

            _context.Users.Add(userentity);
            await _context.SaveChangesAsync();

            //Link new user registration to account if User active/has account then link to that account
            var accountentity = new AccountEntity
            {
                AccountType = "Manager",
                IsActive = true
            };
            _context.Accounts.Add(accountentity);
            await _context.SaveChangesAsync();

            var useraccount = new UserAccount
            {
                userId = userentity.userId,
                accountId = accountentity.accountId

            };
            _context.UserAccounts.Add(useraccount);
            await _context.SaveChangesAsync();
                        
            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
        }
        public async Task<IEnumerable<GetUser>> GetUserAsync()
        {
            var Users = await _context.Users
                .Where(entity => entity.IsActive)
                .Select(entity => new GetUser
                {
                    Id = entity.userId,
                    Username = entity.Username
                })
                .ToListAsync();
            
            return Users;
        }

        public async Task<UserEntity> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(User => User.Email == email.ToLower());
        }

        public async Task<UserEntity> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(User => User.Username.ToLower() == username.ToLower());
        }
    }
}