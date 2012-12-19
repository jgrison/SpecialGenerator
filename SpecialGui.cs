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
            cmbDealership.Items.Add("Richmond Hill Toyota");
            cmbDealership.Items.Add("Lexus Of London");
            cmbDealership.SelectedIndex = 0;
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

            List<string> vImagesDownload = new List<string>();

            for (int i = 0; i <= vehicles.Count - 1; i++)
            {
                vImagesDownload.Add(vehicles[i]);
            }
            
            if (chkDownload.Checked)
            {
                // Loops through and downloads all the image files
                for (int i = 0; i <= vImagesDownload.Count / 4; i++)
                {
                    preownedSpecial.DownloadImages(vImagesDownload[0], vImagesDownload[4]);
                    vImagesDownload.RemoveRange(0, 5);
                }
            }

            // Loops through and writes the images
            for (int i = 0; i <= vehicles.Count / 4; i++)
            {
                preownedSpecial.GenerateSpecial(cmbDealership.SelectedIndex, vehicles[0], vehicles[1], vehicles[2], vehicles[3], saveLocation);
                vehicles.RemoveRange(0, 5);
            }
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
