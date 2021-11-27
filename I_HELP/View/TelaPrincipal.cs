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
using I_HELP.View;

namespace I_HELP
{
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CadastroPessoa tela = new CadastroPessoa();
            tela.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CadastroFamilia tela = new CadastroFamilia();
            tela.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RelatorioAcoes telaAcoes = new RelatorioAcoes();
            telaAcoes.Show();
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

        private void TelaPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Entrega etr = new Entrega();
            etr.Show();
        }
    }
}
