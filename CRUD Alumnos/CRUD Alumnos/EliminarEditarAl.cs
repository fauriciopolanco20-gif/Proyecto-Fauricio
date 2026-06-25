using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Alumnos
{
    /*
     * Autor : Jose Manuel Gómez Alavez
     * Fecha: 10/05/2017
     * Descripciòn: Control de usuario para eliminar y editar los registros que se muestran en un datagridview
     */
    public partial class EliminarEditarAl : UserControl
    {
        private BaseDatos objBD;
        private frmEditar objF;
        public EliminarEditarAl()
        {
            InitializeComponent();
            objBD = new BaseDatos();
        }

        private void EliminarEditarAl_Load(object sender, EventArgs e)
        {

        }

        public void actualizarDgv() 
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = objBD.obtenerTodosAlumnos() ;
            dataGridView1.Refresh();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            llenarDatagrid();
        }

        private void llenarDatagrid() 
        {
            string idAlumno = txtID.Text;
            inicializarDgv();
            DataTable dt = objBD.obtenerAlumnos(idAlumno);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }
            else 
            {
                MessageBox.Show("No se encuentran alumnos registrados con el id ingresado","Editar Alumnos",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            
            
        }

        public void inicializarDgv() 
        {
            idAlumno.DataPropertyName = "idalumno";
            idcarrera.DataPropertyName = "idcarrera";
            colNombre.DataPropertyName = "nombre";
            colApellidos.DataPropertyName = "apellidos";
            colCarrera.DataPropertyName = "carrera";
            colTelefono.DataPropertyName = "telefono";
            colDireccion.DataPropertyName = "direccion";
            dataGridView1.AutoGenerateColumns = false; //Evita que 1
        }

        public void mostrarTodosAlumnos() 
        {
            inicializarDgv();
            dataGridView1.DataSource = objBD.obtenerTodosAlumnos();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void obtenerDatosAlumnos() 
        {
            
            string nombre = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string apellidos = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string telefono = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            string direccion = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            string idAlumno = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            string carrera = dataGridView1.CurrentRow.Cells[6].Value.ToString();

            objF = new frmEditar(this,idAlumno,nombre,apellidos,carrera,telefono,direccion);
            //objF = new frmEditar(this);
            objF.ShowDialog();
        }

        private void btnCheck_CheckedChanged(object sender, EventArgs e)
        {
            if(btnCheck.Checked)
            {
                mostrarTodosAlumnos();
            }
            else if (!btnCheck.Checked) 
            {
                dataGridView1.DataSource = null;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            obtenerDatosAlumnos();
        }

    }
}
