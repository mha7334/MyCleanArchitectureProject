namespace Infrastructure.Authentication
{
    public class JwtSettings
    {
        public static string SectionName { get; } = "JwtSettings";
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpiryMinutes { get; set; }

    }
}
