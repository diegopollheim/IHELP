using ExemploComboBox.Util;
using I_HELP.Controller;
using I_HELP.Model;
using I_HELP.Util;
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
    public partial class CadastroFamilia : Form
    {
        public CadastroFamilia()
        {
            InitializeComponent();
            cbbEstado.Items.Add(new ItemComboBox("Selecione", 0));
            EstadoController controllerEstado = new EstadoController();
            DataTable dtEstados = controllerEstado.BuscarEstado();
            for (int i = 0; i < dtEstados.Rows.Count; i++)
                cbbEstado.Items.Add(new ItemComboBox(dtEstados.Rows[i]["nomest"].ToString(),
                    Convert.ToInt32(dtEstados.Rows[i]["codest"])));
            cbbEstado.SelectedIndex = cbbEstado.FindStringExact("Selecione");
            //cbbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbCidade.Items.Add(new ItemComboBox("Selecione", Convert.ToInt32(0)));
            cbbCidade.SelectedIndex = cbbEstado.FindStringExact("Selecione");
            Registros registros = new Registros();

            ttbRegistro.Text = registros.CriarRegistro();

            btnAlterar.Visible = false;
            btnAlterar.Enabled = false;
            btnSalvar.Visible = true;
            btnSalvar.Enabled = true;
            btnGerar.Visible = true;
            btnGerar.Enabled = true;

        }
        public CadastroFamilia(int id)
        {
            
            InitializeComponent();
            lblTitulo.Text = "ALTERAR ENDEREÇO DA FAMILIA";
            lbIndex.Text = id.ToString();
            cbbEstado.Items.Add(new ItemComboBox("Selecione", 0));
            EstadoController controllerEstado = new EstadoController();
            DataTable dtEstados = controllerEstado.BuscarEstado();
            for (int i = 0; i < dtEstados.Rows.Count; i++)
                cbbEstado.Items.Add(new ItemComboBox(dtEstados.Rows[i]["nomest"].ToString(),
                    Convert.ToInt32(dtEstados.Rows[i]["codest"])));
            cbbEstado.SelectedIndex = cbbEstado.FindStringExact("Selecione");
            //cbbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbCidade.Items.Add(new ItemComboBox("Selecione", Convert.ToInt32(0)));
            cbbCidade.SelectedIndex = cbbEstado.FindStringExact("Selecione");

            FamiliaController familiaController = new FamiliaController();

            DataTable dtFamilia = familiaController.BuscarFamilia(id);

            ttbRegistro.Text = dtFamilia.Rows[0]["regfam"].ToString();

            CidadeController cidadeController = new CidadeController();
            DataTable dtCidade = cidadeController.BuscarCidadeIndice(int.Parse(dtFamilia.Rows[0]["codcid"].ToString()));
            DataTable dtEstado = controllerEstado.BuscarEstadoIndice(int.Parse(dtCidade.Rows[0]["codest"].ToString()));


            cbbEstado.SelectedIndex = cbbEstado.FindStringExact(dtEstado.Rows[0]["nomest"].ToString());

            DataTable consultaCidades = cidadeController.BuscarCidade(int.Parse(dtEstado.Rows[0]["codest"].ToString()));

            cbbCidade.Items.Add(new ItemComboBox("Selecione", Convert.ToInt32(0)));
            for (int i = 0; i < consultaCidades.Rows.Count; i++)
            {
                cbbCidade.Items.Add(new ItemComboBox(consultaCidades.Rows[i]["nomcid"].ToString(), Convert.ToInt32(consultaCidades.Rows[i]["codcid"].ToString())));
            }

            cbbCidade.SelectedIndex = cbbCidade.FindStringExact(dtCidade.Rows[0]["nomcid"].ToString());


            btnAlterar.Visible = true;
            btnAlterar.Enabled = true;
            btnSalvar.Visible = false;
            btnSalvar.Enabled = false;
            btnGerar.Visible = false;
            btnGerar.Enabled = false;
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            Registros registros = new Registros();

            ttbRegistro.Text = registros.CriarRegistro();
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
        private void CriarFamilia_Load(object sender, EventArgs e)
        {

        }

        private void cbbCidade_SelectedIndexChanged(object sender, EventArgs e)
        {

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

            cbbCidade.Items.Add(new ItemComboBox("Selecione", Convert.ToInt32(0)));
            for (int i = 0; i < consultaCidades.Rows.Count; i++)
            {
                cbbCidade.Items.Add(new ItemComboBox(consultaCidades.Rows[i]["nomcid"].ToString(), Convert.ToInt32(consultaCidades.Rows[i]["codcid"].ToString())));
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if ((cbbCidade.SelectedItem as ItemComboBox).Id != 0)
            {
                FamiliaEntity familiaEntity = new FamiliaEntity(1, ttbRegistro.Text, (cbbCidade.SelectedItem as ItemComboBox).Id);
                FamiliaController familiaController = new FamiliaController();
                if (familiaController.CadastrarFamilia(familiaEntity))
                {
                    MessageBox.Show("Familia cadastrada com sucesso", "Concluido!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Houve um erro ao cadastrar a familia");
                }

            }

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if ((cbbCidade.SelectedItem as ItemComboBox).Id != 0)
            {
                FamiliaEntity familiaEntity = new FamiliaEntity(int.Parse(lbIndex.Text), ttbRegistro.Text, (cbbCidade.SelectedItem as ItemComboBox).Id);
                FamiliaController familiaController = new FamiliaController();
                if (familiaController.AlterarFamilia(familiaEntity, int.Parse(lbIndex.Text)))
                {
                    MessageBox.Show("Familia alterara com sucesso", "Concluido!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Houve um erro ao alterar a familia");
                }

            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ttbRegistro_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
