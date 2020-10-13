using System.Collections.Generic;

namespace ManyToManyBreakout.Models
{
    public class IndexWrapper
    {
        public List<User> AllUsers { get; set; }
        public List<Color> AllColors { get; set; }

        public User UserForm { get; set; }
        public Color ColorForm { get; set; }
        public UserLikesColor UserLikesColorForm { get; set; }
    }
}