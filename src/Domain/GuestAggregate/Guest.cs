using Domain.Bill.ValueObjects;
using Domain.Commons.Models;
using Domain.Guest.Entities;
using Domain.Guest.ValueObjects;
using Domain.MenuReview.ValueObjects;
using Domain.User.ValueObjects;

namespace Domain.Host
{
    public sealed class Guest : AggregateRoot<GuestId>
    {

        private readonly List<GuestRating> _ratings = new();
        public IReadOnlyList<GuestRating> GuestRatings => _ratings.AsReadOnly();

        private readonly List<BillId> _billIds = new();
        public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();

        private readonly List<MenuReviewId> _menuReviewIds = new();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

        public UserId UserId { get; set; }

        private Guest(GuestId hostId) : base(hostId) { }

        public static Guest Create()
        {
            return new(GuestId.CreateUnique());
        }
    }
}
