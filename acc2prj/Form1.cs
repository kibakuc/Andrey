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
using System.Windows.Forms;

namespace acc2prj {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            label1.Text = "";
            label2.Text = "0";
        }

        private bool StrNotNumber(string s) {
            if (String.IsNullOrEmpty(s))
                return false;
            foreach (char c in s)
                if (!Char.IsNumber(c))
                    return false;
            return true;
        }

        private void DoRun() {

            string strConn =
                @"User=SYSDBA;
                Password=SaDM1n@;
                Database=main;
                DataSource=iscard-db.bank.lan;
                Port=3050;
                Charset=WIN1251";

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

            string strSQL1 = @"select f.birthplace
                                from east_privateclientsform p
                                left join FINMONFORM F on f.clientprivid=p.clientprivid+0
                                where p.clientodbid=@PARAM";

            string strSQL2 = @"select f.ework
                                from east_privateclientsform p
                                left join privateclients F on f.clientprivid=p.clientprivid+0
                                where p.clientodbid=@PARAM";

            string strSQL3 = @"select F.EWORK, F.CLPOSITION, F.BIRTHDATE,P.CLIENTTYPE, list(AG.CONTRACTNUM || ';' || PR.PROJECTNAME, '|') as CNUM_PRJ
                                from EAST_PRIVATECLIENTSFORM P
                                join PRIVATECLIENTS F on F.CLIENTPRIVID = P.CLIENTPRIVID + 0
                                join AGREEMENTS AG on AG.CLIENTPRIVID = P.CLIENTPRIVID + 0
                                join PROJECTCLASS PR on PR.PROJECTID = AG.PROJECTID + 0
                                join BALANCES BL on BL.CONTRACTID = AG.CONTRACTID + 0 and
                                    BL.ACCSTATUSID <> 2
                                where P.CLIENTODBID = @PARAM
                                group by 1, 2, 3, 4";

            string strSQL4 = @"select F.HZIPCODE,
                                    P.P_REG_REGIONNAME,P.P_REG_DISTRICTNAME,P.P_REG_CITYNAME,
                                    P.P_REG_STREET,P.P_REG_BUILDING,P.P_REG_KORP,P.P_REG_FLAT,
                                    P.P_EQUAL_ADDRESS,P.P_POST_INDEX,P.P_ADR_REGIONNAME,
                                    P.P_ADR_DISTRICTNAME,P.P_ADR_CITYNAME,P.P_ADR_BUILDING,
                                    P.P_ADR_STREET,P.P_ADR_KORP,P.P_ADR_FLAT,
                                    F.EWORK,F.CLPOSITION
                                from EAST_PRIVATECLIENTSFORM P
                                join PRIVATECLIENTS F on F.CLIENTPRIVID = P.CLIENTPRIVID + 0
                                where P.CLIENTODBID = @PARAM";

            string strSQL5 = @"select ap.iban
                                from east_acc_pool ap
                                where ap.accnum = @PARAM";

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
                //cmd = fB.ReturnFbCommand(strSQL);
                //cmd = fB.ReturnFbCommand(strSQL1);
                //cmd = fB.ReturnFbCommand(strSQL2);
                //cmd = fB.ReturnFbCommand(strSQL3);
                //cmd = fB.ReturnFbCommand(strSQL4);
                cmd = fB.ReturnFbCommand(strSQL5);

                //using (ExcelDocument excelDoc = new ExcelDocument(openFileDialog1.FileName)) {
                //    excelDoc.Visible = false;
                ExcelPackage excelDoc = new ExcelPackage(openFileDialog1.FileName);
                try {
                    progressBar1.Maximum = excelDoc.RowsWithDataCount + 1;
                    for (int i = 1; i < excelDoc.RowsWithDataCount + 1; i++) {
                        progressBar1.Value = i;
                        label2.Text = progressBar1.Value.ToString();
                        //MessageBox.Show(excelDoc.GetCellValue(i, 1));
                        if (StrNotNumber(excelDoc.GetCellValue(i, 1).ToString().Trim())) {
                            cmd.Parameters.Clear();
                            //cmd.Parameters.Add("@PARAM", FbDbType.Text).Value = excelDoc.GetCellValue(i, 1).ToString().Trim();
                            cmd.Parameters.Add("@PARAM", FbDbType.Text).Value = excelDoc.GetCellValue(i, 4).ToString().Trim();
                            cmd.Prepare();
                            rdr = cmd.ExecuteReader();
                            if (rdr.Read()) {
                                //while (rdr.Read()) {
                                if (!rdr.IsDBNull(0)) {
                                    //MessageBox.Show(rdr["PROJECTID"].ToString() + " " + rdr["PROJECTNAME"].ToString());

                                    /*
                                    excelDoc.SetCustomFormat("###0", i, 6);
                                    excelDoc.SetCellValue(Convert.ToInt32(rdr["PROJECTID"].ToString()), i, 6);
                                    excelDoc.SetCustomFormat("@", i, 7);
                                    excelDoc.SetCellValue(rdr["PROJECTNAME"].ToString(), i, 7);
                                    */
                                    //excelDoc.SetCustomFormat("@", i, 7);
                                    //excelDoc.SetCellValue(rdr["birthplace"].ToString(), i, 7);

                                    //excelDoc.SetCustomFormat("@", i, 5);
                                    //excelDoc.SetCellValue(rdr["ework"].ToString(), i, 5);

                                    /*
                                    excelDoc.SetCustomFormat("@", i, 5);
                                    excelDoc.SetCellValue(rdr["EWORK"].ToString(), i, 5);
                                    excelDoc.SetCustomFormat("@", i, 6);
                                    excelDoc.SetCellValue(rdr["CLPOSITION"].ToString(), i, 6);
                                    excelDoc.SetCustomFormat("dd.mm.yyyy", i, 7);
                                    excelDoc.SetCellValue(Convert.ToDateTime(rdr["BIRTHDATE"].ToString()), i, 7);
                                    excelDoc.SetCustomFormat("#0", i, 8);
                                    excelDoc.SetCellValue(Convert.ToInt32(rdr["CLIENTTYPE"].ToString()), i, 8);

                                    string[] arr_cnumprj = rdr["CNUM_PRJ"].ToString().Split('|');
                                    int z = 9;
                                    foreach (var cnumprj in arr_cnumprj) {
                                        string[] arr = cnumprj.Split(';');
                                        //MessageBox.Show(arr[0] + " - " + arr[1]);
                                        excelDoc.SetCustomFormat("@", i, z);
                                        excelDoc.SetCellValue(arr[0].ToString(), i, z);
                                        z++;
                                        excelDoc.SetCustomFormat("@", i, z);
                                        excelDoc.SetCellValue(arr[1].ToString(), i, z);
                                        z++;
                                    }
                                    */
                                    /*
                                                                        excelDoc.SetCustomFormat("@", i, 30);
                                                                        excelDoc.SetCellValue(rdr["HZIPCODE"].ToString(), i, 30);
                                                                        excelDoc.SetCustomFormat("@", i, 31);
                                                                        excelDoc.SetCellValue(rdr["P_REG_REGIONNAME"].ToString(), i, 31);
                                                                        excelDoc.SetCustomFormat("@", i, 32);
                                                                        excelDoc.SetCellValue(rdr["P_REG_DISTRICTNAME"].ToString(), i, 32);
                                                                        excelDoc.SetCustomFormat("@", i, 33);
                                                                        excelDoc.SetCellValue(rdr["P_REG_CITYNAME"].ToString(), i, 33);
                                                                        excelDoc.SetCustomFormat("@", i, 34);
                                                                        excelDoc.SetCellValue(rdr["P_REG_STREET"].ToString(), i, 34);

                                                                        excelDoc.SetCustomFormat("@", i, 35);
                                                                        excelDoc.SetCellValue(rdr["P_REG_BUILDING"].ToString(), i, 35);
                                                                        excelDoc.SetCustomFormat("@", i, 36);
                                                                        excelDoc.SetCellValue(rdr["P_REG_KORP"].ToString(), i, 36);
                                                                        excelDoc.SetCustomFormat("@", i, 37);
                                                                        excelDoc.SetCellValue(rdr["P_REG_FLAT"].ToString(), i, 37);

                                                                        excelDoc.SetCustomFormat("@", i, 38);
                                                                        excelDoc.SetCellValue(rdr["P_EQUAL_ADDRESS"].ToString(), i, 38);
                                                                        excelDoc.SetCustomFormat("@", i, 39);
                                                                        excelDoc.SetCellValue(rdr["P_POST_INDEX"].ToString(), i, 39);
                                                                        excelDoc.SetCustomFormat("@", i, 40);
                                                                        excelDoc.SetCellValue(rdr["P_ADR_REGIONNAME"].ToString(), i, 40);

                                                                        excelDoc.SetCustomFormat("@", i, 41);
                                                                        excelDoc.SetCellValue(rdr["P_ADR_DISTRICTNAME"].ToString(), i, 41);
                                                                        excelDoc.SetCustomFormat("@", i, 42);
                                                                        excelDoc.SetCellValue(rdr["P_ADR_CITYNAME"].ToString(), i, 42);
                                                                        excelDoc.SetCustomFormat("@", i, 43);
                                                                        excelDoc.SetCellValue(rdr["P_ADR_BUILDING"].ToString(), i, 43);

                                                                        excelDoc.SetCustomFormat("@", i, 44);
                                                                        excelDoc.SetCellValue(rdr["P_ADR_STREET"].ToString(), i, 44);
                                                                        excelDoc.SetCustomFormat("@", i, 45);
                                                                        excelDoc.SetCellValue(rdr["P_ADR_KORP"].ToString(), i, 45);
                                                                        excelDoc.SetCustomFormat("@", i, 46);
                                                                        excelDoc.SetCellValue(rdr["P_ADR_FLAT"].ToString(), i, 46);

                                    */
                                    /*
                                    excelDoc.SetCustomFormat("@", i, 5);
                                    excelDoc.SetCellValue(rdr["EWORK"].ToString(), i, 5);
                                    excelDoc.SetCustomFormat("@", i, 6);
                                    excelDoc.SetCellValue(rdr["CLPOSITION"].ToString(), i, 6);
                                    */

                                    excelDoc.SetCustomFormat("@", i, 5);
                                    excelDoc.SetCellValue(rdr["iban"].ToString(), i, 5);

                                }
                            }
                            rdr.Close();
                        }
                        Application.DoEvents();
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

        //
        private void Button1_Click(object sender, EventArgs e) {
            DoRun();
            //Application.Exit();
        }

    }
}
