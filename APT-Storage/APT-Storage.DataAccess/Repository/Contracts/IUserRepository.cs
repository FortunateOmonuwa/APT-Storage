using APT_Storage.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APT_Storage.DataAccess.Repository.Contracts
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User user); 

        Task<User> GetUserById(int userId);

        Task<ICollection<User>> GetAllUsers();

        //Task<ICollection<User>> GetAllUsersOrderedByDateCreated();

        Task<User> UpdateUserAsync(User user);

        Task<bool> DeleteUserAsync(int userId);
    }
}
