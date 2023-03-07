using Domain.Commons.Models;
using Domain.Commons.ValueObjects.Rating;
using Domain.Dinner.ValueObjects;
using Domain.Host.ValueObjects;
using Domain.Menu.Entities;
using Domain.Menu.ValueObjects;
using Domain.MenuReview.ValueObjects;

namespace Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId>

{
    private Menu(MenuId menuId,
                 string name,
                 string descriptoin,
                 HostId hostId,
                 List<MenuSection> sections,
                 DateTime createdDateTime,
                 DateTime updatedDateTime)
        : base(menuId)
    {
        Name = name;
        Description = descriptoin;
        HostId = hostId;
        _sections = sections;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }
    public string Name { get; }
    public string Description { get; }
    public AverageRating AverageRating { get; }

    public HostId HostId { get; }

    private List<MenuReviewId> _menuReviewIds = new();

    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

    private List<DinnerId> _dinnerIds = new();

    public IReadOnlyList<DinnerId> Dinners => _dinnerIds.AsReadOnly();


    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private readonly List<MenuSection> _sections = new();

    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();

    public static Menu Create(string name,
                              string description,
                              HostId hostId,
                              List<MenuSection> sections)
    {
        return new(MenuId.CreateUnique(),
                        name,
                        description,
                        hostId,
                        sections,
                        DateTime.UtcNow,
                        DateTime.UtcNow);
    }
}