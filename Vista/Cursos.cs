using Controladora;
using Modelo.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class Cursos : Form
    {

        CursoControladora ctrcurso;
        public Cursos()
        {
            InitializeComponent();
            ctrcurso = new CursoControladora();
        }

        protected override void OnLoad(EventArgs e)
        {
            cursoBindingSource.DataSource = ctrcurso.ListCurso().ToList();
            base.OnLoad(e);
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(nombre.Text))
            {
                ctrcurso.AgregarCurso(new Curso() { Nombre = nombre.Text });
                cursoBindingSource.DataSource = ctrcurso.ListCurso().ToList();
            }
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            if (cursoBindingSource.Current != null)
            {
                Curso cursoDelete = ctrcurso.ListCurso().Where(c => c.CursoId == ((Curso)cursoBindingSource.Current).CursoId).FirstOrDefault();

                if (cursoDelete.Alumno.Any())
                {
                    MessageBox.Show("El curso que intenta borrar tiene alumnos relacionados");
                    return;
                }

                ctrcurso.EliminarCurso(cursoDelete);
                cursoBindingSource.DataSource = ctrcurso.ListCurso();
            }
        }
    }
}
