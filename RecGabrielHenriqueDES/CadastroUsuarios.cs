using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecGabrielHenriqueDES
{
    public partial class CadastroUsuarios : Form
    {
        // CONEXÃO COM O BANCO DE DADOS
        //SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-I1990IS\GABRIELSILVA;Initial Catalog=DBSRBOLETIM;Integrated Security=True");
        SqlConnection conn = new SqlConnection(@"workstation id=GabrielHPortal.mssql.somee.com;packet size=4096;user id=GabrielHenrique_SQLLogin_1;pwd=3g6uekrstq;data source=GabrielHPortal.mssql.somee.com;persist security info=False;initial catalog=GabrielHPortal");
        //CRIAR STRING DE COMANDO
        SqlCommand comando = new SqlCommand();
        //DATA READER
        SqlDataReader dr;
        private string password;
        public CadastroUsuarios()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Ir para Home (Página)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home f1 = new Home();
            f1.Show();
        }
        /// <summary>
        /// Página de Editar Usuarios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditarExcluirUsuarios f1 = new EditarExcluirUsuarios();
            f1.Show();
        }
        /// <summary>
        /// Página Editar e Excluir Usuários
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CadastrarCategoria f1 = new CadastrarCategoria();
            f1.Show();
        }
        /// <summary>
        /// Página Editar e Excluir Categorias
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editarEExcluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditarExcluirCategorias f1 = new EditarExcluirCategorias();
            f1.Show();
        }

        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Criptografia da Senha HASH MD5
        /// </summary>
        private void Criptografia()
        {
            password = textBox4.Text;
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
            byte[] hash = md5.ComputeHash(inputBytes);
            password = BitConverter.ToString(hash).Replace("-", "");
            label2.Text = password.ToString().ToLower();
        }
        /// <summary>
        /// Carregar Usuários
        /// </summary>
        private void CARREGARLISTA()
        {

            conn.Open();
            comando.CommandText = "select * from AspNetUsers";
            dr = comando.ExecuteReader();
            if (dr.HasRows)
            {
                string valor;
                while (dr.Read())
                {
                    label8.Text = (dr[0].ToString());
                    valor = Convert.ToString(label8.Text);
                    valor = (label8.Text) + 1;
                    label8.Text = valor.ToString();
                }
            }
            conn.Close();

        }
        /// <summary>
        /// Ao Clickar Inserir Campos que Foram Preenchidos, Criando um Login ao Sucesso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" & textBox2.Text == "" & textBox3.Text == "" & textBox4.Text == "")
            {
                MessageBox.Show("Preencher Campos. ", "Informação",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Criptografia();
                    conn.Open();
                    comando.CommandText = "insert into AspNetUsers([Id],[Email],[EmailConfirmed],[PasswordHash],[SecurityStamp],[PhoneNumber],[PhoneNumberConfirmed],[TwoFactorEnabled],[LockoutEndDateUtc],[LockoutEnabled],[AccessFailedCount],[UserName]) values ('" + label8.Text + "','" + textBox3.Text + "','" + 0 + "','" + label2.Text + "','" + label9.Text + "','" + "" + "','" + 0 + "','" + 0 + "','" + "" + "','" + 1 + "','" + 0 + "','" + textBox3.Text + "')";
                    comando.ExecuteNonQuery();
                    conn.Close();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    label7.Visible = true;
                    label2.Visible = true;
                    MessageBox.Show("Registro Criado com sucesso!. ", "Informação",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    label7.Visible = false;
                    label2.Visible = false;
                }
                catch
                {
                    MessageBox.Show("Dados Invalidos. ", "Informação",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
                  
             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// Ao Iniciar Entrada do Banco e Iniciar Entrada de Dados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CadastroUsuarios_Load(object sender, EventArgs e)
        {
            comando.Connection = conn;
            CARREGARLISTA();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
