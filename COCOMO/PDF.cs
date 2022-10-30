using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COCOMO
{
    public partial class PDF : Form
    {
        public PDF()
        {
            InitializeComponent();
        }

        private void PDF_Load(object sender, EventArgs e)
        {
            string path = "C:\\Users\\М\\Desktop\\ПИ\\COCOMO\\COCOMO\\Resources\\COCOMO.pdf";
            var doc = PdfiumViewer.PdfDocument.Load(path);
            pdfViewer1.Document = doc;
        }
    }
}
