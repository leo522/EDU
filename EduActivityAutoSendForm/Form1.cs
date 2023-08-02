using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KMU.EduActivity.ApplicationLayer.Services;
using System.Configuration;
using KMU.EduActivity.ApplicationLayer.DTO;
using log4net.Config;


namespace EduActivityAutoSendForm
{
    public partial class Form1 : Form
    {
        
        private string execProc = "";
        public Form1()
        {
            InitializeComponent();
        }

        public Form1(string arg)
        {
            execProc = arg;
            InitializeComponent();
        }
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private void Form1_Load(object sender, EventArgs e)
        {
            XmlConfigurator.Configure(new System.IO.FileInfo("./log4net.config"));

            //try
            //{
            //    AutoSendFormFix(null);
            //    //AutoCreateFormInstance(null);
            //}
            //catch (Exception ex)
            //{
            //    KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService service = new KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService();
            //    try
            //    {
            //        service.WriteLog("排程exe", "發生錯誤:" + ex.Message);
            //    }
            //    catch
            //    {

            //    }
            //}
            //return;


            //KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService sservice = new KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService();
            //sservice.AutoSendFormByID("2018122119");
            //sservice.AutoSendFormByID("2015050501");
            //AutoSendFormFix(null);
            //return;
            //AutoCreateFormInstance(null);
            //sservice.CreateEduForm("2019042101505");
            //return;

            //return;

            //AutoSendForm(null);
            //return;
            log.Info("Form_Load開始");
            if (execProc == "" || execProc.Contains("AutoSendForm"))
            {
                log.Info("AutoSendForm開始");
                try
                {
                    AutoSendForm(null);
                }
                catch (Exception ex)
                {
                    KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService service = new KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService();
                    try
                    {
                        log.Error("Form_Load:AutoSendForm," + ex.Message);
                        service.WriteLog("排程exe", "發生錯誤:" + ex.Message);
                    }
                    catch
                    {

                    }
                }
            }

            if (execProc == "" || execProc.Contains("AutoCreateFormInstance"))
            {
                log.Info("AutoCreateFormInstance開始");
                try
                {
                    AutoCreateFormInstance(null);
                }
                catch (Exception ex)
                {
                    KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService service = new KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService();
                    try
                    {
                        log.Error("Form_Load:AutoCreateFormInstance," + ex.Message);
                        service.WriteLog("排程exe", "發生錯誤:" + ex.Message);
                    }
                    catch
                    {

                    }
                }
            }

            if (execProc == "" || execProc.Contains("CheckExpire"))
            {
                log.Info("CheckExpire開始");
                try
                {
                    CheckExpire(null);
                }
                catch (Exception ex)
                {
                    KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService service = new KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService();
                    try
                    {
                        log.Error("Form_Load:CheckExpire," + ex.Message);
                        service.WriteLog("排程exe", "發生錯誤:" + ex.Message);
                    }
                    catch
                    {

                    }
                }
            }


            if (execProc == "" || execProc.Contains("SendAlert"))
            {
                try
                {
                    SendAlert(null);
                }
                catch (Exception ex)
                {
                    KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService service = new KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService();
                    try
                    {
                        service.WriteLog("排程exe", "發生錯誤:" + ex.Message);
                    }
                    catch
                    {

                    }
                }
            }

            if (execProc == "" || execProc.Contains("SendPassportAlert"))
            {
                try
                {
                    SendPassportAlert(null);
                }
                catch(Exception ex)
                {
                    KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService service = new KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService();
                    try
                    {
                        service.WriteLog("排程exe", "發生錯誤:" + ex.Message);
                    }
                    catch
                    {

                    }
                }
            }


            if (execProc == "" || execProc.Contains("SendEduPassportAlert"))
            {
                try
                {
                    SendEduPassportAlert(null);
                }
                catch (Exception ex)
                {
                    KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService service = new KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService();
                    try
                    {
                        service.WriteLog("排程exe", "發生錯誤:" + ex.Message);
                    }
                    catch
                    {

                    }
                }
            }

            if (execProc == "" || execProc.Contains("SendTeachTimePointData"))
            {
                try
                {
                    SendTeachTimePointData();
                }
                catch (Exception ex)
                {
                    KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService service = new KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService();
                    try
                    {
                        service.WriteLog("排程exe", "發生錯誤:" + ex.Message);
                    }
                    catch
                    {

                    }
                }
            }

            if (execProc == "" || execProc.Contains("DailyJob"))
            {
                try
                {
                    SendRecordWriterAlert();
                }
                catch(Exception ex)
                {
                    KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService service = new KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService();
                    try
                    {
                        service.WriteLog("排程exe", "發生錯誤:" + ex.Message);
                    }
                    catch
                    {

                    }
                }

                try
                {
                    SendRecordWriterExpireAlert();
                }
                catch (Exception ex)
                {
                    KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService service = new KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService();
                    try
                    {
                        service.WriteLog("排程exe", "發生錯誤:" + ex.Message);
                    }
                    catch
                    {

                    }
                }

                try
                {
                    SendRecordSignerAlert();
                }
                catch (Exception ex)
                {
                    KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService service = new KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService();
                    try
                    {
                        service.WriteLog("排程exe", "發生錯誤:" + ex.Message);
                    }
                    catch
                    {

                    }
                }
            }

            log.Info("Form_Load結束");
            this.Close();
        }

