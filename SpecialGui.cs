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
            cmbDealership.Items.Add("Toyota Town");
            cmbDealership.Items.Add("Lexus Of London");
            cmbDealership.Items.Add("Richmond Hill Toyota");
            cmbDealership.SelectedIndex = 0;

            MessageBox.Show(cmbDealership.SelectedIndex.ToString());
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            List<string> vehicles = new List<string>();

            string fileToParse = txtFileName.Text;
            string saveLocation = txtSaveLocation.Text;

            // Create a new Special Instance
            SpecialCreator preownedSpecial = new SpecialCreator();

            // Parse the document and load in all the vehicles
            vehicles = preownedSpecial.ParseDocument(fileToParse);

            // Generate the specials
            preownedSpecial.GenerateSpecial(cmbDealership.SelectedIndex, vehicles[0], vehicles[1], vehicles[2], vehicles[3], saveLocation);
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

        private void btnSaveLocation_Click(object sender, EventArgs e)
        {
            DialogResult save = saveFolder.ShowDialog();

            if (save == DialogResult.OK)
            {
                txtSaveLocation.Text = saveFolder.SelectedPath;
            }

        }
    }
}
