﻿using I_HELP.Controller;
using I_HELP.Model;
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
    public partial class CadastroPessoa : Form
    {
        public CadastroPessoa()
        {
            InitializeComponent();
            dtpNasc.Format = DateTimePickerFormat.Custom;
            //dtpNasc.CustomFormat = "yyyy/MM/dd";
            dtpNasc.CustomFormat = "dd/MM/yyyy"; // Formato do Date Picker
            dtpNasc.MaxDate = DateTime.Today;
            dtpNasc.Value = DateTime.Today.AddYears(-18); // Atribuindo o valor do Data Picker 18 anos atrás baseado na data atual

            btnAlterar.Enabled = false;
            btnCadastrar.Enabled = false;
            btnExcluir.Enabled = false;
            BloquearInputs();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (Validacoes.ValidaCPF(Convert.ToString(mskCPF.Text)))
            {
                if (mskCPF.Text.Length == 11)
                {
                    if (!String.IsNullOrEmpty(ttbNomePessoa.Text)) // Valida campo não podendo ser Vazio
                    {
                        if (!String.IsNullOrEmpty(mskRG.Text)) // Valida campo não podendo ser Vazio
                        {
                            if (mskTelefone.Text.Length == 11)
                            {
                                float idade = DateTime.Now.Year - dtpNasc.Value.Year;
                                if (DateTime.Now.DayOfYear < dtpNasc.Value.DayOfYear) //codigo idade >=18
                                {
                                    idade = idade - 1;
                                };
                                if (idade >= 18)
                                {
                                    PessoaController controller = new PessoaController();
                                    PessoaEntity objPessoa = new PessoaEntity(0, ttbNomePessoa.Text, mskCPF.Text, mskRG.Text, mskTelefone.Text, dtpNasc.Value);
                                    controller.GravarPessoa(objPessoa);

                                    MessageBox.Show("Pessoa cadastrada com sucesso", "Concluido!");
                                    BloquearInputs();
                                    btnCadastrar.Enabled = false;
                                    mskCPF.Enabled = true;

                                    LimparInputs();
                                }
                                else
                                {
                                    MessageBox.Show("Precisa ter mais de 18 anos", "Atenção");
                                    dtpNasc.Focus();
                                }
                            }
                            else
                                MessageBox.Show("Telefone esta inserido incorretamente", "Atenção");
                            mskTelefone.Focus(); // Seta o cursor dentro do campo para que seja feita a correção
                        }
                        else
                            MessageBox.Show("RG esta inserido incorretamente", "Atenção");
                        mskRG.Focus();
                    }
                    else
                        MessageBox.Show("Nome esta inserido incorretamente", "Atenção");
                    ttbNomePessoa.Focus();
                }
                else
                    MessageBox.Show("CPF esta inserido incorretamente", "Atenção");
                mskCPF.Focus();
            }
            else
                MessageBox.Show("O Cpf é invalido", "Atenção");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //var cpfPes = mskCPF.Text;
            //PessoaController controller = new PessoaController();
            //DataTable retorno = controller.BuscarPessoa(cpfPes);
            //MessageBox.Show(retorno.Rows.Count.ToString());
            if (Validacoes.ValidaCPF(Convert.ToString(mskCPF.Text)))
            {
                PessoaController busca = new PessoaController();
                DataTable resultado = busca.BuscarPessoa(mskCPF.Text);
                if (resultado.Rows.Count > 0)
                {
                    mskCPF.Enabled = false; // Bloqueia o input não permitindo mais a alteração
                    btnBuscar.Enabled = false;
                    LiberarInputs();

                    btnAlterar.Enabled = true;
                    btnExcluir.Enabled = true;

                    mskCPF.Text = resultado.Rows[0]["cpfpes"].ToString();
                    ttbNomePessoa.Text = resultado.Rows[0]["nompes"].ToString();
                    mskRG.Text = resultado.Rows[0]["rgpes"].ToString();
                    mskTelefone.Text = resultado.Rows[0]["telpes"].ToString();
                    dtpNasc.Text = resultado.Rows[0]["naspes"].ToString();
                    lbIndice.Text = resultado.Rows[0]["codpes"].ToString();
                }
                else
                {
                    MessageBox.Show("Registro não encontrado");
                    mskCPF.Enabled = false;
                    btnCadastrar.Enabled = true;
                    LiberarInputs(); // Libera os inputs caso o CPF seja válido e não esteja registrado
                }
            }
            else
            {
                MessageBox.Show("O CPF é invalido", "Atenção");
                mskCPF.Focus();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (Validacoes.ValidaCPF(Convert.ToString(mskCPF.Text))) // Validação CPF Válido
            {
                if (mskCPF.Text.Length == 11) // Verifica qtd digitos CPF
                {
                    if (!String.IsNullOrEmpty(ttbNomePessoa.Text)) // Valida campo não podendo ser Vazio
                    {
                        if (!String.IsNullOrEmpty(mskRG.Text)) // Valida campo não podendo ser Vazio
                        {
                            if (mskTelefone.Text.Length == 11)
                            {
                                float idade = DateTime.Now.Year - dtpNasc.Value.Year;
                                if (DateTime.Now.DayOfYear < dtpNasc.Value.DayOfYear) //codigo idade >=18
                                {
                                    idade = idade - 1;
                                };
                                if (idade >= 18)
                                {
                                    PessoaEntity pes = new PessoaEntity(Convert.ToInt32(lbIndice.Text),
                                    ttbNomePessoa.Text,
                                    mskCPF.Text,
                                    mskRG.Text,
                                    mskTelefone.Text,
                                    dtpNasc.Value);

                                    PessoaController ctr = new PessoaController();
                                    if (ctr.AlterarPessoa(pes))
                                    {
                                        MessageBox.Show("Alterado com sucesso!", "Concluido!");
                                        LimparInputs();
                                        btnBuscar.Enabled = true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Erro ao alterar!", "Atenção");
                                    }
                                }
                                else
                                    MessageBox.Show("Precisa ter mais de 18 anos", "Atenção");
                            }
                            else
                                MessageBox.Show("Telefone esta inserido incorretamente", "Atenção");
                        }
                        else
                            MessageBox.Show("RG esta inserido incorretamente", "Atenção");
                    }
                    else
                        MessageBox.Show("Nome esta inserido incorretamente", "Atenção");
                }
                else
                    MessageBox.Show("CPF esta inserido incorretamente", "Atenção");
            }
            else
                MessageBox.Show("O Cpf é invalido", "Atenção");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lbIndice.Text);
            PessoaController excluir = new PessoaController();
            if (excluir.Excluir(id))
            {
                MessageBox.Show("Registro excluído com sucesso", "Concluido!");
                mskCPF.Enabled = true;
                btnBuscar.Enabled = true;
                LimparInputs();
            }
            else
            {
                MessageBox.Show("Erro ao excluir");
            }
        }

        public void LiberarInputs()
        {
            ttbNomePessoa.Enabled = true;
            mskRG.Enabled = true;
            mskTelefone.Enabled = true;
            dtpNasc.Enabled = true;
        }
        public void BloquearInputs()
        {
            ttbNomePessoa.Enabled = false;
            mskRG.Enabled = false;
            mskTelefone.Enabled = false;
            dtpNasc.Enabled = false;
        }

        public void LimparInputs()
        {
            ttbNomePessoa.Clear();
            mskCPF.Clear();
            mskRG.Clear();
            mskTelefone.Clear();
            dtpNasc.Value = DateTime.Today.AddYears(-18);
        }
    }
}
