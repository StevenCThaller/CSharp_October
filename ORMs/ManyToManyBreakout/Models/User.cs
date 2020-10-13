using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManyToManyBreakout.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }

        public List<UserLikesColor> ColorsLiked { get; set; }
    }
}