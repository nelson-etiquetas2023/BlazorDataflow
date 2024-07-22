using Dataflow.Shared.Models;

namespace Dataflow.Server.Repository.Interfaces
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        User? GetUserById(int id, bool trackChanges);
        IEnumerable<User> GetAllUsers(bool trackChange);
    }
}
