using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xls = OfficeOpenXml;

namespace EPPlus_test {
    class ExcelPackage : IDisposable {

        public Xls.ExcelPackage application = null;
        public Xls.ExcelWorkbook workBook = null;
        public Xls.ExcelWorksheet workSheet = null;
        private bool disposed = false;

        public ExcelPackage() {
            application = new Xls.ExcelPackage();
            workBook = application.Workbook;
            workSheet = workBook.Worksheets[1];
        }

        public ExcelPackage(string pathToTemplate) {
            application = new Xls.ExcelPackage(new FileInfo(pathToTemplate));
            workBook = application.Workbook;
            workSheet = workBook.Worksheets[1];
        }

        public int RowsWithDataCount {
            get {
                int usedRowsNum = 0;
                usedRowsNum = workSheet.Dimension.End.Row;
                return usedRowsNum;
            }
        }
        public int ColumnsWithDataCount {
            get {
                int usedColumnsNum = 0;
                usedColumnsNum = workSheet.Dimension.End.Column;
                return usedColumnsNum;
            }
        }
        public string GetCellValue(int rowIndex, int columnIndex) {
            string cellValue = "";
            cellValue = workSheet.Cells[rowIndex, columnIndex].Text;
            return cellValue;
        }
        public void SetCellValue(object cellValue, int rowIndex, int columnIndex) {
            workSheet.Cells[rowIndex, columnIndex].Value = cellValue;
        }
        public void SetCustomFormat(string format, int rowIndex, int columnIndex) {
            ((Xls.ExcelRange)workSheet.Cells[rowIndex, columnIndex]).Style.Numberformat.Format = format;
        }
        public void AutoFitAll() {
            for (int i = 1; i < workSheet.Dimension.End.Column + 1; i++) {
                workSheet.Column(i).AutoFit();
            }
        }
        ~ExcelPackage() {
            this.Dispose();
        }

        public void Dispose() {
            if (!this.disposed) {
                Close();
            }
            this.disposed = true;
            GC.SuppressFinalize(this);
        }
        private void Close() {
            application.Dispose();
            workBook.Dispose();
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(application);
            application = null;
            workBook = null;
            workSheet = null;
            //System.GC.Collect();
        }

        /*        public bool Visible {
                    get {
                        return application.Visible;
                    }
                    set {
                        application.Visible = value;
                    }
                }
        */
    }
}
