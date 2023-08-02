using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class VotePage : AuthPage
{
    private List<VoteGroupDto> CurrentGroups
    {
        get
        {
            return ViewState["CurrentGroups"] as List<VoteGroupDto>;
        }
        set
        {
            ViewState["CurrentGroups"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ID"] == null)
            {
                ShowMessageAndGo("參數傳遞錯誤!", "VoteMain.aspx");
                return;
            }
            ReadVoteGroup();


        }
        else
        {
            string ctrlName = this.Request.Params.Get("__EVENTTARGET");
            if (!String.IsNullOrEmpty(ctrlName))
            {
                Control ctrl = this.FindControl(ctrlName);

                //送出
                if (ctrl == btnSubmit)
                {
                    VoteInstanceDto ins = new VoteInstanceDto();
                    ins.Creater = this.EmpCode;
                    ins.CreateTime = DateTime.Now;
                    ins.MainID = Convert.ToInt32(Request.QueryString["ID"]);
                    ins.Status = "V";
                    List<VoteInsDetDto> list = new List<VoteInsDetDto>();
                    foreach (string key in Request.Form.Keys)
                    {
                        if (key.StartsWith("Group_"))
                        {
                            string values = Request.Form[key];

                            string[] empcodes = values.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                            int groupid = Convert.ToInt32(key.Replace("Group_", ""));

                            VoteGroupDto g = CurrentGroups.Where(c => c.ID == groupid).FirstOrDefault();

                            foreach (string empcode in empcodes)
                            {
                                //還沒寫完
                                VoteInsDetDto dto = new VoteInsDetDto();
                                dto.GroupID = groupid;
                                dto.Value = empcode;
                                VoteItemDto item = g.VoteItems.Where(c => c.Value == dto.Value).FirstOrDefault();
                                dto.Text = item.Text;
                                list.Add(dto);
                            }
                        }
                    }

                    string result = service.SubmitVote(ins, list);
                    if(result == null)
                    {
                        ShowMessageAndGo("投票完成", "VoteMain.aspx");
                    }
                    else
                    {
                        ShowMessageAndGo("投票失敗:" + result, "VoteMain.aspx");
                    }

                }
            }
        }
    }

    private void ReadVoteGroup()
    {
        List<VoteGroupDto> list = service.GetVoteGroups(Convert.ToInt32(Request.QueryString["ID"]));
        CurrentGroups = list;
        GenerateForm();

    }

    private void GenerateForm()
    {

        string html = "";

        VoteMainDto main = service.GetVoteMain(Convert.ToInt32(Request.QueryString["ID"]));

        html += main.Header;

        foreach (VoteGroupDto g in CurrentGroups)
        {
            string functionname = "checkG" + g.ID.ToString();
            html += "<script>function " + functionname + @"(){
	var maxchecked = "+g.CanCheckCount.ToString()+@";
    var cbs = document.getElementsByName('Group_" + g.ID.ToString()+@"');
	var count =0;
	for(var i=0;i<cbs.length;i++)
	{
		if(cbs[i].checked == true)
		{
			count++;
		}
	}
	if(count>maxchecked)
	{
		alert('超過選取上限');
		return false;
	}
}</script>";

            html += "<div><h1>" + g.GroupName + "(最多選取" + g.CanCheckCount.ToString() + "位)</h1> </div>";

            int maxcolumncount = 4;

            html += "<table width=90%>";

            int columncount = 0;
            foreach (VoteItemDto item in g.VoteItems)
            {
                //if (item.Value != this.EmpCode)
                //{
                    if (columncount == 0)
                    {
                        html += "<tr>";
                    }

                    html += "<td><input type=checkbox onclick='return " + functionname + "()' name=Group_" + g.ID.ToString() + " id=Group_" + g.ID.ToString() + "_" + item.Value + " value=" + item.Value + ">" + item.Text + "</input></td>";

                    columncount++;
                    //每行4個
                    if (columncount == maxcolumncount)
                    {
                        html += "</tr>";
                        columncount = 0;
                    }
                //}
            }
            html += "</table><br/>";
        }
        liContent.Text = html;
    }

    protected void GoVote_Click(object sender, EventArgs e)
    {
        GridDataItem item = (sender as Button).Parent.Parent as GridDataItem;
        string mainid = item.GetDataKeyValue("ID").ToString();

        Response.Redirect("VotePage.aspx?ID=" + mainid);
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("VoteMain.aspx");
    }
}