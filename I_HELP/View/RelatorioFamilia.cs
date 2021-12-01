using I_HELP.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace I_HELP.View
{
    public partial class RelatorioFamilia : Form
    {
        public RelatorioFamilia()
        {
            InitializeComponent();

            FamiliaController familiaController = new FamiliaController();

            dgvFamilia.DataSource = familiaController.BuscarPessoa("");
            dgvFamilia.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvFamilia.Columns[0].HeaderText = "#";
            dgvFamilia.Columns[1].HeaderText = "REGISTRO";
            dgvFamilia.Columns[2].HeaderText = "CIDADE";
            
        }


        private void btnCriar_Click(object sender, EventArgs e)
        {
            CadastroFamilia tela = new CadastroFamilia();
            tela.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {            
            CadastroFamilia tela = new CadastroFamilia(int.Parse(dgvFamilia.CurrentRow.Cells[0].Value.ToString()));
            tela.Show();
            this.Close();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
           
            FamiliaController familiaController = new FamiliaController();
            if (familiaController.ExcluirFamilia(int.Parse(dgvFamilia.CurrentRow.Cells[0].Value.ToString())))
            {
                MessageBox.Show("Familia excluida com sucesso", "Concluido!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Houve um erro ao excluir a familia");
            }
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                                       Color.FromArgb(184, 244, 234),
                                                                       Color.FromArgb(116, 236, 126),
                                                                       45F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
