using I_HELP.Controller;
using I_HELP.DAO;
using I_HELP.Model;
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
    public partial class RelatorioAcoes : Form
    {
        public RelatorioAcoes()
        {
            InitializeComponent();

            DataTable acoes = new DataTable();
            BancoInstance banco;
            using (banco = new BancoInstance())
            {
                //Comando SQL que insere no banco
                banco.Banco.ExecuteQuery(@" select acao.codaca, acao.nomeaca, cidade.codcid, acao.dateini, acao.datefim, UPPER(cidade.nomcid), UPPER(estado.sigest), acao.dateini, acao.datefim
                                            from acao
                                            inner join cidade on acao.codcid = cidade.codcid
                                            inner join estado on estado.codest = cidade.codest order by codaca asc ", out acoes);


                dgvAcoes.DataSource = acoes;
            }

            // DEFINE O NOME HEADER DAS COLUNAS
            dgvAcoes.Columns[0].HeaderText = "ID";
            dgvAcoes.Columns[1].HeaderText = "NOME AÇÃO";
            dgvAcoes.Columns[2].Visible = false;
            dgvAcoes.Columns[3].Visible = false;
            dgvAcoes.Columns[4].Visible = false;
            dgvAcoes.Columns[5].HeaderText = "NOME CIDADE";
            dgvAcoes.Columns[6].HeaderText = "SIGLA ESTADO";
            dgvAcoes.Columns[7].HeaderText = "DATA INICIO";
            dgvAcoes.Columns[8].HeaderText = "DATA FINAL";

            // AJUSTA A LARGURA DAS CÉLULAS AUTOMATICAMENTE
            dgvAcoes.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

        private void btnExcluirAca_Click(object sender, EventArgs e)
        {
            AcaoController controller = new AcaoController();
            int linha = int.Parse(dgvAcoes.CurrentRow.Cells[0].Value.ToString());

            if (controller.ExcluirAcao(linha))
            {
                MessageBox.Show("Ação excluida com sucesso!","Concluido");
                RelatorioAcoes telaAcoes = new RelatorioAcoes();
                telaAcoes.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ação excluida com sucesso!","Concluido");
            }
        }


        private void btnAlterar_Click(object sender, EventArgs e)
        {
            int indice = int.Parse(dgvAcoes.CurrentRow.Cells[0].Value.ToString());
            
            
            AcaoEntity objAcao = new AcaoEntity(int.Parse(dgvAcoes.CurrentRow.Cells[0].Value.ToString()),
                                                          dgvAcoes.CurrentRow.Cells[1].Value.ToString(),
                                               int.Parse(dgvAcoes.CurrentRow.Cells[2].Value.ToString()),
                                               DateTime.Parse(dgvAcoes.CurrentRow.Cells[3].Value.ToString()),
                                               DateTime.Parse(dgvAcoes.CurrentRow.Cells[4].Value.ToString()));

            
            CadastroAcao telaAlterar = new CadastroAcao(objAcao);
            telaAlterar.Show();
            this.Close();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            CadastroAcao telaAcao = new CadastroAcao();
            telaAcao.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
