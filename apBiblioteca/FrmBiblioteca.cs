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
		FrmDevolucao frmDevolucao;

		public static bool consulta = false;

		public static string arqLivros = "..\\..\\..\\livros.txt";
		public static string arqLeitores = "..\\..\\..\\leitores.txt";
		public static string arqTipos = "..\\..\\..\\tipos.txt";

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
			consulta = false;
			frmLivros = new FrmLivros();
			frmLivros.Show();
		}

		private void leitoresToolStripMenuItem_Click(object sender, EventArgs e)
		{
			consulta = false;
			frmLeitores = new FrmLeitores();
			frmLeitores.Show();
		}

		private void tiposToolStripMenuItem_Click(object sender, EventArgs e)
		{
			consulta = false;
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
			consulta = false;
			frmEmprestimo = new FrmEmprestimo();
			frmEmprestimo.Show();
		}

		private void devoluçõesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			consulta = false;
			frmDevolucao = new FrmDevolucao();
			frmDevolucao.Show();
		}

		private void livrosToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			consulta = true;
			frmLivros = new FrmLivros();
			frmLivros.Show();
		}

		private void leitoresToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			consulta = true;
			frmLeitores = new FrmLeitores();
			frmLeitores.Show();
		}

		private void tiposToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			consulta = true;
			frmTipos = new FrmTipos();
			frmTipos.Show();
		}
	}
}
