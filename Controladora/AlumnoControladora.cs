using Modelo;
using Modelo.Model;
using Modelo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class AlumnoControladora
    {
        IRepository<Alumno> repository;

        public AlumnoControladora()
        {
            this.repository = SingletonContext.GetContainer().GetInstance<IRepository<Alumno>>();
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

        public List<Alumno> ListarAlumnos()
        {
            return repository.All().ToList();
        }


    }
}
