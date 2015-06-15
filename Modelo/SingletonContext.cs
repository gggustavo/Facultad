using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class SingletonContext
    {

        private static Container Container = null;

        public static void CreateInstance()
        {
            Bootstrap();
        }

        private static void Bootstrap()
        {
            if (Container == null)
            {
                Container = new Container();
                Container.Register<DbContext, UaiFacultadContext>();
                Container.Register<Modelo.Repository.IRepository<Modelo.Model.Curso>, Modelo.Repository.EFRepository<Modelo.Model.Curso>>();
                Container.Register<Modelo.Repository.IRepository<Modelo.Model.Alumno>, Modelo.Repository.EFRepository<Modelo.Model.Alumno>>();
            }
        }

        public static Container GetContainer()
        {
            return Container;
        }

    }
}
