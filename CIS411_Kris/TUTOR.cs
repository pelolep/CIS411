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
    
    public partial class TUTOR
    {
        public TUTOR()
        {
            this.TUTOR_HOUR = new HashSet<TUTOR_HOUR>();
            this.VISITs = new HashSet<VISIT>();
        }
    
        public int TUTOR_ID { get; set; }
        public int CLARION_ID { get; set; }
        public string STATUS { get; set; }
    
        public virtual STUDENT STUDENT { get; set; }
        public virtual ICollection<TUTOR_HOUR> TUTOR_HOUR { get; set; }
        public virtual ICollection<VISIT> VISITs { get; set; }
    }
}