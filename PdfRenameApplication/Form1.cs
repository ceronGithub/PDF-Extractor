using java.awt.geom;
using org.apache.pdfbox;
using org.apache.pdfbox.pdmodel;
using org.apache.pdfbox.pdmodel.font;
using org.apache.pdfbox.util;
using PdfiumViewer;
using PdfRenameApplication.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PdfRenameApplication
{
    public partial class Form1 : Form
    {       
        General_class general_Class = new General_class();
        Folder_creation folderCreation = new Folder_creation();

        public Form1()
        {
            InitializeComponent();
            btnOneDesign();
            folderCreation.folderCreationMainFolder();
            folderCreation.folderCreationProjectFolder();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        string strippedString = "";
        private void button1_Click(object sender, EventArgs e)
        { 
            if (button1.Text == "Reset")
            {
                // reset the form, to its original form
                this.WindowState = FormWindowState.Normal;
                this.Controls.Clear();
                this.InitializeComponent();
                btnOneDesign();                
            }   
            else
            {                                
                button1.Text = "Reset";
                btnOneResetDesign();

                // adjust form design
                this.WindowState = FormWindowState.Maximized;
                this.MaximizeBox = false;
                int ypos = 0;
                int xpos = 0;
                List<string> files = general_Class.locateFile();
                for(int loop = 0; loop < files.Count; loop++)
                {
                    if (loop == 0)
                    {
                        ypos = 70;
                    }
                    else
                    {
                        ypos += 570;
                    }
                    xpos = Convert.ToInt32(System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width * .65);
                    PdfDocument pdfDocument = general_Class.dynamicPdfGenerator(this, files[loop], ypos);
                    general_Class.dynamicLabelAndTextOUTPUT(this, loop, xpos, ypos + 150);
                    general_Class.dynamicLabelAndTextCOORDSX(this, loop, xpos, ypos + 150);
                    general_Class.dynamicLabelAndTextCOORDSY(this, loop, xpos, ypos + 150);
                    general_Class.dynamicLabelAndTextCOORDSWIDTH(this, loop, xpos, ypos + 150);
                    general_Class.dynamicLabelAndTextCOORDSHEIGHT(this, loop, xpos, ypos + 150);
                    general_Class.dynamicLabelAndTextCOORDPAGE(this, loop, xpos, ypos + 150);
                    general_Class.dynamicLabelAndIMAGE(this, loop, xpos, ypos + 150, files[loop]);
                    general_Class.dynamicCropBtn(this, loop, xpos, ypos + 105, files[loop], files,folderCreation.folderPathStringProject(), pdfDocument, ".pdf", files.Count);
                }                
            }
        }
         
        private void btnOneDesign()
        {
            button1.Image = (new Bitmap(Resources.investigate, new Size(30, 20)));
            button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        }
        private void btnOneResetDesign()
        {
            button1.Width = 75;
            button1.Image = (new Bitmap(Resources.reset, new Size(30, 20)));
            button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        }
    }
}
