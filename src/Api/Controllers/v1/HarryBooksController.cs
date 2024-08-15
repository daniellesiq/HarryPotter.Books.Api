using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}")]
    public class HarryBooksController : ControllerBase
    {
        private readonly IGetBooksUseCase _getBooksUseCase;

        public HarryBooksController(IGetBooksUseCase getBooksUseCase)
        {
            _getBooksUseCase = getBooksUseCase;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get All Harry Books.", Description = "Get All")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllBooksAsync(Guid correlationId, CancellationToken cancellationToken)
        {
            var result = await _getBooksUseCase.GetAllBooksAsync(correlationId, cancellationToken);

            if (result is null)
                return NotFound();

            return Ok(result);
        }
    }
}
