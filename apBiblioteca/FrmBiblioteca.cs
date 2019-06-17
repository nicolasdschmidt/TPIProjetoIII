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

		FrmLivros frmLivros;                                                                // declarando novos forms
		FrmLeitores frmLeitores;
		FrmTipos frmTipos;
		FrmEmprestimo frmEmprestimo;
		FrmDevolucao frmDevolucao;

		public static bool consulta = false;                                                // variável para ver em qual aba do livro vai abrir                                      

		public static string arqLivros = "..\\..\\..\\livros.txt";                          // declarando arquivos usados
		public static string arqLeitores = "..\\..\\..\\leitores.txt";
		public static string arqTipos = "..\\..\\..\\tipos.txt";

		public FrmBiblioteca()
		{
			InitializeComponent();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)                
		{
			Close();                                                                          // fecha o forms
		}

		private void livrosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			consulta = false;
			frmLivros = new FrmLivros();                                                     // instancia o forms livros
			frmLivros.Show();                                                                // mostra o forms
		}

		private void leitoresToolStripMenuItem_Click(object sender, EventArgs e)
		{
			consulta = false;
			frmLeitores = new FrmLeitores();                                                 // instancia o forms leitor
            frmLeitores.Show();                                                              // mostra o forms
        }

		private void tiposToolStripMenuItem_Click(object sender, EventArgs e)
		{
			consulta = false;
			frmTipos = new FrmTipos();                                                    // instancia o forms tipos
            frmTipos.Show();                                                              // mostra o forms
        }

		private void FrmBiblioteca_Load(object sender, EventArgs e)
		{
			string[] tempLivros = arqLivros.Split(@"\"[0]);                                    // criar um vetor com 
			lbArqLivros.Text = tempLivros[tempLivros.Length - 1];                              // escreve o ultimo elemento do vetor 
			string[] tempLeitores = arqLeitores.Split(@"\"[0]);
			lbArqLeitores.Text = tempLeitores[tempLeitores.Length - 1];
			string[] tempTipos = arqTipos.Split(@"\"[0]);
			lbArqTipos.Text = tempTipos[tempTipos.Length - 1];
		}

		private void button1_Click(object sender, EventArgs e)                                // botão associar              
		{
			dlgAbrir.Title = "Selecione o arquivo de Livros";
            if (dlgAbrir.ShowDialog() == DialogResult.OK)                                     // abre o dlg para o usuário selecionar outro arquivo livros
            {   
				arqLivros = dlgAbrir.FileName;                                                // recebe o endereço do novo arquivo texto                                 
                string[] tempLivros = arqLivros.Split(@"\"[0]);                               // divide o endereço e o coloca em um vetor
				lbArqLivros.Text = tempLivros[tempLivros.Length - 1];                         // escreve o ultimo elemento do vetor (nomo do arquivo)
                dlgAbrir.Title = "Selecione o arquivo de Leitores";
				if (dlgAbrir.ShowDialog() == DialogResult.OK)                                 // abre o dlg para o usuário selecionar outro arquivo leitor
                {
					arqLeitores = dlgAbrir.FileName;                                          // recebe o endereço do novo arquivo texto  
                    string[] tempLeitores = arqLeitores.Split(@"\"[0]);                       // divide o endereço e o coloca em um vetor
                    lbArqLeitores.Text = tempLeitores[tempLeitores.Length - 1];               // escreve o ultimo elemento do vetor (nomo do arquivo)
                    dlgAbrir.Title = "Selecione o arquivo de Tipos";
					if (dlgAbrir.ShowDialog() == DialogResult.OK)                             // abre o dlg para o usuário selecionar outro arquivo tipo
                    {
						arqTipos = dlgAbrir.FileName;                                         // recebe o endereço do novo arquivo texto  
                        string[] tempTipos = arqTipos.Split(@"\"[0]);                         // divide o endereço e o coloca em um vetor
                        lbArqTipos.Text = tempTipos[tempTipos.Length - 1];                    // escreve o ultimo elemento do vetor (nomo do arquivo)
                    }
				}
			}
		}

		private void empréstimosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			consulta = false;                                                                 
			frmEmprestimo = new FrmEmprestimo();                                              // instancia o forms temprestimo
            frmEmprestimo.Show();                                                             // mostra o forms
        }

		private void devoluçõesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			consulta = false;
			frmDevolucao = new FrmDevolucao();                                                // instancia o forms devoluçao
            frmDevolucao.Show();                                                              // mostra o forms
        }

		private void livrosToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			consulta = true;                                                                   // recebe true, abre na aba de consultas
			frmLivros = new FrmLivros();                                                       // instancia o forms livros vindo de consultas
            frmLivros.Show();                                                                  // mostra o forms
        }

		private void leitoresToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			consulta = true;                                                                   // recebe true, abre na aba de consultas
            frmLeitores = new FrmLeitores();                                                   // instancia o forms leitor vindo de consultas
            frmLeitores.Show();                                                                // mostra o forms
        }

		private void tiposToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			consulta = true;                                                                   // recebe true, abre na aba de consultas
            frmTipos = new FrmTipos();                                                          // instancia o forms tipos vindo de consultas
            frmTipos.Show();                                                                    // mostra o forms
        }
	}
}
