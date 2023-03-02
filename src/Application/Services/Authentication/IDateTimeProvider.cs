namespace Application.Services.Authentication
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}
