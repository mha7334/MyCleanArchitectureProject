using Domain.Commons.Models;
using Domain.Dinner.ValueObjects;
using Domain.Host.ValueObjects;
using Domain.Menu.ValueObjects;

namespace Domain.Host
{
    public sealed class Host : AggregateRoot<HostId>
    {

        private readonly List<MenuId> _menuIds = new();

        public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();

        private readonly List<DinnerId> _dinnerIds = new();

        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

        public DinnerId DinnerId { get; set; }

        private Host(HostId hostId) : base(hostId) { }

        public static Host Create()
        {
            return new(HostId.CreateUnique());
        }
    }
}
