namespace Domain.UseCases.Boundaries.Outputs
{
    public record HarryBooksDto
    {
        public int Number { get; init; }
        public string Title { get; init; } = default!;
        public string OriginalTitle { get; init; } = default!;
        public string ReleaseDate { get; init; } = default!;
        public string Description { get; init; } = default!;
        public int Pages { get; init; } = default!;
    }
}
