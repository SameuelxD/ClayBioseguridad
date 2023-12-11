using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUser : IGeneric<User>
    {
        Task<User> GetByRefreshTokenAsync(string username);
        Task<User> GetByUsernameAsync(string username);
    }
}