using System;

namespace X.Test.AspNetCore2.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Company Company { get; set; }
    }
}
