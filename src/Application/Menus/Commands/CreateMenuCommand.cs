using Domain.Menu;

using ErrorOr;

using MediatR;

namespace Contracts.Menus;

public record CreateMenuCommand(
    Guid HostId,
    string Name,
    string Description,
    List<Guid> Dinners,
    List<Guid> MenuReviewIds,
    List<MenuSectionCommand> Sections) : IRequest<ErrorOr<Menu>>;

public record MenuSectionCommand(
    string Name,
    string Description,
    List<MenuItemCommand> Items);

public record MenuItemCommand(
    string Name,
    string Description);