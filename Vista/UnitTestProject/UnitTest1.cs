using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestIEnumerablePerformance()
        {
            var two = Listar(new Curso().ListCursos() as IEnumerable<Curso>);
        }

        [TestMethod]
        public void TestIQueryablePerformance()
        {
            var two = Listar(new Curso().ListCursos() as IQueryable<Curso>);
        }


        private IEnumerable<Curso> Listar(IQueryable<Curso> curso)
        {
            var watch = new Stopwatch();
            watch.Start();
            var result = curso.Where(_ => _.Nombre != null);
            watch.Stop();
            Console.WriteLine("Completed IQueryable in {0} seconds.", watch.Elapsed.TotalSeconds);
            return result;
        }

        private IEnumerable<Curso> Listar(IEnumerable<Curso> curso)
        {
            var watch = new Stopwatch();
            watch.Start();
            var result = curso.Where(_ => _.Nombre != null);
            watch.Stop();
            Console.WriteLine("Completed IEnumerable in {0} seconds.", watch.Elapsed.TotalSeconds);
            return result;
        }


    }
}
