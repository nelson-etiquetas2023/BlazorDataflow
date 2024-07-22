using Dataflow.Server.Data;
using Dataflow.Server.Repository.Interfaces;
using Dataflow.Shared.Models;

namespace Dataflow.Server.Repository.Implementations
{
    public class UserRepository(AppDbContext context) : RepositoryBase<User>(context), IUserRepository
    {
        public void CreateUser(User user) => Create(user);
        public void UpdateUser(User user) => Update(user);
        public void DeleteUser(User user) => Delete(user);
        public User? GetUserById(int id, bool trackChanges) => 
            FindByCondition(x => x.IdUser.Equals(id),trackChanges).SingleOrDefault();
        public IEnumerable<User> GetAllUsers(bool trackChange) => 
            FindAll(trackChange).OrderBy(x => x.Name).ToList();
           
        
    }
}
