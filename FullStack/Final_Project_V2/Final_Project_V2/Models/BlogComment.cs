//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Final_Project_V2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BlogComment
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Content { get; set; }
        public Nullable<int> Blog_Id { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual Blog Blog { get; set; }
    }
}
