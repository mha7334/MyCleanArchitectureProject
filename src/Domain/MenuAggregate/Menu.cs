using Domain.Commons.Models;
using Domain.Dinner.ValueObjects;
using Domain.Host.ValueObjects;
using Domain.Menu.Entities;
using Domain.Menu.ValueObjects;
using Domain.MenuReview.ValueObjects;

namespace Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId>

{
    private Menu(MenuId id,
                 string name,
                 string descriptoin,
                 HostId hostId,
                 DateTime createdDateTime,
                 DateTime updatedDateTime
        )
        : base(id)
    {
        Name = name;
        Description = descriptoin;
        HostId = hostId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }
    public string Name { get; }
    public string Description { get; }
    public float AverageRating { get; }

    public HostId HostId { get; }

    private List<MenuReviewId> _menuReviewIds = new();

    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

    private List<DinnerId> _dinners = new();

    public IReadOnlyList<DinnerId> Dinners => _dinners.AsReadOnly();


    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private readonly List<MenuSection> _sections = new();

    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();

    public static Menu Create(string name,
                              string description,
                              HostId hostId)
    {
        return new Menu(MenuId.CreateUnique(),
                        name,
                        description,
                        hostId,
                        DateTime.UtcNow,
                        DateTime.UtcNow);
    }
}
