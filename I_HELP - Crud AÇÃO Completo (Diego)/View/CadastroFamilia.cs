using I_HELP.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace I_HELP.View
{
    public partial class CadastroFamilia : Form
    {
        public CadastroFamilia()
        {
            InitializeComponent();

            FamiliaController familiaController = new FamiliaController();

            dgvFamilia.DataSource = familiaController.BuscarPessoa("");


        }

        private void ttbBusca_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblBuscar.Visible = String.IsNullOrEmpty(ttbBusca.Text);
        }

        private void ttbBusca_KeyDown(object sender, KeyEventArgs e)
        {
            lblBuscar.Visible = String.IsNullOrEmpty(ttbBusca.Text);
        }

        private void ttbBusca_KeyUp(object sender, KeyEventArgs e)
        {
            lblBuscar.Visible = String.IsNullOrEmpty(ttbBusca.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ttbBusca.Text.Replace(" ","").Length>0)
            {
                FamiliaController familiaController = new FamiliaController();

                dgvFamilia.DataSource = familiaController.BuscarPessoa(ttbBusca.Text);
            }
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            CriarFamilia tela = new CriarFamilia();
            tela.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show(dgvFamilia.CurrentCell.RowIndex.ToString());
        }
    }
}
