using System;
using System.IO;
using System.Windows.Forms;

namespace apBiblioteca
{
	class Leitor : IComparable<Leitor>, IRegistro
	{
		public const int tamanhoCodigoLeitor = 6;
		const int tamanhoNome = 35;
		const int tamanhoEndereco = 50;
		const int tamanhoQuantosLivros = 2;
		const int tamanhoCodigoLivro = Livro.tamanhoCodigoLivro;

		const int inicioCodigoLeitor = 0;
		const int inicioNome = inicioCodigoLeitor + tamanhoCodigoLeitor;
		const int inicioEndereco = inicioNome + tamanhoNome;
		const int inicioQuantosLivros = inicioEndereco + tamanhoEndereco;
		const int inicioCodigosLivros = inicioQuantosLivros + tamanhoQuantosLivros;
		const int maximoLivrosComLeitor = 5;

		string codigoLeitor;
		string nomeLeitor;
		string enderecoLeitor;
		int quantosLivrosComLeitor;
		string[] codigoLivroComLeitor;

		public Leitor()
		{
		}
		public Leitor(string cl)
		{
			CodigoLeitor = cl;
		}
		public Leitor(string leitor, string nome, string endereco, int quantos, string[] livros)
		{
			CodigoLeitor = leitor;
			NomeLeitor = nome;
			EnderecoLeitor = endereco;
			QuantosLivrosComLeitor = quantos;
			CodigoLivroComLeitor = livros;
		}

		public void LerRegistro(StreamReader arq)
		{
			if (!arq.EndOfStream)
			{
				String linha = arq.ReadLine();
				CodigoLeitor = linha.Substring(inicioCodigoLeitor, tamanhoCodigoLeitor);
				NomeLeitor = linha.Substring(inicioNome, tamanhoNome);
				EnderecoLeitor = linha.Substring(inicioEndereco, tamanhoEndereco);
				QuantosLivrosComLeitor = int.Parse(linha.Substring(inicioQuantosLivros,
												   tamanhoQuantosLivros));

				CodigoLivroComLeitor = new string[maximoLivrosComLeitor];
				for (int indice = 0; indice < QuantosLivrosComLeitor; indice++)
					CodigoLivroComLeitor[indice] =
					   linha.Substring(inicioCodigosLivros + tamanhoCodigoLivro * indice,
									   tamanhoCodigoLivro);
			}
		}

		public string CodigoLeitor
		{
			get => codigoLeitor;
			set
			{
				if (value.Length > tamanhoCodigoLeitor)
					value = value.Substring(0, tamanhoCodigoLeitor);
				codigoLeitor = value.PadLeft(tamanhoCodigoLeitor, '0');
			}
		}
		public string NomeLeitor
		{
			get => nomeLeitor;
			set
			{
				if (value.Length > tamanhoNome)
					value = value.Substring(0, tamanhoNome);
				nomeLeitor = value.PadRight(tamanhoNome, ' ');
			}
		}
		public string EnderecoLeitor
		{
			get => enderecoLeitor;
			set
			{
				if (value.Length > tamanhoEndereco)
					value = value.Substring(0, tamanhoEndereco);
				enderecoLeitor = value.PadRight(tamanhoEndereco, ' ');
			}
		}
		public int QuantosLivrosComLeitor
		{
			get => quantosLivrosComLeitor;
			set
			{
				if (value >= 0 && value < maximoLivrosComLeitor)
					quantosLivrosComLeitor = value;
			}
		}
		public string[] CodigoLivroComLeitor
		{
			get => codigoLivroComLeitor;
			set => codigoLivroComLeitor = value;
		}

		public String ParaArquivo()
		{
			string saida = CodigoLeitor.ToString() + NomeLeitor +
						   EnderecoLeitor +
						   QuantosLivrosComLeitor.ToString().PadLeft(tamanhoQuantosLivros, ' ');

			for (int indice = 0; indice < QuantosLivrosComLeitor; indice++)
				saida += CodigoLivroComLeitor[indice];
			return saida;
		}

