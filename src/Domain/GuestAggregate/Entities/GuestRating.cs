using Domain.Commons.Models;
using Domain.Dinner.ValueObjects;
using Domain.Guest.ValueObjects;
using Domain.Host.ValueObjects;

namespace Domain.Guest.Entities
{
    public sealed class GuestRating : Entity<GuestRatingId>
    {
        public HostId HostId { get; }
        public DinnerId DinnerId { get; }
        public float Rating { get; }

        private GuestRating(GuestRatingId guestRatingId,
                            float rating)
            : base(guestRatingId)
        {
            Rating = rating;
        }

        public static GuestRating Create(float rating)
        {
            return new(GuestRatingId.CreateUnique(), rating);
        }
    }
}