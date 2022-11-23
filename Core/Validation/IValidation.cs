using System.Threading;
using System.Threading.Tasks;

namespace Core.Validation
{
    public interface IValidation<T>
    {
        Task Validate(T model, CancellationToken cancellationToken = default);
    }
}
