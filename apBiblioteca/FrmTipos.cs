using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace apBiblioteca
{
	public partial class FrmTipos : Form
	{
		VetorDados<Tipo> osTipos;

		public FrmTipos()
		{
			InitializeComponent();
		}

		private void FrmTipos_Load(object sender, EventArgs e)
		{
			osTipos = new VetorDados<Tipo>(50);
			int indice = 0;
			barraDeFerramentas.ImageList = imlBotoes;
			foreach (ToolStripItem item in barraDeFerramentas.Items)
				if (item is ToolStripButton) // se não é separador:
					(item as ToolStripButton).ImageIndex = indice++;
			osTipos.LerDados(FrmBiblioteca.arqTipos);
			osTipos.PosicionarNoPrimeiro();
			AtualizarDataGridView();
			if (FrmBiblioteca.consulta)
				tabControl1.SelectedTab = tpLista;
		}

		private void AtualizarDataGridView()
		{
			dgvTipos.Rows.Clear();
			osTipos.Ordenar();
			for (int i = 0; i < osTipos.Tamanho; i++)
			{
				Tipo tipoAdicionar = osTipos[i];
				dgvTipos.Rows.Insert(i, tipoAdicionar.CodigoTipo, tipoAdicionar.NomeTipo);
			}
			AtualizarTela();
		}

		private void AtualizarTela()
		{
			if (!osTipos.EstaVazio)
			{
				Tipo tipo = osTipos[osTipos.PosicaoAtual];
				txtCodigoTipo.Text = tipo.CodigoTipo.ToString();
				txtDescricaoTipo.Text = tipo.NomeTipo.ToString();
				dgvTipos.ClearSelection();
				dgvTipos.Rows[osTipos.PosicaoAtual].Selected = true;
				dgvTipos.CurrentCell = dgvTipos.Rows[osTipos.PosicaoAtual].Cells[0];
				dgvTipos.BeginEdit(true);
				dgvTipos.EndEdit();
			}
		}

		private void LimparTela()
		{
			txtCodigoTipo.Clear();
			txtDescricaoTipo.Clear();
		}

		private void btnInicio_Click(object sender, EventArgs e)
		{
			osTipos.PosicionarNoPrimeiro();
			AtualizarTela();
		}

		private void btnAnterior_Click(object sender, EventArgs e)
		{
			osTipos.RetrocederPosicao();
			AtualizarTela();
		}

		private void btnProximo_Click(object sender, EventArgs e)
		{
			osTipos.AvancarPosicao();
			AtualizarTela();
		}

		private void btnUltimo_Click(object sender, EventArgs e)
		{
			osTipos.PosicionarNoUltimo();
			AtualizarTela();
		}

		private void btnProcurar_Click(object sender, EventArgs e)
		{
			LimparTela();
			osTipos.SituacaoAtual = Situacao.pesquisando;
			txtCodigoTipo.Focus();
			stlbMensagem.Text = "Digite o código do livro que busca";
		}

		private void btnNovo_Click(object sender, EventArgs e)
		{
			osTipos.SituacaoAtual = Situacao.incluindo;
			LimparTela();
			txtCodigoTipo.Enabled = true;
			txtDescricaoTipo.Enabled = true;
			txtCodigoTipo.Focus();
			stlbMensagem.Text = "Digite os novos dados";

			btnSalvar.Enabled = true;
		}

		private void btnEditar_Click(object sender, EventArgs e)
		{
			osTipos.SituacaoAtual = Situacao.editando;
			txtCodigoTipo.Enabled = true;
			txtDescricaoTipo.Enabled = true;
			txtCodigoTipo.Focus();
			stlbMensagem.Text = "Digite os novos dados";

			btnSalvar.Enabled = true;
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			osTipos.SituacaoAtual = Situacao.navegando;
		}

		private void btnSalvar_Click(object sender, EventArgs e)
		{
			if (osTipos.SituacaoAtual == Situacao.incluindo) // está no modo de inclusão
			{
				var novoDado = new Tipo(byte.Parse(txtCodigoTipo.Text), Capitalize(txtDescricaoTipo.Text));
				osTipos.Incluir(novoDado);
				// para mudar o registro com o qual trabalhamos no momento
				AtualizarDataGridView();
				osTipos.SituacaoAtual = Situacao.navegando; // termina o modo de inclusão
			}
			else  // verificar se está editando
			  if (osTipos.SituacaoAtual == Situacao.editando)
			{
				osTipos[osTipos.PosicaoAtual] = new Tipo(byte.Parse(txtCodigoTipo.Text), Capitalize(txtDescricaoTipo.Text));
				osTipos.SituacaoAtual = Situacao.navegando;
				txtCodigoTipo.Enabled = false;
				AtualizarDataGridView();
			}
			btnSalvar.Enabled = false;
		}

		private void btnExcluir_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(
				   $"Deseja realmente excluir o registro?{Environment.NewLine}" +
				   $"{osTipos[osTipos.PosicaoAtual].CodigoTipo} - {osTipos[osTipos.PosicaoAtual].NomeTipo}", "Exclusão",
				   MessageBoxButtons.YesNo,
				   MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				osTipos.Excluir(osTipos.PosicaoAtual);
				if (osTipos.PosicaoAtual >= osTipos.Tamanho)
					osTipos.PosicionarNoUltimo();
				AtualizarTela();
			}
		}

		private void btnSair_Click(object sender, EventArgs e)
		{
			Close();
		}

		public string Capitalize(string str)
		{
			str = str.Trim();
			if (str == null)
				return null;

			if (str.Length > 1)
				return char.ToUpper(str[0]) + str.Substring(1);

			return str.ToUpper();
		}

		private void dgvTipos_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			// ao clicar numa célula, seleciona a sua linha e define-a como a posição selecionada no vetor
			(sender as DataGridView).CurrentRow.Selected = true;
			osTipos.PosicaoAtual = (sender as DataGridView).CurrentCell.RowIndex;
			AtualizarDataGridView();
		}

		private void txtCodigoTipo_Leave(object sender, EventArgs e)
		{
			int ondeIncluir = -1;
			if (txtCodigoTipo.Text == "")
				MessageBox.Show("Digite um código válido!");
			else
			{
				var procurado = new Tipo(byte.Parse(txtCodigoTipo.Text), "");
				switch (osTipos.SituacaoAtual)
				{
					case Situacao.incluindo:
						if (osTipos.Existe(procurado, ref ondeIncluir))   // se já existe o código
						{
							MessageBox.Show("Código repetido; inclusão cancelada.");
							osTipos.SituacaoAtual = Situacao.navegando;
							AtualizarTela(); // restaura o registro visível anteriormente
						}
						else // o código ainda não existe no vetor dados
						{
							txtDescricaoTipo.Focus();
							stlbMensagem.Text = "Digite os demais dados. Após isso pressione [Salvar]";
						}
						break;
					case Situacao.pesquisando:
						int ondeAchou = 0;
						if (!osTipos.Existe(procurado, ref ondeAchou))
						{
							MessageBox.Show("Código não foi cadastrado ainda.");
							AtualizarTela();
							osTipos.SituacaoAtual = Situacao.navegando;
						}
						else  // encontrou o código procurado na posição ondeAchou
						{
							osTipos.PosicaoAtual = ondeAchou;
							AtualizarTela();
							osTipos.SituacaoAtual = Situacao.navegando;
						}
						break;
				}
			}
		}

		private void tpLista_Enter(object sender, EventArgs e)
		{
			osTipos.ExibirDados(lsbTipos, "Código Descrição");
		}
	}
}
