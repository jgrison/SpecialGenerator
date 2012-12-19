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
    public partial class SpecailGui : Form
    {
        public SpecailGui()
        {
            InitializeComponent();
        }

        private void SpecailGui_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            List<string> vehicles = new List<string>();

            string fileToParse = @"C:\Users\Jeff\Documents\Visual Studio 2012\Projects\SpecialGenerator\Test\cars.txt";

            SpecialCreator preownedSpecial = new SpecialCreator();

            vehicles = preownedSpecial.ParseDocument(fileToParse);
            MessageBox.Show(vehicles[0] + vehicles[1] + vehicles[2] + vehicles[3]);
        }
    }
}
