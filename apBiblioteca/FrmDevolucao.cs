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
	public partial class FrmDevolucao : Form
	{
		VetorDados<Leitor> osLeitores;
		VetorDados<Livro> osLivros;
		public FrmDevolucao()
		{
			InitializeComponent();
		}

		private void txtCodigoLeitor_Leave(object sender, EventArgs e)
		{
			if (txtCodigoLeitor.Text == "")                                                                         // verifica se o campo "txtCodigoLeitor" está vazio                         
                MessageBox.Show("Digite um código válido!", "Código" +
                    " inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);                                       // mostra um erro
            else                                                                                                    // se houver algo
            {
				var procurado = new Leitor(txtCodigoLeitor.Text);                                                   // cria um objeto leitor com o codigo passado
                int ondeAchou = 0;
				if (!osLeitores.Existe(procurado, ref ondeAchou))                                                   // se não entrontou o leitor
                {
					MessageBox.Show("Leitor não encontrado");
					txtNomeLeitor.Clear();
					cbLivro.Enabled = false;
				}
				else                                                                                                // encontrou o código procurado na posição ondeAchou
				{
					osLeitores.PosicaoAtual = ondeAchou;
					txtNomeLeitor.Text = osLeitores[osLeitores.PosicaoAtual].NomeLeitor.Trim();                     // mostra o nome do leitor com base no código passado
                    cbLivro.Enabled = true;
					cbLivro.Items.Clear();
                    // percorre os livros com o leitor
					for (int i = 0; i < osLeitores[osLeitores.PosicaoAtual].QuantosLivrosComLeitor; i++)
					{
						string codLivro = osLeitores[osLeitores.PosicaoAtual].CodigoLivroComLeitor[i];               // recebe o codigo de um livro com o leitor
						for (int j = 0; j < osLivros.Tamanho; j++)
                        {
                            // percorre e coloca os livros com leito em cada item do ComboBox "cbLivro"
                            if (osLivros[j].CodigoLivro == codLivro)
								cbLivro.Items.Add(osLivros[j].TituloLivro.Trim());
						}
					}
				}
			}
		}

		private void FrmDevolucao_Load(object sender, EventArgs e)
		{
            // instancia e lê os vetores

            osLeitores = new VetorDados<Leitor>(50);
			osLeitores.LerDados(FrmBiblioteca.arqLeitores);
			osLivros = new VetorDados<Livro>(50);
			osLivros.LerDados(FrmBiblioteca.arqLivros);
		}

		private void btnDevolver_Click(object sender, EventArgs e)
		{
			var oLeitor = osLeitores[osLeitores.PosicaoAtual];                          // pega o objeto da posição atual
            var oLivro = osLivros[osLivros.PosicaoAtual];                               // pega o objeto da posição atual
            oLeitor.Devolver(oLivro);
			osLeitores.GravarDados(FrmBiblioteca.arqLeitores);                          // grava os dados no arquivo arqLeitores
            osLivros.GravarDados(FrmBiblioteca.arqLivros);                              // grava os dados no arquivo arqLivros
            cbLivro.Items.Clear();
			cbLivro.SelectedText = "";
			for (int i = 0; i < osLeitores[osLeitores.PosicaoAtual].QuantosLivrosComLeitor; i++)    // percorre os livros com o leitor
			{
				string codLivro = osLeitores[osLeitores.PosicaoAtual].CodigoLivroComLeitor[i];      // um livro com leitor 
				for (int j = 0; j < osLivros.Tamanho; j++)                                          // percorre o vetor livros
				{
					if (osLivros[j].CodigoLivro == codLivro)
						cbLivro.Items.Add(osLivros[j].TituloLivro.Trim());                          // adiciona no ComboBox "cbLivros"
				}
			}
		}

		private void cbLivro_SelectedIndexChanged(object sender, EventArgs e)
		{
			btnDevolver.Enabled = true;                                                 // para devolver o livro
			for (int i = 0; i < osLivros.Tamanho; i++)                                  // percorre o vetor livros
			{
                // procura o índice do livro selecionado
				if (osLivros[i].TituloLivro.Trim() == cbLivro.SelectedItem.ToString().Trim())
				{
					osLivros.PosicaoAtual = i;                                          // recebe o índice do livro selecionado
				}
			}
		}
	}
}
