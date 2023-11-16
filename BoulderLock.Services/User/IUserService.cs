using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoulderLock.Data.Entities;
using BoulderLock.Models.User;

namespace BoulderLock.Services.User
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(UserRegister model);
    }
}