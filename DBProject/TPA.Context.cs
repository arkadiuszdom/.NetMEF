﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBProject
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TPAEntities : DbContext
    {
        public TPAEntities()
            : base("Data Source = DESKTOP - 1B7KRH0\\SQLEXPRESS; Initial Catalog = TPA; Integrated Security = True; MultipleActiveResultSets=True;Application Name = EntityFramework")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Constructor> Constructor { get; set; }
        public virtual DbSet<Method> Method { get; set; }
        public virtual DbSet<MethodParameter> MethodParameter { get; set; }
        public virtual DbSet<Model> Model { get; set; }
        public virtual DbSet<Namespace> Namespace { get; set; }
        public virtual DbSet<Property> Property { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<Log> LogSet { get; set; }
    }
}
