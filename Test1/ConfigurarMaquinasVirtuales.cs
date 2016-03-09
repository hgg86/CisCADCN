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
    public partial class ConPiezarMaquinasVirtuales : Form
    {
        public ConPiezarMaquinasVirtuales()
        {
            InitializeComponent();
        }

        private void TipoMaquionacomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            EjesXcomboBox.Enabled = TipoMaquinacomboBox.SelectedIndex == 0;
            EjesYcomboBox.Enabled = TipoMaquinacomboBox.SelectedIndex == 0;
            EjesZcomboBox.Enabled = false;
            EjesAcomboBox.Enabled = false;
            EjesBcomboBox.Enabled = false;
            EjesCcomboBox.Enabled = TipoMaquinacomboBox.SelectedIndex == 1;

            ModeloMaquinacomboBox.Items.Clear();
            if (TipoMaquinacomboBox.SelectedIndex == 0)
            {
                ModeloMaquinacomboBox.Items.Add("Simple XY");
                ModeloMaquinacomboBox.Items.Add("Simple XYZ");
                ModeloMaquinacomboBox.Items.Add("Simple Bisel XYZAB");
                ModeloMaquinacomboBox.Items.Add("Multicabezal XYZ");
                ModeloMaquinacomboBox.Items.Add("Multicabezal XY");
                ModeloMaquinacomboBox.Items.Add("Multicabezal Bisel XYZAB");
            }
            else
            {
                ModeloMaquinacomboBox.Items.Add("Simple XYC");
                ModeloMaquinacomboBox.Items.Add("Simple XYZC");
                ModeloMaquinacomboBox.Items.Add("Simple Bisel XYZCAB");
                ModeloMaquinacomboBox.Items.Add("Multicabezal XYZC");
                ModeloMaquinacomboBox.Items.Add("Multicabezal XYC");
                ModeloMaquinacomboBox.Items.Add("Multicabezal Bisel XYZCAB");
            }
            ModeloMaquinacomboBox.SelectedIndex = -1;
        }
    }
}
