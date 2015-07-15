namespace Controladora
{
    using Modelo;
    using Modelo.Model;
    using Modelo.Repository;
    using System.Collections.Generic;

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

        public IEnumerable<Curso> ListarCursos()
        {
            foreach (var item in repository.GetAll())
            {
                yield return item;
            }
        }

    }
}
