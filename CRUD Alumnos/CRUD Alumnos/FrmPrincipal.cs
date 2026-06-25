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
     * Fecha: 10/05/2017
     * Descripciòn: Este es el formulario principal del CRUD Alumnos, sobre el form se muestran los controles de usuario, editar alumnos
     * y agregar alumnos
     */
    public partial class FrmPrincipal : Form
    {
        private AgregarAlumno objA;
        private EliminarEditarAl objAE;
        private BaseDatos objBD;
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void agregarAlumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirAgregarAlumno();
        }

        private void abrirAgregarAlumno() 
        {
            if(!panel1.Controls.Contains(objA))
            {
                panel1.Controls.Clear();
                objA = new AgregarAlumno();
                objA.Location = new Point(120, 20);
                panel1.Controls.Add(objA);
            }
        }

        private void abrirEliminarAlumno() 
        {
            panel1.Controls.Clear();
            objAE = new EliminarEditarAl();
            panel1.Controls.Add(objAE);
        }

        private void eliminarEditarAlumno() 
        {
            objAE = new EliminarEditarAl();

        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Width += 5;
            pictureBox1.Height += 5;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Width -= 5;
            pictureBox1.Height -= 5;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Width += 5;
            pictureBox2.Height += 5;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Width -= 5;
            pictureBox2.Height -= 5;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Width += 5;
            pictureBox3.Height += 5;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Width -= 5;
            pictureBox3.Height -= 5;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            abrirAgregarAlumno();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            abrirEliminarAlumno();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }       
       
    }
}
