using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecGabrielHenriqueDES
{
    public partial class EditarExcluirCategorias : Form
    {
        // CONEXÃO COM O BANCO DE DADOS
        //SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-I1990IS\GABRIELSILVA;Initial Catalog=DBSRBOLETIM;Integrated Security=True");
        SqlConnection conn = new SqlConnection(@"workstation id=GabrielHPortal.mssql.somee.com;packet size=4096;user id=GabrielHenrique_SQLLogin_1;pwd=3g6uekrstq;data source=GabrielHPortal.mssql.somee.com;persist security info=False;initial catalog=GabrielHPortal");
        //CRIAR STRING DE COMANDO
        SqlCommand comando = new SqlCommand();
        //DATA READER
        SqlDataReader dr;
        public EditarExcluirCategorias()
        {
            InitializeComponent();
            

        }
        /// <summary>
        /// Cadastro de Categorias
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
        /// Método Carregar Lista de Categorias quando solicitado
        /// </summary>
        private void CARREGARLISTA()
        {

            conn.Open();
            comando.CommandText = "select * from Categories";
            dr = comando.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    comboBox1.Items.Add (dr[1].ToString());
                }
            }
            conn.Close();

        }
        /// <summary>
        /// Página de Incicio (Home)
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
        /// <summary>
        /// Página de Editar e Excluir Usuários
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditarExcluirUsuarios f1 = new EditarExcluirUsuarios();
            f1.Show();
        }

        private void editarEExcluirToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void EditarExcluirCategorias_Load(object sender, EventArgs e)
        {
            comando.Connection = conn;
            CARREGARLISTA();
        }
        /// <summary>
        /// Método de Mostra Categorias
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            comando.CommandText = "select * from Categories WHERE [Name] = '" + comboBox1.Text + "'";
            dr = comando.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    textBox2.Text = (dr[1].ToString());
                }
            }
            conn.Close();
        }
        /// <summary>
        /// Método de Atualizar Dados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                if (textBox2.Text == "")
                {

                    MessageBox.Show("Busque a Categoria Selecionada. ", "Informação",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                  
                   
                }
                else
                {
                    conn.Open();
                    comando.CommandText = "SELECT * FROM Categories UPDATE Categories SET Name = '" + textBox2.Text + "' where [Name] = '" + comboBox1.Text + "' ";
                    comando.ExecuteNonQuery();
                    conn.Close();
                    textBox2.Clear();
                    comboBox1.Items.Clear();
                    comboBox1.Text = "";
                    CARREGARLISTA();
                    MessageBox.Show("Categoria Atualizada. ", "Informação",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Dados Invalidos. ", "Informação",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }
        /// <summary>
        /// Método de Excluir Categorias
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "")
                {

                MessageBox.Show("Busque a Categoria Selecionada. ", "Informação",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                }
                else
                {
                    conn.Open();
                    comando.CommandText = "SELECT * FROM Categories DELETE Categories where [Name] = '" + comboBox1.Text + "' ";
                    comando.ExecuteNonQuery();
                    conn.Close();
                    textBox2.Clear();
                    comboBox1.Items.Clear();
                    comboBox1.Text = "";
                    CARREGARLISTA();
                    MessageBox.Show("Categoria Deletada. ", "Informação",
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
