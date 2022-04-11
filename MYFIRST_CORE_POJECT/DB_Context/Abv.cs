using System;
using System.Collections.Generic;

#nullable disable

namespace MYFIRST_CORE_POJECT.DB_Context
{
    public partial class Abv
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long? Mobile { get; set; }
        public string Department { get; set; }
        public string City { get; set; }
    }
}
