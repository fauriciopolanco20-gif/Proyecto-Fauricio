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
     * Fecha: 10/05/2016
     * Descripciòn: Form  tipo control de usuario, se usa para la captura de información de los alumnos
     */
    public partial class AgregarAlumno : UserControl
    {
        private BaseDatos objBD;
        private string idAlumno;

        public string IdAlumno
        {
            get { return idAlumno; }
            set { idAlumno = value; }
        }
        private string carrera;

        public string Carrera
        {
            get { return carrera; }
            set { carrera = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private string apellidos;

        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }
        private string telefono;

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        private string direccion;

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        public AgregarAlumno()
        {
            InitializeComponent();
            llenarCombo();
        }

        private void AgregarAlumno_Load(object sender, EventArgs e)
        {

        }

        //LLena el combobox de con las carreras existentes en la tabla carrera.
        // el retorno de la consulta es un datatable, el cual se pasa al datasource del combobox
        public void llenarCombo() 
        {
            objBD = new BaseDatos();
            comboBox1.DataSource = objBD.obtenerCarreras();
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "idCarrera";
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            agregarAlumno();
        }

        private bool obtenerDatosAlumnos() 
        {
            if(txtID.Text != String.Empty && txtNombre.Text != String.Empty & txtApellidos.Text != String.Empty
                && txtTelefono.Text != String.Empty && txtDireccion.Text != String.Empty)
            {
                IdAlumno = txtID.Text;
                Carrera = Convert.ToString(comboBox1.SelectedValue);
                Nombre = txtNombre.Text;
                Apellidos = txtApellidos.Text;
                Telefono = txtTelefono.Text;
                Direccion = txtDireccion.Text;
                return true;
            }else 
            {
                return false;
            }
        }

        private void nuevoRegistro() 
        {
            txtID.Text = String.Empty;
            txtNombre.Text = String.Empty;
            txtApellidos.Text = String.Empty;
            txtTelefono.Text = String.Empty;
            txtDireccion.Text = String.Empty;
        }

        private void agregarAlumno() 
        {
            objBD = new BaseDatos();
            if (obtenerDatosAlumnos()) 
            {
                if (objBD.insertarRegistro("insert into alumnos values('" + IdAlumno + "','" + Carrera + "','" + Nombre
                                                                     + "','" + Apellidos + "','" + Telefono + "','" + Direccion + "')"))
                {
                    MessageBox.Show("Alumno registrado correctamente","Agregar alumno",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    nuevoRegistro();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al registrar al alumno", "Agregar alumno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } 
            else 
            {
                MessageBox.Show("Campos vacíos, por favor ingresa datos", "Agregar alumno", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
