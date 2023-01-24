using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Login 
{
    public partial class FrmLogin : Form 
    {
        public FrmLogin() 
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e) 
        {

        }

        private void btnLogin_Click(object sender, EventArgs e) 
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-10E4PJ8\SQLEXPRESS01;Initial Catalog=LoginC#;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            string login = "select*from user_tb where usuario='" + txtuser.Text + "'and senha='" + txtpass.Text + "'";
            cmd = new SqlCommand(login, con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true) 
            {
                new Form3().Show();
                this.Hide();
            } 
            else 
            {
                MessageBox.Show("Usuário ou senha inválida", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lblCadastre_Click(object sender, EventArgs e)
        {
            new FrmCadastro().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            if (txtpass.PasswordChar == '*') 
            {
                button1.BringToFront();
                txtpass.PasswordChar = '\0';
            }
        }

        private void button2_Click(object sender, EventArgs e) 
        {
            if (txtpass.PasswordChar == '\0') 
            {
                button2.BringToFront();
                txtpass.PasswordChar = '*';
            }
        }
    }
}
