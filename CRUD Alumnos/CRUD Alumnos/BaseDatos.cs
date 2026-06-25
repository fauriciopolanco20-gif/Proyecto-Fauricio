using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace CRUD_Alumnos
{
    /
    class BaseDatos
    {
        private MySqlConnection conexion;
        private string servidor;
        private string baseDatos;
        private string usuario;
        private string password;
        public BaseDatos() 
        {
            establecerConfiguracion();
        }

        //Se configura la conexion al SGBD MySql, el constructor de la clase MySqlConnection establece la conexion de
        //acuerdo a los parametros establecidos.
        private void establecerConfiguracion() 
        {
            servidor = "localhost";
            baseDatos = "escuela";
            usuario = "root";
            password = "";
            string cadenaConexion = "SERVER=" + servidor + ";" + "DATABASE=" + baseDatos + ";" + "UID=" + usuario + ";" + "PASSWORD=" + password + ";";
            conexion = new MySqlConnection(cadenaConexion);
        }

        public bool abrirConexion() 
        {
            try
            {
                conexion.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }
        public bool cerrarConexion() 
        {
            try 
            {
                conexion.Close();
                return true;
            }
            catch(MySqlException ex)
            {
                return false;
            }
        }

        public bool insertarRegistro(string query) 
        {
            try 
            {
                if (abrirConexion())
                {
                    MySqlCommand cmd = new MySqlCommand(query,conexion);
                    cmd.ExecuteNonQuery();
                    this.cerrarConexion();
                    return true;
                }
                else { return false; }
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Error en el registro "+ex);
                return false;
            }
        }

        public DataTable obtenerCarreras() 
        {
            DataTable dt = new DataTable();
            string query = "select * from carreras";

            try
            {
                if (abrirConexion())
                {

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    MySqlDataAdapter dataA = new MySqlDataAdapter(cmd);
                    dataA.Fill(dt);
                    this.cerrarConexion();

                }
                else 
                {
                    MessageBox.Show("Ocurrio un error en la consulta a la BD");
                }
                return dt;
                
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Error en la consulta "+ex);
                return dt;
            }
        }

        public DataTable obtenerAlumnos(string idA) 
        {
            string query = "select idalumno,alumnos.idCarrera,alumnos.nombre,apellidos,carreras.nombre as carrera,telefono,direccion from alumnos"
                            +",carreras where carreras.idCarrera = alumnos.idcarrera and  idAlumno =" + "'" + idA + "'";
            DataTable dt = new DataTable();
            try
            {
                if(abrirConexion())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    MySqlDataAdapter adt = new MySqlDataAdapter(cmd);
                    adt.Fill(dt);
                    this.cerrarConexion();
                }
                return dt;
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Error en la consulta " + ex);
                return dt;
            }
        }

        public DataTable obtenerTodosAlumnos()
        {
            string query = "select idalumno,alumnos.idCarrera as idcarrera,alumnos.nombre,apellidos,carreras.nombre as carrera,telefono,direccion from alumnos"
                            + ",carreras where carreras.idCarrera = alumnos.idcarrera";
            DataTable dt = new DataTable();
            try
            {
                if (abrirConexion())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    MySqlDataAdapter adt = new MySqlDataAdapter(cmd);
                    adt.Fill(dt);
                    this.cerrarConexion();
                }
                return dt;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error en la consulta " + ex);
                return dt;
            }
        }

        public bool actualizarAlumno(string idAlumno,string idCarrera,string nombre,string apellidos,string telefono,string direccion) 
        {
            string query = "update alumnos set idCarrera=@idCarrera,nombre=@nombre,apellidos=@apellidos,"
                            +"telefono=@telefono,direccion=@direccion where idalumno=@idAlumno"; 
            try
            {
                if(abrirConexion())
                {
                    MySqlCommand cmd = new MySqlCommand(query,conexion);
                    cmd.Parameters.AddWithValue("@idCarrera",idCarrera);
                    cmd.Parameters.AddWithValue("@nombre",nombre);
                    cmd.Parameters.AddWithValue("@apellidos", apellidos);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@direccion", direccion);
                    cmd.Parameters.AddWithValue("@idAlumno", idAlumno);
                    cmd.ExecuteNonQuery();
                    return true;
                }else
                {
                    return false;
                }
            }catch(MySqlException)
            {
                return false;
            }

        }

        public bool eliminarAlumno(string idAlumno) 
        {
            string query = "delete from alumnos where idAlumno =@idAlumno";
            try 
            {
                if (abrirConexion())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@idAlumno",idAlumno);
                    cmd.ExecuteNonQuery();
                    return true;
                } 
                else
                {
                    return false;
                }
            }
            catch(MySqlException ex)
            {
                return false;
            }
        }


    }
}
