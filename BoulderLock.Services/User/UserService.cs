using BoulderLock.Data;
using BoulderLock.Data.Entities;
using BoulderLock.Models;
using BoulderLock.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BoulderLock.Services.User
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly ApplicationDbContext _dbContext;
        public UserService(ApplicationDbContext context, ApplicationDbContext dbContext)
        {
            _context = context;
            _dbContext = dbContext;
        }
        public async Task<bool> RegisterUserAsync(UserRegister model)
        {
            var entity = new UserEntity
            {
                userId = model.Id,
                accountId = model.Acc_Id,
                Email = model.Email,
                Username = model.Username,
                Role = model.Role,
                loginPass = model.Password
            };

            _context.Users.Add(entity);
            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
        }
        public async Task<IEnumerable<GetUser>> GetUserAsync()
        {
            var Users = await _dbContext.Users
                .Where(entity => entity.IsActive)
                .Select(entity => new GetUser
                {
                    Id = entity.userId,
                    Username = entity.Username
                })
                .ToListAsync();
            
            return Users;
        }
    }
}