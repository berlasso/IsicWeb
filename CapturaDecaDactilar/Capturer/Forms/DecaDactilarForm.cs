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

namespace Capturer.Forms
{
    public partial class DecaDactilarForm : Form
    {
        public Image []_dedos = new Image[10];
        private PrintDocument printDocument1 = new PrintDocument();
        Bitmap memoryImage= null;
       
        PrintDialog printdlg = new PrintDialog();
        PrintPreviewDialog printPrvDlg = new PrintPreviewDialog();

        

        private PrintPreviewControl ppc;
      

      

        public DecaDactilarForm()
        {
            InitializeComponent();
          //  imprimir.Click += new EventHandler(imprimir_Click);
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printDocument1.DefaultPageSettings.Landscape = true; //or false!
            printDocument1.OriginAtMargins = true;
             
           
            
        }
     
       

     


       
        void imprimir_Click(object sender, EventArgs e)
        {
           CaptureScreen();
          // printDocument1.DefaultPageSettings.Landscape = true;
           printPrvDlg.Document = printDocument1;
           printPrvDlg.ShowDialog();
          // printDocument1.Print();
         
        }

       
        private void CaptureScreen()
        {
            if (memoryImage != null)
            {
                SalvaImagen(memoryImage);
                return;
            }
            Graphics myGraphics = this.CreateGraphics();
            
            Size s = this.BackgroundImage.Size;

            s.Width = s.Width - 50;
            s.Height = s.Height - 30;
             memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            //Bitmap resized = new Bitmap(memoryImage, new Size(s.Width / 50, s.Height / 50));
          
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
           
            memoryGraphics.CopyFromScreen(this.Location.X + 25, this.Location.Y+ 30, 0, 0, s);
        //   memoryImage = new Bitmap(s.Width/2, s.Height/2, memoryGraphics);
              // SaveImage(memoryImage);
            SalvaImagen(memoryImage);
           
                   
   
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

        public void InicilizaDedos(MemoryStream []imgStream, string apeynom, string codigBarra)
        {
            this.lCodBarra.Text = codigBarra;
            this.lApeyNom.Text = apeynom;
            for (var i = 0; i < 10; i++)
            {
              
                if (imgStream[i] != null)
                { _dedos[i] = Image.FromStream(imgStream[i]); }
                // Pruebo darle un dedo al NFingerView
               
            }
         /* crear un fingerView con tempplate 
          * this.nFAnularView.Finger = dedosF[1];


            using (NImage image =  dedosF[1].GetImage(false))
				{float zoom = 1;
					if (image != null)
					{
						Size clientSize = nFAnularView.Size;

						
						zoom = Math.Min((float)clientSize.Width / (int)image.Width, (float)clientSize.Height / (int)image.Height);
						zoom = Math.Max(0.01f, zoom);
					}
                nFAnularView.Zoom = zoom;
			    nFAnularView.Invalidate();
				}
			
			*/
        }
        public void SeteaImagenes()
        {
            if (_dedos[0] != null)
            {
                pulgarIzquierdo.Image = _dedos[0];
                this.pulgarIzquierdo.SizeMode = PictureBoxSizeMode.Zoom;
                pulgarDerecho.Refresh();
            }
            if (_dedos[1] != null)
            {
                indiceIzquierdo.Image = _dedos[1];
                this.indiceIzquierdo.SizeMode = PictureBoxSizeMode.Zoom;
                indiceIzquierdo.Refresh();
            }

            if (_dedos[2] != null)
            {
                medioIzquierdo.Image = _dedos[2];
                this.medioIzquierdo.SizeMode = PictureBoxSizeMode.Zoom;
                medioIzquierdo.Refresh();
            }

            if (_dedos[3] != null)
            {
                anularIzquierdo.Image = _dedos[3];
                this.anularIzquierdo.SizeMode = PictureBoxSizeMode.Zoom;
                anularIzquierdo.Refresh();
            }

            if (_dedos[4] != null)
            {
                meniqueIzquierdo.Image = _dedos[4];
                this.meniqueIzquierdo.SizeMode = PictureBoxSizeMode.Zoom;
                meniqueIzquierdo.Refresh();
            }
            if (_dedos[5] != null)
            {
                pulgarDerecho.Image = _dedos[5];
                this.pulgarDerecho.SizeMode = PictureBoxSizeMode.Zoom;
                pulgarDerecho.Refresh();
            }
            if (_dedos[6] != null)
            {
                indiceDerecho.Image = _dedos[6];
                this.indiceDerecho.SizeMode = PictureBoxSizeMode.Zoom;
                indiceDerecho.Refresh();
            }
            if (_dedos[7] != null)
            {
                medioDerecho.Image = _dedos[7];
                this.medioDerecho.SizeMode = PictureBoxSizeMode.Zoom;
                medioDerecho.Refresh();
            }
            if (_dedos[8] != null)
            {
                anularDerecho.Image = _dedos[8];
                this.anularDerecho.SizeMode = PictureBoxSizeMode.Zoom;
                anularDerecho.Refresh();
            }

            if (_dedos[9] != null)
            {
                meniqueDerecho.Image = _dedos[9];
                this.meniqueDerecho.SizeMode = PictureBoxSizeMode.Zoom;
                meniqueDerecho.Refresh();
            }

           
        }

        private void DecaDactilarForm_Load(object sender, EventArgs e)
        {
            // Carga la pantalla setea Imagenes y prepara el bmp
            SeteaImagenes();
            

        }

    

        private void button1_Click_1(object sender, EventArgs e)
        {
            CaptureScreen();
            // printDocument1.DefaultPageSettings.Landscape = true;
            printPrvDlg.Document = printDocument1;
           
            Size rect = new Size(800,900);
            printPrvDlg.ClientSize = rect;
          
            printPrvDlg.ShowDialog();

            // printDocument1.Print();
        }

       
       

       

    }
}
