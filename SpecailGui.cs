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

            vehicles.Add("N0001");
            vehicles.Add("http://pictures.dealer.com/t/toyotatownltdtc/0191/d85f7f07be30c4bdc2e0bc578ce3c511x.jpg");
            vehicles.Add("N0002");
            vehicles.Add("http://pictures.dealer.com/t/toyotatownltdtc/1475/thumb_3df8889fd7ef3401b2aff3b42fc81193x.jpg");

            SpecialCreator preownedSpecial = new SpecialCreator();
            MessageBox.Show(preownedSpecial.DownloadImages(vehicles));
        }
    }
}
