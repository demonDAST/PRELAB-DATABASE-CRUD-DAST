using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace PRELAB_DATABASE_CRUD_DAST
{
    public partial class CRUD : Form
    {
        string conexion = "Data Source=DESKTOP-OEFHTVH\\SQLEXPRESS;Initial Catalog=DATABASE_CRUD;Integrated Security=True";
        private void MostrarDatos()
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Estudiantes", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
        }
        public CRUD()
        {
            InitializeComponent();
            MostrarDatos();
        }

        private void CRUD_Load(object sender, EventArgs e)
        {

        }
        private void Limpiar()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtGrado.Clear();
            txtSeccion.Clear();
            txtTelefono.Clear();
            txtMatricula.Clear();
            txtCiclo.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();
            dtpFecha.Value = DateTime.Now;
            txtProfesor.Clear();
            txtObs.Clear();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    con.Open();
                    string query = "INSERT INTO Estudiantes (Nombre, Grado, Seccion, Telefono, Matricula, Ciclo, Correo, Direccion, FechaNacimiento, Tutor, Observaciones) " +
                                   "VALUES (@Nombre, @Grado, @Seccion, @Telefono, @Matricula, @Ciclo, @Correo, @Direccion, @FechaNacimiento, @Tutor, @Observaciones)";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@Grado", txtGrado.Text);
                    cmd.Parameters.AddWithValue("@Seccion", txtSeccion.Text);
                    cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                    cmd.Parameters.AddWithValue("@Matricula", txtMatricula.Text);
                    cmd.Parameters.AddWithValue("@Ciclo", txtCiclo.Text);
                    cmd.Parameters.AddWithValue("@Correo", txtCorreo.Text);
                    cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text);

                    DateTime fechaNacimiento;
                    if (DateTime.TryParse(dtpFecha.Text, out fechaNacimiento))
                    {
                        cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                    }
                    else
                    {
                        MessageBox.Show("Fecha de nacimiento inválida.");
                        return;
                    }

                    cmd.Parameters.AddWithValue("@Tutor", txtProfesor.Text);
                    cmd.Parameters.AddWithValue("@Observaciones", txtObs.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Registro agregado exitosamente.");
                    MostrarDatos(); // Refrescamos la tabla
                    Limpiar(); // Limpiamos los campos
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar registro: " + ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    con.Open();
                    string query = "UPDATE Estudiantes SET Nombre=@Nombre, Grado=@Grado, Seccion=@Seccion, Telefono=@Telefono, Matricula=@Matricula, Ciclo=@Ciclo, Correo=@Correo, Direccion=@Direccion, FechaNacimiento=@FechaNacimiento, Tutor=@Tutor, Observaciones=@Observaciones WHERE Id=@Id";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@Id", txtId.Text);
                    cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@Grado", txtGrado.Text);
                    cmd.Parameters.AddWithValue("@Seccion", txtSeccion.Text);
                    cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                    cmd.Parameters.AddWithValue("@Matricula", txtMatricula.Text);
                    cmd.Parameters.AddWithValue("@Ciclo", txtCiclo.Text);
                    cmd.Parameters.AddWithValue("@Correo", txtCorreo.Text);
                    cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text);

                    DateTime fechaNacimiento;
                    if (DateTime.TryParse(dtpFecha.Text, out fechaNacimiento))
                    {
                        cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                    }
                    else
                    {
                        MessageBox.Show("Fecha de nacimiento inválida.");
                        return;
                    }

                    cmd.Parameters.AddWithValue("@Tutor", txtProfesor.Text);
                    cmd.Parameters.AddWithValue("@Observaciones", txtObs.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Registro actualizado exitosamente.");
                    MostrarDatos();
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar registro: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    con.Open();
                    string query = "DELETE FROM Estudiantes WHERE Id=@Id";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@Id", txtId.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Registro eliminado exitosamente.");
                    MostrarDatos();
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar registro: " + ex.Message);
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgv.Rows[e.RowIndex];

                txtId.Text = fila.Cells["Id"].Value.ToString();
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtGrado.Text = fila.Cells["Grado"].Value.ToString();
                txtSeccion.Text = fila.Cells["Seccion"].Value.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
                txtMatricula.Text = fila.Cells["Matricula"].Value.ToString();
                txtCiclo.Text = fila.Cells["Ciclo"].Value.ToString();
                txtCorreo.Text = fila.Cells["Correo"].Value.ToString();
                txtDireccion.Text = fila.Cells["Direccion"].Value.ToString();
                dtpFecha.Text = fila.Cells["FechaNacimiento"].Value.ToString();
                txtProfesor.Text = fila.Cells["Tutor"].Value.ToString();
                txtObs.Text = fila.Cells["Observaciones"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Creditos v3 = new Creditos();
            v3.Show();
            this.Hide();
        }
    }
}
