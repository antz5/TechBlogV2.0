﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BlogTechnicallyEntities : DbContext
    {
        public BlogTechnicallyEntities()
            : base("name=BlogTechnicallyEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BlogTechnically_Category> BlogTechnically_Category { get; set; }
        public virtual DbSet<BlogTechnically_Comment> BlogTechnically_Comment { get; set; }
        public virtual DbSet<BlogTechnically_Permission> BlogTechnically_Permission { get; set; }
        public virtual DbSet<BlogTechnically_Post> BlogTechnically_Post { get; set; }
        public virtual DbSet<BlogTechnically_Profile> BlogTechnically_Profile { get; set; }
        public virtual DbSet<BlogTechnically_Role> BlogTechnically_Role { get; set; }
        public virtual DbSet<BlogTechnically_Token> BlogTechnically_Token { get; set; }
        public virtual DbSet<BlogTechnically_User> BlogTechnically_User { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
