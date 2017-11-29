using System.Threading.Tasks;

namespace PDMAngular.Persistence
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
