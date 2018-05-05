using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecGabrielHenriqueDES
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Método ir Página Usuários
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
        /// Método Editar e Excluir Usuários
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
        /// Método ir Página de Categorias
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
        /// Método Editar e Excluir Categorias
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editarEExcluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditarExcluirCategorias f1 = new EditarExcluirCategorias();
            f1.Show();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {

        }
    }
}