        public void SendRecordWriterAlert()
        {
            string mailcontenttemplate = @"
{0} 您好，<br>
<br>
會議主題：{1}<br>
記錄者：{2}<br>
請於活動結束後前往教學管理系統填寫會議記錄
系統網址：https://www.kmuh.org.tw/Web/EduActivity
";
            KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService service = new KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService();
            List<MailListDto> list = service.GetReocrdWritterDailyAlert(DateTime.Now.Date);
            
            foreach(MailListDto dto in list)
            {
                try
                {
                    string mailcontent = string.Format(mailcontenttemplate, dto.EmpName, dto.OtherParam1, dto.EmpName);

                    string subject = "會議記錄填寫提醒";
//#if DEBUG
//                    SendMailHtml("1020640@kmuh.org.tw", subject, mailcontent, "1020640");
//                    break;
//#else
                    if (dto.Email == null || dto.Email == "")
                    {
                        dto.Email = dto.EmpCode + "@kmuh.org.tw";
                    }
                    SendMailHtml(dto.Email, subject, mailcontent, "ap_sender");

//#endif

                }
                catch (Exception ex)
                {

                }


            }
        }

        public void SendRecordWriterExpireAlert()
        {
            string mailcontenttemplate = @"
{0} 您好，<br>
<br>
會議主題：{1}<br>
記錄者：{2}<br>
活動已結束{3}天<br>
請儘快前往教學管理系統填寫會議記錄
系統網址：https://www.kmuh.org.tw/Web/EduActivity
";
            int expiredays = 3;

            KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService service = new KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService();
            List<MailListDto> list = service.GetReocrdWritterDailyAlert(DateTime.Now.Date.AddDays((-1) * expiredays));

            foreach (MailListDto dto in list)
            {
                try
                {
                    string mailcontent = string.Format(mailcontenttemplate, dto.EmpName, dto.OtherParam1, dto.EmpName, expiredays.ToString());

                    string subject = "會議記錄填寫提醒";
//#if DEBUG
//                    SendMailHtml("1020640@kmuh.org.tw", subject, mailcontent, "1020640");
//                    break;
//#else
                    if (dto.Email == null || dto.Email == "")
                    {
                        dto.Email = dto.EmpCode + "@kmuh.org.tw";
                    }
                    SendMailHtml(dto.Email, subject, mailcontent, "ap_sender");

//#endif

                }
                catch (Exception ex)
                {

                }


            }
        }

        public void SendRecordSignerAlert()
        {
            string mailcontenttemplate = @"
{0} 您好,<br>
教學管理系統中有您需要簽核的會議記錄<br>
請儘快前往教學管理系統進行簽核
系統網址：https://www.kmuh.org.tw/Web/EduActivity
";
            int expiredays = 3;

            KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService service = new KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService();
            List<MailListDto> list = service.GetRecordSignerAlert();

            foreach (MailListDto dto in list)
            {
                try
                {
                    string mailcontent = string.Format(mailcontenttemplate, dto.EmpName);

                    string subject = "會議記錄簽核提醒";
//#if DEBUG
//                    SendMailHtml("1020640@kmuh.org.tw", subject, mailcontent, "1020640");
//                    break;
//#else
                    if (dto.Email == null || dto.Email == "")
                    {
                        dto.Email = dto.EmpCode + "@kmuh.org.tw";
                    }
                    SendMailHtml(dto.Email, subject, mailcontent, "ap_sender");

//#endif

                }
                catch (Exception ex)
                {

                }


            }
        }



