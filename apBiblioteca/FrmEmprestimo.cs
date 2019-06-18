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
	public partial class FrmEmprestimo : Form
	{
		VetorDados<Leitor> osLeitores;
		VetorDados<Livro> osLivros;
		public FrmEmprestimo()
		{
			InitializeComponent();
		}

		private void txtCodigoLeitor_Leave(object sender, EventArgs e)
		{
			if (txtCodigoLeitor.Text == "")                                                 // verifica se o campo "txtCodigoLeitor" está vazio                                                                     
				MessageBox.Show("Digite um código válido!", "Código inv" +
                    "álido", MessageBoxButtons.OK, MessageBoxIcon.Error);                   // mostra um erro
			else                                                                            // se houver algo                                         
			{
				var procurado = new Leitor(txtCodigoLeitor.Text);                           // cria um objeto leitor com o codigo passado
				int ondeAchou = 0;
				if (!osLeitores.Existe(procurado, ref ondeAchou))                           // se não entrontou o leitor
				{
					MessageBox.Show("Leitor não encontrado");
					txtNomeLeitor.Clear();
					cbLivro.Enabled = false;
				}
				else                                                                        // encontrou o código procurado na posição ondeAchou
				{
					osLeitores.PosicaoAtual = ondeAchou;                                    
					txtNomeLeitor.Text = osLeitores[osLeitores.PosicaoAtual].NomeLeitor.Trim(); // mostra o nome do leitor com base no código passado
					cbLivro.Enabled = true;
					cbLivro.Items.Clear();
                    // percorre e coloca os livros em cada item do ComboBox "cbLivro"
					for (int i = 0; i < osLivros.Tamanho; i++)
					{
						cbLivro.Items.Add(osLivros[i].TituloLivro.Trim());
					}
				}
			}
		}

		private void FrmEmprestimo_Load(object sender, EventArgs e)
		{
            // instancia e lê os vetores

            osLeitores = new VetorDados<Leitor>(50);                
			osLeitores.LerDados(FrmBiblioteca.arqLeitores);
			osLivros = new VetorDados<Livro>(50);
			osLivros.LerDados(FrmBiblioteca.arqLivros);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var oLeitor = osLeitores[osLeitores.PosicaoAtual];                  // pega o objeto da posição atual
			var oLivro = osLivros[osLivros.PosicaoAtual];                       // pega o objeto da posição atual
            oLeitor.Emprestar(oLivro);
			osLeitores.GravarDados(FrmBiblioteca.arqLeitores);                  // grava os dados no arquivo arqLeitores
			osLivros.GravarDados(FrmBiblioteca.arqLivros);                      // grava os dados no arquivo arqLivros
		}

		private void cbLivro_SelectedIndexChanged(object sender, EventArgs e)
		{
			btnEmprestar.Enabled = true;                                            // ativa o botão de emprestar se um livro foi escolhido
			osLivros.PosicaoAtual = cbLivro.SelectedIndex;                          // recebe a poisção do índice seleciona no cbLivro
		}
	}
}
