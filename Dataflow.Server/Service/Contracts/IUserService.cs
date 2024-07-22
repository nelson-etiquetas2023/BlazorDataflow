using Dataflow.Shared.Models;


namespace Dataflow.Server.Service.Contracts
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers(bool trackChanges);
        User? GetUserById(int id, bool trackChanges);

    }
}
