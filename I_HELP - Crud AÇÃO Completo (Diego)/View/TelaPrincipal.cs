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
            CadastroAcao tela = new CadastroAcao();
            tela.Show();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                                       Color.FromArgb(101, 206, 255),
                                                                       Color.FromArgb(174, 253, 48),
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
    }
}
