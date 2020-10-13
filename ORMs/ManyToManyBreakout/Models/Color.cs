using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManyToManyBreakout.Models
{
    public class Color
    {
        [Key]
        public int ColorId { get; set; }
        public string Name { get; set; }

        public List<UserLikesColor> UsersWhoLike { get; set; }
    }
}