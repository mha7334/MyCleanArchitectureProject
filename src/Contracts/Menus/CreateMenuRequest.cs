namespace Contracts.Menus;

public record CreateMenuRequest(
    Guid HostId,
    string Name,
    string Description,
    List<MenuSectionRequest> Sections);

public record MenuSectionRequest(
    string Name,
    string Description,
    List<MenuItemRequest> Items);

public record MenuItemRequest(
    string Name,
    string Description);