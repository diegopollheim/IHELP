
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Familia
            // 
            this.Familia.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Familia.AutoSize = true;
            this.Familia.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Familia.Location = new System.Drawing.Point(333, 233);
            this.Familia.Name = "Familia";
            this.Familia.Size = new System.Drawing.Size(125, 31);
            this.Familia.TabIndex = 0;
            this.Familia.Text = "PESSOA";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(273, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 31);
            this.label2.TabIndex = 2;
            // 
            // cbbPessoa
            // 
            this.cbbPessoa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbbPessoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbPessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbPessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbPessoa.FormattingEnabled = true;
            this.cbbPessoa.Location = new System.Drawing.Point(339, 267);
            this.cbbPessoa.Name = "cbbPessoa";
            this.cbbPessoa.Size = new System.Drawing.Size(658, 46);
            this.cbbPessoa.TabIndex = 3;
            this.cbbPessoa.SelectedValueChanged += new System.EventHandler(this.cbbPessoa_SelectedValueChanged);
            // 
            // cbbAcao
            // 
            this.cbbAcao.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbbAcao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbAcao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbAcao.Enabled = false;
            this.cbbAcao.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbAcao.FormattingEnabled = true;
            this.cbbAcao.Location = new System.Drawing.Point(339, 368);
            this.cbbAcao.Name = "cbbAcao";
            this.cbbAcao.Size = new System.Drawing.Size(658, 46);
            this.cbbAcao.TabIndex = 4;
            this.cbbAcao.SelectedIndexChanged += new System.EventHandler(this.cbbAcao_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(333, 334);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "AÇÃO";
            // 
            // btnGravar
            // 
            this.btnGravar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGravar.BackColor = System.Drawing.Color.SpringGreen;
            this.btnGravar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnGravar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGravar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnGravar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGravar.Location = new System.Drawing.Point(752, 467);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(245, 50);
            this.btnGravar.TabIndex = 6;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = false;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // dtpEnt
            // 
            this.dtpEnt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpEnt.CustomFormat = "dd/mm/yyyy";
            this.dtpEnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.dtpEnt.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dtpEnt.Location = new System.Drawing.Point(339, 472);
            this.dtpEnt.MaxDate = new System.DateTime(2100, 12, 25, 0, 0, 0, 0);
            this.dtpEnt.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpEnt.Name = "dtpEnt";
            this.dtpEnt.Size = new System.Drawing.Size(272, 45);
            this.dtpEnt.TabIndex = 18;
            this.dtpEnt.Value = new System.DateTime(2021, 11, 11, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(333, 438);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 31);
            this.label3.TabIndex = 19;
            this.label3.Text = "DATA";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1639, 91);
            this.lblTitulo.TabIndex = 20;
            this.lblTitulo.Text = "ENTREGA DE AÇOES PARA AS FAMILIAS";
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.Red;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(1168, 12);
            this.button4.MaximumSize = new System.Drawing.Size(75, 75);
            this.button4.MinimumSize = new System.Drawing.Size(50, 50);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 50);
            this.button4.TabIndex = 21;
            this.button4.Text = "VOLTAR";
            this.button4.UseMnemonic = false;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Entrega
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuPopup;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(1255, 720);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpEnt);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbbAcao);
            this.Controls.Add(this.cbbPessoa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Familia);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Entrega";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Entrega";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button button4;
    }
}