        public void SendTeachTimePointData()
        {
            string mailcontenttemplate = @"
{0} 您好,<br>
您於<font color='blue'> {1}~{2} </font>之教學工作評估，如下：<br>
<table align='center' border='1' cellspacing='0'>
<tr>
<td>教學工作評估</td>
<td>計算時機</td>
<td>時數(點數)</td>
</tr>
<tr>
<td>教學時數</td>
<td>{9}</td>
<td>{3}小時</td>
</tr>
<tr>
<td>教學點數</td>
<td>主治醫師教學記錄(106 學年度(含)起)</td>
<td>{4}點</td>
</tr>
<tr>
<td>教師成長訓練時數</td>
<td></td>
<td>{5}小時</td>
</tr>
<tr>
<td rowspan='4'>OSCE認證</td>
<td>{11}</td>
<td>{6}</td>
</tr>
<tr>
<td>學校BLOCK整合課程</td>
<td>{10}小時</td>
</tr>
<tr>
<td>OSCE時數(考官+SP)</td>
<td>{7}小時</td>
</tr>
<tr>
<td>OSCE教案/高階擬真教案撰寫</td>
<td>{8}篇
{12}
</td>
</tr>
</table>
<pre>
【評估辦法】
    ●教學點數：
        -主治醫師教學點數：近三年教學點數達到 30 點，且每年不得低於 8 點，或最近三年之教學點數達 35 點，且每年不得低於 6 點。
        -總住院醫師教學點數：具有教學點數每年至少 4 點。
    ●訓練時數：
        -主治醫師訓練時數：近三年教師成長教育訓練時數達到 15 小時，且每年不得低於 3 小時。
        - 總住院醫師訓練時數：每年教師成長教育訓練時數至少 5 小時。
    ●教學時數：本校醫學院教師擔任附屬機構各醫療單位主治醫師身分者，每週基本授課時數以 4 小時為原則。
    ●符合學會認證考官之證明；並具備下列要求之一者：
    (一)近三學年度擔任下列活動 OSCE 考官：學校 BLOCK 整合課程、 醫院臨床教育訓練部或學會舉辦之考試或標準化病人訓練，其時數合計 18 小時以上。
    (二)近三學年度撰寫 OSCE 教案一篇以上之證明。
詳細明細，可至教學管理系統之「教學工作評估」查詢，連結網址：
https://www.kmuh.org.tw/Web/EduActivity/TeachTimeQuery.aspx
</pre>
";


            /*
教學時數 ： xxx小時
教學點數 ： xxx點
教師成長訓練時數 ： xxx小時
OSCE認證 ：
  OSCE學會認證考官 ： xxxx年x月x日~xxxx年x月x日 有效
  OSCE時數 ： xxx小時
  OSCE教案/高階擬真教案撰寫 ： x篇

            */
            DateTime nowdate = DateTime.Now.Date;
            int syear = nowdate.Month > 8 ? nowdate.Year : nowdate.Year - 1;
            DateTime edate = new DateTime(nowdate.Year, nowdate.Month, 1).AddDays(-1);

            //DateTime edate = new DateTime(2018, 7, 31);// nowdate.Date;
            DateTime sdate = new DateTime(syear, 8, 1);
            List<V_KmuEmpDto> doclist = new List<V_KmuEmpDto>();
            using (KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService service = new KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService())
            {
                doclist = service.GetEmpListByJobCode("VS").Union(service.GetEmpListByJobCode("CR")).ToList();
            }
            //測試
            //doclist = new List<V_KmuEmpDto>();
            //V_KmuEmpDto admin = new V_KmuEmpDto();
            //admin.Empcode = "1090031";
            //admin.Empname = "靖雅喔";
            //admin.Email = "1090031@kmuh.org.tw";
            //admin.Deptcode = "7100";
            //doclist.Add(admin);

            //V_KmuEmpDto admin2 = new V_KmuEmpDto();
            //admin2.Empcode = "940109";
            //admin2.Empname = "陳德明";
            //admin2.Email = "940109@kmuh.org.tw";
            //admin2.Deptcode = "7100";

            //doclist.Add(admin2);

            //V_KmuEmpDto admin3 = new V_KmuEmpDto();
            //admin3.Empcode = "1020640";
            //admin3.Empname = "吳健璋";
            //admin3.Email = "1020640@kmuh.org.tw";
            //admin3.Deptcode = "7000";

            //doclist.Add(admin3);


            //V_KmuEmpDto admin4 = new V_KmuEmpDto();
            //admin4.Empcode = "1010593";
            //admin4.Empname = "曹振媛";
            //admin4.Email = "1010593@kmuh.org.tw";
            //admin4.Deptcode = "7100";

            //doclist.Add(admin4);


            //測試
//#if DEBUG
            //doclist = doclist.Where(c => c.Empcode == "1020640").ToList();
//#endif

            //doclist = doclist.Where(c => c.Empcode == "1050561").ToList();
            

            foreach (V_KmuEmpDto emp in doclist)
            {
                using (KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService service = new KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService())
                {
                    try
                    {

                        List<TeachPointCalcSumData> list = service.GetTeachPointCalcData(3, new List<string> { emp.Empcode }, sdate, edate);
                        
                        string parm0 = emp.Empname;
                        string parm1 = (sdate.Year - 1911).ToString() + "學年度(期間" + sdate.ToString("yyyy/MM/dd");
                        string parm2 = edate.ToString("yyyy/MM/dd") + ")";

                        var data = list.Where(c => c.EmpCode == emp.Empcode).FirstOrDefault();
                        string parm3 = "0";
                        string parm4 = "0";

                        string parm7 = "";
                        string parm8 = "";
                        string parm12 = "";

                        if (data != null)
                        {
                            var timedata = data.ItemDatas.Where(c => c.ItemID == 36).FirstOrDefault();
                            parm3 = timedata == null ? "0" : timedata.SumPoint.ToString();
                            parm4 = data.SumPoint.ToString();

                            var oscetimepoint = data.ItemDatas.Where(c => c.ItemID == 23).FirstOrDefault();
                            var oscetimepoint2 = data.ItemDatas.Where(c => c.ItemID == 27).FirstOrDefault();
                            decimal oscetime = 0;
                            if (oscetimepoint != null)
                            {
                                oscetime += oscetimepoint.SumPoint * 2;
                            }
                            if (oscetimepoint2 != null)
                            {
                                oscetime += oscetimepoint2.SumPoint * 2;
                            }

                            parm7 = oscetime.ToString();

                            var oscepoint = data.ItemDatas.Where(c => c.ItemID == 25).FirstOrDefault();
                            parm8 = oscepoint == null ? "0" : (oscepoint.SumPoint / 3).ToString();
                            if (oscepoint != null && oscepoint.SumPoint > 0)
                            {
                                foreach (var det in oscepoint.DetailData)
                                {
                                    parm12 += "<br>";
                                    parm12 += det.PointDesc;
                                }
                            }
                        }

                        decimal? trainingdata = service.QueryTrainingTimeEmpItemData(emp.Empcode, null, sdate, edate, null, null, null).Sum(c => c.TimeHour);
                        string parm5 = trainingdata.HasValue ? trainingdata.Value.ToString() : "0";


                        var certdata = service.GetAvailableOSCECertData(emp.Empcode, sdate, edate);
                        string parm6 = "無認證";
                        if (certdata != null)
                        {
                            if (certdata.Remark != null && certdata.Remark != "")
                            {
                                parm6 = certdata.Remark;
                            }
                            else
                            {
                                if ((certdata.Edate >= edate || (certdata.Edate >= sdate && certdata.Edate < edate)))
                                {
                                    parm6 = certdata.Sdate.ToString("yyyy年MM月dd日") + "~" + certdata.Edate.ToString("yyyy年MM月dd日") + " 有效";
                                }
                            }
                        }

                        var blockdata = service.QueryOSCEBlockTimeEmpItemData(emp.Empcode, null, sdate, edate, null, null).Sum(c => c.TrainingTime);
                        string parm10 = "0";
                        if (certdata != null)
                        {
                            parm10 = blockdata.ToString();
                        }

                        string parm9 = "";
                        string parm11 = "";
                        if (emp.Deptcode == "1300")
                        {
                            parm9 = "學校臨床教師 - 牙科(106 起)";
                            parm11 = "牙科臨床技能小組";
                        }
                        else
                        {
                            parm9 = "學校臨床教師(106 起)";
                            parm11 = "OSCE學會認證考官";
                        }

                        try
                        {
                            service.InsertMonthlyTeachPointCalcData(emp.Empcode, DateTime.Now.Date, sdate, edate, parm0, parm1, parm2, parm3, parm4, parm5, parm6, parm7, parm8, parm9, parm10, parm11, parm12, null);
                        }
                        catch (Exception ex)
                        {
                            service.WriteLog("SendTeachTimePointData", emp.Empcode + "發生錯誤1:" + ex.Message);
                        }

                        string mailcontent = string.Format(mailcontenttemplate, parm0, parm1, parm2, parm3, parm4, parm5, parm6, parm7, parm8, parm9, parm10, parm11, parm12);

                        if (data != null)
                        {
                            try
                            {
                                string subject = string.Format("{0}-{1} 之教學工作評估", parm1, parm2);
                                //                        #if DEBUG
                                //                        SendMailHtml("1020640@kmuh.org.tw", subject, mailcontent, "1020640");
                                //#else

                                if (emp.Email == null || emp.Email == "")
                                {
                                    emp.Email = emp.Empcode + "@kmuh.org.tw";
                                }
                                //SendMailHtml(emp.Email, subject, mailcontent, "ap_sender");
                                //#endif
                            }
                            catch (Exception ex)
                            {

                            }
                        }

                    }
                    catch (Exception eee)
                    {
                        service.WriteLog("SendTeachTimePointData", emp.Empcode + "發生錯誤2:" + eee.Message);
                    }
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.WaitForFullGCComplete();
            }
            


        }



        public void SendEduPassportAlert(object arg)
        {
            KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService service = new KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService();

            service.WriteLog("SendEduPassportAlert", "開始執行");
            
            try
            {
                Dictionary<string, string[]> smslist = new Dictionary<string, string[]>();

                string returnVal = null;
                ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["dsEduActivity"];
                if (settings != null)
                    returnVal = settings.ConnectionString;

                System.Data.SqlClient.SqlConnection _conn = new System.Data.SqlClient.SqlConnection(returnVal);
                System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(@"select a.TTarget,count(*) as datacount, b.email from 
EduPassportInsItem a
left join V_KmuEmp b on a.TTarget = b.empcode
left join edupassportinstance c on a.instanceid = c.instanceid
where a.status = '1' and c.status <>'X' group by a.TTarget,b.email", _conn);


                System.Data.DataTable dt = new System.Data.DataTable();
                adp.Fill(dt);

                foreach (System.Data.DataRow dr in dt.Rows)
                {
                    try
                    {
                        string msg = AlertEduPassportMsgContent.Replace("<rowcount>", dr["datacount"].ToString()).Replace("<url>", "https://www.kmuh.org.tw/Web/EduActivity/EduPassportInsItemTeacherView.aspx");

                        try
                        {
                            SendMail(dr["email"].ToString().Replace(";", ""), msg, msg, "ap_sender");//dr["CREATER"].ToString());
                            service.WriteLog("SendPassportAlert", "已email通知" + dr["email"].ToString() + "審核學習護照" + DateTime.Now.Date.ToString("yyyy/MM/dd"));
                        }
                        catch (Exception ex)
                        {
                            service.WriteLog("SendPassportAlert", "email通知" + dr["email"].ToString() + "審核學習護照時發生錯誤,內容:" + ex.Message);
                        }

                        //if (dr["TargetType"].ToString() != "Member")
                        //{
                        if (dr["CREATER"].ToString().Trim() != "")
                        {
                            if (!smslist.ContainsKey(dr["TTarget"].ToString()))
                            {
                                smslist.Add(dr["TTarget"].ToString(), new string[] { msg, "1020640" });
                            }
                        }
                        //}

                    }
                    catch (Exception ex)
                    {
                        service.WriteLog("SendPassportAlert", "發生錯誤:" + ex.Message);
                    }

                }


                foreach (string target in smslist.Keys)
                {
                    try
                    {
                        //SendSMS(target, smslist[target][0], smslist[target][1]);
                    }
                    catch (Exception ex)
                    {
                        service.WriteLog("SendPassportAlert", "簡訊通知" + target + "時發生錯誤,內容:" + ex.Message);
                    }
                }


            }
            catch (Exception ex)
            {
                service.WriteLog("SendPassportAlert", "發生錯誤:" + ex.Message);
            }
            finally
            {
                service.WriteLog("SendPassportAlert", "執行結束");
            }
        }


        public void SendPassportAlert(object arg)
        {
            KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService service = new KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService();

            service.WriteLog("SendPassportAlert", "開始執行");

            try
            {
                Dictionary<string, string[]> smslist = new Dictionary<string, string[]>();

                string returnVal = null;
                ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["dsEduActivity"];
                if (settings != null)
                    returnVal = settings.ConnectionString;

                System.Data.SqlClient.SqlConnection _conn = new System.Data.SqlClient.SqlConnection(returnVal);
                System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(@"select a.designationTeacherNumber,count(*) as datacount, b.email from 
PassPortStudentApplicationItem a
left join V_KmuEmp b on a.designationTeacherNumber = b.empcode
where a.checkStatus = '1' group by a.designationTeacherNumber,b.email", _conn);


                System.Data.DataTable dt = new System.Data.DataTable();
                adp.Fill(dt);

                foreach (System.Data.DataRow dr in dt.Rows)
                {
                    try
                    {
                        string msg = AlertPassportMsgContent.Replace("<rowcount>", dr["datacount"].ToString()).Replace("<url>", " https://www.kmuh.org.tw/Web/EduActivity/PassPortCheckForTeacherCopy.aspx");
                        
                    
                        try
                        {

                            SendMail(dr["email"].ToString().Replace(";", ""), msg, msg, "ap_sender");//dr["CREATER"].ToString());
                            //SendMail("1020640@ms.kmuh.org.tw", msg, msg, "ap_sender");//dr["CREATER"].ToString());
                            //smslist.Add("900091", new string[] { msg, "1020640" });
                            //break;
                            service.WriteLog("SendPassportAlert", "已email通知" + dr["email"].ToString() + "審核臨床分級" + DateTime.Now.Date.ToString("yyyy/MM/dd"));
                        }
                        catch (Exception ex)
                        {
                            service.WriteLog("SendPassportAlert", "email通知" + dr["email"].ToString() + "審核臨床分級時發生錯誤,內容:" + ex.Message);
                        }

                        //if (dr["TargetType"].ToString() != "Member")
                        //{
                        if (dr["designationTeacherNumber"].ToString().Trim() != "")
                        {
                            
                            if (!smslist.ContainsKey(dr["designationTeacherNumber"].ToString()))
                            {
                                smslist.Add(dr["designationTeacherNumber"].ToString(), new string[] { msg, "1020640" });
                            }
                        }
                        //}

                    }
                    catch (Exception ex)
                    {
                        service.WriteLog("SendPassportAlert", "發生錯誤:" + ex.Message);
                    }

                }
                
                foreach (string target in smslist.Keys)
                {
                    try
                    {
                        //SendSMS(target, smslist[target][0], smslist[target][1]);
                    }
                    catch (Exception ex)
                    {
                        service.WriteLog("SendPassportAlert", "簡訊通知" + target + "時發生錯誤,內容:" + ex.Message);
                    }
                }


            }
            catch (Exception ex)
            {
                service.WriteLog("SendPassportAlert", "發生錯誤:" + ex.Message);
            }
            finally
            {
                service.WriteLog("SendPassportAlert", "執行結束");
            }
        }

        public void SendAlert(object arg)
        {
            //半夜不要送
            if((DateTime.Now.Hour>=18 && DateTime.Now.Hour<=23) || (DateTime.Now.Hour>=0 && DateTime.Now.Hour<=9))
            {
                return;
            }
            KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService service = new KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService();

            service.WriteLog("SendAlert", "開始執行");

            try
            {
                Dictionary<string, string[]> smslist = new Dictionary<string, string[]>();

                string returnVal = null;
                ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["dsEduActivity"];
                if (settings != null)
                    returnVal = settings.ConnectionString;


                System.Data.SqlClient.SqlConnection _conn = new System.Data.SqlClient.SqlConnection(returnVal);
                System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(@"select c.instance_name,a.TargetID as TargetID, c.CREATER as CREATER,a.INSTANCE_ID,a.TargetType ,e.email, pi.INSTANCE_ID as nextinsid,t.ALERT_NEXT_MESSAGE from form_instance_targets a 
inner join FORM_INSTANCES c on a.INSTANCE_ID = c.INSTANCE_ID and (c.expiredate is null or c.expiredate>='" + DateTime.Now.ToString("yyyy/MM/dd") + @"' )
inner join eduterm tt on c.inhospid = tt.edutermid
inner join V_KmuEmp e on a.TargetID = e.empcode
inner join FORM_TEMPLATES t on c.TEMPLATE_ID = t.TEMPLATE_ID
left join FORM_INSTANCES pi on pi.PARENT_INSTANCE_ID = c.parent_instance_id and pi.INSTANCE_ID > c.instance_id and t.ALERT_NEXT_MESSAGE is not null
where a.AlertTime is null 
and not exists (select 1 from FORM_INSTANCE_TARGETS b where b.INSTANCE_ID = a.instance_id and b.TargetOrder< a.targetorder and b.Status = '0' )
and not exists (select 1 from form_instances d where d.PARENT_INSTANCE_ID = c.parent_instance_id and d.INSTANCE_ID< c.instance_id and d.Status = '0'  )
and a.Status = '0' and c.CREATER is not null and c.CREATER<>'' and a.targetid is not null and a.targetid <>''
and not exists (select 1 from EduNotAlertSetting na where na.empcode = e.empcode and na.alerttype='SendAlert' )
and c.instance_create_datetime >= getdate()-10
", _conn);
                Dictionary<string,string> alertnextlist = new Dictionary<string,string>();
                System.Data.DataTable dt = new System.Data.DataTable();
                adp.Fill(dt);

                foreach (System.Data.DataRow dr in dt.Rows)
                {
                    try
                    {
                        if (dr["ALERT_NEXT_MESSAGE"] != DBNull.Value)
                        {
                            if(alertnextlist.Keys.Contains(dr["ALERT_NEXT_MESSAGE"].ToString()))
                            {
                                if(alertnextlist[dr["ALERT_NEXT_MESSAGE"].ToString()] != "")
                                {
                                    alertnextlist[dr["ALERT_NEXT_MESSAGE"].ToString()] += ",";
                                }

                                alertnextlist[dr["ALERT_NEXT_MESSAGE"].ToString()] += dr["nextinsid"].ToString();
                            }
                            else
                            {
                                alertnextlist.Add(dr["ALERT_NEXT_MESSAGE"].ToString(), dr["nextinsid"].ToString());
                            }
                        }



                        string msg = AlertMsgContent.Replace("<form_name>", dr["INSTANCE_NAME"].ToString()).Replace("<url>", ServerUrl + "InstanceDetial.aspx?instance_id=" + dr["INSTANCE_ID"].ToString());
                        string smsmsg = AlertMsgSMSContent.Replace("<form_name>", dr["INSTANCE_NAME"].ToString());

                        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("update form_instance_targets set alerttime = getdate() where targetid = @targetid and instance_id = @instance_id and targettype = @targettype", _conn);
                        cmd.Parameters.AddWithValue("@targetid", dr["TargetID"].ToString());
                        cmd.Parameters.AddWithValue("@instance_id", Convert.ToInt32(dr["INSTANCE_ID"]));
                        cmd.Parameters.AddWithValue("@targettype", dr["TargetType"].ToString());

                        if (_conn.State != ConnectionState.Open)
                            _conn.Open();

                        cmd.ExecuteNonQuery();

                        try
                        {
                            SendMail(dr["email"].ToString().Replace(";", ""), msg, msg, "ap_sender");//dr["CREATER"].ToString());
                            service.WriteLog("SendAlert", "已email通知" + dr["email"].ToString() + "填寫" + dr["INSTANCE_NAME"].ToString() + ",內容:" + msg);
                        }
                        catch (Exception ex)
                        {
                            service.WriteLog("SendAlert", "email通知" + dr["email"].ToString() + "填寫" + dr["INSTANCE_NAME"].ToString() + "時發生錯誤,內容:" + ex.Message);
                        }
                        
                        //if (dr["TargetType"].ToString() != "Member")
                        //{
                        if (dr["CREATER"].ToString().Trim() != "")
                        {
                            if (!smslist.ContainsKey(dr["TargetID"].ToString()))
                            {
                                smslist.Add(dr["TargetID"].ToString(), new string[] { smsmsg, dr["CREATER"].ToString() });
                            }


                        }
                        //}

                    }
                    catch (Exception ex)
                    {
                        service.WriteLog("SendAlert", "發生錯誤:" + ex.Message);
                    }

                }

                foreach (string target in smslist.Keys)
                {
                    try
                    {
                        //SendSMS(target, smslist[target][0], smslist[target][1]);
                    }
                    catch (Exception ex)
                    {
                        service.WriteLog("SendAlert", "簡訊通知" + target + "時發生錯誤,內容:" + ex.Message);
                    }
                }


                foreach(string bodystr in alertnextlist.Keys)
                {
                    adp = new System.Data.SqlClient.SqlDataAdapter(@"select c.instance_name,a.TargetID as TargetID, c.CREATER as CREATER,a.INSTANCE_ID,a.TargetType ,e.email, pi.INSTANCE_ID as nextinsid,t.ALERT_NEXT_MESSAGE from form_instance_targets a 
inner join FORM_INSTANCES c on a.INSTANCE_ID = c.INSTANCE_ID and (c.expiredate is null or c.expiredate>='" + DateTime.Now.ToString("yyyy/MM/dd") + @"' )
inner join eduterm tt on c.inhospid = tt.edutermid
inner join V_KmuEmp e on a.TargetID = e.empcode
inner join FORM_TEMPLATES t on c.TEMPLATE_ID = t.TEMPLATE_ID
left join FORM_INSTANCES pi on pi.PARENT_INSTANCE_ID = c.parent_instance_id and pi.INSTANCE_ID > c.instance_id and t.ALERT_NEXT_MESSAGE is not null
where a.AlertTime is null 
and not exists (select 1 from FORM_INSTANCE_TARGETS b where b.INSTANCE_ID = a.instance_id and b.TargetOrder< a.targetorder and b.Status = '0' )
and not exists (select 1 from form_instances d where d.PARENT_INSTANCE_ID = c.parent_instance_id and d.INSTANCE_ID< c.instance_id and d.Status = '0'  )
and a.Status = '0' and c.CREATER is not null and c.CREATER<>'' and a.targetid is not null and a.targetid <>''
", _conn);
                }


            }
            catch (Exception ex)
            {
                service.WriteLog("SendAlert", "發生錯誤:" + ex.Message);
            }
            finally
            {
                service.WriteLog("SendAlert", "執行結束");
            }
        }

        public void AutoSendForm(object arg)
        {
            
            KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService service = new KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService();

            try
            {

                service.WriteLog("AutoSendForm", "開始執行");
                //20160616000000000916
                DateTime d = DateTime.Now.Date.AddDays(-7);

                while (d <= DateTime.Now.Date)
                {

                    string result = service.AutoSendForm(d);

                    d = d.AddDays(1);

                }

            }
            catch (Exception ex)
            {
                service.WriteLog("AutoSendForm", "發生錯誤:" + ex.Message);
            }
            finally
            {
                service.WriteLog("AutoSendForm", "執行結束");
            }
            
        }

        public void AutoSendFormFix(object arg)
        {

            //KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService service = new KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService();

            try
            {

                //service.WriteLog("AutoSendForm", "開始執行");
                //20160616000000000916

                DateTime d = new DateTime(2023, 3, 19);
                while (d < new DateTime(2023, 4, 17))
                {
                    using (KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService service = new KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService())
                    {
                        string result = service.AutoSendForm(d);

                        d = d.AddDays(1);
                    }

                }
                

                //DateTime date = DateTime.Now.Date.AddDays(-1);
                //string result = service.AutoSendForm(date);
                //date = date.AddDays(-1);

                //result = service.AutoSendForm(date);




            }
            catch (Exception ex)
            {
                //service.WriteLog("AutoSendForm", "發生錯誤:" + ex.Message);
            }
            finally
            {
                //service.WriteLog("AutoSendForm", "執行結束");
            }
        }


        public void AutoCreateFormInstance(object arg)
        {
            KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService service = new KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService();

            

            try
            {
                service.WriteLog("AutoCreateFormInstance", "開始執行");
                service.AutoCreateFormInstance(DateTime.Now.Date);
            }
            catch (Exception ex)
            {
                service.WriteLog("AutoCreateFormInstance", "發生錯誤:" + ex.Message);
            }
            finally
            {
                service.WriteLog("AutoCreateFormInstance", "執行結束");
            }
        }


        public void CheckExpire(object arg)
        {
            //if (DateTime.Now.Hour == 10)
            //{
                KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService service = new KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService();

                service.WriteLog("CheckExpire", "開始執行");

                try
                {
                    string returnVal = null;
                    ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["dsEduActivity"];
                    if (settings != null)
                        returnVal = settings.ConnectionString;


                    System.Data.SqlClient.SqlConnection _conn = new System.Data.SqlClient.SqlConnection(returnVal);
                    System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(@"select 
a.INSTANCE_NAME,a.INSTANCE_ID,a.expireDate,c.empname,c.empcode as empcode,c.email as email,b.TargetType,a.creater as CREATER 
from FORM_INSTANCES a 
inner join FORM_INSTANCE_TARGETS b on a.INSTANCE_ID = b.INSTANCE_ID
inner join eduterm tt on a.inhospid = tt.edutermid
inner join V_KmuEmp c on b.TargetID = c.empcode
where b.Status = '0' and a.expireDate is not null
and not exists (select 1 from form_instances d where d.PARENT_INSTANCE_ID = a.parent_instance_id and d.INSTANCE_ID< a.instance_id and d.Status = '0'  )
and 
(
CONVERT(varchar,GETDATE()+3,111) = CONVERT(varchar, a.expireDate,111)
or CONVERT(varchar,GETDATE()+1,111) = CONVERT(varchar, a.expireDate,111)
)
and not exists (select 1 from EduNotAlertSetting na where na.empcode = c.empcode and na.alerttype='CheckExpire' )
", _conn);

                    //                SqlDataAdapter adp = new SqlDataAdapter(@"select 
                    //a.INSTANCE_NAME,a.expireDate,c.empname,'930632' as empcode,'1020640@ms.kmuh.org.tw' as email,b.TargetType,'1020640' as CREATER 
                    //from FORM_INSTANCES a 
                    //inner join FORM_INSTANCE_TARGETS b on a.INSTANCE_ID = b.INSTANCE_ID
                    //inner join V_KmuEmp c on b.TargetID = c.empcode
                    //where b.Status = '0' and a.expireDate is not null
                    //and CONVERT(varchar,GETDATE()+1,111) = CONVERT(varchar, a.expireDate,111)
                    //", _conn);

                    System.Data.DataTable dt = new System.Data.DataTable();
                    adp.Fill(dt);

                    Dictionary<string, string[]> smslist = new Dictionary<string, string[]>();
                    foreach (System.Data.DataRow dr in dt.Rows)
                    {


                        string msg = MsgContent.Replace("<form_name>", dr["INSTANCE_NAME"].ToString()).Replace("<expire_date>", Convert.ToDateTime(dr["expireDate"]).ToString("yyyy/MM/dd")).Replace("<url>", ServerUrl + "InstanceDetial.aspx?instance_id=" + dr["INSTANCE_ID"].ToString());
                        string smsmsg = MsgSMSContent.Replace("<form_name>", dr["INSTANCE_NAME"].ToString()).Replace("<expire_date>", Convert.ToDateTime(dr["expireDate"]).ToString("yyyy/MM/dd"));
                        try
                        {
                            SendMail(dr["email"].ToString(), msg, msg, "ap_sender");//dr["CREATER"].ToString());
                            service.WriteLog("CheckExpire", "已email通知" + dr["email"].ToString() + "填寫" + dr["INSTANCE_NAME"].ToString() + ",內容:" + msg);
                        }
                        catch (Exception ex)
                        {
                            service.WriteLog("CheckExpire", "email通知" + dr["email"].ToString() + "填寫" + dr["INSTANCE_NAME"].ToString() + "時發生錯誤,內容:" + ex.Message);
                        }

                        //if (dr["TargetType"].ToString() != "Member")
                        //{

                        if (dr["CREATER"].ToString().Trim() != "")
                        {
                            if (!smslist.Keys.Contains(dr["empcode"].ToString()))
                            {
                                smslist.Add(dr["empcode"].ToString(), new string[] { smsmsg, dr["CREATER"].ToString() });
                            }

                        }
                    }

                    foreach (string target in smslist.Keys)
                    {
                        try
                        {
                            //SendSMS(target, smslist[target][0], smslist[target][1]);
                        }
                        catch (Exception ex)
                        {
                            service.WriteLog("CheckExpire", "簡訊通知" + target + "表單將逾期時發生錯誤,內容:" + ex.Message);
                        }
                    }

                    smslist = new Dictionary<string, string[]>();

                    //處理當天已逾期
                    adp = new System.Data.SqlClient.SqlDataAdapter(@"select 
a.INSTANCE_NAME,a.INSTANCE_ID,a.expireDate,c.empname,c.empcode as empcode,c.email as email,b.TargetType,a.creater as CREATER 
from FORM_INSTANCES a 
inner join FORM_INSTANCE_TARGETS b on a.INSTANCE_ID = b.INSTANCE_ID
inner join eduterm tt on a.inhospid = tt.edutermid
inner join V_KmuEmp c on b.TargetID = c.empcode
where b.Status = '0' and a.expireDate is not null
and not exists (select 1 from form_instances d where d.PARENT_INSTANCE_ID = a.parent_instance_id and d.INSTANCE_ID< a.instance_id and d.Status = '0'  )
and CONVERT(varchar,GETDATE(),111) = CONVERT(varchar, a.expireDate+1,111)
", _conn);

                    dt = new System.Data.DataTable();
                    adp.Fill(dt);


                    foreach (System.Data.DataRow dr in dt.Rows)
                    {


                        string msg = IsExpireMsgContent.Replace("<form_name>", dr["INSTANCE_NAME"].ToString()).Replace("<expire_date>", Convert.ToDateTime(dr["expireDate"]).ToString("yyyy/MM/dd"));
                        string smsmsg = IsExpireMsgContent.Replace("<form_name>", dr["INSTANCE_NAME"].ToString()).Replace("<expire_date>", Convert.ToDateTime(dr["expireDate"]).ToString("yyyy/MM/dd"));
                        try
                        {
                            SendMail(dr["email"].ToString(), msg, msg, "ap_sender");//dr["CREATER"].ToString());
                            service.WriteLog("CheckExpire", "已email通知" + dr["email"].ToString() + "填寫" + dr["INSTANCE_NAME"].ToString() + ",內容:" + msg);
                        }
                        catch (Exception ex)
                        {
                            service.WriteLog("CheckExpire", "email通知" + dr["email"].ToString() + "填寫" + dr["INSTANCE_NAME"].ToString() + "時發生錯誤,內容:" + ex.Message);
                        }

                        //if (dr["TargetType"].ToString() != "Member")
                        //{

                        if (dr["CREATER"].ToString().Trim() != "")
                        {
                            if (!smslist.Keys.Contains(dr["empcode"].ToString()))
                            {
                                smslist.Add(dr["empcode"].ToString(), new string[] { smsmsg, dr["CREATER"].ToString() });
                            }

                        }
                    }


                    foreach (string target in smslist.Keys)
                    {
                        try
                        {
                            //SendSMS(target, smslist[target][0], smslist[target][1]);
                        }
                        catch (Exception ex)
                        {
                            service.WriteLog("CheckExpire", "簡訊通知" + target + "表單將逾期時發生錯誤,內容:" + ex.Message);
                        }
                    }

                }
                catch (Exception ex)
                {
                    service.WriteLog("CheckExpire", "發生錯誤:" + ex.Message);
                }
                finally
                {
                    service.WriteLog("CheckExpire", "執行結束");
                }
            //}
        }

        private void SendMail(string mailto, string subject, string body, string creater)
        {
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("ms.kmuh.org.tw");


            System.Net.NetworkCredential _MailCredentials = new System.Net.NetworkCredential("ap_sender", "Ap_Sender!#%");

            client.Credentials = _MailCredentials;


            // 設定Email訊息, 包含寄件人、收件人、主旨、內容
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.From = new System.Net.Mail.MailAddress(creater + "@ms.kmuh.org.tw", "教學管理系統");
            mail.To.Add(mailto);
            mail.Subject = subject;
            mail.Body = body;
            // 發送
            client.Send(mail);
        }


        private void SendMailHtml(string mailto, string subject, string body, string creater)
        {
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("ms.kmuh.org.tw");


            System.Net.NetworkCredential _MailCredentials = new System.Net.NetworkCredential("ap_sender", "Ap_Sender!#%");

            client.Credentials = _MailCredentials;


            // 設定Email訊息, 包含寄件人、收件人、主旨、內容
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.From = new System.Net.Mail.MailAddress(creater + "@ms.kmuh.org.tw", "教學管理系統");
            mail.To.Add(mailto);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            // 發送
            client.Send(mail);
        }


        private const string AppName = "98";
        private const string MsgContent = "您應填寫的表單 <form_name> 將於<expire_date>逾期, 請儘快前往填寫 填寫網址:<url>";
        private const string MsgSMSContent = "您應填寫的表單 <form_name> 將於<expire_date>逾期, 請儘快前往填寫";
        private const string AlertMsgContent = "您的表單 <form_name> 已可開始填寫, 請儘快前往填寫 填寫網址:<url>";
        private const string AlertMsgSMSContent = "您的表單 <form_name> 已可開始填寫, 請儘快前往填寫";
        private const string IsExpireMsgContent = "您應填寫的表單 <form_name> 已於<expire_date>逾期，請儘快前往系統點選填寫(逾期)進行填寫";
        private const string ServerUrl = "https://www.kmuh.org.tw/web/EduActivity/";
        private const string AlertPassportMsgContent = "您有<rowcount>筆待審核的臨床照護分級資料，為保障醫療品質及學員學習權益，請儘速前往審核。 審核網址: <url>";
        private const string AlertEduPassportMsgContent = "您有<rowcount>筆待審核的學習護照資料，為保障學員學習權益，請儘速前往審核。 審核網址: <url>";

        ////ins_malsnd_rtn(cr_a.receiver, s_content, cr_a.sys_id, cr.creater);
        //private void SendSMS(string receiver, string msg, string sender)
        //{
        //    string sql = "ins_malsnd_rtn";

        //    System.Data.OracleClient.OracleParameterCollection parms = new System.Data.OracleClient.OracleParameterCollection();
        //    parms.Add(new System.Data.OracleClient.OracleParameter("v_personal_code", receiver));
        //    parms.Add(new System.Data.OracleClient.OracleParameter("v_message", msg));
        //    parms.Add(new System.Data.OracleClient.OracleParameter("v_sys_id", AppName));
        //    parms.Add(new System.Data.OracleClient.OracleParameter("v_send_user", sender));

        //    KMU.EduActivity.ApplicationLayer.Utility.OracleConnectionUtils.ExecuteProcedure(sql, parms);
        //}

        private void SendSMS(string receiver, string msg, string sender)
        {
            string sql = "psn.SP_SENDMSG";

            System.Data.OracleClient.OracleParameterCollection parms = new System.Data.OracleClient.OracleParameterCollection();
            System.Data.OracleClient.OracleParameter par = new System.Data.OracleClient.OracleParameter("SenderEmp", sender);
            par.DbType = DbType.String;
            parms.Add(par);

            par = new System.Data.OracleClient.OracleParameter("ReceivePhoneNO", DBNull.Value);
            par.DbType = DbType.String;
            parms.Add(par);

            par = new System.Data.OracleClient.OracleParameter("ReceiveEmp", receiver);
            par.DbType = DbType.String;
            parms.Add(par);

            par = new System.Data.OracleClient.OracleParameter("messagetext", msg);
            par.DbType = DbType.String;
            parms.Add(par);

            par = new System.Data.OracleClient.OracleParameter("sendtime", DBNull.Value);
            par.DbType = DbType.DateTime;
            parms.Add(par);
            
            par = new System.Data.OracleClient.OracleParameter("requirereply", DBNull.Value);
            par.DbType = DbType.String;
            parms.Add(par);

            par = new System.Data.OracleClient.OracleParameter("v_sys_id", AppName);
            par.DbType = DbType.String;
            parms.Add(par);
            
            par = new System.Data.OracleClient.OracleParameter("SND_ID", DBNull.Value);
            par.DbType = DbType.String;
            par.Direction = ParameterDirection.Output;
            par.Size = 5000;
            parms.Add(par);

            KMU.EduActivity.ApplicationLayer.Utility.OracleConnectionUtils.ExecuteProcedure(sql, parms);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                AutoSendForm(null);
                CheckExpire(null);
                SendAlert(null);

            }
            catch (Exception ex)
            {
                listBox1.Items.Add(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService service = new KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService();
            service.CreateEduForm("2019111100458");
            service.CreateEduForm("2019111100459");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService service = new KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService();
            service.CreateEduFormFix(textBox1.Text);
        }
    }
}
