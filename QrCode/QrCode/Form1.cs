using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MessagingToolkit.QRCode;
using MessagingToolkit.QRCode.Codec;

namespace QrCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Image QRCodeOlustur(string Veri1, int QrCodeDuzey)
        {
            
                string veri = Veri1;
                MessagingToolkit.QRCode.Codec.QRCodeEncoder QrCodeEncode = new MessagingToolkit.QRCode.Codec.QRCodeEncoder();
                QrCodeEncode.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                string ECC = comboBox2.SelectedItem.ToString();
                if (ECC == "L") { QrCodeEncode.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L; }
                else if (ECC == "M") { QrCodeEncode.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M; }
                else if (ECC == "Q") { QrCodeEncode.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.Q; }
                else if (ECC == "H") { QrCodeEncode.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H; }
               
                  QrCodeEncode.QRCodeVersion = QrCodeDuzey;
                  try
                  {
                      System.Drawing.Bitmap BitMap = QrCodeEncode.Encode(veri);
                      return BitMap; 
                  }
                  catch (Exception)
                  {   MessageBox.Show("Lütfen Kategori Ayarını Doğru Seçiniz");
                      string hata="Hata";
                      System.Drawing.Bitmap BitMap2 = QrCodeEncode.Encode(hata);
                      return BitMap2;
                  }
                
               
         }
        private void button2_Click(object sender, EventArgs e)
        {
            Image ResimAl;
            ResimAl = pictureBox1.Image;
            ResimAl.Save("D:\\" + RandomString(4) + ".jpg");
            MessageBox.Show("Olusturulan QR Code’unuz D’ye Kaydedildi.");
        }

        private string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int seviye = Convert.ToInt32(comboBox1.SelectedItem.ToString());
                pictureBox1.Image = QRCodeOlustur(textBox1.Text, seviye);
            }
            catch (Exception) {
                MessageBox.Show("Lütfen Kategori Ayarlarını Seçiniz");
            }
        }

        
    }
}
