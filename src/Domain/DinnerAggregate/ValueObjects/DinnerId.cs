using Domain.Commons.Models;

namespace Domain.Dinner.ValueObjects
{
    public class DinnerId : ValueObject
    {
        public Guid Value { get; private set; }

        private DinnerId(Guid value)
        {
            Value = value;
        }

        public static DinnerId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
        public static DinnerId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}