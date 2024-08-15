using Domain.UseCases.Boundaries.Outputs;
using Refit;

namespace Infra.Https
{
    public interface IGetBooksHttps
    {
        [Get("/pt/books")]
        Task<IEnumerable<HarryBooksDto>> GetAllHarryBooksAsync(CancellationToken cancellationToken);
    }
}
