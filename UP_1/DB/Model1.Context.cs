﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UP_1.DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class UP_LAB_2Entities : DbContext
    {
        public UP_LAB_2Entities()
            : base("name=UP_LAB_2Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Akademiki> Akademiki { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Disciplina> Disciplina { get; set; }
        public virtual DbSet<Ekzamen> Ekzamen { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Fakultet> Fakultet { get; set; }
        public virtual DbSet<Inshener> Inshener { get; set; }
        public virtual DbSet<Kafedra> Kafedra { get; set; }
        public virtual DbSet<Prepodovatel> Prepodovatel { get; set; }
        public virtual DbSet<Specialnost> Specialnost { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Ucheniki> Ucheniki { get; set; }
        public virtual DbSet<Zav_kafedroy> Zav_kafedroy { get; set; }
        public virtual DbSet<Zavka> Zavka { get; set; }
        public virtual DbSet<Gimnazist> Gimnazist { get; set; }
    }
}