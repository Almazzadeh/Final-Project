﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Final_ProjectEntities : DbContext
    {
        public Final_ProjectEntities()
            : base("name=Final_ProjectEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Animation> Animation { get; set; }
        public virtual DbSet<AnimationSide> AnimationSide { get; set; }
        public virtual DbSet<FourDiv> FourDiv { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<MobileOperator> MobileOperator { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public virtual DbSet<Shipping> Shipping { get; set; }
        public virtual DbSet<AboutWallpaper> AboutWallpaper { get; set; }
        public virtual DbSet<OurTeam> OurTeam { get; set; }
        public virtual DbSet<Blog> Blog { get; set; }
    }
}
