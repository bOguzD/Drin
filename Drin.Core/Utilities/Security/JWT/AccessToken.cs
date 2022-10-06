namespace Drin.Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int UserId { get; set; }
    }
}
