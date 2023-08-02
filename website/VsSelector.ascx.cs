using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using KMU.EduActivity.ApplicationLayer.DTO;
using KMU.EduActivity.ApplicationLayer.Services;

public partial class VsSelector : System.Web.UI.UserControl
{
    public bool Enabled
    {
        get
        {
            return rcbSelection.Enabled;
        }
        set
        {
            rcbSelection.Enabled = value;
            btnQuery.Enabled = value;
        }
    }

    public string SelectedValue
    {
        get
        {
            return rcbSelection.SelectedValue;
        }
        set
        {
            ReadTeacher(value, "");
        }
    }

    public string SelectedText
    {
        get
        {
            return rcbSelection.Text;
        }
        set
        {
            rcbSelection.Text = value;
        }
    }



    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            if (rcbSelection.Text != "" && ViewState[this.ClientID + "DataSession"] != null)
            {
                SelectKmuDoctorDto dto = (ViewState[this.ClientID + "DataSession"] as List<SelectKmuDoctorDto>).Where(c => c.displayname == rcbSelection.Text).FirstOrDefault();
                if (dto != null)
                {
                    rcbSelection.SelectedValue = dto.code;
                }
            }
        }

        //if (rcbSelection.SelectedValue != null && rcbSelection.SelectedValue != "")
        //{
        //    rcbSelection.DataSource = Session[this.ClientID + "DataSession"];
        //    this.SelectedValue = rcbSelection.SelectedValue;
        //    //ReadTeacher(rcbSelection.SelectedValue, "");
        //}
    }


    public void Clear()
    {
        rcbSelection.SelectedValue = null;
        rcbSelection.Text = "";
        ViewState[this.ClientID + "DataSession"] = null;
        tbEmpCode.Text = "";
        tbName.Text = "";
    }

    private void ReadTeacher(string empcode, string empname)
    {

        rcbSelection.OpenDropDownOnLoad = false;
        rcbSelection.ClearSelection();

        rcbSelection.DataSource = null;
        rcbSelection.SelectedValue = null;
        if ((empcode == "" || empcode == null) && (empname == "" || empname == null))
        {
            rcbSelection.DataBind();
            return;
        }

        EduActivityAppService service = new EduActivityAppService();

        List<SelectKmuDoctorDto> list = service.GetKmuDoctor(empcode, empname);

        rcbSelection.DataValueField = "code";
        rcbSelection.DataTextField = "displayname";

        ViewState[this.ClientID + "DataSession"] = list;
        rcbSelection.DataSource = ViewState[this.ClientID + "DataSession"];
        rcbSelection.DataBind();

        if (empcode != "" && empcode != null && list.Count(c => c.code == empcode) > 0)
        {
            rcbSelection.SelectedValue = empcode;
        }
        else
        {
            if (list.Count == 1)
            {
                rcbSelection.SelectedIndex = 0;
            }

            if (list.Count > 1)
            {
                rcbSelection.OpenDropDownOnLoad = true;
            }
        }
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        ReadTeacher(tbEmpCode.Text.Trim(), tbName.Text.Trim());
    }
}