using ExemploComboBox.Util;
using I_HELP.Controller;
using I_HELP.Util;
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
    public partial class CriarFamilia : Form
    {
        public CriarFamilia()
        {
            InitializeComponent();
            cbbEstado.Items.Add(new ItemComboBox("Selecione ", 0));
            EstadoController controllerEstado = new EstadoController();
            DataTable dtEstados = controllerEstado.BuscarEstado();
            for (int i = 0; i < dtEstados.Rows.Count; i++)
                cbbEstado.Items.Add(new ItemComboBox(dtEstados.Rows[i]["nomest"].ToString(),
                    Convert.ToInt32(dtEstados.Rows[i]["codest"])));
            cbbEstado.SelectedIndex = cbbEstado.FindStringExact("Selecione ");
            //cbbEstado.DropDownStyle = ComboBoxStyle.DropDownList;

            Registros registros = new Registros();

            //ttbRegistro.Text = registros.CriarRegistro();
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            Registros registros = new Registros();

            //ttbRegistro.Text = registros.CriarRegistro();
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

            for (int i = 0; i < consultaCidades.Rows.Count; i++)
            {
                cbbCidade.Items.Add(new ItemComboBox(consultaCidades.Rows[i]["nomcid"].ToString(), Convert.ToInt32(consultaCidades.Rows[i]["codcid"].ToString())));
            }
        }
    }
}
