using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PracticeProjectLive.Empmodel
{
    public partial class TblDetails
    {
        public int EdId { get; set; }
        public string Address { get; set; }
        public string Education { get; set; }
        public string Qualification { get; set; }
        public string QualificationYear { get; set; }
        public decimal? Percentage { get; set; }
        public int? Eid { get; set; }

        public virtual TblEmployee E { get; set; }
    }
}
