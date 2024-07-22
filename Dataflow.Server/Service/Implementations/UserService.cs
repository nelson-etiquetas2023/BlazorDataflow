using Dataflow.Server.Repository.Interfaces;
using Dataflow.Server.Service.Contracts;
using Dataflow.Shared.Models;

namespace Dataflow.Server.Service.Implementations
{
    internal sealed class UserService(IrepositoryManager repository) : IUserService
    {
        private readonly IrepositoryManager _repository = repository;


        public User? GetUserById(int id, bool trackChanges) 
        {
            var user = _repository.User.GetUserById(id, trackChanges);
            //chekear si el usuario es null.
            return user;
        }
        public IEnumerable<User> GetAllUsers(bool trackChanges) 
        {
            try
            {
                var users = _repository.User.GetAllUsers(trackChanges);
                return users;   
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
