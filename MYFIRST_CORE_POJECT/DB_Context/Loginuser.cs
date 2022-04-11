using System;
using System.Collections.Generic;

#nullable disable

namespace MYFIRST_CORE_POJECT.DB_Context
{
    public partial class Loginuser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
