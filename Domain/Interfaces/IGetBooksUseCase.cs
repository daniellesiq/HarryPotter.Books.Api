using Domain.UseCases.Boundaries.Outputs;

namespace Domain.Interfaces
{
    public interface IGetBooksUseCase
    {
        Task<IEnumerable<HarryBooksDto>> GetAllBooksAsync(Guid correlationId, CancellationToken cancellationToken);
    }
}
