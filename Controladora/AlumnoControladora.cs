namespace Controladora
{
    using Modelo;
    using Modelo.Model;
    using Modelo.Repository;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Entity;

    public class AlumnoControladora
    { 
        IRepository<Alumno> repository;

        public AlumnoControladora(Business.ILogic T)
        {
            repository = T.GetRepositoryAlumno();
        }

        public void AgregarAlumno(Alumno entity)
        {
            repository.Add(entity);
            repository.Commit();
        }

        public void EliminarAlumno(int AlumnoId)
        {
            repository.Delete(AlumnoId);
            repository.Commit();
        }

        public void ModificarAlumno(Alumno entity)
        {
            repository.Update(entity);
            repository.Commit();
        }

        public Alumno ObtenerAlumno(int AlumnoId)
        {
            return repository.Find(a => a.AlumnoId == AlumnoId).FirstOrDefault();
        }

        public IEnumerable<Alumno> ListarAlumnos()
        {
            return repository.Fetch().Include("Curso");
        }

    }
}
