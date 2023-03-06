using Domain.Commons.Models;
using Domain.Guest.ValueObjects;
using Domain.Host.ValueObjects;
using Domain.Menu.ValueObjects;
using Domain.MenuReview.ValueObjects;

namespace Domain.Menu;

public sealed class MenuReview : AggregateRoot<MenuReviewId>

{
    private MenuReview(MenuReviewId id,
                       float rating,
                       string review)
        : base(id)
    {
        Review = review;
        Rating = rating;
    }

    public MenuId MenuId { get; }
    public HostId HostId { get; }
    public GuestId GuestId { get; }
    public float Rating { get; }
    public string Review { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public static MenuReview Create(string name, float rating, string review)
    {
        return new(MenuReviewId.CreateUnique(), rating, review);
    }
}
