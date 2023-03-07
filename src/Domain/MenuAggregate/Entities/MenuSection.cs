using Domain.Commons.Models;
using Domain.Menu.ValueObjects;

namespace Domain.Menu.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        public string Name { get; }
        public string Description { get; }

        private readonly List<MenuItem> _items = new();

        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

        private MenuSection(MenuSectionId menuSectionId,
            string name,
            string description,
            List<MenuItem> items)
            : base(menuSectionId)
        {
            Name = name;
            _items = items;
            description = description;
        }

        public static MenuSection Create(string name,
            string description,
            List<MenuItem> items)
        {
            return new(
                MenuSectionId.CreateUnique(), name, description, items);
        }

    }

}