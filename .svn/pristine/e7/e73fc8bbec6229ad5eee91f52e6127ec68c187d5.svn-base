using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Drawing.Printing;
using Neurotec.Biometrics;
using Neurotec.Images;
using System.Drawing.Imaging;
using System.Reflection;
using System.Drawing.Drawing2D;

namespace Capturer.Forms
{
    public partial class DecaDactilarForm : Form
    {
       
        private PrintDocument printDocument1 = new PrintDocument();
        Bitmap memoryImage= null;
       
        PrintDialog printdlg = new PrintDialog();
        PrintPreviewDialog printPrvDlg = new PrintPreviewDialog();
        private Bitmap  _decaDactilar;
     
        private PrintPreviewControl ppc;
      

      

        public DecaDactilarForm()
        {
            InitializeComponent();
          //  imprimir.Click += new EventHandler(imprimir_Click);
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printDocument1.DefaultPageSettings.Landscape = true; //or false!
            printDocument1.OriginAtMargins = true;
            this.Size = new Size(1940,700);
             
           
            
        }

       public  void inicializaImagen(Bitmap deca)
        {


           _decaDactilar = deca;
        }

     


       
        void imprimir_Click(object sender, EventArgs e)
        {
                  // printDocument1.DefaultPageSettings.Landscape = true;
           printPrvDlg.Document = printDocument1;
           printPrvDlg.ShowDialog();
          // printDocument1.Print();
         
        }

       
     

     /*   private void SaveImage(Bitmap b)
        {
            b.Save(@"C:\imagenesDeca\\imagenDeca.bmp");
        
        }*/

        private void SalvaImagen(Bitmap b)
        {
            // Displays a SaveFileDialog so the user can save the Image
            // assigned to Button2.
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog1.Title = "Indique el directorio donde guardar la Decadactilar";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                   (System.IO.FileStream)saveFileDialog1.OpenFile();
                // Saves the Image in the appropriate ImageFormat based upon the
                // File type selected in the dialog box.
                // NOTE that the FilterIndex property is one-based.
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        b.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case 2:
                       b.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Bmp);
                        break;

                    case 3:
                        b.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                }

                fs.Close();
            }
        }


        private void printDocument1_PrintPage(System.Object sender,System.Drawing.Printing.PrintPageEventArgs e)
        {

            // This code will print a 27 cm X 18 cm image at Left = 2.54 cm, Top  = 2.54 cm on landscape paper.
            //double cmToUnits = 100 / 2.54;
            //e.Graphics.DrawImage(memoryImage, 0, 0,(float)(27 * cmToUnits),(float)(18 * cmToUnits));

            double cmToUnits = 100 / 2.54;
            
          //  e.Graphics.DrawImage(memoryImage, 0, 0, (float)(20 * cmToUnits), (float)(8 * cmToUnits));
            e.Graphics.DrawImage(memoryImage, 0, 0, (float)(20 * cmToUnits), (float)(8 * cmToUnits));
        




        }

       
        private void DecaDactilarForm_Load(object sender, EventArgs e)
        {
            // Carga la pantalla setea Imagenes y prepara el bmp
            
        }

    

        private void button1_Click_1(object sender, EventArgs e)
        {

            // printDocument1.DefaultPageSettings.Landscape = true;
            printPrvDlg.Document = printDocument1;
           
            Size rect = new Size(800,900);
            printPrvDlg.ClientSize = rect;
          
            printPrvDlg.ShowDialog();

            // printDocument1.Print();
        }
        public static Bitmap resizeImage(Bitmap imgToResize, Size size)
        {
            return (new Bitmap(imgToResize, size));
        }

        private void DecaDactilarForm_Paint(object sender, PaintEventArgs e)
        {
           //1924,811
            int alto, ancho;
            alto = e.ClipRectangle.Height / 539 == 0 ? 1 : e.ClipRectangle.Height / 539;
            ancho = e.ClipRectangle.Width / 1386 == 0 ? 1 : e.ClipRectangle.Width / 1386 ;
           
           Bitmap nuevo = new Bitmap(_decaDactilar,new Size(ancho * 1386,alto  * 539));
            e.Graphics.DrawImage(nuevo, new Point(10, 10));
          
         
            
        }

        private void DecaDactilarForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _decaDactilar.Dispose();
        }






       

    }
}
