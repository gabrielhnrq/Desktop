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
    public partial class CadastrarCategoria : Form
    {
        // CONEXÃO COM O BANCO DE DADOS
        //SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-I1990IS\GABRIELSILVA;Initial Catalog=DBSRBOLETIM;Integrated Security=True");
        SqlConnection conn = new SqlConnection(@"workstation id=GabrielHPortal.mssql.somee.com;packet size=4096;user id=GabrielHenrique_SQLLogin_1;pwd=3g6uekrstq;data source=GabrielHPortal.mssql.somee.com;persist security info=False;initial catalog=GabrielHPortal");
        //CRIAR STRING DE COMANDO
        SqlCommand comando = new SqlCommand();
        //DATA READER
        SqlDataReader dr;
        public CadastrarCategoria()
        {
            InitializeComponent();
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Página HOME (Inicio)
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
        /// Editar e Excluir Usuários
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
        /// Página de Editar e Excluir Categorias
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editarEExcluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditarExcluirCategorias f1 = new EditarExcluirCategorias();
            f1.Show();
        }
        /// <summary>
        /// Ao Acionar Criarar a Categoria Solicitada do Campo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                comando.CommandText = "insert into Categories([Name]) values ('" + textBox1.Text + "')";
                comando.ExecuteNonQuery();
                conn.Close();
                textBox1.Clear();
                MessageBox.Show("Categoria Registrada com sucesso!. ", "Informação",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Dados Invalidos. ", "Informação",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Ao Iniciar conectar a Entrada de Dados (Banco de Dados)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CadastrarCategoria_Load(object sender, EventArgs e)
        {
            comando.Connection = conn;

        }
    }
}
