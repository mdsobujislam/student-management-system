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
    
    public partial class registration
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Nic { get; set; }
        public Nullable<int> Course_id { get; set; }
        public Nullable<int> Batch_id { get; set; }
        public Nullable<int> Telno { get; set; }
    
        public virtual batch batch { get; set; }
        public virtual course course { get; set; }
    }
}