using Data.Models.Interfaces;

namespace Data.Models.Models
{
    public class UserToken : IIdable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Token { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
