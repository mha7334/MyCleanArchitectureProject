using Domain.Bill.ValueObjects;
using Domain.Commons.Models;
using Domain.Dinner.ValueObjects;
using Domain.Guest.ValueObjects;

namespace Domain.Dinner.Entities
{
    public sealed class Reservation : Entity<ReservationId>
    {
        public DinnerId DinnerId { get; }
        public GuestId GuestId { get; }
        public BillId BillId { get; }

        private Reservation(ReservationId reservationId) : base(reservationId) { }

        public static Reservation Create()
        {
            return new(ReservationId.CreateUnique());
        }

    }
}