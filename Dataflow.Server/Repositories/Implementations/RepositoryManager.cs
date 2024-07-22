using Dataflow.Server.Data;
using Dataflow.Server.Repository.Interfaces;

namespace Dataflow.Server.Repository.Implementations
{
    public sealed class RepositoryManager(AppDbContext context) : IrepositoryManager
    {
        private readonly AppDbContext _context = context;
        private readonly Lazy<IUserRepository> _userRepository = new(() => new UserRepository(context));

        public IUserRepository User => _userRepository.Value;
        public void Save() => _context.SaveChanges();

    }
}
