using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test1
{
    public partial class ProgresoForm : Form
    {
        private bool m_bAbortar = false;
        public ProgresoForm()
        {
            InitializeComponent();
        }

        private void Pararbutton_Click(object sender, EventArgs e)
        {
            m_bAbortar = true;
        }

        private void ProgresoForm_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
        }
        public bool ValorProgreso (int Valor)
        {
            progressBar1.Value = Valor;
            return (m_bAbortar);
        }
    }
}
