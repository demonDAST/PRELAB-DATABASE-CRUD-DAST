using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRELAB_DATABASE_CRUD_DAST
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void pb1_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn1_MouseEnter(object sender, EventArgs e)
        {
            btn1.ForeColor = Color.White;
        }

        private void btn1_MouseLeave(object sender, EventArgs e)
        {
            btn1.ForeColor = Color.Black;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            string usuario = txt1.Text;      
            string contrasena = txt2.Text; 
           
            if (usuario == "DAST" && contrasena == "1234")
            { 
                CRUD v2 = new CRUD();
                v2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
