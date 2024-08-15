using Domain.Interfaces;
using Domain.Interfaces.Https;
using Domain.UseCases.Boundaries.Outputs;
using Microsoft.Extensions.Logging;

namespace Domain.UseCases
{
    public class GetBooksUseCase : IGetBooksUseCase
    {
        private readonly IGetBookService _getBookService;
        private readonly ILogger<GetBooksUseCase> _logger;
        public GetBooksUseCase(IGetBookService getBookService, ILogger<GetBooksUseCase> logger)
        {
            _getBookService = getBookService;
            _logger = logger;
        }

        public Task<IEnumerable<HarryBooksDto>> GetAllBooksAsync(Guid correlationId, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting | {Class} | CorrelationId: {CorrelationId}",
                nameof(GetBooksUseCase),
                correlationId);

            var result = _getBookService.GetAllBooksAsync(correlationId, cancellationToken);

            return result;
        }
    }
}
