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
    public partial class FrmCadastro : Form 
    {
        public FrmCadastro() 
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-10E4PJ8\SQLEXPRESS01;Initial Catalog=LoginC#;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        private void FrmCadastro_Load(object sender, EventArgs e) 
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e) 
        {
            if (txtuserC.Text == "" && txtpassC.Text == "") 
            {
                MessageBox.Show("Usuário ou senha errada", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
            else if (txtpassCF.Text == txtpassC.Text) 
            {
                con.Open();
                string Cadastro = "insert into user_tb values('" + txtuserC.Text + "','" + txtpassC.Text + "')";
                cmd = new SqlCommand(Cadastro, con);
                cmd.ExecuteReader();
                con.Close();
                txtuserC.Text = ""; txtpassC.Text = ""; txtpassCF.Text = "";
                MessageBox.Show("Usuário criado com sucesso", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
            else 
            {
                MessageBox.Show("as senha são diferentes", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblLogin_Click(object sender, EventArgs e) 
        {
            new FrmLogin().Show();
            this.Hide();
        }
    }
}
