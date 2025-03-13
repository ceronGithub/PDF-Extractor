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

        public PdfiumViewer.PdfDocument dynamicPdfGenerator(Form form, string files, int ypos)
        {           
            PdfViewer pdfViewer = new PdfViewer();
            pdfViewer = new PdfViewer();
            pdfViewer.Height = 500;
            //pdfViewer[i].Width = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width;
            pdfViewer.Width = 800;
            pdfViewer.Location = new System.Drawing.Point(0, ypos);
            //zoom
            pdfViewer.ZoomMode = PdfViewerZoomMode.FitWidth;
                        
            // load pdf file.
            byte[] bytes = System.IO.File.ReadAllBytes(files);
            var stream = new MemoryStream(bytes);
            PdfiumViewer.PdfDocument pdfDocument = PdfiumViewer.PdfDocument.Load(stream);
            pdfViewer.Document = pdfDocument;          

            //nuget freespire.PDFViewer.
            ////nuget install pdfiuemViewer
            ////nuget install pdfbox
            //nuget install IKVM.OpenJDK.Charset
            //nuget install IKVM.OpenJDK.Core
            //nuget install IKVM.OpenJDK.Util
            //nuget install IKVM.OpenJDK.Runtime                
            //general / choose item / browse /locationproject folder / packages / pdfiumviewer / lib / net20 / pdfiumviewer.dll                

            form.Controls.Add(pdfViewer);
            return pdfDocument;                            
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

        public void dynamicLabelAndTextOUTPUT(Form form, int i, int xpos, int ypos)
        {  
            System.Windows.Forms.Label labelOutput = new System.Windows.Forms.Label();
            System.Windows.Forms.TextBox txtOutput = new System.Windows.Forms.TextBox();
            
            labelOutput.Name = "PDF-output-lbl-" + i;
            labelOutput.Text = "INVOICE :";
            labelOutput.Width = 60;
            labelOutput.Height = 30;
            labelOutput.Location = new System.Drawing.Point(xpos,ypos);
                            
            txtOutput.Name = "PDF-output-txt-" + i;
            txtOutput.Text = "";                
            txtOutput.Width = 150;
            txtOutput.Height = 30;
            txtOutput.Location = new System.Drawing.Point(xpos + 60, ypos-3);                

            form.Controls.Add(labelOutput);
            form.Controls.Add(txtOutput);                        
        }

        public void dynamicLabelAndTextCOORDSX(Form form, int i, int xpos, int ypos)
        {            
            System.Windows.Forms.Label labelOutput = new System.Windows.Forms.Label();
            System.Windows.Forms.TextBox txtOutput = new System.Windows.Forms.TextBox();

            labelOutput = new System.Windows.Forms.Label();
            labelOutput.Name = "PDF-x-lbl-" + i;
            labelOutput.Text = "X :";
            labelOutput.Width = 20;
            labelOutput.Height = 30;
            labelOutput.Location = new System.Drawing.Point(xpos, ypos + 50);

            txtOutput = new System.Windows.Forms.TextBox();
            txtOutput.Name = "PDF-x-txt-" + i;
            txtOutput.Text = "";
            txtOutput.Width = 30;
            txtOutput.Height = 30;
            txtOutput.Location = new System.Drawing.Point(xpos + 20, ypos - 3 + 50);            

            form.Controls.Add(labelOutput);
            form.Controls.Add(txtOutput);            
        }

        public void dynamicLabelAndTextCOORDSY(Form form, int i, int xpos, int ypos)
        {
            System.Windows.Forms.Label labelOutput = new System.Windows.Forms.Label();
            System.Windows.Forms.TextBox txtOutput = new System.Windows.Forms.TextBox();
         
            labelOutput = new System.Windows.Forms.Label();
            labelOutput.Name = "PDF-y-lbl-" + i;
            labelOutput.Text = "Y :";
            labelOutput.Width = 20;
            labelOutput.Height = 30;
            labelOutput.Location = new System.Drawing.Point(xpos + 60, ypos + 50);

            txtOutput = new System.Windows.Forms.TextBox();
            txtOutput.Name = "PDF-y-txt-" + i;
            txtOutput.Text = "";
            txtOutput.Width = 30;
            txtOutput.Height = 30;
            txtOutput.Location = new System.Drawing.Point(xpos + 80, ypos - 3 + 50);            

            form.Controls.Add(labelOutput);
            form.Controls.Add(txtOutput);            
        }

        public void dynamicLabelAndTextCOORDSWIDTH(Form form, int i, int xpos, int ypos)
        {
            System.Windows.Forms.Label labelOutput = new System.Windows.Forms.Label();
            System.Windows.Forms.TextBox txtOutput = new System.Windows.Forms.TextBox();
            
            labelOutput = new System.Windows.Forms.Label();
            labelOutput.Name = "PDF-w-lbl-" + i;
            labelOutput.Text = "WIDTH :";
            labelOutput.Width = 50;
            labelOutput.Height = 30;
            labelOutput.Location = new System.Drawing.Point(xpos, ypos + 90);

            txtOutput = new System.Windows.Forms.TextBox();
            txtOutput.Name = "PDF-w-txt-" + i;
            txtOutput.Text = "";
            txtOutput.Width = 50;
            txtOutput.Height = 30;
            txtOutput.Location = new System.Drawing.Point(xpos + 55, ypos - 3 + 90);           

            form.Controls.Add(labelOutput);
            form.Controls.Add(txtOutput);            
        }

        public void dynamicLabelAndTextCOORDSHEIGHT(Form form, int i, int xpos, int ypos)
        {
            System.Windows.Forms.Label labelOutput = new System.Windows.Forms.Label();
            System.Windows.Forms.TextBox txtOutput = new System.Windows.Forms.TextBox();

            labelOutput = new System.Windows.Forms.Label();
            labelOutput.Name = "PDF-h-lbl-" + i;
            labelOutput.Text = "HEIGHT :";
            labelOutput.Width = 55;
            labelOutput.Height = 30;
            labelOutput.Location = new System.Drawing.Point(xpos, ypos + 120);

            txtOutput = new System.Windows.Forms.TextBox();
            txtOutput.Name = "PDF-h-txt-" + i;                
            txtOutput.Width = 50;
            txtOutput.Height = 30;
            txtOutput.Location = new System.Drawing.Point(xpos + 55, ypos - 3 + 120);            

            form.Controls.Add(labelOutput);
            form.Controls.Add(txtOutput);            
        }

        public void dynamicLabelAndTextCOORDPAGE(Form form, int i, int xpos, int ypos)
        {
            System.Windows.Forms.Label labelOutput = new System.Windows.Forms.Label();
            System.Windows.Forms.TextBox txtOutput = new System.Windows.Forms.TextBox();

            labelOutput = new System.Windows.Forms.Label();
            labelOutput.Name = "PDF-pg-lbl-" + i;
            labelOutput.Text = "PAGES :";                
            labelOutput.Width = 50;
            labelOutput.Height = 30;
            labelOutput.Location = new System.Drawing.Point(xpos, ypos + 150);

            txtOutput = new System.Windows.Forms.TextBox();
            txtOutput.Name = "PDF-pg-txt-" + i;
            txtOutput.Text = "";
            txtOutput.Width = 50;
            txtOutput.Height = 30;
            txtOutput.Location = new System.Drawing.Point(xpos + 55, ypos - 3 + 150);            

            form.Controls.Add(labelOutput);
            form.Controls.Add(txtOutput);
           
        }

        public void dynamicCropBtn(Form form, int i, int xpos, int ypos, string file, string path, PdfiumViewer.PdfDocument pdfDocument, string fileExtension)
        //public string dynamicCropBtn(Form form, int ttlOfTextbox, int xpos, int ypos, string value)
        {            
            System.Windows.Forms.Button cropBtn = new System.Windows.Forms.Button();
           
            cropBtn = new System.Windows.Forms.Button();
            cropBtn.Name = "CropBtn" + i;
            cropBtn.Text = "Re/Crop";
            cropBtn.Width = 80;
            cropBtn.Height = 85;
            cropBtn.Location = new System.Drawing.Point(xpos + 120, ypos + 130);                
            form.Controls.Add(cropBtn);
                
            cropBtn.Click += (sender, e) => cropString(sender, e, file, form, i, path, pdfDocument, fileExtension);            
        }

        public void cropString(object sender, EventArgs e, string file, Form form, int index, string path, PdfiumViewer.PdfDocument pdfDocument, string fileExtension)
        {
            string strippedString = "";            
            
            if (form.Controls[("CropBtn" + (index))].Text != "Re/Crop")
            {                
                strippedString = form.Controls[("PDF-output-txt-" + (index))].Text;
                //check if string is empty
                if (strippedString != "")
                {
                    form.Controls[("CropBtn" + (index))].Text = "Re/Crop";
                    savePdfFile(folderCreation.folderPathStringProject(), pdfDocument, strippedString, ".pdf");
                    MessageBox.Show("PDF-file has been created \n @ : " + folderCreation.folderPathStringProject(), "NOTE!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string[] dynamicTxtboxName = { "PDF-x-txt-" + (index), "PDF-y-txt-" + (index), "PDF-w-txt-" + (index), "PDF-h-txt-" + (index), "PDF-pg-txt-" + (index), "PDF-output-txt-" + (index) };
                    form.Controls[dynamicTxtboxName[0]].Text = "";
                    form.Controls[dynamicTxtboxName[1]].Text = "";
                    form.Controls[dynamicTxtboxName[2]].Text = "";
                    form.Controls[dynamicTxtboxName[3]].Text = "";
                    form.Controls[dynamicTxtboxName[4]].Text = "";
                    form.Controls[dynamicTxtboxName[5]].Text = "";
                }
                else
                {
                    MessageBox.Show("Stripped string is empty", "NOTE!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    form.Controls[("CropBtn" + (index))].Text = "Re/Crop";
                }                
            }           
            else
            {
                double[] cords = new double[4];
                int page = 0;

                string[] dynamicTxtboxName = { "PDF-x-txt-" + (index), "PDF-y-txt-" + (index), "PDF-w-txt-" + (index), "PDF-h-txt-" + (index), "PDF-pg-txt-" + (index), "PDF-output-txt-" + (index) };
                //convertion from string to double
                Double.TryParse(form.Controls[dynamicTxtboxName[0]].Text, out cords[0]);
                Double.TryParse(form.Controls[dynamicTxtboxName[1]].Text, out cords[1]);
                Double.TryParse(form.Controls[dynamicTxtboxName[2]].Text, out cords[2]);
                Double.TryParse(form.Controls[dynamicTxtboxName[3]].Text, out cords[3]);
                int.TryParse(form.Controls[dynamicTxtboxName[4]].Text, out page);

                // get certain text from pdf
                PDDocument doc = PDDocument.load(file);
                Rectangle2D rect = new Rectangle2D.Double(cords[0], cords[1], cords[2], cords[3]);
                PDFTextStripperByArea stripper = new PDFTextStripperByArea();
                String regionName = "INVOICE";
                stripper.addRegion(regionName, rect);
                stripper.extractRegions((PDPage)doc.getDocumentCatalog().getAllPages().get(page));
                strippedString = string.Join("", stripper.getTextForRegion(regionName).Split(Path.GetInvalidFileNameChars()));

                form.Controls[dynamicTxtboxName[5]].Text = strippedString;
                DialogResult result = MessageBox.Show("CHECK INVOICE. \n CLICK YES TO SAVE \n CLICK NO TO MODIFY COORDINATES","NOTE!",MessageBoxButtons.YesNo,MessageBoxIcon.Information);                
                if (result == DialogResult.Yes)
                {
                    form.Controls[dynamicTxtboxName[5]].Text = strippedString;
                    form.Controls[("CropBtn" + (index))].Text = "SAVE-PDF";
                }
                else
                {
                    form.Controls[dynamicTxtboxName[5]].Text = strippedString;
                    form.Controls[("CropBtn" + (index))].Text = "Re/Crop";
                }
            }            
            
            //return strippedString;
        }

        public string defaultCropString(string file, int page)
        {
            string strippedString = "";

            // get certain text from pdf
            PDDocument doc = PDDocument.load(file);
            Rectangle2D rect = new Rectangle2D.Double(85, 90, 55, 10);
            PDFTextStripperByArea stripper = new PDFTextStripperByArea();
            String regionName = "INVOICE";
            stripper.addRegion(regionName, rect);
            stripper.extractRegions((PDPage)doc.getDocumentCatalog().getAllPages().get(page));
            strippedString = string.Join("", stripper.getTextForRegion(regionName).Split(Path.GetInvalidFileNameChars()));
            return strippedString;
        }
        public void savePdfFile(string path, PdfiumViewer.PdfDocument pdfDocument, string fileName, string fileExtension)
        {            
            string file = path + "\\" + fileName + fileExtension;          
            //System.IO.File.Copy(pathFolder, path[i]);
            pdfDocument.Save(file);
        }
    }
}

/*
* checks all control elements
    foreach (Control element in form.Controls)
    {
    MessageBox.Show(element.Name);
    } 
*/