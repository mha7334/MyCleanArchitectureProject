using Domain.Bill.ValueObjects;
using Domain.Commons.Models;
using Domain.Dinner.ValueObjects;
using Domain.Guest.ValueObjects;

namespace Domain.Host
{
    public sealed class Bill : AggregateRoot<BillId>
    {
        public decimal Amount { get; }
        public string Currency { get; }

        public DinnerId DinnerId { get; }
        public GuestId GuestId { get; }

        private Bill(BillId billId, decimal amount, string currency) : base(billId)
        {
            Amount = amount;
            Currency = currency;
        }

        public static Bill Create(decimal amount, string currency)
        {
            return new(BillId.CreateUnique(), amount, currency);
        }
    }
}
