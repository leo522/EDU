<%@ Application Language="C#" %>

<script runat="server">

    System.Threading.Timer autoSendTimer;
    System.Threading.Timer checkExpireTimer;
    System.Threading.Timer sendAlertTimer;

    
    void Application_Start(object sender, EventArgs e) 
    {
        // 應用程式啟動時執行的程式碼
        //System.Threading.AutoResetEvent areRoutine = new System.Threading.AutoResetEvent(false);
        //System.Threading.TimerCallback autoSendtcb = AutoSendForm;
        //autoSendTimer = new System.Threading.Timer(autoSendtcb, areRoutine, 0, 600000);

        //System.Threading.AutoResetEvent areRoutineExpireCheck = new System.Threading.AutoResetEvent(false);
        //System.Threading.TimerCallback ExpireChecktcb = CheckExpire;
        //checkExpireTimer = new System.Threading.Timer(ExpireChecktcb, areRoutineExpireCheck, 0, 30000);

        //System.Threading.AutoResetEvent areRoutineSendAlert = new System.Threading.AutoResetEvent(false);
        //System.Threading.TimerCallback SendAlerttcb = SendAlert;
        //sendAlertTimer = new System.Threading.Timer(SendAlerttcb, areRoutineSendAlert, 0, 300000);

    }

    public void SendAlert(object arg)
    {
        KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService service = new KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService();

        service.WriteLog("SendAlert", "開始執行");

        try
        {
            string returnVal = null;
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["dsEduActivity"];
            if (settings != null)
                returnVal = settings.ConnectionString;


            System.Data.SqlClient.SqlConnection _conn = new System.Data.SqlClient.SqlConnection(returnVal);
            System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(@"select c.instance_name,a.TargetID as TargetID, c.CREATER as CREATER,a.INSTANCE_ID,a.TargetType ,e.email from form_instance_targets a 
inner join FORM_INSTANCES c on a.INSTANCE_ID = c.INSTANCE_ID
inner join sys_Public..V_KmuEmp e on a.TargetID = e.empcode
where a.AlertTime is null 
and not exists (select 1 from FORM_INSTANCE_TARGETS b where b.INSTANCE_ID = a.instance_id and b.TargetOrder< a.targetorder and b.Status = '0' )
and not exists (select 1 from form_instances d where d.PARENT_INSTANCE_ID = c.parent_instance_id and d.INSTANCE_ID< c.instance_id and d.Status = '0'  )
and a.Status = '0' and c.CREATER is not null and c.CREATER<>''
", _conn);

            System.Data.DataTable dt = new System.Data.DataTable();
            adp.Fill(dt);


            foreach (System.Data.DataRow dr in dt.Rows)
            {
                string msg = AlertMsgContent.Replace("<form_name>", dr["INSTANCE_NAME"].ToString()).Replace("<url>", ServerUrl + "InstanceDetial.aspx?instance_id=" + dr["INSTANCE_ID"].ToString());


                SendMail(dr["email"].ToString(), msg, msg, dr["CREATER"].ToString());
                service.WriteLog("SendAlert", "已email通知" + dr["email"].ToString() + "填寫" + dr["INSTANCE_NAME"].ToString() + ",內容:" + msg);
                if (dr["TargetType"].ToString() != "Member")
                {
                    if (dr["CREATER"].ToString().Trim() != "")
                    {
                        //SendSMS(dr["TargetID"].ToString(), msg, dr["CREATER"].ToString());
                    }
                }

                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("update form_instance_targets set alerttime = getdate() where targetid = @targetid and instance_id = @instance_id and targettype = @targettype", _conn);
                cmd.Parameters.AddWithValue("@targetid", dr["TargetID"].ToString());
                cmd.Parameters.AddWithValue("@instance_id", Convert.ToInt32(dr["INSTANCE_ID"]));
                cmd.Parameters.AddWithValue("@targettype", dr["TargetType"].ToString());

                cmd.ExecuteNonQuery();
                
            }
        }
        finally
        {
            service.WriteLog("SendAlert", "執行結束");
        }
    }

    public void AutoSendForm(object arg)
    {
        KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService service = new KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService();

        service.WriteLog("AutoSendForm", "開始執行");

        try
        {

            service.AutoSendForm(DateTime.Now.Date);
        }
        catch (Exception ex)
        {
            service.WriteLog("AutoSendForm", ex.Message);
        }
        finally
        {
            service.WriteLog("AutoSendForm", "執行結束");
        }
    }


    public void CheckExpire(object arg)
    {
        if (DateTime.Now.Hour == 8 && DateTime.Now.Minute == 00 && DateTime.Now.Second <= 30)
        {
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
a.INSTANCE_NAME,a.expireDate,c.empname,c.empcode as empcode,c.email as email,b.TargetType,a.creater as CREATER 
from FORM_INSTANCES a 
inner join FORM_INSTANCE_TARGETS b on a.INSTANCE_ID = b.INSTANCE_ID
inner join sys_Public..V_KmuEmp c on b.TargetID = c.empcode
where b.Status = '0' and a.expireDate is not null
and CONVERT(varchar,GETDATE()+1,111) = CONVERT(varchar, a.expireDate,111)
", _conn);

                //                SqlDataAdapter adp = new SqlDataAdapter(@"select 
                //a.INSTANCE_NAME,a.expireDate,c.empname,'930632' as empcode,'1020640@ms.kmuh.org.tw' as email,b.TargetType,'1020640' as CREATER 
                //from FORM_INSTANCES a 
                //inner join FORM_INSTANCE_TARGETS b on a.INSTANCE_ID = b.INSTANCE_ID
                //inner join sys_Public..V_KmuEmp c on b.TargetID = c.empcode
                //where b.Status = '0' and a.expireDate is not null
                //and CONVERT(varchar,GETDATE()+1,111) = CONVERT(varchar, a.expireDate,111)
                //", _conn);

                System.Data.DataTable dt = new System.Data.DataTable();
                adp.Fill(dt);


                foreach (System.Data.DataRow dr in dt.Rows)
                {
                    string msg = MsgContent.Replace("<form_name>", dr["INSTANCE_NAME"].ToString()).Replace("<expire_date>", Convert.ToDateTime(dr["expireDate"]).ToString("yyyy/MM/dd")).Replace("<url>", ServerUrl + "InstanceDetial.aspx?instance_id=" + dr["INSTANCE_ID"].ToString());


                    SendMail(dr["email"].ToString(), msg, msg, dr["CREATER"].ToString());
                    service.WriteLog("CheckExpire", "已email通知" + dr["email"].ToString() + "填寫" + dr["INSTANCE_NAME"].ToString() + ",內容:" + msg);
                    if (dr["TargetType"].ToString() != "Member")
                    {
                        if (dr["CREATER"].ToString().Trim() != "")
                        {
                            SendSMS(dr["empcode"].ToString(), msg, dr["CREATER"].ToString());
                        }
                    }
                }
            }
            finally
            {
                service.WriteLog("CheckExpire", "執行結束");
            }
        }
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  應用程式關閉時執行的程式碼

    }
        
    void Application_Error(object sender, EventArgs e) 
    {   
        // 發生未處理錯誤時執行的程式碼

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // 啟動新工作階段時執行的程式碼

    }

    void Session_End(object sender, EventArgs e) 
    {
        // 工作階段結束時執行的程式碼。 
        // 注意: 只有在 Web.config 檔將 sessionstate 模式設定為 InProc 時，
        // 才會引發 Session_End 事件。如果將工作階段模式設定為 StateServer 
        // 或 SQLServer，就不會引發這個事件。

    }

    private void SendMail(string mailto, string subject, string body, string creater)
    {
        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("mail.kmuh.org.tw");
        // 設定Email訊息, 包含寄件人、收件人、主旨、內容
        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.From = new System.Net.Mail.MailAddress(creater + "@ms.kmuh.org.tw", "教學管理系統");
        mail.To.Add(mailto);
        mail.Subject = subject;
        mail.Body = body;
        // 發送
        client.Send(mail);
    }


    private const string AppName = "98";
    private const string MsgContent = "您應填寫的表單 <form_name> 將於<expire_date>逾期, 請儘快前往填寫 填寫網址:<url>";
    private const string AlertMsgContent = "您的表單 <form_name> 已可開始填寫, 請儘快前往填寫 填寫網址:<url>";
    private const string ServerUrl = "http://www2.kmuh.org.tw/web/EduActivity/";
    
    //ins_malsnd_rtn(cr_a.receiver, s_content, cr_a.sys_id, cr.creater);
    private void SendSMS(string receiver, string msg, string sender)
    {
        string sql = "ins_malsnd_rtn";

        System.Data.OracleClient.OracleParameterCollection parms = new System.Data.OracleClient.OracleParameterCollection();
        parms.Add(new System.Data.OracleClient.OracleParameter("v_personal_code", receiver));
        parms.Add(new System.Data.OracleClient.OracleParameter("v_message", msg));
        parms.Add(new System.Data.OracleClient.OracleParameter("v_sys_id", AppName));
        parms.Add(new System.Data.OracleClient.OracleParameter("v_send_user", sender));

        KMU.EduActivity.ApplicationLayer.Utility.OracleConnectionUtils.ExecuteProcedure(sql, parms);
    }
</script>
