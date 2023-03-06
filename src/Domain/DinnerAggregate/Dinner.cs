using Domain.Commons.Models;
using Domain.Dinner.Entities;
using Domain.Dinner.ValueObjects;
using Domain.Host.ValueObjects;
using Domain.Menu.ValueObjects;

namespace Domain.Dinner
{
    public sealed class Dinner : AggregateRoot<DinnerId>
    {
        public string Name { get; }
        public string Description { get; }

        public HostId HostId { get; }
        public MenuId MenuId { get; }

        private List<Reservation> _reservations = new();

        public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();

        private Dinner(DinnerId dinnerId, string name, string description) : base(dinnerId)
        {
            Name = name;
            Description = description;
        }


    }
}
