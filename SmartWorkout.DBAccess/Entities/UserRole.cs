using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWorkout.DBAccess.Entities
{
    public class UserRole
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<User> Users { get; set; } = null!;
    }
}
