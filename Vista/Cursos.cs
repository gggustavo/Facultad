namespace Vista
{
    using Controladora;
    using Modelo.Model;
    using System;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;

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
            cursoBindingSource.DataSource = ctrcurso.ListarCursos().GetEnumerator();
            base.OnLoad(e);
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(nombre.Text))
            {
                ctrcurso.AgregarCurso(new Curso() { Nombre = nombre.Text });
                cursoBindingSource.DataSource = ctrcurso.ListarCursos().GetEnumerator();
            }
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            if (cursoBindingSource.Current != null)
            {
                var cursoId = ((Curso)cursoBindingSource.Current).CursoId;
                var cursoDelete = ctrcurso.ListarCursos()
                                        .Where(_ => _.CursoId == cursoId).First();

                if (cursoDelete.Alumno.Any())
                {
                    MessageBox.Show("El curso que intenta borrar tiene alumnos relacionados");
                    return;
                }

                ctrcurso.EliminarCurso(cursoDelete);
                cursoBindingSource.DataSource = ctrcurso.ListarCursos().GetEnumerator();
            }
        }
    }
}
