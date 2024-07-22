using Dataflow.Server.Repository.Interfaces;
using Dataflow.Server.Service.Contracts;

namespace Dataflow.Server.Service.Implementations
{
    public sealed class ServiceManager(IrepositoryManager repositorymanager) : IServiceManager
    {
        private readonly Lazy<IUserService> _userService = new(() => new UserService(repositorymanager));

        public IUserService UserService => _userService.Value;
    }
}
