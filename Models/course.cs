//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ManagementStudent.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class course
    {
        public course()
        {
            this.registrations = new HashSet<registration>();
        }
    
        public int Id { get; set; }
        public string Course1 { get; set; }
        public Nullable<int> Duration { get; set; }
    
        public virtual ICollection<registration> registrations { get; set; }
    }
}