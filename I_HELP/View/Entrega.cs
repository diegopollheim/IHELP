using ExemploComboBox.Util;
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
    public partial class Entrega : Form
    {
        public Entrega()
        {
            InitializeComponent();

            dtpEnt.Format = DateTimePickerFormat.Custom;
            dtpEnt.CustomFormat = "dd/MM/yyyy"; // Formato do Date Picker

            cbbPessoa.Items.Add(new ItemComboBox("Selecione", 0));
            PessoaController selecionarpessoa = new PessoaController();
            DataTable dtPessoas = selecionarpessoa.SelecionarPessoas();
            for (int i = 0; i < dtPessoas.Rows.Count; i++)
                cbbPessoa.Items.Add(new ItemComboBox(dtPessoas.Rows[i]["cpfpes"].ToString() + " - " + dtPessoas.Rows[i]["nompes"].ToString(),
                     Convert.ToInt32(dtPessoas.Rows[i]["codpes"])));
            cbbPessoa.SelectedIndex = cbbPessoa.FindStringExact("Selecione");
            cbbAcao.Enabled = false;

            AcaoController acao = new AcaoController();
            DataTable dtAcoes = new DataTable();

            cbbAcao.Items.Add(new ItemComboBox("Selecione", 0));
            BancoInstance banco;
            using (banco = new BancoInstance())
            {
                //Comando SQL que insere no banco
                banco.Banco.ExecuteQuery(@"select * from acao", out dtAcoes);
            }
            for (int i = 0; i < dtAcoes.Rows.Count; i++)
                cbbAcao.Items.Add(new ItemComboBox(dtAcoes.Rows[i]["nomeaca"].ToString(),
                    Convert.ToInt32(dtAcoes.Rows[i]["codaca"])));

            cbbAcao.SelectedIndex = cbbAcao.FindStringExact("Selecione");
        }

        private void Entrega_Load(object sender, EventArgs e)
        {
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

        private void cbbPessoa_SelectedValueChanged(object sender, EventArgs e)
        {
            cbbAcao.Enabled = true;


        }

        private void cbbAcao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if((cbbAcao.SelectedItem as ItemComboBox).Id != 0)
            {
                AcaoController acaoController = new AcaoController();
                DataTable dtAcao = acaoController.TrazerAcao((cbbAcao.SelectedItem as ItemComboBox).Id);

                dtpEnt.MinDate = DateTime.Now.AddYears(-100);
                dtpEnt.MaxDate = DateTime.Now.AddYears(+100);
                dtpEnt.MinDate = DateTime.Parse(dtAcao.Rows[0]["dateini"].ToString());
                dtpEnt.MaxDate = DateTime.Parse(dtAcao.Rows[0]["datefim"].ToString());
                dtpEnt.Text = dtAcao.Rows[0]["dateini"].ToString();
                dtpEnt.Value = DateTime.Parse(dtAcao.Rows[0]["dateini"].ToString());
            }
            else
            {

                dtpEnt.MinDate = DateTime.Now.AddYears(-100);
                dtpEnt.MaxDate = DateTime.Now.AddYears(+100); 

                dtpEnt.MaxDate = DateTime.Now;
                dtpEnt.MinDate = DateTime.Now;
                dtpEnt.Value = DateTime.Now;
            }
           
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if ((cbbPessoa.SelectedItem as ItemComboBox).Id != 0)
            {
                if ((cbbAcao.SelectedItem as ItemComboBox).Id != 0)
                {
                    PessoaController pessoaController = new PessoaController();
                    DataTable dtPessoa = pessoaController.BuscarPessoaId((cbbPessoa.SelectedItem as ItemComboBox).Id);

                    EntregaControler entregaController = new EntregaControler();
                    DataTable dtEntrega = entregaController.BuscarPorAcaoFamilia((cbbAcao.SelectedItem as ItemComboBox).Id, Convert.ToInt32(dtPessoa.Rows[0]["codfam"].ToString()));

                    if (dtEntrega.Rows.Count == 0)
                    {
                        if (entregaController.CadastrarEntrega(new EntregaEntity((cbbAcao.SelectedItem as ItemComboBox).Id, Convert.ToInt32(dtPessoa.Rows[0]["codfam"]), (cbbPessoa.SelectedItem as ItemComboBox).Id, dtpEnt.Value)))
                        {
                            MessageBox.Show("Entrega cadastrada com sucesso", "Concluido");
                            this.Close();
                        }
                    }
                    else
                    {
                        DataTable dtFamiliar = pessoaController.BuscarPessoaId(int.Parse(Convert.ToInt32(dtEntrega.Rows[0]["codpes"]).ToString()));
                        MessageBox.Show("Uma pessoa de mesma familia ja participou desta ação.","Atenção");
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
