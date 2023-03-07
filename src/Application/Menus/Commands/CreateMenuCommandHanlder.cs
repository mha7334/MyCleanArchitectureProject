using Application.Common.Interfaces.Persistence;

using Contracts.Menus;

using Domain.Host.ValueObjects;
using Domain.Menu;
using Domain.Menu.Entities;

using ErrorOr;

using MediatR;

namespace Application.Menus.Commands;

public class CreateMenuCommandHanlder : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    public readonly IMenuRepository _menuRepository;

    public CreateMenuCommandHanlder(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        //create menu
        var menu = Menu.Create(
            hostId: HostId.Create(request.HostId),
            name: request.Name,
            description: request.Description,
            sections: request.Sections.ConvertAll(
                section => MenuSection.Create(
                section.Name,
                section.Description,
                section.Items.ConvertAll(item => MenuItem.Create(
                    item.Name,
                    item.Description)))));

        //persist menu

        _menuRepository.Add(menu);

        //return menu

        return menu;
    }
}
