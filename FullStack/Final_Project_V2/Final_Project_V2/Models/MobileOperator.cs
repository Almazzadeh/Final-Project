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
    
    public partial class MobileOperator
    {
        public int Id { get; set; }
        public string Carrier { get; set; }
        public string Rating { get; set; }
        public Nullable<bool> Voice1 { get; set; }
        public Nullable<bool> Voice2 { get; set; }
        public Nullable<bool> C2GData { get; set; }
        public Nullable<bool> C3GData { get; set; }
        public Nullable<bool> C4GData { get; set; }
    }
}