namespace FashionHexa.DTO
{
    public class UserRatingsDTO
    {
        public int? UserRatingsId { get; set; }
        public int? Ratings { get; set; }

        public DateTime RatedAt { get; set; }
        public int? ProductId {  get; set; }
        public int? UserId {  get; set; }
    }
}
