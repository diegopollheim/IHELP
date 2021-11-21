using I_HELP.Controller;
using I_HELP.DAO;
using I_HELP.Model;
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
                banco.Banco.ExecuteQuery(@"select * from acao", out acoes);
                dgvAcoes.DataSource = acoes;
            }
        }
        
        private void btnExcluirAca_Click(object sender, EventArgs e)
        {
            AcaoController controller = new AcaoController();
            int linha = int.Parse(dgvAcoes.CurrentRow.Cells[0].Value.ToString());

            if (controller.ExcluirAcao(linha))
            {
                MessageBox.Show("Ação excluida com sucesso!","Concluido");
                this.Close();
            }
            else
            {
                MessageBox.Show("Ação excluida com sucesso!","Concluido");
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            CadastroAcao telaAcao = new CadastroAcao();
            telaAcao.Show();
            this.Close();
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
    }
}