		public void Emprestar(Livro livroAEmprestar)
		{ 
			if (int.Parse(livroAEmprestar.CodigoLeitorComLivro) == 0)
			{
				if (QuantosLivrosComLeitor <= 5)
				{
					CodigoLivroComLeitor[QuantosLivrosComLeitor] = livroAEmprestar.CodigoLivro;
					QuantosLivrosComLeitor++;
					livroAEmprestar.CodigoLeitorComLivro = CodigoLeitor;
					MessageBox.Show($"{livroAEmprestar.TituloLivro.Trim()} foi emprestado a {NomeLeitor.Trim()}.", "Empréstimo realizado com sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
					MessageBox.Show($"O leitor ({CodigoLeitor}) {NomeLeitor.Trim()} já possui o número máximo de livros emprestados", "Máximo de livros alcançado", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				string diaSemana = livroAEmprestar.DataDevolucao.DayOfWeek.ToString();
				switch (diaSemana)
				{
					case "Sunday":		diaSemana = "domingo";			break;
					case "Monday":		diaSemana = "segunda-feira";	break;
					case "Tuesday":		diaSemana = "terça-feira";		break;
					case "Wednesday":	diaSemana = "quarta-feira";		break;
					case "Thursday":	diaSemana = "quinta-feira";		break;
					case "Friday":		diaSemana = "sexta-feira";		break;
					case "Saturday":	diaSemana = "sábado";			break;
				}
				string dia = livroAEmprestar.DataDevolucao.Day.ToString();
				string mes = livroAEmprestar.DataDevolucao.Month.ToString();
				switch (mes)
				{
					case "1": mes  = "janeiro";		break;
					case "2": mes  = "fevereiro";	break;
					case "3": mes  = "março";		break;
					case "4": mes  = "abril";		break;
					case "5": mes  = "maio";		break;
					case "6": mes  = "junho";		break;
					case "7": mes  = "julho";		break;
					case "8": mes  = "agosto";		break;
					case "9": mes  = "setembro";	break;
					case "10": mes = "outubro";		break;
					case "11": mes = "novembro";	break;
					case "12": mes = "dezembro";	break;
				}
				string ano = livroAEmprestar.DataDevolucao.Year.ToString();
				MessageBox.Show($"O livro selecionado já está emprestado.{Environment.NewLine}" +
					$"A data de devolução prevista é {diaSemana}, {dia} de {mes} de {ano}.", "Livro emprestado", MessageBoxButtons.OK, MessageBoxIcon.Error);			}
		}

		public void Devolver(Livro livroADevolver)
		{
			for (int i = 0; i < QuantosLivrosComLeitor; i++)
			{
				if (CodigoLivroComLeitor[i] == livroADevolver.CodigoLivro)
				{
					for (int j = i; j < QuantosLivrosComLeitor; j++)
					{
						CodigoLivroComLeitor[j] = CodigoLivroComLeitor[j + 1];
					}
					QuantosLivrosComLeitor--;
					livroADevolver.CodigoLeitorComLivro = "000000";
					MessageBox.Show($"{livroADevolver.TituloLivro.Trim()} foi devolvido!", "Devolução realizada com sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
		}

		public override String ToString()
		{
			string saida = CodigoLeitor + " " + NomeLeitor + " " + EnderecoLeitor + " " +
						   QuantosLivrosComLeitor.ToString().PadLeft(tamanhoQuantosLivros, ' ');
			for (int indice = 0; indice < QuantosLivrosComLeitor; indice++)
				saida += " " +
					 CodigoLivroComLeitor[indice].PadRight(
										  Livro.tamanhoCodigoLivro, ' ');
			return saida;
		}

		public int CompareTo(Leitor outro)
		{
			return codigoLeitor.CompareTo(outro.codigoLeitor);
		}
	}
}
