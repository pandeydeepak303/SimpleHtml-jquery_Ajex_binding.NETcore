using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PracticeProjectLive.Empmodel
{
    public partial class TblCompany
    {
        public TblCompany()
        {
            TblEmployee = new HashSet<TblEmployee>();
        }

        public int Cid { get; set; }
        public string Cname { get; set; }

        public virtual ICollection<TblEmployee> TblEmployee { get; set; }
    }
}
