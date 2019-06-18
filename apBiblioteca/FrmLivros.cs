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
	public partial class FrmLivros : Form
	{
		VetorDados<Livro> osLivros;                                                             // osLivros armazenará os dados lidos e terá os métodos de manutenção
		VetorDados<Leitor> osLeitores;
		VetorDados<Tipo> osTipos;
		int ondeIncluir = 0;                                                                    // global --> acessível na classe toda
		public FrmLivros()
		{
			InitializeComponent();
		}

		private void FrmFunc_Load(object sender, EventArgs e)
		{
			int indice = 0;
			barraDeFerramentas.ImageList = imlBotoes;
			foreach (ToolStripItem item in barraDeFerramentas.Items)
				if (item is ToolStripButton)                                                    // se não é separador:
					(item as ToolStripButton).ImageIndex = indice++;

			osLivros = new VetorDados<Livro>(50);                                               // instancia com vetor dados com 50 posições
			osLeitores = new VetorDados<Leitor>(50);                                            // instancia com vetor dados com 50 posições
			osTipos = new VetorDados<Tipo>(50);                                                 // instancia com vetor dados com 50 posições
			osLivros.LerDados(FrmBiblioteca.arqLivros);
			osLeitores.LerDados(FrmBiblioteca.arqLeitores);
			osTipos.LerDados(FrmBiblioteca.arqTipos);
			if (osLivros != null)                                                               // verifica se não está vazio
                osLivros.PosicionarNoPrimeiro();                                                // posciona na primeira posição
            AtualizarDataGridView();
			if (FrmBiblioteca.consulta)                                                         // verifica se é uma consulta
                tabControl1.SelectedTab = tpLista;                                              // coloca na aba de consulta
        }

		private void AtualizarDataGridView()
		{
			dgvTipoLivro.Rows.Clear();                                                          // limpa o data grid view
			osTipos.Ordenar();                                                                  // ordena o vetor
			for (int i = 0; i < osTipos.Tamanho; i++)                                           // percorre o vetor
			{
				Tipo tipoAdicionar = osTipos[i];                                                // objeto da posição i do vetos osTipos
				dgvTipoLivro.Rows.Insert(i, tipoAdicionar.CodigoTipo, tipoAdicionar.NomeTipo);  // insere uma linha com os dados
			}
			AtualizarTela();
		}

		private void btnInicio_Click(object sender, EventArgs e)
		{
			osLivros.PosicionarNoPrimeiro();
			AtualizarTela();
		}
		private void btnAnterior_Click(object sender, EventArgs e)
		{
			osLivros.RetrocederPosicao();
			AtualizarTela();
		}
		private void btnProximo_Click(object sender, EventArgs e)
		{
			osLivros.AvancarPosicao();
			AtualizarTela();
		}
		private void btnUltimo_Click(object sender, EventArgs e)
		{
			osLivros.PosicionarNoUltimo();
			AtualizarTela();
		}

		private void AtualizarTela()
		{
			if (!osLivros.EstaVazio)                                                        // verifica se não está vazio
            {
				int indice = osLivros.PosicaoAtual;                                         // recebe a posição atual do vetor
				txtCodigoLivro.Text = osLivros[indice].CodigoLivro + "";
				txtTituloLivro.Text = osLivros[indice].TituloLivro;
				dgvTipoLivro.ClearSelection();
				osTipos.PosicaoAtual = osLivros[indice].TipoLivro - 1;
				for (int i = 0; i < dgvTipoLivro.RowCount; i++)                                     // percorre o data gried view
				{
					if (int.Parse(dgvTipoLivro.Rows[i].Cells[0].Value.ToString()) == osTipos[osTipos.PosicaoAtual].CodigoTipo)      // verifica se o tipo do
                                                                                                                                    // livro é igual ao tipo 
                                                                                                                                    // da posição atual no
                                                                                                                                    // data gried view
					{
                        dgvTipoLivro.Rows[i].Selected = true;                                                                       // seleciona o tipo (coloca e azul)
						dgvTipoLivro.CurrentCell = dgvTipoLivro.Rows[i].Cells[0];
						dgvTipoLivro.BeginEdit(true);
						dgvTipoLivro.EndEdit();
					}
				}
                // zera os textbox do groupbox2
				txtLeitorComLivro.Text = "000000";
				txtDataDevolucao.Text = "";
				txtNomeLeitor.Text = "";
				if (osLivros[indice].CodigoLeitorComLivro != "000000")                              // livro emprestado?
				{
					int ondeLeitor = 0;
					var leitorProc = new Leitor(osLivros[indice].CodigoLeitorComLivro);             // cria um leitor com o código "CodigoLeitorComLivro"
					if (osLeitores.Existe(leitorProc, ref ondeLeitor))                              // verifica se esse leitor existe
					{
                        // mostra os dados do leitor nos textbox's do groupbox2
                        txtLeitorComLivro.Text = osLivros[indice].CodigoLeitorComLivro;
						txtNomeLeitor.Text = osLeitores[ondeLeitor].NomeLeitor;
						txtDataDevolucao.Text = osLivros[indice].DataDevolucao.ToShortDateString();
					}
				}

				TestarBotoes();                                                                      // atualiza o estado dos botões
                stlbMensagem.Text =
				  "Registro " + (osLivros.PosicaoAtual + 1) +
							 "/" + osLivros.Tamanho;
			}
		}
		private void LimparTela()
		{
			txtCodigoLivro.Clear();                                    // limpa o codigo do leitor
            txtTituloLivro.Clear();                                    // limpa o nome do leitor
            txtLeitorComLivro.Text = "000000";                         // coloca um código de leitor neutro 
			txtDataDevolucao.Text = "";                                // limpa data de devolução
            txtNomeLeitor.Text = "";                                   // limpa o nome do leitor
		}

		private void TestarBotoes()
		{
            // ativa os botões
            btnInicio.Enabled = true;                                             
            btnAnterior.Enabled = true;
			btnProximo.Enabled = true;
			btnUltimo.Enabled = true;
			if (osLivros.EstaNoInicio)                                            // para desativar os botões de retroceder e voltar ao inicio
            {
				btnInicio.Enabled = false;
				btnAnterior.Enabled = false;
			}
			if (osLivros.EstaNoFim)                                               // para desativar os botões de avançar e ir ao final
            {
				btnProximo.Enabled = false;
				btnUltimo.Enabled = false;
			}
		}

		private void btnNovo_Click(object sender, EventArgs e)
		{
			// saímos do modo de navegação e entramos no modo de inclusão:
			osLivros.SituacaoAtual = Situacao.incluindo;

			// preparamos a tela para que seja possível digitar dados do novo livro
			LimparTela();

			// colocamos o cursor no campo chave
			txtCodigoLivro.Focus();

			// Exibimos mensagem no statusStrip para instruir o usuário a digitar dados
			stlbMensagem.Text = "Digite o código do novo livro";

			dgvTipoLivro.Enabled = true;
			btnSalvar.Enabled = true;
		}

		private void txtMatricula_Leave(object sender, EventArgs e)                            // ao sair do campo "txtCodigoLeitor"
        {
			if (txtCodigoLivro.Text == "")
				MessageBox.Show("Digite um código válido!");
			else
			{
				var procurado = new Livro(txtCodigoLivro.Text);
				switch (osLivros.SituacaoAtual)                                                 // escolhe a operação de acordo com o modo de navegação
                {
					case Situacao.incluindo:                                                    // INCLUINDO
                        if (osLivros.Existe(procurado, ref ondeIncluir))                        // se já existe o código
						{
							MessageBox.Show("Código repetido; inclusão cancelada.");
							osLivros.SituacaoAtual = Situacao.navegando;                        // cancela a inclusão e retorna a navegação
                            AtualizarTela();                                                    // restaura o registro visível anteriormente
						}
						else                                                                    // o código ainda não existe no vetor dados
						{
							txtTituloLivro.Focus();
							stlbMensagem.Text = "Digite os demais dados. Após isso pressione [Salvar]";
						}
						break;
					case Situacao.pesquisando:                                                  // PESQUISANDO   
                        int ondeAchou = 0;
						if (!osLivros.Existe(procurado, ref ondeAchou))                         // se não achou o codigo procurado
                        {
							MessageBox.Show("Código não foi cadastrado ainda.");
							AtualizarTela();                                                    // atualiza a tela e colocar na primeira posição
                            osLivros.SituacaoAtual = Situacao.navegando;                        // volta para o modo de navegação
                        }
						else                                                                    // encontrou o código procurado na posição ondeAchou
                        {
                            // para mudar o registro com o qual trabalhamos no momento
                            osLivros.PosicaoAtual = ondeAchou;
							AtualizarTela();
							osLivros.SituacaoAtual = Situacao.navegando;                        // para mudar o registro com o qual trabalhamos no momento// volta para o modo de navegação
                        }
						break;
				}
			}
		}

		private void btnSalvar_Click(object sender, EventArgs e)
		{
			int qualTipo = -1;
			qualTipo = int.Parse(dgvTipoLivro.SelectedCells[0].FormattedValue.ToString());
			if (qualTipo == -1)
				MessageBox.Show("Selecione um tipo de livro antes de salvar o registro!");
			else
			  if (osLivros.SituacaoAtual == Situacao.incluindo)                                                 // está no modo de inclusão
			{
				var novoDado = new Livro(txtCodigoLivro.Text,
									   txtTituloLivro.Text, qualTipo,
									   new DateTime(1899, 12, 31),
									   "000000");
				osLivros.Incluir(novoDado, ondeIncluir);
				// para mudar o registro com o qual trabalhamos no momento
				osLivros.PosicaoAtual = ondeIncluir;
				dgvTipoLivro.Enabled = false;
				AtualizarTela();
				osLivros.SituacaoAtual = Situacao.navegando;                                                    // termina o modo de inclusão
			}
			else                                                                                                // verificar se está editando
				if (osLivros.SituacaoAtual == Situacao.editando)
			{
				osLivros[osLivros.PosicaoAtual] = new Livro(
					  txtCodigoLivro.Text, txtTituloLivro.Text, qualTipo,                                       // únicos alterável
                      osLivros[osLivros.PosicaoAtual].DataDevolucao,
					  osLivros[osLivros.PosicaoAtual].CodigoLeitorComLivro);                                    // cria um novo leitor na posição do leitor antigo 
                                                                                                                // com as propiedades novas
                osLivros.SituacaoAtual = Situacao.navegando;
				txtCodigoLivro.ReadOnly = false;
				dgvTipoLivro.Enabled = false;
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
			osLivros.GravarDados(FrmBiblioteca.arqLivros);                                            // salva as alterações no arquivo texto
        }

		private void btnExcluir_Click(object sender, EventArgs e)
		{
			if (int.Parse(osLivros[osLivros.PosicaoAtual].CodigoLeitorComLivro) == 0)                                   // verifica se o livro não está emprestado
            {
				if (MessageBox.Show(
					   $"Deseja realmente excluir {osLivros[osLivros.PosicaoAtual].TituloLivro.Trim()} ({osLivros[osLivros.PosicaoAtual].CodigoLivro})?", "Exclusão",
					   MessageBoxButtons.YesNo,
					   MessageBoxIcon.Warning) == DialogResult.Yes)                                                     // para garantir que a ação é consciente
                {
					osLivros.Excluir(osLivros.PosicaoAtual);
					if (osLivros.PosicaoAtual >= osLivros.Tamanho)                                                      // verifica se é o último que foi excluido
                        osLivros.PosicionarNoUltimo();                                                                  // posiciona no anterior, o novo último
                    AtualizarTela();
				}
			}
			else
				MessageBox.Show($"O livro não pode ser excluído, pois está emprestado ao leitor {osLivros[osLivros.PosicaoAtual].CodigoLeitorComLivro}", "Falha ao excluir o livro", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void btnProcurar_Click(object sender, EventArgs e)
		{
			LimparTela();                                                                       // retira todas as informações da tela
            osLivros.SituacaoAtual = Situacao.pesquisando;                                      // alterea o modo para indicar o processo ao sair do campo "txtCodigoLeito"
            txtCodigoLivro.Focus();
			stlbMensagem.Text = "Digite o código do livro que busca";
		}

		private void tpLista_Enter(object sender, EventArgs e)
		{
			osLivros.ExibirDados(lsbLivros, "Código  Título                        Tipo Devolução  Leitor com o livro");     // coloca um cabeçalho na consulta
        }

		private void btnEditar_Click(object sender, EventArgs e)
		{
			osLivros.SituacaoAtual = Situacao.editando;                                                 // para indicar o processo ao clicar em Salvar
            txtCodigoLivro.ReadOnly = true;                                                             // para não permitir alterar a código do livro
			dgvTipoLivro.Enabled = true;
			stlbMensagem.Text = "Modifique os campos desejados e pressione [Salvar]";
			txtTituloLivro.Focus();

			btnSalvar.Enabled = true;                                                                   // permite salvar as alterações
        }

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			osLivros.SituacaoAtual = Situacao.navegando;                                    // volta para o modo de navegação
            AtualizarTela();
			btnSalvar.Enabled = false;                                                      // bloqueia o botão Salvar
        }

		private void dgvTipoLivro_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			// ao clicar numa célula, seleciona a sua linha e define-a como a posição selecionada no vetor
			(sender as DataGridView).CurrentRow.Selected = true;
			osTipos.PosicaoAtual = (sender as DataGridView).CurrentCell.RowIndex;
		}
	}
}

