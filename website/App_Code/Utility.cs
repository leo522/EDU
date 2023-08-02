using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using NPOI.HSSF.UserModel;
using System.Web.UI;
using System.Collections;
using System.Reflection;
using NPOI.XSSF.UserModel;
using System.Net;
using System.Collections.Specialized;
using System.Text;
using Newtonsoft.Json;

/// <summary>
/// Utility 的摘要描述
/// </summary>
public class Utility
{
	public Utility()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}


    public static int? GetNullInt(string input)
    {
        if (input == null)
        {
            return null;
        }

        if (input.Trim() == "")
        {
            return null;
        }
        else
        {
            return Convert.ToInt32(input);
        }
    }


    public static string ValidToken(string AccessToken, string OAuthServer)
    {
        if (AccessToken != null && AccessToken != "")
        {
            try
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(OAuthServer + "/connect/accesstokenvalidation");
                request.Method = "POST";
                request.Headers.Add("Authorization", "Basic Y29kZWNsaWVudDpzZWNyZXQ=");
                request.ContentType = "application/x-www-form-urlencoded";


                NameValueCollection postParams = System.Web.HttpUtility.ParseQueryString(string.Empty);
                postParams.Add("token", AccessToken);

                byte[] byteArray = Encoding.UTF8.GetBytes(postParams.ToString());
                using (Stream reqStream = request.GetRequestStream())
                {
                    reqStream.Write(byteArray, 0, byteArray.Length);
                }


                //發出Request
                string responseStr = "";
                using (WebResponse response = request.GetResponse())
                {

                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        responseStr = reader.ReadToEnd();
                    }

                }

                var result = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseStr);

                return result["sub"].ToString();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }



    public static string GetNullString(string input)
    {
        if (input == null)
        {
            return null;
        }
        if (input.Trim() == "")
        {
            return null;
        }
        else
        {
            return input.Trim();
        }
    }

    public object GetObjectPropValue(object dto, string probName)
    {
        Type t = dto.GetType();
        PropertyInfo[] pis = t.GetProperties();

        object value = null;
        foreach (PropertyInfo pi in pis)
        {
            if (pi.Name == probName )
            {
                
                try
                {
                    value = pi.GetValue(dto, null);
                }
                catch
                {
                }

            }
        }

        return value;
    }

    public DataTable ConvertToDataTable(IEnumerable ien, Dictionary<string, string> columnmap, string tablename)
    {
        DataTable dt = new DataTable(tablename);

        foreach (string columnname in columnmap.Values)
        {
            if (!dt.Columns.Contains(columnname))
            {
                dt.Columns.Add(columnname);
            }
        }

        foreach (object obj in ien)
        {
            Type t = obj.GetType();
            PropertyInfo[] pis = t.GetProperties();

            DataRow dr = dt.NewRow();

            foreach (PropertyInfo pi in pis)
            {
                if (columnmap.Keys.Contains(pi.Name))
                {
                    object value = null;
                    try
                    {
                        value = pi.GetValue(obj, null);
                    }
                    catch
                    {
                    }


                    if (value == null)
                    {
                        dr[columnmap[pi.Name]] = DBNull.Value;
                    }
                    else
                    {
                        dr[columnmap[pi.Name]] = value;
                    }
                }
            }
            dt.Rows.Add(dr);
        }

        return dt;
    }

    public byte[] ExportDataTableToExcel(DataTable dt, string title)
    {
        HSSFWorkbook workbook = new HSSFWorkbook();
        HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet("工作表1");
        //顯示 Table 0 的所有欄位名稱
        HSSFRow titleRow = (HSSFRow)sheet.CreateRow(0);
        titleRow.CreateCell(0).SetCellValue(title);
        sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, 0, dt.Columns.Count));

        HSSFRow headerRow = (HSSFRow)sheet.CreateRow(1);
        foreach (DataColumn column in dt.Columns)
        {
            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
        }
        //顯示 所有資料列
        int rowIndex = 2;
        foreach (DataRow row in dt.Rows)
        {
            HSSFRow dataRow = (HSSFRow)sheet.CreateRow(rowIndex);
            foreach (DataColumn column in dt.Columns)
            {
                dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
            }
            dataRow = null;
            rowIndex++;
        }

        // 產生 Excel 資料流
        MemoryStream ms = new MemoryStream();
        workbook.Write(ms);
        headerRow = null;
        sheet = null;
        workbook = null;


        return ms.ToArray();

    }

    public byte[] ExportDataTableToExcel(DataTable dt)
    {
        HSSFWorkbook workbook = new HSSFWorkbook();


        int rowIndex = 0;               // Starting Row (0 = Header)
        int sheetIndex = 1;             // Starting sheet is always set to "Sheet1"
        const int maxRows = 65535;      // Max rows p/sheet in Excel 2003
        const int maxCells = 32767;
        
        HSSFSheet sheet = null;
        foreach (DataRow row in dt.Rows)
        {
            // Check if max rows hit, if so start new sheet and copy headers from current sheet.
            if (rowIndex % maxRows == 0)
            {


                sheet = (HSSFSheet)workbook.CreateSheet("工作表" + sheetIndex.ToString());
                //顯示 Table 0 的所有欄位名稱

                HSSFRow headerRow = (HSSFRow)sheet.CreateRow(0);
                foreach (DataColumn column in dt.Columns)
                {
                    headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                }
                // Increment sheet counter
                sheetIndex++;


                rowIndex = 1;
            }
            HSSFRow dataRow = (HSSFRow)sheet.CreateRow(rowIndex);
            foreach (DataColumn column in dt.Columns)
            {
                dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString().Length > 32767 ? row[column].ToString().Substring(0, 32767) : row[column].ToString());
            }
            dataRow = null;
            rowIndex++;
        }


        // 產生 Excel 資料流
        MemoryStream ms = new MemoryStream();
        workbook.Write(ms);
        
        
        workbook = null;


        return ms.ToArray();

    }

    public static DataTable ReadDatToDataTable(string filename)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("EmpCode");
        dt.Columns.Add("CheckInTime");
        int counter = 0;
        string line;

        // Read the file and display it line by line.
        System.IO.StreamReader file =
           new System.IO.StreamReader(filename);
        while ((line = file.ReadLine()) != null)
        {
            try
            {
                string cardno = line.Substring(18);
                if(cardno.Length>8)
                {
                    cardno = String.Format("{0:X}", Convert.ToInt32(cardno)).PadLeft(8, '0');
                }
                DataRow dr = dt.NewRow();
                dr["EmpCode"] = cardno;
                dr["CheckInTime"] = line.Substring(0, 10) + " " + line.Substring(10, 5);
                dt.Rows.Add(dr);

                counter++;
            }
            catch
            {
            }
        }

        file.Close();

        return dt;
    }


    public static DataTable ReadExcelAsTableNPOI(string fileName)
    {
        using (FileStream fs = new FileStream(fileName, FileMode.Open))
        {
            if (fileName.EndsWith("xlsx"))
            {
                XSSFWorkbook wb = new XSSFWorkbook(fs);
                XSSFSheet sheet = wb.GetSheetAt(0) as XSSFSheet;
                DataTable table = new DataTable();
                //由第一列取標題做為欄位名稱
                XSSFRow headerRow = sheet.GetRow(0) as XSSFRow;
                if (headerRow != null)
                {
                    int cellCount = headerRow.LastCellNum;
                    for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                        //以欄位文字為名新增欄位，此處全視為字串型別以求簡化
                        table.Columns.Add(
                            new DataColumn(headerRow.GetCell(i).StringCellValue));

                    //略過第零列(標題列)，一直處理至最後一列
                    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                    {
                        XSSFRow row = sheet.GetRow(i) as XSSFRow;
                        if (row == null) 
                        {
                            continue;
                        }
                        if(row.FirstCellNum<0)
                        {
                            continue;
                        }
                        DataRow dataRow = table.NewRow();
                        //依先前取得的欄位數逐一設定欄位內容
                        for (int j = row.FirstCellNum; j < cellCount; j++)
                            if (row.GetCell(j) != null)
                            {
                                //如要針對不同型別做個別處理，可善用.CellType判斷型別
                                //再用.StringCellValue, .DateCellValue, .NumericCellValue...取值
                                //此處只簡單轉成字串
                                XSSFCell cell = row.GetCell(j) as XSSFCell;
                                if (table.Columns[j].ColumnName == "起始日" || table.Columns[j].ColumnName == "結束日" || table.Columns[j].ColumnName == "操作日期" || table.Columns[j].ColumnName == "發生日期(西元年)" || table.Columns[j].ColumnName == "日期")
                                {
                                    dataRow[j] = cell.DateCellValue;
                                }
                                else
                                {
                                    dataRow[j] = cell.ToString();
                                }

                            }
                        table.Rows.Add(dataRow);
                    }
                    return table;

                }
                else
                {
                    throw new Exception("沒有資料");
                }
            }
            else
            {

                HSSFWorkbook wb = new HSSFWorkbook(fs);
                HSSFSheet sheet = wb.GetSheetAt(0) as HSSFSheet;
                DataTable table = new DataTable();
                //由第一列取標題做為欄位名稱
                HSSFRow headerRow = sheet.GetRow(0) as HSSFRow;
                if (headerRow != null)
                {
                    int cellCount = headerRow.LastCellNum;
                    for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                        //以欄位文字為名新增欄位，此處全視為字串型別以求簡化
                        table.Columns.Add(
                            new DataColumn(headerRow.GetCell(i).StringCellValue));

                    //略過第零列(標題列)，一直處理至最後一列
                    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                    {
                        HSSFRow row = sheet.GetRow(i) as HSSFRow;
                        if (row == null)
                        {
                            continue;
                        }
                        DataRow dataRow = table.NewRow();
                        //依先前取得的欄位數逐一設定欄位內容
                        for (int j = row.FirstCellNum; j < cellCount; j++)
                            if (row.GetCell(j) != null)
                            {
                                //如要針對不同型別做個別處理，可善用.CellType判斷型別
                                //再用.StringCellValue, .DateCellValue, .NumericCellValue...取值
                                //此處只簡單轉成字串
                                HSSFCell cell = row.GetCell(j) as HSSFCell;
                                if (table.Columns[j].ColumnName == "起始日" || table.Columns[j].ColumnName == "結束日" || table.Columns[j].ColumnName == "操作日期")
                                {
                                    dataRow[j] = cell.DateCellValue;
                                }
                                else
                                {
                                    dataRow[j] = cell.ToString();
                                }

                            }
                        table.Rows.Add(dataRow);
                    }
                    return table;

                }
                else
                {
                    throw new Exception("沒有資料");
                }
            }
        }
    }


}