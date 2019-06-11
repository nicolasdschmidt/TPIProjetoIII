namespace apBiblioteca
{
  partial class FrmBiblioteca
  {
    /// <summary>
    /// Variável de designer necessária.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Limpar os recursos que estão sendo usados.
    /// </summary>
    /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Código gerado pelo Windows Form Designer

    /// <summary>
    /// Método necessário para suporte ao Designer - não modifique 
    /// o conteúdo deste método com o editor de código.
    /// </summary>
    private void InitializeComponent()
    {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBiblioteca));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.manutençãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.livrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tiposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.leitoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.sairToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.operaçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.empréstimosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.devoluçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.livrosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.leitoresToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.button1 = new System.Windows.Forms.Button();
			this.lbArqLivros = new System.Windows.Forms.Label();
			this.lbArqLeitores = new System.Windows.Forms.Label();
			this.lbArqTipos = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.dlgAbrir = new System.Windows.Forms.OpenFileDialog();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manutençãoToolStripMenuItem,
            this.operaçõesToolStripMenuItem,
            this.consultasToolStripMenuItem,
            this.sairToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(430, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// manutençãoToolStripMenuItem
			// 
			this.manutençãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.livrosToolStripMenuItem,
            this.tiposToolStripMenuItem,
            this.leitoresToolStripMenuItem,
            this.toolStripMenuItem1,
            this.sairToolStripMenuItem1});
			this.manutençãoToolStripMenuItem.Name = "manutençãoToolStripMenuItem";
			this.manutençãoToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
			this.manutençãoToolStripMenuItem.Text = "Manutenção";
			// 
			// livrosToolStripMenuItem
			// 
			this.livrosToolStripMenuItem.Name = "livrosToolStripMenuItem";
			this.livrosToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
			this.livrosToolStripMenuItem.Text = "Livros";
			this.livrosToolStripMenuItem.Click += new System.EventHandler(this.livrosToolStripMenuItem_Click);
			// 
			// tiposToolStripMenuItem
			// 
			this.tiposToolStripMenuItem.Name = "tiposToolStripMenuItem";
			this.tiposToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
			this.tiposToolStripMenuItem.Text = "Tipos";
			this.tiposToolStripMenuItem.Click += new System.EventHandler(this.tiposToolStripMenuItem_Click);
			// 
			// leitoresToolStripMenuItem
			// 
			this.leitoresToolStripMenuItem.Name = "leitoresToolStripMenuItem";
			this.leitoresToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
			this.leitoresToolStripMenuItem.Text = "Leitores";
			this.leitoresToolStripMenuItem.Click += new System.EventHandler(this.leitoresToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(112, 6);
			// 
			// sairToolStripMenuItem1
			// 
			this.sairToolStripMenuItem1.Name = "sairToolStripMenuItem1";
			this.sairToolStripMenuItem1.Size = new System.Drawing.Size(115, 22);
			this.sairToolStripMenuItem1.Text = "Sair";
			this.sairToolStripMenuItem1.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// operaçõesToolStripMenuItem
			// 
			this.operaçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.empréstimosToolStripMenuItem,
            this.devoluçõesToolStripMenuItem});
			this.operaçõesToolStripMenuItem.Name = "operaçõesToolStripMenuItem";
			this.operaçõesToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
			this.operaçõesToolStripMenuItem.Text = "Operações";
			// 
			// empréstimosToolStripMenuItem
			// 
			this.empréstimosToolStripMenuItem.Name = "empréstimosToolStripMenuItem";
			this.empréstimosToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			this.empréstimosToolStripMenuItem.Text = "Empréstimos";
			// 
			// devoluçõesToolStripMenuItem
			// 
			this.devoluçõesToolStripMenuItem.Name = "devoluçõesToolStripMenuItem";
			this.devoluçõesToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			this.devoluçõesToolStripMenuItem.Text = "Devoluções";
			// 
			// consultasToolStripMenuItem
			// 
			this.consultasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.livrosToolStripMenuItem1,
            this.leitoresToolStripMenuItem1});
			this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
			this.consultasToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
			this.consultasToolStripMenuItem.Text = "Consultas";
			// 
			// livrosToolStripMenuItem1
			// 
			this.livrosToolStripMenuItem1.Name = "livrosToolStripMenuItem1";
			this.livrosToolStripMenuItem1.Size = new System.Drawing.Size(115, 22);
			this.livrosToolStripMenuItem1.Text = "Livros";
			// 
			// leitoresToolStripMenuItem1
			// 
			this.leitoresToolStripMenuItem1.Name = "leitoresToolStripMenuItem1";
			this.leitoresToolStripMenuItem1.Size = new System.Drawing.Size(115, 22);
			this.leitoresToolStripMenuItem1.Text = "Leitores";
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
			this.sairToolStripMenuItem.Text = "Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 203);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 40);
			this.button1.TabIndex = 1;
			this.button1.Text = "Associar arquivos";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// lbArqLivros
			// 
			this.lbArqLivros.AutoSize = true;
			this.lbArqLivros.Location = new System.Drawing.Point(156, 203);
			this.lbArqLivros.Name = "lbArqLivros";
			this.lbArqLivros.Size = new System.Drawing.Size(35, 13);
			this.lbArqLivros.TabIndex = 2;
			this.lbArqLivros.Text = "label1";
			// 
			// lbArqLeitores
			// 
			this.lbArqLeitores.AutoSize = true;
			this.lbArqLeitores.Location = new System.Drawing.Point(156, 218);
			this.lbArqLeitores.Name = "lbArqLeitores";
			this.lbArqLeitores.Size = new System.Drawing.Size(35, 13);
			this.lbArqLeitores.TabIndex = 3;
			this.lbArqLeitores.Text = "label2";
			// 
			// lbArqTipos
			// 
			this.lbArqTipos.AutoSize = true;
			this.lbArqTipos.Location = new System.Drawing.Point(156, 233);
			this.lbArqTipos.Name = "lbArqTipos";
			this.lbArqTipos.Size = new System.Drawing.Size(35, 13);
			this.lbArqTipos.TabIndex = 4;
			this.lbArqTipos.Text = "label3";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(114, 233);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(36, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Tipos:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(103, 218);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Leitores:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(112, 203);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(38, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Livros:";
			// 
			// dlgAbrir
			// 
			this.dlgAbrir.CheckFileExists = false;
			// 
			// FrmBiblioteca
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(430, 255);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lbArqTipos);
			this.Controls.Add(this.lbArqLeitores);
			this.Controls.Add(this.lbArqLivros);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FrmBiblioteca";
			this.Text = "Biblioteca de Alexandria";
			this.Load += new System.EventHandler(this.FrmBiblioteca_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem manutençãoToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem livrosToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem leitoresToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem operaçõesToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem empréstimosToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem devoluçõesToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem livrosToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem leitoresToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tiposToolStripMenuItem;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label lbArqLivros;
		private System.Windows.Forms.Label lbArqLeitores;
		private System.Windows.Forms.Label lbArqTipos;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.OpenFileDialog dlgAbrir;
	}
}

