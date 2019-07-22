using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPPlus_test {
    class Program {
        static void Main(string[] args) {
            string filename = "d:\\new\\ШС 0507 оригинал.xlsx";
            ExcelPackage excelDoc = new ExcelPackage(filename);
            try {
                //Console.WriteLine(excelDoc.RowsWithDataCount + " " + excelDoc.ColumnsWithDataCount);

                for (int i = 1; i < excelDoc.RowsWithDataCount + 1; i++) {
                    Console.WriteLine(excelDoc.GetCellValue(i, 1).ToString().Trim());
                    //excelDoc.SetCustomFormat("@", i, 6);
                    excelDoc.workSheet.Column(1).AutoFit();
                    excelDoc.SetCustomFormat("###0.00", i, 6);
                    excelDoc.SetCellValue(Convert.ToInt64(excelDoc.GetCellValue(i, 1).ToString().Trim()), i, 6);
                }
                excelDoc.AutoFitAll();
                excelDoc.application.SaveAs(new FileInfo(filename));
            } finally {
                excelDoc.Dispose();
            }


        }
    }
}
