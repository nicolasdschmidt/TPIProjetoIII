namespace apBiblioteca
{
	partial class FrmDevolucao
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtCodigoLeitor = new System.Windows.Forms.TextBox();
			this.txtNomeLeitor = new System.Windows.Forms.TextBox();
			this.cbLivro = new System.Windows.Forms.ComboBox();
			this.btnDevolver = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(55, 74);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "Leitor:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(61, 110);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 18);
			this.label2.TabIndex = 1;
			this.label2.Text = "Livro:";
			// 
			// txtCodigoLeitor
			// 
			this.txtCodigoLeitor.Location = new System.Drawing.Point(113, 71);
			this.txtCodigoLeitor.Name = "txtCodigoLeitor";
			this.txtCodigoLeitor.Size = new System.Drawing.Size(100, 26);
			this.txtCodigoLeitor.TabIndex = 2;
			this.txtCodigoLeitor.Leave += new System.EventHandler(this.txtCodigoLeitor_Leave);
			// 
			// txtNomeLeitor
			// 
			this.txtNomeLeitor.Location = new System.Drawing.Point(219, 71);
			this.txtNomeLeitor.Name = "txtNomeLeitor";
			this.txtNomeLeitor.ReadOnly = true;
			this.txtNomeLeitor.Size = new System.Drawing.Size(280, 26);
			this.txtNomeLeitor.TabIndex = 3;
			// 
			// cbLivro
			// 
			this.cbLivro.Enabled = false;
			this.cbLivro.FormattingEnabled = true;
			this.cbLivro.Location = new System.Drawing.Point(113, 107);
			this.cbLivro.Name = "cbLivro";
			this.cbLivro.Size = new System.Drawing.Size(386, 26);
			this.cbLivro.TabIndex = 4;
			this.cbLivro.SelectedIndexChanged += new System.EventHandler(this.cbLivro_SelectedIndexChanged);
			// 
			// btnDevolver
			// 
			this.btnDevolver.Enabled = false;
			this.btnDevolver.Location = new System.Drawing.Point(408, 142);
			this.btnDevolver.Name = "btnDevolver";
			this.btnDevolver.Size = new System.Drawing.Size(91, 30);
			this.btnDevolver.TabIndex = 5;
			this.btnDevolver.Text = "Devolver";
			this.btnDevolver.UseVisualStyleBackColor = true;
			this.btnDevolver.Click += new System.EventHandler(this.btnDevolver_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(151, 18);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(261, 32);
			this.label3.TabIndex = 6;
			this.label3.Text = "Devolução de Livros";
			// 
			// FrmDevolucao
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.ClientSize = new System.Drawing.Size(588, 200);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnDevolver);
			this.Controls.Add(this.cbLivro);
			this.Controls.Add(this.txtNomeLeitor);
			this.Controls.Add(this.txtCodigoLeitor);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "FrmDevolucao";
			this.Text = "FrmDevolucao";
			this.Load += new System.EventHandler(this.FrmDevolucao_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtCodigoLeitor;
		private System.Windows.Forms.TextBox txtNomeLeitor;
		private System.Windows.Forms.ComboBox cbLivro;
		private System.Windows.Forms.Button btnDevolver;
		private System.Windows.Forms.Label label3;
	}
}