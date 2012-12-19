using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;
using System.IO;

namespace SpecialGenerator
{
    class SpecialCreator
    {
        // Parse the document with vehicle information
        public List<string> ParseDocument(string fileLocation)
        {
            List<string> vehicleList = new List<string>();
            string line;

            using (StreamReader file = new StreamReader(@fileLocation))
            {
                while ((line = file.ReadLine()) != null)
                {

                    char[] delimiters = new char[] { '|' };

                    string[] parts = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < parts.Length; i++)
                    {
                        vehicleList.Add(parts[i]);
                    }
                }

                file.Close();
            }

            return vehicleList;
        }

        // Download the Images
        public string DownloadImages(List<string> vehicles)
        {
            try
            {
                WebClient webClient = new WebClient();

                for (int i = 0; i <= vehicles.Count / 2; i++)
                {
                    webClient.DownloadFile(vehicles[1], @"c:\" + vehicles[0] + ".jpg");
                    vehicles.RemoveAt(1);
                    vehicles.RemoveAt(0);
                }

                webClient.Dispose();
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
