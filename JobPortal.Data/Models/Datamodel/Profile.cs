//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JobPortal.Data.Models.Datamodel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Profile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public int JobTitleId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    
        public virtual JobTitle JobTitle { get; set; }
    }
}
