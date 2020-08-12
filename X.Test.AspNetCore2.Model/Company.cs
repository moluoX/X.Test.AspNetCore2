using System;
using System.Collections.Generic;
using System.Text;

namespace X.Test.AspNetCore2.Model
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
