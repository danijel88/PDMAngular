using System.Threading.Tasks;

namespace PDMAngular.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
