using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace SpecialGenerator
{
    class SpecialCreator
    {
        // Parse the document with vehicle information
        public List<string> ParseDocument(string fileLocation)
        {
            List<string> vehicleList = new List<string>();
            string line;

            try
            {
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
            catch (IOException ex)
            {
                MessageBox.Show(ex.ToString(), "File Read Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return vehicleList;
            }
        }

        // Download the Images
        public void DownloadImages(string vehicleStockNumber, string vehicleImage)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFile(vehicleImage, @"C:\Users\jgrison\Documents\Development\Test\Cars\" + vehicleStockNumber + ".jpg");
                webClient.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Image Download Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Generate the preowned specials
        public void GenerateSpecial(int dealershipID, string vehicleStockNumber, string vehiclePreviousPrice, string vehiclePrice, string vehicleName, string saveLocation)
        {
            // ToyotaTown
            if (dealershipID == 0)
            {
                Bitmap specialTemplate = new Bitmap(@"C:\Users\jgrison\Documents\Development\Test\Template Files\tt_template.png");
                Bitmap vImage = new Bitmap(@"C:\Users\jgrison\Documents\Development\Test\Cars\" + vehicleStockNumber + ".jpg");
                Bitmap priceOverlay = new Bitmap(@"C:\Users\jgrison\Documents\Development\Test\Template Files\price_overlay.png");

                // Create a new instances of Graphics from the Bitmap
                Graphics g = Graphics.FromImage(specialTemplate);

                // Draw & Resize the image as required
                g.DrawImage(vImage, 90, 80, 320, 214);

                // Create a new StringFormat and set its alignment to center
                StringFormat strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Center;

                // Draw the text on the image
                g.DrawString(vehicleName, new Font("Tahoma", 5, FontStyle.Bold), Brushes.Black, new RectangleF(0, 300, 500, 500), strFormat);
                g.DrawString("$" + vehiclePreviousPrice, new Font("Tahoma", 6, FontStyle.Bold), Brushes.Black, new RectangleF(-90, 350, 500, 500), strFormat);
                g.DrawString("$" + vehiclePrice, new Font("Tahoma", 6, FontStyle.Bold), Brushes.Black, new RectangleF(-90, 393, 500, 500), strFormat);
                g.DrawString("+HST & Licensing Fees  |  Stock #" + vehicleStockNumber, new Font("Tahoma", 3), Brushes.Black, new RectangleF(0, 430, 500, 500), strFormat);

                // Draw line through was price
                g.DrawImageUnscaled(priceOverlay, 100, 356);

                // Save the special and push success or failure message
                specialTemplate.Save(saveLocation + "\\" + vehicleStockNumber + ".png");

            }
            
            // Richmond Hill Toyota
            else if (dealershipID == 1)
            {
                Bitmap specialTemplate = new Bitmap(@"C:\Users\jgrison\Documents\Development\Test\Template Files\rht_template.png");
                Bitmap vImage = new Bitmap(@"C:\Users\jgrison\Documents\Development\Test\Cars\" + vehicleStockNumber + ".jpg");
                Bitmap priceOverlay = new Bitmap(@"C:\Users\jgrison\Documents\Development\Test\Template Files\price_overlay.png");

                // Create a new instances of Graphics from the Bitmap
                Graphics g = Graphics.FromImage(specialTemplate);

                // Draw & Resize the image as required
                g.DrawImage(vImage, 90, 80, 320, 214);

                // Create a new StringFormat and set its alignment to center
                StringFormat strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Center;

                // Draw the text on the image
                g.DrawString(vehicleName, new Font("Tahoma", 5, FontStyle.Bold), Brushes.Black, new RectangleF(0, 300, 500, 500), strFormat);
                g.DrawString("$" + vehiclePreviousPrice, new Font("Tahoma", 6, FontStyle.Bold), Brushes.Black, new RectangleF(-90, 350, 500, 500), strFormat);
                g.DrawString("$" + vehiclePrice, new Font("Tahoma", 6, FontStyle.Bold), Brushes.Black, new RectangleF(-90, 393, 500, 500), strFormat);
                g.DrawString("+HST & Licensing Fees  |  Stock #" + vehicleStockNumber, new Font("Tahoma", 3), Brushes.Black, new RectangleF(0, 430, 500, 500), strFormat);

                // Draw line through was price
                g.DrawImageUnscaled(priceOverlay, 100, 356);

                // Save the special and push success or failure message
                specialTemplate.Save(saveLocation + "\\" + vehicleStockNumber + ".png");

            }

            // Lexus of London
            else if (dealershipID == 2)
            {
                Bitmap specialTemplate = new Bitmap(@"C:\Users\jgrison\Documents\Development\Test\Template Files\lol_template.png");
                Bitmap vImage = new Bitmap(@"C:\Users\jgrison\Documents\Development\Test\Cars\" + vehicleStockNumber + ".jpg");

                // Create a new instances of Graphics from the Bitmap
                Graphics g = Graphics.FromImage(specialTemplate);

                // Draw & Resize the image as required
                g.DrawImage(vImage, 60, 95, 330, 224);

                // Create a new StringFormat and set its alignment to center
                StringFormat strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Center;

                // Draw the text on the image
                g.DrawString(vehicleName, new Font("Tahoma", 20, FontStyle.Bold), Brushes.Black, new RectangleF(0, 322, 450, 500), strFormat);
                g.DrawString("$" + vehiclePreviousPrice, new Font("Tahoma", 18, FontStyle.Bold), Brushes.White, new RectangleF(-90, 362, 937, 500), strFormat);
                g.DrawString("$" + vehiclePrice, new Font("Tahoma", 36, FontStyle.Bold), Brushes.Black, new RectangleF(-90, 368, 500, 500), strFormat);
                g.DrawString(vehicleStockNumber, new Font("Tahoma", 14), Brushes.White, new RectangleF(0, 382, 746, 500), strFormat);

                // Save the special and push success or failure message
                specialTemplate.Save(saveLocation + "\\" + vehicleStockNumber + ".png");
            }
        }
    }
}
