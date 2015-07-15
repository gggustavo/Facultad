namespace Modelo
{
    using Modelo.Model;
    using System.Data.Entity;

    public class UaiFacultadContext : DbContext
    {
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }

        public UaiFacultadContext()
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            base.OnModelCreating(modelBuilder);

            //One-to-Many relationship
            // modelBuilder.Entity<Curso>().HasMany<Alumno>(a => a.Alumno).WithRequired();
        }
    }
}