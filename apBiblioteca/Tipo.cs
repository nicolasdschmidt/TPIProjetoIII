using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace apBiblioteca
{
	class Tipo : IComparable<Tipo>, IRegistro
	{
		const int inicioCodigo = 0;
		const int tamanhoCodigo = 2;
		const int inicioDescricao = inicioCodigo + tamanhoCodigo;
		const int tamanhoDescricao = 20;

		byte codigoTipo;
		string nomeTipo;

		public Tipo()
		{

		}

		public Tipo(byte ct, string nt)
		{
			CodigoTipo = ct;
			NomeTipo = nt;
		}

		public void LerRegistro(StreamReader arq)
		{
			string linhaLida = arq.ReadLine();

			CodigoTipo = byte.Parse(linhaLida.Substring(inicioCodigo, tamanhoCodigo));
			NomeTipo = linhaLida.Substring(inicioDescricao);
		}

		public string ParaArquivo()
		{
			return codigoTipo.ToString().PadRight(2) + nomeTipo.PadRight(20);
		}

		public int CompareTo(Tipo outro)
		{
			return codigoTipo.CompareTo(outro.codigoTipo);
		}

		public byte CodigoTipo { get => codigoTipo; set => codigoTipo = value; }
		public string NomeTipo { get => nomeTipo; set => nomeTipo = value.Trim(); }
	}
}
