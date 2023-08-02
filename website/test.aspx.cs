using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using KMU.EduActivity.ApplicationLayer.Services;
using KMU.EduActivity.DomainModel.Entities;


public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if(IsPostBack)
        {
            if(Request.Form["test"]!=null)
            {
                Label1.Text = Request.Form["test"];
            }
        }
    }
    protected void btnReCalc_Click(object sender, EventArgs e)
    {
        string[] idlist = TextBox1.Text.Split(',');

        foreach (string idstr in idlist)
        {
            ReCalc(Convert.ToInt32(idstr));


        }

    }

    private void ReCalc(int instanceid)
    {
        HtmlFormUtility.Components.HtmlForm htmlform = new HtmlFormUtility.Components.HtmlForm();
        List<HtmlFormUtility.Components.HtmlForm> list = htmlform.Query(Convert.ToInt32(instanceid), true, true, false);
        htmlform.ReCalc();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        HtmlFormUtility.Components.ViewComponent vc = new HtmlFormUtility.Components.ViewComponent();
        List<HtmlFormUtility.FORM_INSTANCES> list = vc.ListFormInstancesByTemplateId(Convert.ToInt32(TextBox2.Text));
        foreach (HtmlFormUtility.FORM_INSTANCES ins in list)
        {

            if (ins.Status != "0" && ins.INSTANCE_CREATE_DATETIME <= new DateTime(2014, 9, 18))
            {
                ReCalc(ins.INSTANCE_ID);
            }
        }
        //33
        //list = vc.ListFormInstancesByTemplateId(9);
        //foreach (HtmlFormUtility.FORM_INSTANCES ins in list)
        //{
        //    if (ins.Status != "0")
        //    {
        //        ReCalc(ins.INSTANCE_ID);
        //    }
        //}

        //list = vc.ListFormInstancesByTemplateId(56);
        //foreach (HtmlFormUtility.FORM_INSTANCES ins in list)
        //{
        //    if (ins.Status != "0")
        //    {
        //        ReCalc(ins.INSTANCE_ID);
        //    }
        //}

        //list = vc.ListFormInstancesByTemplateId(81);
        //foreach (HtmlFormUtility.FORM_INSTANCES ins in list)
        //{
        //    if (ins.Status != "0")
        //    {
        //        ReCalc(ins.INSTANCE_ID);
        //    }
        //}
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        using (EduActivityAppService service = new EduActivityAppService())
        {
            List<EduFormTemplateListDto> list = service.GetAllEduFormTemplateList();
            list = list.Where(c => c.ExecuteDate > DateTime.Now.Date).ToList();
            foreach (EduFormTemplateListDto dto in list)
            {
                if (dto.TEMPLATE_ID != 9)
                {
                    continue;
                }

                EduTermDto term = service.GetEduTermByID(dto.EduTermID);

                if (term != null)
                {

                    List<EduFormTemplateTargetDto> targetlist = service.GetEduFormTemplateTargets(dto.FTListID);

                    AutoEduFormTemplateListDto atdto = new AutoEduFormTemplateListDto();
                    HtmlFormUtility.Components.ViewComponent vc = new HtmlFormUtility.Components.ViewComponent();
                    HtmlFormUtility.FORM_TEMPLATES template = vc.GetFormTemplateById(dto.TEMPLATE_ID);
                    atdto.Creater = dto.Creater;
                    atdto.MultiTarget = template.IsMultiTargetForm;
                    atdto.TEMPLATE_ID = dto.TEMPLATE_ID;
                    atdto.EachStudent = dto.EachStudent == null ? true : dto.EachStudent.Value;
                    List<AutoEduFormTemplateTargetDto> attdtolist = new List<AutoEduFormTemplateTargetDto>();

                    foreach (EduFormTemplateTargetDto target in targetlist)
                    {
                        if (target.RoleType == "T")
                        {
                            atdto.TeacherType = target.TeacherType;
                        }
                        if (target.RoleType != "T" && target.RoleType != "S")
                        {
                            atdto.TeacherType = target.RoleType;
                        }
                        AutoEduFormTemplateTargetDto tdto = new AutoEduFormTemplateTargetDto();

                        tdto.AutoFTListID = dto.FTListID;
                        if (target.ExpireDate.HasValue)
                        {

                            TimeSpan ts = target.ExpireDate.Value - dto.ExecuteDate;
                            tdto.ExpireDays = Convert.ToInt32(ts.TotalDays);
                            tdto.ExpireDaysType = "AfterSend";
                        }
                        tdto.RoleType = target.RoleType;
                        tdto.SubTEMPLATE_ID = target.SubTEMPLATE_ID;
                        tdto.UserDefineTargetID = target.UserDefineTargetID;

                        attdtolist.Add(tdto);

                    }



                    dto.CreateSQL = service.GenerateSql(dto.FTListID, dto.ExecuteDate, term, atdto, attdtolist);

                    service.UpdateEduFormTemplateList(dto);
                }
            }
        }
    }
    protected void btnSendForm_Click(object sender, EventArgs e)
    {
        using (EduActivityAppService service = new EduActivityAppService())
        {
            service.CreateEduForm(tbFTListID.Text);
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        using (EduActivityAppService service = new EduActivityAppService())
        {
            service.FixTemplateName(Convert.ToInt32(tbFixTemplateID.Text));

        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        using (EduActivityAppService service = new EduActivityAppService())
        {
            service.FixInstanceName(Convert.ToInt32(tbFixInstance.Text));

        }

    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        using (EduActivityAppService service = new EduActivityAppService())
        {
            service.FixInstanceElements(190);

        }


    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        using (EduActivityAppService service = new EduActivityAppService())
        {
            service.CreateEduForm("2015061827878");

        }

    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        using (EduActivityContext service = new EduActivityContext())
        {
            string[] actarr = new string[] {"A","B","C","D","E"};

            var data = service.HealTeachTimes.Where(c => !actarr.Contains(c.ActType) && c.ActType.Trim() != "").ToList();

            foreach(var d in data)
            {
                string act = d.ActType.Replace("h", "").Replace("+", "").Replace(",", "").Replace(":", "");

                string[] pointarr = act.Split(new string[] { "A", "B", "C" }, StringSplitOptions.RemoveEmptyEntries);

                if (pointarr.Length == 3)
                {
                    for (int i = 0; i < pointarr.Length; i++)
                    {
                        HealTeachTime newht = new HealTeachTime();
                        newht.ActType = actarr[i];
                        newht.DataDate = d.DataDate;
                        newht.DeptCode = d.DeptCode;
                        newht.EmpCode = d.EmpCode;
                        newht.HospCode = d.HospCode;
                        newht.TargetType = d.TargetType;
                        newht.TeachTime = Convert.ToInt32(pointarr[i]);
                        service.Add(newht);
                    }
                }

                if(pointarr.Length == 2)
                {
                    if(act.Contains("A"))
                    {
                        HealTeachTime newht = new HealTeachTime();
                        newht.ActType = "A";
                        newht.DataDate = d.DataDate;
                        newht.DeptCode = d.DeptCode;
                        newht.EmpCode = d.EmpCode;
                        newht.HospCode = d.HospCode;
                        newht.TargetType = d.TargetType;
                        newht.TeachTime = Convert.ToInt32(pointarr[0]);
                        service.Add(newht);
                        if (act.Contains("B"))
                        {
                            HealTeachTime newht2 = new HealTeachTime();
                            newht2.ActType = "B";
                            newht2.DataDate = d.DataDate;
                            newht2.DeptCode = d.DeptCode;
                            newht2.EmpCode = d.EmpCode;
                            newht2.HospCode = d.HospCode;
                            newht2.TargetType = d.TargetType;
                            newht2.TeachTime = Convert.ToInt32(pointarr[1]);
                            service.Add(newht2);
                        }
                        else
                        {
                            HealTeachTime newht2 = new HealTeachTime();
                            newht2.ActType = "C";
                            newht2.DataDate = d.DataDate;
                            newht2.DeptCode = d.DeptCode;
                            newht2.EmpCode = d.EmpCode;
                            newht2.HospCode = d.HospCode;
                            newht2.TargetType = d.TargetType;
                            newht2.TeachTime = Convert.ToInt32(pointarr[1]);
                            service.Add(newht2);
                        }
                    }
                    else
                    {
                        HealTeachTime newht = new HealTeachTime();
                        newht.ActType = "B";
                        newht.DataDate = d.DataDate;
                        newht.DeptCode = d.DeptCode;
                        newht.EmpCode = d.EmpCode;
                        newht.HospCode = d.HospCode;
                        newht.TargetType = d.TargetType;
                        newht.TeachTime = Convert.ToInt32(pointarr[0]);
                        service.Add(newht);

                        HealTeachTime newhtc = new HealTeachTime();
                        newhtc.ActType = "C";
                        newhtc.DataDate = d.DataDate;
                        newhtc.DeptCode = d.DeptCode;
                        newhtc.EmpCode = d.EmpCode;
                        newhtc.HospCode = d.HospCode;
                        newhtc.TargetType = d.TargetType;
                        newhtc.TeachTime = Convert.ToInt32(pointarr[1]);
                        service.Add(newhtc);
                    }


                }
            }
            service.Delete(data);


            try
            {
                service.SaveChanges();
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }


        }
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        DateTime sdate = new DateTime(2015, 1, 12);
        DateTime edate = new DateTime(2016, 8, 23);
        string t = "season";
        using (EduActivityAppService service = new EduActivityAppService())
        {
            List<DateTime[]> test = service.GetTeachPointCalcMonthList(sdate, edate, t);
        }
    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        using (EduActivityAppService service = new EduActivityAppService())
        {
            service.FixTemplateContent();
        }
    }
}