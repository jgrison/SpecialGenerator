using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpecialGenerator
{
    public partial class SpecialGui : Form
    {
        public SpecialGui()
        {
            InitializeComponent();
        }

        private void SpecailGui_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            List<string> vehicles = new List<string>();

            string fileToParse = txtFileName.Text;

            SpecialCreator preownedSpecial = new SpecialCreator();

            vehicles = preownedSpecial.ParseDocument(fileToParse);

            MessageBox.Show(vehicles[0] + "\n" + vehicles[1] + "\n" + vehicles[2] + "\n" + vehicles[3] + "\n" + vehicles[4]);
        }

        private void btnOpenTextFile_Click(object sender, EventArgs e)
        {
            DialogResult result = openText.ShowDialog(); 

            if (result == DialogResult.OK)
            {
                string file = openText.FileName;
                txtFileName.Text = file;
            }
        }
    }
}
