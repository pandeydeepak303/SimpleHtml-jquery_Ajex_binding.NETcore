using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PracticeProjectLive.Empmodel
{
    public partial class TblDepartment
    {
        public TblDepartment()
        {
            TblEmployee = new HashSet<TblEmployee>();
        }

        public int Did { get; set; }
        public string DepName { get; set; }

        public virtual ICollection<TblEmployee> TblEmployee { get; set; }
    }
}
