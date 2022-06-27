using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace _1119
{
    class WbExcel
    {
        //프로그램이 종료될 때 : Closed
        public static void FileSave(List<Account> accs)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workBook = null;
            Excel.Worksheet workSheet = null;

            try
            {
                // 저장파일명
                string xlsxfile = string.Format("{0}_Account.xlsx", DateTime.Now.ToString("yyyyMMddHHmmss"));

                // 기존파일있을경우 삭제
                FileInfo excelFile = new FileInfo(xlsxfile);
                if (excelFile.Exists) { excelFile.Delete(); }

                // 바탕화면 경로
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                // 엑셀 파일 저장 경로
                string path = Path.Combine(desktopPath, xlsxfile);

                // 엑셀 어플리케이션 생성
                excelApp = new Excel.Application();
                // 워크북 추가
                workBook = excelApp.Workbooks.Add();
                // 엑셀 첫번째 워크시트 가져오기
                workSheet = workBook.Worksheets.get_Item(1) as Excel.Worksheet;
                workSheet.Cells[1, 1] = "데이터개수";
                workSheet.Cells[1, 2] = accs.Count;

                workSheet.Cells[2, 1] = "계좌번호";
                workSheet.Cells[2, 2] = "이름";
                workSheet.Cells[2, 3] = "잔액";
                workSheet.Cells[2, 4] = "일시";
                workSheet.Cells[2, 5] = "일자";
                workSheet.Cells[2, 6] = "시간";


                for (int i = 0; i < accs.Count; i++)
                {
                    Account acc = accs[i]; // 셀에 데이터 입력 
                    workSheet.Cells[3 + i, 1] = acc.accId;
                    workSheet.Cells[3 + i, 2] = acc.accName;
                    workSheet.Cells[3 + i, 3] = acc.accMoney;
                    workSheet.Cells[3 + i, 4] = acc.accTime.ToString();
                    workSheet.Cells[3 + i, 5] = acc.accTime.ToShortDateString();
                    workSheet.Cells[3 + i, 6] = acc.accTime.ToShortTimeString(); ;

                }
                workSheet.Columns.AutoFit(); // 열 너비 자동 맞춤 
                workBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookDefault); // 엑셀 파일 저장 
                workBook.Close(true);
                excelApp.Quit();
            }
            finally
            {
                ReleaseExcelObject(workSheet);
                ReleaseExcelObject(workBook);
                ReleaseExcelObject(excelApp);
            }
        }

        private static void ReleaseExcelObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }

        //프로그램이 실행될 때 Load( 파일 로드)
        static void FileLoad(List<Account> accs)
        {

        }
    }
}
