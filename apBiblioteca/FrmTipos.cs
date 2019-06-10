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
	public partial class FrmTipos : Form
	{
		public FrmTipos()
		{
			InitializeComponent();
		}

		private void FrmTipos_Load(object sender, EventArgs e)
		{
			int indice = 0;
			barraDeFerramentas.ImageList = imlBotoes;
			foreach (ToolStripItem item in barraDeFerramentas.Items)
				if (item is ToolStripButton) // se não é separador:
					(item as ToolStripButton).ImageIndex = indice++;
		}
	}
}
