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
using PdfRenameApplication.Properties;
using Syncfusion.Pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
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
        List<double> defaultCords = new List<double>();
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
            if(i == 0)
            {
                txtOutput.Text = "" + 85;
            }            
            else
            {
                txtOutput.Text = "";
            }
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
            if (i == 0)
            {
                txtOutput.Text = "" + 70;
            }
            else
            {
                txtOutput.Text = "";
            }            
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
            if (i == 0)
            {
                txtOutput.Text = "" + 10;
            }
            else
            {
                txtOutput.Text = "";
            }
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
            labelOutput.Height = 15;
            labelOutput.Location = new System.Drawing.Point(xpos, ypos + 150);

            txtOutput = new System.Windows.Forms.TextBox();
            txtOutput.Name = "PDF-pg-txt-" + i;
            if (i == 0)
            {
                txtOutput.Text = "" + 0;
            }
            else
            {
                txtOutput.Text = "";
            }
            txtOutput.Width = 50;
            txtOutput.Height = 30;
            txtOutput.Location = new System.Drawing.Point(xpos + 55, ypos - 3 + 150);            

            form.Controls.Add(labelOutput);
            form.Controls.Add(txtOutput);
           
        }
        public void dynamicLabelAndIMAGE(Form form, int i, int xpos, int ypos, string file)
        {
            System.Windows.Forms.Label labelOutput = new System.Windows.Forms.Label();
            System.Windows.Forms.Button imgOutput = new System.Windows.Forms.Button();
            System.Windows.Forms.TextBox txtOutput = new System.Windows.Forms.TextBox();

            labelOutput = new System.Windows.Forms.Label();
            labelOutput.Name = "PDF-img-lbl-" + i;
            labelOutput.Text = "FILE NAME :";
            labelOutput.Width = 70;
            labelOutput.Height = 15;
            labelOutput.Location = new System.Drawing.Point(xpos + 250, ypos);

            imgOutput = new System.Windows.Forms.Button();
            imgOutput.Name = "PDF-img-" + i; 
            imgOutput.Image = (new Bitmap(Resources.pdf, new Size(150, 150)));
            imgOutput.Width = 150;
            imgOutput.Height = 150;
            imgOutput.Enabled = false;
            imgOutput.Location = new System.Drawing.Point(xpos + 250, ypos + 40);

            txtOutput = new System.Windows.Forms.TextBox();
            txtOutput.Name = "PDF-txt-lbl-" + i;
            txtOutput.Text = file.ToString();
            txtOutput.ScrollBars = ScrollBars.Horizontal;
            txtOutput.Width = 200;            
            txtOutput.Height = 15;
            txtOutput.Location = new System.Drawing.Point(xpos + 250, ypos - 3 + 20);

            form.Controls.Add(labelOutput);
            form.Controls.Add(imgOutput);
            form.Controls.Add(txtOutput);
        }

        public void dynamicCropBtn(Form form, int i, int xpos, int ypos, string file, List<string> fileCollection ,string path, PdfiumViewer.PdfDocument pdfDocument, string fileExtension, int ttlCountOfPdf)        
        {            
            System.Windows.Forms.Button cropBtn = new System.Windows.Forms.Button();
           
            cropBtn = new System.Windows.Forms.Button();
            cropBtn.Name = "CropBtn" + i;
            cropBtn.Text = "Re/Crop";
            cropBtn.Width = 80;
            cropBtn.Height = 85;
            cropBtn.Location = new System.Drawing.Point(xpos + 120, ypos + 130);                
            form.Controls.Add(cropBtn);
                
            cropBtn.Click += (sender, e) => cropString(sender, e, file, fileCollection, form, i, path, pdfDocument, fileExtension, xpos + 120, ypos + 130, ttlCountOfPdf);            
        }

        public void dynamicDefaultCoordsBtn(Form form, int xpos, int ypos, List<double> coords, int ttlCountOfPdf, List<string> fileCollection, PdfiumViewer.PdfDocument pdfDocument)        
        {
            System.Windows.Forms.Button setDeaultCoordBtn = new System.Windows.Forms.Button();

            setDeaultCoordBtn = new System.Windows.Forms.Button();
            setDeaultCoordBtn.Name = "setStandardCoordsBtn";
            setDeaultCoordBtn.Text = "Set Coords as standard(to all).";
            setDeaultCoordBtn.Width = 200;
            setDeaultCoordBtn.Height = 50;
            setDeaultCoordBtn.Location = new System.Drawing.Point(xpos - 120, ypos + 85);
            form.Controls.Add(setDeaultCoordBtn);

            //MessageBox.Show(string.Join("", defaultCords[0]));

            setDeaultCoordBtn.Click += (sender, e) => setCoordsToDefault(sender, e, form, coords, ttlCountOfPdf, fileCollection, pdfDocument);
        }



        // this counts how many times user is attempting to get the right coordinates
        int noCount = 0;

        public void cropString(object sender, EventArgs e, string file, List<string> fileCollection ,Form form, int index, string path, PdfiumViewer.PdfDocument pdfDocument, string fileExtension, int xpos, int ypos, int ttlCountOfPdf)
        {
            //count the ttl pages of the pdf
            // dynamic element name/s
            string[] dynamicTxtboxName = { "PDF-x-txt-" + (index), "PDF-y-txt-" + (index), "PDF-w-txt-" + (index), "PDF-h-txt-" + (index), "PDF-pg-txt-" + (index), "PDF-output-txt-" + (index) };
            // get and set the strippedString
            string strippedString = "";            
            int pages = Convert.ToInt32(form.Controls[(dynamicTxtboxName[4])].Text);
            
            //validates if the pages entered are within a range of array.
            if (pages < pdfDocument.PageCount)
            {
                // savings
                if (form.Controls[("CropBtn" + (index))].Text != "Re/Crop")
                {
                    strippedString = form.Controls[("PDF-output-txt-" + (index))].Text;
                    //check if string is empty
                    if (strippedString != "")
                    {                                                 
                        form.Controls[("CropBtn" + (index))].BackColor = System.Drawing.Color.Green;
                        savePdfFile(folderCreation.folderPathStringProject(), pdfDocument, strippedString, ".pdf");

                        form.Controls[("CropBtn" + (index))].Text = "SAVED!";
                        form.Controls[dynamicTxtboxName[0]].Enabled = false; //x
                        form.Controls[dynamicTxtboxName[1]].Enabled = false; //y
                        form.Controls[dynamicTxtboxName[2]].Enabled = false; //w
                        form.Controls[dynamicTxtboxName[3]].Enabled = false; //h
                        form.Controls[dynamicTxtboxName[4]].Enabled = false; //pg
                        form.Controls[dynamicTxtboxName[5]].Enabled = false; //output
                        form.Controls[("CropBtn" + (index))].Enabled = false;
                        if (index == 0)
                        {
                            form.Controls[("setStandardCoordsBtn")].Enabled = false;                            
                        }
                        else
                        {
                            form.Controls[("setStandardCoordsBtn")].Enabled = true;                            
                        }
                        MessageBox.Show("PDF-file has been created \n @ : " + folderCreation.folderPathStringProject(), "NOTE!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    if (noCount < 3)
                    {
                        //convertion from string to double
                        Double.TryParse(form.Controls[dynamicTxtboxName[0]].Text, out cords[0]); // x
                        Double.TryParse(form.Controls[dynamicTxtboxName[1]].Text, out cords[1]); // y
                        Double.TryParse(form.Controls[dynamicTxtboxName[2]].Text, out cords[2]); // w
                        Double.TryParse(form.Controls[dynamicTxtboxName[3]].Text, out cords[3]); // h
                        int.TryParse(form.Controls[dynamicTxtboxName[4]].Text, out page); // page
                    }
                    else
                    {
                        cords[0] = 0;
                        cords[1] = 10;
                        cords[2] = 500;
                        form.Controls[dynamicTxtboxName[0]].Text = "" + cords[0];
                        form.Controls[dynamicTxtboxName[1]].Text = "" + cords[1];
                        form.Controls[dynamicTxtboxName[2]].Text = "" + cords[2];
                        noCount = 0;
                    }

                    // string output
                    strippedString = cutStringFromPdf(file, cords[0], cords[1], cords[2], cords[3], page);
                    
                    form.Controls[dynamicTxtboxName[5]].Text = strippedString;
                    DialogResult result = MessageBox.Show("\t CHECK INVOICE. \n CLICK 'YES' TO SAVE \n CLICK 'NO' TO MODIFY COORDINATES", "NOTE!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        defaultCords.Add(cords[0]); // x
                        defaultCords.Add(cords[1]); // y
                        defaultCords.Add(cords[2]); // w
                        defaultCords.Add(cords[3]); // h
                        defaultCords.Add(page); // page
                        // make the btn visible only on first pdfviewer
                        if(index == 0)
                        {
                            dynamicDefaultCoordsBtn(form, xpos, ypos, defaultCords, ttlCountOfPdf, fileCollection, pdfDocument);
                        }                        
                        form.Controls[dynamicTxtboxName[5]].Text = strippedString;
                        form.Controls[("CropBtn" + (index))].Text = "SAVE-PDF";
                    }
                    else
                    {                        
                        form.Controls[dynamicTxtboxName[5]].Text = strippedString;
                        form.Controls[("CropBtn" + (index))].Text = "Re/Crop";                        
                    }
                    noCount++;
                }
            }
            else
            {
                MessageBox.Show("Page is out of range!.", "ERROR-PAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
            
            //return strippedString;
        }



        public void setCoordsToDefault(object sender, EventArgs e, Form form ,List<double> coords, int ttlCountOfPdf, List<string> fileCollection, PdfiumViewer.PdfDocument pdfDocument)
        {
            string[] strippedString = new string[fileCollection.Count];
            if(form.Controls[("setStandardCoordsBtn")].Text != "SAVE-ALL-PDF")
            {
                for (int index = 0; index < ttlCountOfPdf; index++)
                {
                    string[] dynamicTxtboxName = { "PDF-x-txt-" + (index), "PDF-y-txt-" + (index), "PDF-w-txt-" + (index), "PDF-h-txt-" + (index), "PDF-pg-txt-" + (index), "PDF-output-txt-" + (index) };
                    string[] dynamicBtnName = { "CropBtn" + (index) };
                    form.Controls[dynamicTxtboxName[0]].Text = "" + coords[0]; // x
                    form.Controls[dynamicTxtboxName[1]].Text = "" + coords[1]; // y 
                    form.Controls[dynamicTxtboxName[2]].Text = "" + coords[2]; // w
                    form.Controls[dynamicTxtboxName[3]].Text = "" + coords[3]; // h
                    form.Controls[dynamicTxtboxName[4]].Text = "" + coords[4]; // pg          

                    strippedString[index] = cutStringFromPdf(fileCollection[index], coords[0], coords[1], coords[2], coords[3], Convert.ToInt32(coords[4]));
                    form.Controls[dynamicTxtboxName[5]].Text = strippedString[index];
                    if (form.Controls[dynamicTxtboxName[5]].Text != string.Empty && form.Controls[dynamicTxtboxName[5]].Text != "")
                    {                        
                        //form.Controls[dynamicBtnName[0]].Text = "SAVE-PDF";                        
                        form.Controls[("setStandardCoordsBtn")].Text = "SAVE-ALL-PDF";
                    }
                    
                }
                MessageBox.Show("Please check all pdf-document. if invoice is correct.", "PLEASE DOUBLE CHECK!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }           
            else
            {                                
                for (int index = 0; index < fileCollection.Count; index++)
                {
                    string[] dynamicTxtboxName = { "PDF-x-txt-" + (index), "PDF-y-txt-" + (index), "PDF-w-txt-" + (index), "PDF-h-txt-" + (index), "PDF-pg-txt-" + (index), "PDF-output-txt-" + (index) };
                    string[] dynamicBtnName = { "CropBtn" + (index) };
                    if (form.Controls[dynamicTxtboxName[5]].Text != string.Empty && form.Controls[dynamicTxtboxName[5]].Text != "")
                    {
                        form.Controls[dynamicBtnName[0]].Text = "SAVED!";
                        form.Controls[dynamicBtnName[0]].Enabled = false;
                        form.Controls[dynamicBtnName[0]].BackColor = System.Drawing.Color.Green;
                        form.Controls[("setStandardCoordsBtn")].Text = "SAVED!";
                        form.Controls[("setStandardCoordsBtn")].Visible = false;
                        savePdfFile(folderCreation.folderPathStringProject() ,pdfDocument, form.Controls[dynamicTxtboxName[5]].Text, ".pdf");
                    }
                }
                MessageBox.Show("All pdf document has been save \n @" + folderCreation.folderPathStringProject(), "PDF FILES SUCCESFULLY RENAMED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
        
        public string cutStringFromPdf( string file, double x, double y, double w, double h, int page)
        {
            string strippedString = "";
            // get certain text from pdf
            PDDocument doc = PDDocument.load(file);
            Rectangle2D rect = new Rectangle2D.Double(x, y, w, h);
            PDFTextStripperByArea stripper = new PDFTextStripperByArea();
            String regionName = "INVOICE";
            stripper.addRegion(regionName, rect);
            stripper.extractRegions((PDPage)doc.getDocumentCatalog().getAllPages().get(page));
            return strippedString = string.Join("", stripper.getTextForRegion(regionName).Split(Path.GetInvalidFileNameChars()));

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