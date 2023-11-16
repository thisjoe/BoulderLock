using BoulderLock.Data;
using BoulderLock.Data.Entities;
using BoulderLock.Models.User;

namespace BoulderLock.Services.User
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
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
    }
}