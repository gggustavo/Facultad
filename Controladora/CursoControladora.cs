using Modelo;
using Modelo.Model;
using Modelo.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class CursoControladora
    {
        IRepository<Curso> repository;

        public CursoControladora()
        {
            repository = SingletonContext.GetContainer().GetInstance<IRepository<Curso>>();
        }

        public void AgregarCurso(Curso entity)
        {
            repository.Add(entity);
            repository.Commit(); 
        }

        public void EliminarCurso(Curso entity)
        {
            repository.Delete(entity);
            repository.Commit();
        }

        public IQueryable<Curso> ListCurso()
        {
            return repository.All();
        }

    }
}
