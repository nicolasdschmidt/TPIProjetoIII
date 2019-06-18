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
	public partial class FrmLeitores : Form
	{
		VetorDados<Livro> osLivros;                                         // osLivros armazenará os dados lidos e terá os métodos de manutenção
		VetorDados<Leitor> osLeitores;
		int ondeIncluir = 0;                                                // global --> acessível na classe toda

		string nomeArquivoLeitores, nomeArquivoLivros;

		public FrmLeitores()
		{
			InitializeComponent();
		}

		private void FrmFunc_Load(object sender, EventArgs e)
		{
			int indice = 0;
			barraDeFerramentas.ImageList = imlBotoes;                       // coloca imagens nos botões
			foreach (ToolStripItem item in barraDeFerramentas.Items)
				if (item is ToolStripButton)                                // se não é separador:
					(item as ToolStripButton).ImageIndex = indice++;

			nomeArquivoLeitores = FrmBiblioteca.arqLeitores;                // recebe os nomes dos arquivosdados no FrmBiblioteca
			nomeArquivoLivros = FrmBiblioteca.arqLivros;

			osLeitores = new VetorDados<Leitor>(50);                        // instancia com vetor dados com 50 posições
			osLeitores.LerDados(nomeArquivoLeitores);                       
			osLivros = new VetorDados<Livro>(50);                           // instancia com vetor dados com 50 posições
			osLivros.LerDados(nomeArquivoLivros);

            if (osLeitores != null)                                         // verifica se não está vazio
				osLeitores.PosicionarNoPrimeiro();                          // posciona na primeira posição
			AtualizarTela();
            if (FrmBiblioteca.consulta)                                     // verifica se é uma consulta
				tabControl1.SelectedTab = tpLista;                          // coloca na aba de consulta
		}

		private void btnInicio_Click(object sender, EventArgs e)
		{
			osLeitores.PosicionarNoPrimeiro();                              
			AtualizarTela();
		}
		private void btnAnterior_Click(object sender, EventArgs e)
		{
			osLeitores.RetrocederPosicao();
			AtualizarTela();
		}
		private void btnProximo_Click(object sender, EventArgs e)
		{
			osLeitores.AvancarPosicao();
			AtualizarTela();
		}
		private void btnUltimo_Click(object sender, EventArgs e)
		{
			osLeitores.PosicionarNoUltimo();
			AtualizarTela();
		}

		private void AtualizarTela()
		{
			if (!osLeitores.EstaVazio)                                          // verifica se não está vazio
			{
				Leitor oLeitor = osLeitores[osLeitores.PosicaoAtual];           // recebe o leitor da posição atual
				txtCodigoLeitor.Text = (oLeitor.CodigoLeitor + "").Trim();      // escreve o leitor
				txtNomeLeitor.Text = oLeitor.NomeLeitor.Trim();                 // escreve o livro
				txtEndereco.Text = oLeitor.EnderecoLeitor.Trim();               // escreve o endereço
				dgvLivros.RowCount = oLeitor.QuantosLivrosComLeitor + 1;        // adiciona o número de linhas necessárias no data gried view

				for (int umLivro = 0;
						 umLivro < oLeitor.QuantosLivrosComLeitor; umLivro++)   // percorre os livros com o leitor
				{
					int ondeLivro = -1;                                         
					var livroProcurado =
						new Livro(oLeitor.CodigoLivroComLeitor[umLivro]);       // recebe o livro com o leitor
					if (osLivros.Existe(livroProcurado, ref ondeLivro))         // verifica se o livro porcurado existe no vetor livros
					{
                        // escreve os dados do livro no Data Grid View
						Livro oLivro = osLivros[ondeLivro];
						dgvLivros.Rows[umLivro].Cells[0].Value = oLivro.CodigoLivro;
						dgvLivros.Rows[umLivro].Cells[1].Value = oLivro.TituloLivro;
						dgvLivros.Rows[umLivro].Cells[2].Value = oLivro.DataDevolucao.ToShortDateString();
						if (oLivro.DataDevolucao < DateTime.Now.Date)           // verifica se está atrasado
							dgvLivros.Rows[umLivro].Cells[3].Value = "S";
						else
							dgvLivros.Rows[umLivro].Cells[3].Value = "N";
					}
				}

				TestarBotoes();                                                   // atualiza o estado dos botões
				stlbMensagem.Text =
				  "Registro " + (osLeitores.PosicaoAtual + 1) +
							 "/" + osLeitores.Tamanho;
			}
		}
		private void LimparTela()
		{
			txtCodigoLeitor.Clear();                                    // limpa o codigo do leitor
			txtNomeLeitor.Clear();                                      // limpa o nome do leitor
            txtEndereco.Text = "";                                      // limpa o endereço do leitor
            dgvLivros.RowCount = 1;                                     // retorna a primeira linha no data grid view
		}

		private void TestarBotoes()
		{
			btnInicio.Enabled = true;                                               // ativa os botões
			btnAnterior.Enabled = true;
			btnProximo.Enabled = true;
			btnUltimo.Enabled = true;
			if (osLeitores.EstaNoInicio)                                            // para desativar os botões de retroceder e voltar ao inicio
			{
				btnInicio.Enabled = false;
				btnAnterior.Enabled = false;
			}
			if (osLeitores.EstaNoFim)                                               // para desativar os botões de avançar e ir ao final
            {
				btnProximo.Enabled = false;
				btnUltimo.Enabled = false;
			}
		}

		private void btnNovo_Click(object sender, EventArgs e)
		{
			// saímos do modo de navegação e entramos no modo de inclusão:
			osLeitores.SituacaoAtual = Situacao.incluindo;

			// preparamos a tela para que seja possível digitar dados do novo livro
			LimparTela();

			// colocamos o cursor no campo chave
			txtCodigoLeitor.Focus();

			// exibimos mensagem no statusStrip para instruir o usuário a digitar dados
			stlbMensagem.Text = "Digite o código do novo leitor";

            // ativa o botão Salvar
			btnSalvar.Enabled = true;                                                       
		}

		private void txtMatricula_Leave(object sender, EventArgs e)                                 // ao sair do campo "txtCodigoLeitor"
        {
			if (txtCodigoLeitor.Text == "")
				MessageBox.Show("Digite um código válido!");
			else
			{
				var procurado = new Leitor(txtCodigoLeitor.Text);
				switch (osLeitores.SituacaoAtual)                                                   // escolhe a operação de acordo com o modo de navegação
				{
					case Situacao.incluindo:                                                        // INCLUINDO
						if (osLeitores.Existe(procurado, ref ondeIncluir))                          // se já existe o código
						{
							MessageBox.Show("Código repetido; inclusão cancelada.");
							osLeitores.SituacaoAtual = Situacao.navegando;                          // cancela a inclusão e retorna a navegação
							AtualizarTela();                                                        // restaura o registro visível anteriormente
						}
						else                                                                        // o código ainda não existe no vetor dados
						{
							txtNomeLeitor.Focus();                                                  // foca no campo "txtNomeLeitor"
							stlbMensagem.Text = "Digite os demais dados. Após isso pressione [Salvar]";
						}
						break;
					case Situacao.pesquisando:                                                      // PESQUISANDO                               
						int ondeAchou = 0;
						if (!osLeitores.Existe(procurado, ref ondeAchou))                           // se não achou o codigo procurado
						{
							MessageBox.Show("Código não foi cadastrado ainda.");
							AtualizarTela();                                                        // atualiza a tela e colocar na primeira posição
							osLeitores.SituacaoAtual = Situacao.navegando;                          // volta para o modo de navegação
						}
						else                                                                        // encontrou o código procurado na posição ondeAchou
						{
                            // para mudar o registro com o qual trabalhamos no momento
                            osLeitores.PosicaoAtual = ondeAchou;                                    
							AtualizarTela();                                                        
							osLeitores.SituacaoAtual = Situacao.navegando;                          // volta para o modo de navegação
						}
						break;
				}
			}
		}                   

		private void btnSalvar_Click(object sender, EventArgs e)
		{
			if (osLeitores.SituacaoAtual == Situacao.incluindo)                           // está no modo de inclusão
			{
                var novoDado = new Leitor(txtCodigoLeitor.Text,
                                       txtNomeLeitor.Text,
                                       txtEndereco.Text,
                                       0,                                                 // --> 0 é o número de livros emprestados
									   new string[5]);                                    // vetor com 5 códigos de livro vazios
				osLeitores.Incluir(novoDado, ondeIncluir);
	            
                // para mudar o registro com o qual trabalhamos no momento
				osLeitores.PosicaoAtual = ondeIncluir;                                    
				AtualizarTela();                                                          
				osLeitores.SituacaoAtual = Situacao.navegando;                            // termina o modo de inclusão
			}
			else                                                                          
			  if (osLeitores.SituacaoAtual == Situacao.editando)                          // verificar se está editando
            {
				osLeitores[osLeitores.PosicaoAtual] =
				  new Leitor(
					  osLeitores[osLeitores.PosicaoAtual].CodigoLeitor,
					  txtNomeLeitor.Text,                                                 // únicos campos alteráveis
					  txtEndereco.Text,   
					  osLeitores[osLeitores.PosicaoAtual].QuantosLivrosComLeitor,
					  osLeitores[osLeitores.PosicaoAtual].CodigoLivroComLeitor
					);                                                                    // cria um novo leitor na posição do leitor antigo 
                                                                                          // com as propiedades novas

				osLeitores.SituacaoAtual = Situacao.navegando;
				txtCodigoLeitor.ReadOnly = false;
				AtualizarTela();
			}
			btnSalvar.Enabled = false;
		}

		private void btnSair_Click(object sender, EventArgs e)
		{
			// fecha o formulário mas antes dispara o evento FormClosing
			Close();
		}

		private void FrmFunc_FormClosing(object sender, FormClosingEventArgs e)
		{
			osLeitores.GravarDados(nomeArquivoLeitores);                                            // salva as alterações no arquivo texto
		}

		private void btnExcluir_Click(object sender, EventArgs e)
		{
			if (osLeitores[osLeitores.PosicaoAtual].QuantosLivrosComLeitor == 0)                        // verifica se o leitor não contém livros   
			{
				if (MessageBox.Show(
					   "Deseja realmente excluir?", "Exclusão",
					   MessageBoxButtons.YesNo,
					   MessageBoxIcon.Warning) == DialogResult.Yes)                                     // para garantir que a ação é consciente
				{
					osLeitores.Excluir(osLeitores.PosicaoAtual);
					if (osLeitores.PosicaoAtual >= osLeitores.Tamanho)                                  // verifica se é o último que foi excluido
						osLeitores.PosicionarNoUltimo();                                                // posiciona no anterio, o novo último
					AtualizarTela();
				}
			}
			else
				MessageBox.Show($"O leitor não pode ser excluído, pois está com {osLeitores[osLeitores.PosicaoAtual].QuantosLivrosComLeitor} livros.", "Falha ao excluir o leitor", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void btnProcurar_Click(object sender, EventArgs e)
		{
			LimparTela();                                                                   // retira todas as informações da tela
			osLeitores.SituacaoAtual = Situacao.pesquisando;                                // alterea o modo para indicar o processo ao sair do campo "txtCodigoLeito"
            txtCodigoLeitor.Focus();
			stlbMensagem.Text = "Digite o código do leitor que busca";
		}

		private void tpLista_Enter(object sender, EventArgs e)
		{
			osLeitores.ExibirDados(lsbLivros, "Código Nome                                Endereço");
		}

		private void btnEditar_Click(object sender, EventArgs e)
		{
			osLeitores.SituacaoAtual = Situacao.editando;                                           // para indicar o processo ao clicar em Salvar
			txtCodigoLeitor.ReadOnly = true;                                                        // para não permitir alterar a matrícula
			stlbMensagem.Text = "Modifique os campos desejados e pressione [Salvar]";
			txtNomeLeitor.Focus();

			btnSalvar.Enabled = true;                                                               // permite salvar as alterações
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			osLeitores.SituacaoAtual = Situacao.navegando;                                          // volta para o modo de navegação
			AtualizarTela();
			btnSalvar.Enabled = false;                                                              // bloqueia o botão Salvar
		}
	}
}

