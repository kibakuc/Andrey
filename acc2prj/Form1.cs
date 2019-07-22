using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace acc2prj {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            label1.Text = "";
            label2.Text = "0";
        }

        private void DoRun() {
            string strConn =
                @"User=SYSDBA;
                Password=SaDM1n@;
                Database=main;
                DataSource=iscard-db.bank.lan;
                Port=3050;
                Dialect=1;
                Charset=WIN1251;
                Role=SYSDBA;
                Connection lifetime=15;
                Pooling=true;
                MinPoolSize=0;
                MaxPoolSize=50;
                Packet Size=8192;
                ServerType=0";

            string strSQL = @"select PR.PROJECTID, PR.PROJECTNAME
                                                            from ACCOUNTS AC
                                                            join PROJECTCLASS PR on PR.PROJECTID = AC.PROJECTID + 0
                                                            where AC.ACCNUM = @PARAM
                                                            union all
                                                            select PR.PROJECTID,PR.PROJECTNAME
                                                            from EAST_ACC_POOL AP
                                                            join AGREEMENTS K on k.contractid = ap.contractid + 0
                                                            join PROJECTCLASS PR on PR.PROJECTID = K.PROJECTID + 0
                                                            where AP.ACCNUM = @PARAM";


            var result = openFileDialog1.ShowDialog();
            if (result != DialogResult.OK) {
                MessageBox.Show("Файл не выбран!", "Информация");
                return;
            }
            //string filename = System.IO.Path.GetFileName(openFileDialog1.FileName);
            //String xlsPath = System.IO.Path.GetDirectoryName(openFileDialog1.FileName);

            progressBar1.Value = 0;
            label1.Text = openFileDialog1.FileName;
            label2.Text = progressBar1.Value.ToString();


            FbDataReader rdr;
            FbCommand cmd;
            using (FBDatabase fB = new FBDatabase(strConn)) {
                fB.OpenConection();
                cmd = fB.ReturnFbCommand(strSQL);

                //using (ExcelDocument excelDoc = new ExcelDocument(openFileDialog1.FileName)) {
                //    excelDoc.Visible = false;
                ExcelPackage excelDoc = new ExcelPackage(openFileDialog1.FileName);
                try {
                    progressBar1.Maximum = excelDoc.RowsWithDataCount + 1;
                    for (int i = 1; i < excelDoc.RowsWithDataCount + 1; i++) {
                        progressBar1.Value = i;
                        label2.Text = progressBar1.Value.ToString();
                        //MessageBox.Show(excelDoc.GetCellValue(i, 1));

                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@PARAM", FbDbType.Text).Value = excelDoc.GetCellValue(i, 1).ToString().Trim();
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read()) {
                            //while (rdr.Read()) {
                            if (!rdr.IsDBNull(0)) {
                                //MessageBox.Show(rdr["PROJECTID"].ToString() + " " + rdr["PROJECTNAME"].ToString());
                                excelDoc.SetCustomFormat("###0", i, 6);
                                excelDoc.SetCellValue(Convert.ToInt32(rdr["PROJECTID"].ToString()), i, 6);
                                excelDoc.SetCustomFormat("@", i, 7);
                                excelDoc.SetCellValue(rdr["PROJECTNAME"].ToString(), i, 7);
                            }
                        }
                        rdr.Close();
                    }
                    //excelDoc.workSheet.Columns.AutoFit();
                    //excelDoc.application.DisplayAlerts = false;
                    //excelDoc.workBook.SaveAs(openFileDialog1.FileName);
                    excelDoc.AutoFitAll();
                    excelDoc.application.SaveAs(new FileInfo(openFileDialog1.FileName));
                } finally {
                    excelDoc.Dispose();
                }
                progressBar1.Value = 0;
                label1.Text = "Файл успешно обработан!";
            }

        }

        private void Button1_Click(object sender, EventArgs e) {
            DoRun();
            //Application.Exit();
        }

    }
}
