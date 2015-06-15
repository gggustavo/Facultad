using Modelo.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Modelo
{
    public class UaiFacultadContext : DbContext
    {
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }

        public UaiFacultadContext()
        {
            this.Configuration.LazyLoadingEnabled = true;

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //One-to-Many relationship
           // modelBuilder.Entity<Curso>().HasMany<Alumno>(a => a.Alumno).WithRequired();
        }
    }
}
