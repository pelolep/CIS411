//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CIS411
{
    using System;
    using System.Collections.Generic;
    
    public partial class PROFESSOR
    {
        public PROFESSOR()
        {
            this.COURSEs = new HashSet<COURSE>();
        }
    
        public string PROF_EMAIL { get; set; }
        public string LASTNAME { get; set; }
        public string FIRSTNAME { get; set; }
    
        public virtual ICollection<COURSE> COURSEs { get; set; }
    }
}