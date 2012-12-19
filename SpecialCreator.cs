using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;

namespace SpecialGenerator
{
    class SpecialCreator
    {

        public void DownloadImages(List<string> vehicles)
        {
            try
            {
                WebClient webClient = new WebClient();

                for (int i = 0; i <= vehicles.Count / 2; i++)
                {
                    Console.WriteLine("Downloading Images for Stock#: " + vehicles[0]);
                    webClient.DownloadFile(vehicles[1], @"c:\" + vehicles[0] + ".jpg");
                    vehicles.RemoveAt(1);
                    vehicles.RemoveAt(0);
                }

                webClient.Dispose();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
