using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apBiblioteca
{
	public partial class FrmBiblioteca : Form
	{

		FrmLivros frmLivros;
		FrmLeitores frmLeitores;
		FrmTipos frmTipos;
		FrmEmprestimo frmEmprestimo;

		public static string arqLivros = "Z:\\1o semestre\\Técnicas De Programação\\Projeto III Git\\TPProjetoIII\\livros.txt";
		public static string arqLeitores = "Z:\\1o semestre\\Técnicas De Programação\\Projeto III Git\\TPProjetoIII\\leitores.txt";
		public static string arqTipos = "Z:\\1o semestre\\Técnicas De Programação\\Projeto III Git\\TPProjetoIII\\tipos.txt";

		public FrmBiblioteca()
		{
			InitializeComponent();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void livrosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmLivros = new FrmLivros();
			frmLivros.Show();
		}

		private void leitoresToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmLeitores = new FrmLeitores();
			frmLeitores.Show();
		}

		private void tiposToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmTipos = new FrmTipos();
			frmTipos.Show();
		}

		private void FrmBiblioteca_Load(object sender, EventArgs e)
		{
			string[] tempLivros = arqLivros.Split(@"\"[0]);
			lbArqLivros.Text = tempLivros[tempLivros.Length - 1];
			string[] tempLeitores = arqLeitores.Split(@"\"[0]);
			lbArqLeitores.Text = tempLeitores[tempLeitores.Length - 1];
			string[] tempTipos = arqTipos.Split(@"\"[0]);
			lbArqTipos.Text = tempTipos[tempTipos.Length - 1];
		}

		private void button1_Click(object sender, EventArgs e)
		{
			dlgAbrir.Title = "Selecione o arquivo de Livros";
			if (dlgAbrir.ShowDialog() == DialogResult.OK)
			{
				arqLivros = dlgAbrir.FileName;
				string[] tempLivros = arqLivros.Split(@"\"[0]);
				lbArqLivros.Text = tempLivros[tempLivros.Length - 1];
				dlgAbrir.Title = "Selecione o arquivo de Leitores";
				if (dlgAbrir.ShowDialog() == DialogResult.OK)
				{
					arqLeitores = dlgAbrir.FileName;
					string[] tempLeitores = arqLeitores.Split(@"\"[0]);
					lbArqLeitores.Text = tempLeitores[tempLeitores.Length - 1];
					dlgAbrir.Title = "Selecione o arquivo de Tipos";
					if (dlgAbrir.ShowDialog() == DialogResult.OK)
					{
						arqTipos = dlgAbrir.FileName;
						string[] tempTipos = arqTipos.Split(@"\"[0]);
						lbArqTipos.Text = tempTipos[tempTipos.Length - 1];
					}
				}
			}
		}

		private void empréstimosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmEmprestimo = new FrmEmprestimo();
			frmEmprestimo.Show();
		}
	}
}
