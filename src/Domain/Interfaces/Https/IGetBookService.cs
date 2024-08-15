using Domain.UseCases.Boundaries.Outputs;

namespace Domain.Interfaces.Https
{
    public interface IGetBookService
    {
        Task<IEnumerable<HarryBooksDto>> GetAllBooksAsync(Guid correlationId, CancellationToken cancellationToken);
    }
}
