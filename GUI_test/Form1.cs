using Microsoft.Office.Interop.Word;
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

namespace GUI_test {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            //richTextBox1.SelectedRtf = @"{\rtf1\ansi Adding some \b text\b0.}";
            if (openFile.ShowDialog() == DialogResult.OK) {
                richTextBox1.LoadFile(openFile.FileName, RichTextBoxStreamType.RichText);

            }
            //readFileContent("D:\\new\\GlobalMoney\\gm1.rtf");
            //MessageBox.Show(Factory.Russian.Declension.Parse("генеральный директор").Dative);
        }

        private void Button1_Click(object sender, EventArgs e) {
            richTextBox1.SaveFile("C:\\MyDocument.rtf", RichTextBoxStreamType.RichText);
        }

        private void readFileContent(string path) {
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            object file = path;
            object nullobj = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(
                ref file, ref nullobj, ref nullobj,
                ref nullobj, ref nullobj, ref nullobj,
                ref nullobj, ref nullobj, ref nullobj,
                ref nullobj, ref nullobj, ref nullobj);
            doc.ActiveWindow.Selection.WholeStory();
            doc.ActiveWindow.Selection.Copy();
            IDataObject data = Clipboard.GetDataObject();
            richTextBox1.Rtf = data.GetData(DataFormats.Rtf).ToString();
            doc.Close(ref nullobj, ref nullobj, ref nullobj);
            wordApp.Quit(ref nullobj, ref nullobj, ref nullobj);
        }


    }
}
