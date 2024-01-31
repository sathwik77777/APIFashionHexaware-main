namespace FashionHexa.Models
{
    public class AuthResponse
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RoleName {  get; set; }
        public string Token { get; set; }
    }

}
