using System.Text.Json;
using FreelanceHub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreelanceHub.Data.Configurations;

public sealed class JobOfferConfiguration : IEntityTypeConfiguration<JobOffer>
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);

    public void Configure(EntityTypeBuilder<JobOffer> builder)
    {
        builder.ToTable("JobOffers", table =>
        {
            table.HasCheckConstraint(
                "CK_JobOffers_ApplicantsCount",
                "ApplicantsCount IS NULL OR ApplicantsCount >= 0");
        });

        builder.HasKey(offer => offer.Id);

        builder.Property(offer => offer.Id)
            .ValueGeneratedNever();

        builder.Property(offer => offer.ExternalId)
            .HasMaxLength(256);

        builder.Property(offer => offer.Platform)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(offer => offer.Title)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(offer => offer.DescriptionSummary)
            .HasMaxLength(2_000);

        builder.Property(offer => offer.OriginalUrl)
            .HasMaxLength(2_048)
            .IsRequired();

        builder.Property(offer => offer.CanonicalUrl)
            .HasMaxLength(2_048);

        builder.Property(offer => offer.BudgetMinimum)
            .HasPrecision(18, 2);

        builder.Property(offer => offer.BudgetMaximum)
            .HasPrecision(18, 2);

        builder.Property(offer => offer.Currency)
            .HasMaxLength(3);

        builder.Property(offer => offer.PaymentType)
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.Property(offer => offer.Location)
            .HasMaxLength(300);

        builder.Property(offer => offer.Tags)
            .HasConversion(
                tags => JsonSerializer.Serialize(tags, JsonOptions),
                json => JsonSerializer.Deserialize<List<string>>(json, JsonOptions) ?? new List<string>())
            .Metadata.SetValueComparer(new ValueComparer<List<string>>(
                (left, right) => left != null && right != null && left.SequenceEqual(right),
                tags => tags.Aggregate(0, (hash, tag) => HashCode.Combine(hash, tag.GetHashCode())),
                tags => tags.ToList()));

        builder.Property(offer => offer.Status)
            .HasConversion<string>()
            .HasMaxLength(20)
            .IsRequired();

        builder.HasIndex(offer => offer.Platform);
        builder.HasIndex(offer => offer.PublishedAt);
        builder.HasIndex(offer => offer.Status);
        builder.HasIndex(offer => new { offer.Status, offer.PublishedAt });

        builder.HasIndex(offer => new { offer.Platform, offer.ExternalId })
            .IsUnique()
            .HasFilter("ExternalId IS NOT NULL");

        builder.HasIndex(offer => new { offer.Platform, offer.CanonicalUrl })
            .IsUnique()
            .HasFilter("CanonicalUrl IS NOT NULL");
    }
}
