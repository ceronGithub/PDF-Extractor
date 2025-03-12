using com.sun.corba.se.spi.orb;
using iTextSharp.text;
using iTextSharp.text.pdf;
using java.awt;
using java.awt.geom;
using javax.swing.text;
using org.apache.pdfbox.pdmodel;
using org.apache.pdfbox.util;
using org.w3c.dom;
using PdfiumViewer;
using Syncfusion.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PdfRenameApplication
{
    internal class General_class
    {
        Folder_creation folderCreation = new Folder_creation();
        public List<string> locateFile()
        {            
            OpenFileDialog browseFile = new OpenFileDialog();
            List<string> files = new List<string>();
            // allow text, and excel file only
            browseFile.Filter = "Document File |*.pdf";
            browseFile.Multiselect = true;
            browseFile.CheckFileExists = true;
            browseFile.AddExtension = true;

            // if click ok          
            if (browseFile.ShowDialog() == DialogResult.OK)
            {
                foreach(string filess in browseFile.FileNames)
                {
                    files.Add(filess);
                }                                
            }
            return files;
        }

        public void dynamicPdfGenerator(Form form, List<string> files, int page)
        {            
            PdfViewer[] pdfViewer = new PdfViewer[files.Count];
            string[] strippedString = new string[files.Count];
            string[] path = new string[files.Count];
            int ypos = 0;
            for (int i = 0; i < files.Count; i++)
            {
                if(i == 0)
                {
                    ypos = 70;
                }
                else
                {
                    ypos += 570;
                }
                pdfViewer[i] = new PdfViewer();
                pdfViewer[i].Height = 500;
                //pdfViewer[i].Width = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width;
                pdfViewer[i].Width = 800;
                pdfViewer[i].Location = new System.Drawing.Point(0, ypos);
                //zoom
                pdfViewer[i].ZoomMode = PdfViewerZoomMode.FitWidth;
                        
                // load pdf file.
                byte[] bytes = System.IO.File.ReadAllBytes(files[i]);
                var stream = new MemoryStream(bytes);
                PdfiumViewer.PdfDocument pdfDocument = PdfiumViewer.PdfDocument.Load(stream);
                pdfViewer[i].Document = pdfDocument;                

                //nuget freespire.PDFViewer.
                ////nuget install pdfiuemViewer
                ////nuget install pdfbox
                //nuget install IKVM.OpenJDK.Charset
                //nuget install IKVM.OpenJDK.Core
                //nuget install IKVM.OpenJDK.Util
                //nuget install IKVM.OpenJDK.Runtime                
                //general / choose item / browse /locationproject folder / packages / pdfiumviewer / lib / net20 / pdfiumviewer.dll                

                // get certain text from pdf
                PDDocument doc = PDDocument.load(files[i]);
                Rectangle2D rect = new Rectangle2D.Double(85, 90, 55, 10);
                PDFTextStripperByArea stripper = new PDFTextStripperByArea();
                String regionName = "INVOICE";
                stripper.addRegion(regionName, rect);
                stripper.extractRegions((PDPage)doc.getDocumentCatalog().getAllPages().get(page));
                strippedString[i] = string.Join("",stripper.getTextForRegion(regionName).Split(Path.GetInvalidFileNameChars()));                

                form.Controls.Add(pdfViewer[i]);
                
                double yypos = 150;
                double xxpos = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width * .65;
                pdfViewer[i].MouseMove += (sender, e) => trial_MouseMove(sender, e, stream);

                int adjustmentXY = 100;
                int adjustmentOneY = 50;
                int adjustmentOneX = 100;

                //dynamic design
                dynamicLabelAndTextOUTPUT(form, files.Count, Convert.ToInt32(xxpos) + adjustmentOneX, Convert.ToInt32(yypos)+ adjustmentOneY, strippedString[i]);
                dynamicLabelAndTextCOORDSX(form, files.Count, Convert.ToInt32(xxpos) + adjustmentXY, Convert.ToInt32(yypos) + adjustmentXY, strippedString[i]);
                dynamicLabelAndTextCOORDSY(form, files.Count, Convert.ToInt32(xxpos) + adjustmentXY, Convert.ToInt32(yypos) + adjustmentXY, strippedString[i]);
                dynamicLabelAndTextCOORDSWIDTH(form, files.Count, Convert.ToInt32(xxpos) + adjustmentXY, Convert.ToInt32(yypos) + adjustmentXY, strippedString[i]);
                dynamicLabelAndTextCOORDSHEIGHT(form, files.Count, Convert.ToInt32(xxpos) + adjustmentXY, Convert.ToInt32(yypos) + adjustmentXY, strippedString[i]);

                savePdfFile(folderCreation.folderPathStringProject(), pdfDocument, strippedString[i], ".pdf");                
            }
        }

        public void trial_MouseMove(object sender, MouseEventArgs e, MemoryStream stream)
        {
            /*
            var args = (MouseEventArgs)e;
            int _clickX = e.Location.X;
            int _clickY = e.Location.Y;

            Point DevicePoint = new Point((int)_clickX, (int)_clickY);
            PdfDocument pdfdocument = PdfDocument.Load(stream);
            PdfPoint PDFpoint = pdfdocument.PointToPdf(0,System.Drawing.Point(e.X, e.Y));

            float pdfX = PDFpoint.Location.X;
            float pdfY = PDFpoint.Location.Y;
            */
        }

        public string dynamicLabelAndTextOUTPUT(Form form, int ttlOfTextbox, int xpos, int ypos, string value)
        {            
            string output = "";
            System.Windows.Forms.Label[] labelOutput = new System.Windows.Forms.Label[ttlOfTextbox];
            System.Windows.Forms.TextBox[] txtOutput = new System.Windows.Forms.TextBox[ttlOfTextbox];

            for (int i = 0; i<ttlOfTextbox; i++)
            {
                if(i == 0)
                {
                    ypos = ypos;
                }
                else
                {
                    ypos += 600;
                }
                labelOutput[i] = new System.Windows.Forms.Label();
                labelOutput[i].Text = "INVOICE :";
                labelOutput[i].Width = 60;
                labelOutput[i].Height = 30;
                labelOutput[i].Location = new System.Drawing.Point(xpos,ypos);
                
                txtOutput[i] = new System.Windows.Forms.TextBox();
                txtOutput[i].Text = value;                
                txtOutput[i].Width = 150;
                txtOutput[i].Height = 30;
                txtOutput[i].Location = new System.Drawing.Point(xpos + 60, ypos-3);
                output = txtOutput[i].Text;                

                form.Controls.Add(labelOutput[i]);
                form.Controls.Add(txtOutput[i]);
            }
            return output;
        }

        public string dynamicLabelAndTextCOORDSX(Form form, int ttlOfTextbox, int xpos, int ypos, string value)
        {
            string output = "";
            System.Windows.Forms.Label[] labelOutput = new System.Windows.Forms.Label[ttlOfTextbox];
            System.Windows.Forms.TextBox[] txtOutput = new System.Windows.Forms.TextBox[ttlOfTextbox];

            for (int i = 0; i < ttlOfTextbox; i++)
            {
                if (i == 0)
                {
                    ypos = ypos;
                }
                else
                {
                    ypos += 600;
                }
                labelOutput[i] = new System.Windows.Forms.Label();
                labelOutput[i].Text = "X :";
                labelOutput[i].Width = 20;
                labelOutput[i].Height = 30;
                labelOutput[i].Location = new System.Drawing.Point(xpos, ypos + 50);

                txtOutput[i] = new System.Windows.Forms.TextBox();
                txtOutput[i].Text = "";
                txtOutput[i].Width = 30;
                txtOutput[i].Height = 30;
                txtOutput[i].Location = new System.Drawing.Point(xpos + 20, ypos - 3 + 50);
                output = txtOutput[i].Text;

                form.Controls.Add(labelOutput[i]);
                form.Controls.Add(txtOutput[i]);
            }
            return output;
        }

        public string dynamicLabelAndTextCOORDSY(Form form, int ttlOfTextbox, int xpos, int ypos, string value)
        {
            string output = "";
            System.Windows.Forms.Label[] labelOutput = new System.Windows.Forms.Label[ttlOfTextbox];
            System.Windows.Forms.TextBox[] txtOutput = new System.Windows.Forms.TextBox[ttlOfTextbox];

            for (int i = 0; i < ttlOfTextbox; i++)
            {
                if (i == 0)
                {
                    ypos = ypos;
                }
                else
                {
                    ypos += 600;
                }
                labelOutput[i] = new System.Windows.Forms.Label();
                labelOutput[i].Text = "Y :";
                labelOutput[i].Width = 20;
                labelOutput[i].Height = 30;
                labelOutput[i].Location = new System.Drawing.Point(xpos + 60, ypos + 50);

                txtOutput[i] = new System.Windows.Forms.TextBox();
                txtOutput[i].Text = "";
                txtOutput[i].Width = 30;
                txtOutput[i].Height = 30;
                txtOutput[i].Location = new System.Drawing.Point(xpos + 80, ypos - 3 + 50);
                output = txtOutput[i].Text;

                form.Controls.Add(labelOutput[i]);
                form.Controls.Add(txtOutput[i]);
            }
            return output;
        }

        public string dynamicLabelAndTextCOORDSWIDTH(Form form, int ttlOfTextbox, int xpos, int ypos, string value)
        {
            string output = "";
            System.Windows.Forms.Label[] labelOutput = new System.Windows.Forms.Label[ttlOfTextbox];
            System.Windows.Forms.TextBox[] txtOutput = new System.Windows.Forms.TextBox[ttlOfTextbox];

            for (int i = 0; i < ttlOfTextbox; i++)
            {
                if (i == 0)
                {
                    ypos = ypos;
                }
                else
                {
                    ypos += 600;
                }
                labelOutput[i] = new System.Windows.Forms.Label();
                labelOutput[i].Text = "WIDTH :";
                labelOutput[i].Width = 50;
                labelOutput[i].Height = 30;
                labelOutput[i].Location = new System.Drawing.Point(xpos, ypos + 85);

                txtOutput[i] = new System.Windows.Forms.TextBox();
                txtOutput[i].Text = "";
                txtOutput[i].Width = 50;
                txtOutput[i].Height = 30;
                txtOutput[i].Location = new System.Drawing.Point(xpos + 50, ypos - 3 + 85);
                output = txtOutput[i].Text;

                form.Controls.Add(labelOutput[i]);
                form.Controls.Add(txtOutput[i]);
            }
            return output;
        }

        public string dynamicLabelAndTextCOORDSHEIGHT(Form form, int ttlOfTextbox, int xpos, int ypos, string value)
        {
            string output = "";
            System.Windows.Forms.Label[] labelOutput = new System.Windows.Forms.Label[ttlOfTextbox];
            System.Windows.Forms.TextBox[] txtOutput = new System.Windows.Forms.TextBox[ttlOfTextbox];

            for (int i = 0; i < ttlOfTextbox; i++)
            {
                if (i == 0)
                {
                    ypos = ypos;
                }
                else
                {
                    ypos += 600;
                }
                labelOutput[i] = new System.Windows.Forms.Label();
                labelOutput[i].Text = "HEIGHT :";
                labelOutput[i].Width = 55;
                labelOutput[i].Height = 30;
                labelOutput[i].Location = new System.Drawing.Point(xpos, ypos + 120);

                txtOutput[i] = new System.Windows.Forms.TextBox();
                txtOutput[i].Text = "";
                txtOutput[i].Width = 50;
                txtOutput[i].Height = 30;
                txtOutput[i].Location = new System.Drawing.Point(xpos + 55, ypos - 3 + 120);
                output = txtOutput[i].Text;

                form.Controls.Add(labelOutput[i]);
                form.Controls.Add(txtOutput[i]);
            }
            return output;
        }

        public void savePdfFile(string path, PdfiumViewer.PdfDocument pdfDocument, string fileName, string fileExtension)
        {            
            string file = path + "\\" + fileName + fileExtension;          
            //System.IO.File.Copy(pathFolder, path[i]);
            pdfDocument.Save(file);
        }
    }
}
