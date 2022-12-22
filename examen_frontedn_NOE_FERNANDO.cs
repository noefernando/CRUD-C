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

namespace examen_backend_NOE_FERNANDO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conexion.Conectar();
            MessageBox.Show("Conexion exitosa");
            dataGridView1.DataSource = llenar_grid();
        }

        public DataTable llenar_grid()
        {
            conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "SELECT*FROM usuario";
            SqlCommand cmd = new SqlCommand(consulta,conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            return dt;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            conexion.Conectar();
            string insertar = "INSERT INTO usuario (nombre,email,pass) values (@nombre,@email,@pass)";
            SqlCommand cmd1 = new SqlCommand(insertar,conexion.Conectar());
            
            //cmd1.Parameters.AddWithValue("@id", txtID.Text); Tiene identity
            cmd1.Parameters.AddWithValue("@nombre", txtNombre.Text);
            cmd1.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd1.Parameters.AddWithValue("@pass", txtPass.Text);

            cmd1.ExecuteNonQuery();

            MessageBox.Show("Datos ingresados");

            dataGridView1.DataSource = llenar_grid();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            conexion.Conectar();
            string update = "UPDATE usuario SET nombre=@nombre, email=@email, pass=@pass where id=@id";
            SqlCommand cmd2 = new SqlCommand(update, conexion.Conectar());

            cmd2.Parameters.AddWithValue("@id", txtID.Text);
            cmd2.Parameters.AddWithValue("@nombre", txtNombre.Text);
            cmd2.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd2.Parameters.AddWithValue("@pass", txtPass.Text);

            cmd2.ExecuteNonQuery();

            MessageBox.Show("Datos actualizados");

            dataGridView1.DataSource = llenar_grid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtEmail.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtPass.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            }
            catch { }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            conexion.Conectar();
            string DELETE = "DELETE usuario FROM usuario where id=@id";

            SqlCommand cmd3 = new SqlCommand(DELETE, conexion.Conectar());

            cmd3.Parameters.AddWithValue("@id", txtID.Text);
            cmd3.Parameters.AddWithValue("@nombre", txtNombre.Text);
            cmd3.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd3.Parameters.AddWithValue("@pass", txtPass.Text);

            cmd3.ExecuteNonQuery();
            MessageBox.Show("Datos Eliminados");
            dataGridView1.DataSource = llenar_grid();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtNombre.Text = "";
            txtEmail.Text = "";
            txtPass.Text = "";
        }
    }
}
