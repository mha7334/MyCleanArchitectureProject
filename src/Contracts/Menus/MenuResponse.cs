namespace Contracts.Menus;

public record MenuResponse(
    Guid Id,
    string Name,
    string Description,
    float? AverageRating,
    string HostId,
    List<string> DinnerIds,
    List<string> MenuReviewIds,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime,
    List<MenuSectionResponse> Sections);

public record MenuSectionResponse(
    string Id,
    string Name,
    string Descriptoin,
    List<MenuItemResponse> Items);

public record MenuItemResponse(
    string Id,
    string Name,
    string Description);