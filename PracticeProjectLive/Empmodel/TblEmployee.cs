using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PracticeProjectLive.Empmodel
{
    public partial class TblEmployee
    {
        public TblEmployee()
        {
            TblDetails = new HashSet<TblDetails>();
        }

        public int Eid { get; set; }
        public string EmpName { get; set; }
        public int? Did { get; set; }
        public int? Cid { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual TblCompany C { get; set; }
        public virtual TblDepartment D { get; set; }
        public virtual ICollection<TblDetails> TblDetails { get; set; }
    }
}
