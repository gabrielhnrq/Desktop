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
    public partial class EditarExcluirUsuarios : Form
    {
        // CONEXÃO COM O BANCO DE DADOS
        //SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-I1990IS\GABRIELSILVA;Initial Catalog=DBSRBOLETIM;Integrated Security=True");
        SqlConnection conn = new SqlConnection(@"workstation id=GabrielHPortal.mssql.somee.com;packet size=4096;user id=GabrielHenrique_SQLLogin_1;pwd=3g6uekrstq;data source=GabrielHPortal.mssql.somee.com;persist security info=False;initial catalog=GabrielHPortal");
        //CRIAR STRING DE COMANDO
        SqlCommand comando = new SqlCommand();
        //DATA READER
        SqlDataReader dr;
        public EditarExcluirUsuarios()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Página de Cadastro de Usuários
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CadastroUsuarios f1 = new CadastroUsuarios();
            f1.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Método de Mostrar Usuário
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            comando.CommandText = "select * from AspNetUsers WHERE [Email] = '" + comboBox2.Text + "'";
            dr = comando.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    textBox3.Text = (dr[1].ToString());
                }
            }
            conn.Close();
        }
        /// <summary>
        /// ir Página de Inicio (HOME)
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
        /// ir Página de Categoria
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
        /// Ir Página de Editar e Excluir (Categorias)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editarEExcluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditarExcluirCategorias f1 = new EditarExcluirCategorias();
            f1.Show();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Carregar todos os Email dos Usuários Cadastrados
        /// </summary>
        private void CARREGARLISTA()
        {

            conn.Open();
            comando.CommandText = "select * from AspNetUsers";
            dr = comando.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    comboBox2.Items.Add(dr[1].ToString());
                }
            }
            conn.Close();

        }
        /// <summary>
        /// Criptografia Hash MD5 (ASPNET TRATAR APENAS COM CRIPTOGRAFIA EM SENHAS) 
        /// </summary>
        private void Criptografia()
        {
            string password;
            password = textBox4.Text;
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
            byte[] hash = md5.ComputeHash(inputBytes);
            password = BitConverter.ToString(hash).Replace("-", "");
            label3.Text = password.ToString().ToLower();
        }
        /// <summary>
        /// Método Carregar Sessao de Entrada no Banco, e Lista de Usuários
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditarExcluirUsuarios_Load(object sender, EventArgs e)
        {
            comando.Connection = conn;
            CARREGARLISTA();
        }
        /// <summary>
        /// Método Buscar Email, Podendo Editar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox2.Text == "")
                {

                    MessageBox.Show("Busque a Email Selecionada. ", "Informação",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                }
                else
                {
                    conn.Open();
                    comando.CommandText = "SELECT * FROM AspNetUsers UPDATE AspNetUsers SET Email = '" + textBox3.Text + "' where [Email] = '" + comboBox2.Text + "' ";
                    comando.ExecuteNonQuery();
                    comando.CommandText = "SELECT * FROM AspNetUsers UPDATE AspNetUsers SET UserName = '" + textBox3.Text + "' where [UserName] = '" + comboBox2.Text + "' ";
                    comando.ExecuteNonQuery();
                    Criptografia();
                    comando.CommandText = "SELECT * FROM AspNetUsers UPDATE AspNetUsers SET [PasswordHash] = '" + label3.Text + "' where [Email]= '" + comboBox2.Text + "' ";
                    comando.ExecuteNonQuery();
                    conn.Close();
                    textBox3.Clear();
                    comboBox2.Items.Clear();
                    comboBox2.Text = "";
                    label4.Visible = true;
                    label3.Visible = true;
                    CARREGARLISTA();
                    MessageBox.Show("Usuário Atualizada. ", "Informação",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    label4.Visible = false;
                    label3.Visible = false;
                    textBox4.Clear();

                }
            }
            catch
            {
                MessageBox.Show("Dados Invalidos. ", "Informação",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           

        }
        /// <summary>
        /// Método de Deletar Usuário
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox2.Text == "")
                {

                    MessageBox.Show("Busque a Categoria Selecionada. ", "Informação",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                }
                else
                {
                    conn.Open();
                    comando.CommandText = "SELECT * FROM AspNetUsers DELETE AspNetUsers where [Email] = '" + comboBox2.Text + "' ";
                    comando.ExecuteNonQuery();
                    conn.Close();
                    comboBox2.Items.Clear();
                    comboBox2.Text = "";
                    CARREGARLISTA();
                    MessageBox.Show("Usuário Deletado. ", "Informação",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Dados Invalidos. ", "Informação",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
