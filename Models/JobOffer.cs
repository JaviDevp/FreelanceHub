namespace FreelanceHub.Models;

public sealed class JobOffer
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string? ExternalId { get; set; }

    public required string Platform { get; set; }

    public required string Title { get; set; }

    public string? DescriptionSummary { get; set; }

    public required string OriginalUrl { get; set; }

    public string? CanonicalUrl { get; set; }

    public decimal? BudgetMinimum { get; set; }

    public decimal? BudgetMaximum { get; set; }

    public string? Currency { get; set; }

    public PaymentType? PaymentType { get; set; }

    public DateTimeOffset? PublishedAt { get; set; }

    public string? Location { get; set; }

    public bool? IsRemote { get; set; }

    public List<string> Tags { get; set; } = [];

    public int? ApplicantsCount { get; set; }

    public JobOfferStatus Status { get; set; } = JobOfferStatus.Active;

    public DateTimeOffset FetchedAt { get; set; } = DateTimeOffset.UtcNow;

    public DateTimeOffset LastVerifiedAt { get; set; } = DateTimeOffset.UtcNow;
}
