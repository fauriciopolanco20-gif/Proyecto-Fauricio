using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Alumnos
{
    /*
     * Autor : Jose Manuel Gómez Alavez
     * Fecha: 10/05/2016
     * Descripciòn:Formulario para la edicion de datos de los alumnos, se muestra sobre el formulario principal
     */
    public partial class frmEditar : Form
    {
        private BaseDatos objBD;
        private EliminarEditarAl objEdit;
        private string idAlumno;

        //Contructors, recibe como parametro el form EliminarEditarAl  y los datos del alumno a modificar
        //El primer parametro es para actualizar los datos de la tabla al momento de cerrar el formulario de edicion de alumnos
        public frmEditar(EliminarEditarAl frm,string idAlumno,string nombre,string apellidos,string carrera,string telefono,string direccion)
        {
            InitializeComponent();
            objEdit = frm;
            this.idAlumno = idAlumno;
            cargarDatosAlumnos(nombre,apellidos,carrera,telefono,direccion);
            desactivarEdicion();
        }

        
        private void frmEditar_Load(object sender, EventArgs e)
        {
            
        }


        private void cargarDatosAlumnos(string nombre, string apellidos, string carrera, string telefono, string direccion) 
        {
            txtNombre.Text = nombre;
            txtApellidos.Text = apellidos;
            cargarComboCarreras(carrera);
            txtTelefono.Text = telefono;
            txtDireccion.Text = direccion;
        }

        private void actualizarDatosAlumnos() 
        {
            string idAlumno = this.idAlumno;
            string nombre = txtNombre.Text;
            string apellidos =  txtApellidos.Text;
            string idcarrera = comboBox1.SelectedValue.ToString();
            string telefono = txtTelefono.Text;
            string direccion = txtDireccion.Text;

            objBD = new BaseDatos();
            if (objBD.actualizarAlumno(idAlumno, idcarrera, nombre, apellidos, telefono, direccion))
            {
                DialogResult resultado = MessageBox.Show("Datos actualizados correctamente", "Editar Alumnos",MessageBoxButtons.OK,MessageBoxIcon.Information);
                if(resultado == DialogResult.OK)
                    objEdit.actualizarDgv();
            }
            else 
            {
                MessageBox.Show("Error al actualizar datos","Editar Alumnos",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void desactivarEdicion() 
        {
            txtNombre.Enabled = false;
            txtApellidos.Enabled = false;
            comboBox1.Enabled = false;
            txtTelefono.Enabled = false;
            txtDireccion.Enabled = false;
        }

        private void activarEdicion() 
        {
            txtNombre.Enabled = true;
            txtApellidos.Enabled = true;
            comboBox1.Enabled = true;
            txtTelefono.Enabled = true;
            txtDireccion.Enabled = true;
            
        }
        private void cargarComboCarreras(string carrera) 
        {
            objBD = new BaseDatos();
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "idCarrera";
            comboBox1.DataSource = objBD.obtenerCarreras();
            comboBox1.SelectedValue = carrera;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            intercambiarBoton();
        }

        private void intercambiarBoton() 
        {
            if (!txtNombre.Enabled)
            {
                activarEdicion();
                button1.Text = "Guardar";
            }
            else 
            {
                actualizarDatosAlumnos();
                objEdit.actualizarDgv();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            eliminarAlumno();
            this.Close();
        }

        private void eliminarAlumno() 
        {
            objBD = new BaseDatos();
            if (objBD.eliminarAlumno(idAlumno))
            {
               DialogResult resultado =  MessageBox.Show("Alumno eliminado correctamente","Editar Alumnos",MessageBoxButtons.OK,MessageBoxIcon.Information);
               if(resultado == DialogResult.OK)
                    objEdit.actualizarDgv();
            }
            else 
            {
                MessageBox.Show("Error al eliminar el alumnos", "Editar Alumnos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
