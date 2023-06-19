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
        Task<User> CreateUserAsync(User user); //Creates a new user

        Task<User> GetUserById(int userId); //Get's a user by Id

        Task<ICollection<User>> GetAllUsers();

        Task<ICollection<User>> GetAllUsersOrderedByDateCreated();

        Task<User> UpdateUserAsync(User user, int userId);

        Task<bool> DeleteUserAsync(int userId);
    }
}
