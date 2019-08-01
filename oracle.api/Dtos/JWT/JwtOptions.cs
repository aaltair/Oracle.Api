namespace oracle.api.Dtos.JWT
{
    public class JwtOptions
    {
        public string SecretKey { get; set; }
        public int ExpiryDay { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
    }
}