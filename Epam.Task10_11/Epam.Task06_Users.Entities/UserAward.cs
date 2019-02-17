using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task06_Users.Entities
{
    public class UserAward
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int AwardId { get; set; }
    }
}
