using Domain.Interfaces.Https;
using Domain.UseCases.Boundaries.Outputs;
using Infra.Https;
using Microsoft.Extensions.Logging;

namespace Infra.Services
{
    public class GetBookService : IGetBookService
    {
        private readonly IGetBooksHttps _getBooksHttps;
        private readonly ILogger<GetBookService> _logger;
        public GetBookService(IGetBooksHttps getBooksHttps, ILogger<GetBookService> logger)
        {
            _getBooksHttps = getBooksHttps;
            _logger = logger;
        }

        public async Task<IEnumerable<HarryBooksDto>> GetAllBooksAsync(Guid correlationId, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Starting | {Class} | CorrelationId: {CorrelationId}",
                    nameof(GetBookService), 
                    correlationId);

                return await _getBooksHttps.GetAllHarryBooksAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError("{Class} | Message: {Message} | CorrelationId: {CorrelationId}",
                    nameof(GetBookService),
                    ex.Message, 
                    correlationId);
                throw;
            }
        }
    }
}
