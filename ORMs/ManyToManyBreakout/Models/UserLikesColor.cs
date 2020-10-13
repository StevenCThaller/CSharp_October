using System.ComponentModel.DataAnnotations;

namespace ManyToManyBreakout.Models
{
    public class UserLikesColor
    {
        [Key]
        public int UserLikesColorId { get; set; }
        public int UserId { get; set; }
        public int ColorId { get; set; }

        public User User { get; set; }
        public Color Color { get; set; }
    }
}