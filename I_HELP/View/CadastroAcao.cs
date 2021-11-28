using ExemploComboBox.Util;
using I_HELP.Controller;
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
    public partial class CadastroAcao : Form
    {
        public CadastroAcao()
        {
            InitializeComponent();
            btnSalAlt.Hide();

            DefinirValoresDataPicker();

            EstadoController controllerEstado = new EstadoController();
            DataTable dtEstados = controllerEstado.BuscarEstado();
            for (int i = 0; i < dtEstados.Rows.Count; i++)
                cbbEstado.Items.Add(new ItemComboBox(dtEstados.Rows[i]["nomest"].ToString(),
                    Convert.ToInt32(dtEstados.Rows[i]["codest"])));
            cbbEstado.SelectedIndex = cbbEstado.FindStringExact("Selecione ");
        }

        public CadastroAcao(AcaoEntity acao) // INICIA QUANDO FOR PARA FAZER ALTERAÇÃO DA ACAO
        {
            // CONFIG INICIAIS
            InitializeComponent();
            lbIndiceAca.Hide();
            lblTitulo.Text = "Alterar dados da AÇÃO"; // altera o titulo quando estiver sendo feita uma alteração em uma ação
            lbIndiceAca.Text = acao.Id.ToString(); // reserva o codaca para fazer o update
            btnCadastrar.Hide();
            btnSalAlt.Show();

            //CHAMA METODO DE DEFINE OS DATEPICKERS
            DefinirValoresDataPicker();

            // Preenche os campos na tela com a ação que veio do relatorio
            ttbNomeAcao.Text = acao.Nome.ToString();

            dtpIni.MinDate = acao.DateIni;
            dtpIni.Value = acao.DateIni;
            dtpFinal.MinDate = acao.DateIni;
            dtpFinal.Value = acao.DateFim;

            // Faz uma busca no banco nas tabelas Cidade e Estado e traz a cidade e estado da AÇÃO
            AcaoController controller = new AcaoController();
            DataTable cidadeEstado = controller.BuscarEstadoCidadeAcao(acao.CodCid);
            
            // Preenche os ComboBoxs com todos os estados
            EstadoController controllerEstado = new EstadoController();
            DataTable dtEstados = controllerEstado.BuscarEstado();
            for (int i = 0; i < dtEstados.Rows.Count; i++)
                cbbEstado.Items.Add(new ItemComboBox(dtEstados.Rows[i]["nomest"].ToString(),
                    Convert.ToInt32(dtEstados.Rows[i]["codest"])));
            
            // Defini o estado e cidade baseado na busca da AÇÃO que está sendo feita a alteração
            cbbEstado.SelectedIndex = cbbEstado.FindStringExact(cidadeEstado.Rows[0][0].ToString()); // Define o Valor inicial do CBB
            cbbCidade.SelectedIndex = cbbCidade.FindStringExact(cidadeEstado.Rows[0][1].ToString()); // Define o Valor inicial do CBB

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
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ttbNomeAcao.Text))
            {
                if (!String.IsNullOrEmpty(cbbCidade.Text))
                {
                    //Monta o objAcao e cadastra no banco de dados
                    AcaoController controler = new AcaoController();
                    AcaoEntity objAcao = new AcaoEntity(0, ttbNomeAcao.Text.ToUpper(), (cbbCidade.SelectedItem as ItemComboBox).Id, dtpIni.Value, dtpFinal.Value);

                    if (controler.CadastrarAcao(objAcao))
                    {
                        MessageBox.Show("Ação Gravada com Sucesso", "Concluido");
                        this.Close();
                    }                    
                    else
                    {
                        MessageBox.Show("Não foi possivel gravar!", "Erro");
                    }
                }
                else
                {
                    MessageBox.Show("Informe o código da cidade", "Atenção");
                }
            }
            else
            {
                MessageBox.Show("Informe um nome para a ação", "Atenção");
            }            
        }

        private void btnVerRel_Click(object sender, EventArgs e)
        {
            RelatorioAcoes rel = new RelatorioAcoes();
            rel.Show();
            this.Close();
        }

        private void cbbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Limpando elementos do combobox
            cbbCidade.Items.Clear();

            //Bloqueando edição do usuário
            //cbbCidade.DropDownStyle = ComboBoxStyle.DropDownList;
            int idSelecionado = (cbbEstado.SelectedItem as ItemComboBox).Id;

            CidadeController cidadeController = new CidadeController();
            DataTable consultaCidades = cidadeController.BuscarCidade(idSelecionado);

            for (int i = 0; i < consultaCidades.Rows.Count; i++)
            {
                cbbCidade.Items.Add(new ItemComboBox(consultaCidades.Rows[i]["nomcid"].ToString(), Convert.ToInt32(consultaCidades.Rows[i]["codcid"].ToString())));
            }
        }

        private void btnSalAlt_Click(object sender, EventArgs e)
        {
            // Código de alteração da acao

            if (!String.IsNullOrEmpty(ttbNomeAcao.Text))
            {
                if (!String.IsNullOrEmpty(cbbEstado.Text))
                {
                    if (!String.IsNullOrEmpty(cbbCidade.Text))
                    {
                        //Monta o objAcao e cadastra no banco de dados
                        AcaoController controler = new AcaoController();
                        AcaoEntity objAcao = new AcaoEntity(0, ttbNomeAcao.Text.ToUpper(), (cbbCidade.SelectedItem as ItemComboBox).Id, dtpIni.Value, dtpFinal.Value);

                        if (controler.AlterarAcao(objAcao, int.Parse(lbIndiceAca.Text)))
                        {
                            MessageBox.Show("Ação Alterada com Sucesso", "Concluido");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Não foi possivel salvar a alteração!", "Erro");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Selecione a cidade", "Atenção");
                    }                   
                }
                else
                {
                    MessageBox.Show("Selecione o Estado", "Atenção");
                }
            }
            else
            {
                    MessageBox.Show("Informe um nome para a AÇÃO", "Atenção");
            }
        }

        private void DefinirValoresDataPicker()
        {
            // DEFINE O FORMATO DOS DATEPICKERS
            dtpIni.Format = DateTimePickerFormat.Custom;
            dtpFinal.Format = DateTimePickerFormat.Custom;
            dtpIni.CustomFormat = "dd/MM/yyyy"; // Formato do Date Picker
            dtpFinal.CustomFormat = "dd/MM/yyyy"; // Formato do Date Picker

            // DEFINE VALOR INICIAL E MÁXIMO E MINIMO DATA INICIAL DA AÇÃO
            dtpIni.Value = DateTime.Today;
            dtpIni.MinDate = DateTime.Today;
            dtpIni.MaxDate = DateTime.Today.AddDays(10);

        }

        private void dtpIni_ValueChanged(object sender, EventArgs e)
        {
            // Define a data minima do fim da acao baseado na data do inicio da mesma
            dtpFinal.MinDate = dtpIni.Value;
            dtpFinal.MaxDate = dtpIni.Value.AddDays(10);
        }

        private void cbbEstado_SelectedValueChanged(object sender, EventArgs e)
        {
            cbbCidade.Items.Clear();
            cbbCidade.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
