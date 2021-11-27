
namespace I_HELP.View
{
    partial class Entrega
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Familia = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbPessoa = new System.Windows.Forms.ComboBox();
            this.cbbAcao = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGravar = new System.Windows.Forms.Button();
            this.dtpEnt = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Familia
            // 
            this.Familia.AutoSize = true;
            this.Familia.Location = new System.Drawing.Point(12, 19);
            this.Familia.Name = "Familia";
            this.Familia.Size = new System.Drawing.Size(42, 13);
            this.Familia.TabIndex = 0;
            this.Familia.Text = "Pessoa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 2;
            // 
            // cbbPessoa
            // 
            this.cbbPessoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbPessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbPessoa.FormattingEnabled = true;
            this.cbbPessoa.Location = new System.Drawing.Point(66, 16);
            this.cbbPessoa.Name = "cbbPessoa";
            this.cbbPessoa.Size = new System.Drawing.Size(315, 21);
            this.cbbPessoa.TabIndex = 3;
            this.cbbPessoa.SelectedValueChanged += new System.EventHandler(this.cbbPessoa_SelectedValueChanged);
            // 
            // cbbAcao
            // 
            this.cbbAcao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbAcao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbAcao.Enabled = false;
            this.cbbAcao.FormattingEnabled = true;
            this.cbbAcao.Location = new System.Drawing.Point(66, 54);
            this.cbbAcao.Name = "cbbAcao";
            this.cbbAcao.Size = new System.Drawing.Size(315, 21);
            this.cbbAcao.TabIndex = 4;
            this.cbbAcao.SelectedIndexChanged += new System.EventHandler(this.cbbAcao_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ação";
            // 
            // btnGravar
            // 
            this.btnGravar.Location = new System.Drawing.Point(15, 154);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(75, 23);
            this.btnGravar.TabIndex = 6;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // dtpEnt
            // 
            this.dtpEnt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpEnt.CustomFormat = "dd/mm/yyyy";
            this.dtpEnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.dtpEnt.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dtpEnt.Location = new System.Drawing.Point(57, 90);
            this.dtpEnt.MaxDate = new System.DateTime(2100, 12, 25, 23, 59, 59, 0);
            this.dtpEnt.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpEnt.Name = "dtpEnt";
            this.dtpEnt.Size = new System.Drawing.Size(206, 45);
            this.dtpEnt.TabIndex = 18;
            this.dtpEnt.Value = new System.DateTime(2021, 11, 11, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Data";
            // 
            // Entrega
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 309);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpEnt);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbbAcao);
            this.Controls.Add(this.cbbPessoa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Familia);
            this.Name = "Entrega";
            this.Text = "Entrega";
            this.Load += new System.EventHandler(this.Entrega_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Familia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbPessoa;
        private System.Windows.Forms.ComboBox cbbAcao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.DateTimePicker dtpEnt;
        private System.Windows.Forms.Label label3;
    }
}