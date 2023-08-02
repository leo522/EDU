using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;
using KMU.EduActivity.ApplicationLayer.Services;

public partial class DeptSelector : System.Web.UI.UserControl
{
    protected EduActivityAppService service = new EduActivityAppService();

    private bool _withEmptyDept = false;
    public bool WithEmptyDept
    {
        get
        {
            return _withEmptyDept;
        }
        set
        {
            _withEmptyDept = value;
        }
    }

    private string _emptyDeptName = "";
    public string EmptyDeptName
    {
        get
        {
            return _emptyDeptName;
        }
        set
        {
            _emptyDeptName = value;
        }
    }


    public string GetDeptName(string deptcode)
    {
        List<V_departmentDto> list = ViewState[this.ID + "DeptList"] as List<V_departmentDto>;
        V_departmentDto dep = list.Where(c => c.Deptcode == deptcode).FirstOrDefault();
        if (dep != null)
        {
            return dep.DisplayName;
        }
        else
        {
            return "";
        }
    }

    public string SelectHospCode
    {
        get
        {
            return rcbHosp.SelectedValue;
        }
    }

    public string SelectHospName
    {
        get
        {
            return rcbHosp.Text;
        }
    }

    public string SelectDeptName
    {
        get
        {
            return ddlUnit.Text;
        }
    }

    public V_departmentDto SelectDept
    {
        get
        {
            if (ViewState[this.ID + "DeptList"] != null)
            {
                if (ddlUnit.SelectedValue != null && ddlUnit.SelectedValue != "")
                {
                    List<V_departmentDto> list = ViewState[this.ID + "DeptList"] as List<V_departmentDto>;
                    V_departmentDto dep = list.Where(c => c.Deptcode == ddlUnit.SelectedValue && c.Hospcode == rcbHosp.SelectedValue).FirstOrDefault();
                    return dep;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindHosp();
            BindDept();
        }
    }
    protected void rcbHosp_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        BindDept();
        ddlUnit.SelectedValue = "";
    }

    public void Select(string hospcode, string deptcode)
    {
        try
        {
            rcbHosp.SelectedValue = hospcode;
            BindDept();
            ddlUnit.SelectedValue = deptcode;
        }
        catch
        {

        }
    }

    private void BindHosp()
    {
        List<HospDto> hosplist = service.GetHosp();
        rcbHosp.DataTextField = "hospname";
        rcbHosp.DataValueField = "hospcode";
        rcbHosp.DataSource = hosplist;
        rcbHosp.DataBind();
    }

    private void BindDept()
    {
        try
        {
            List<V_departmentDto> list = service.GetDepts(rcbHosp.SelectedValue);
            ViewState[this.ID + "DeptList"] = list;
            if (WithEmptyDept)
            {
                V_departmentDto nullitem = new V_departmentDto();
                nullitem.Deptcode = "";
                nullitem.Deptname = EmptyDeptName;
                nullitem.Hospcode = rcbHosp.SelectedValue;
                nullitem.Hospname = rcbHosp.Text;
                list.Insert(0, nullitem);
            }
            ddlUnit.DataValueField = "deptcode";
            ddlUnit.DataTextField = "DisplayName";
            ddlUnit.DataSource = list;
            if(list.Count(c=> c.Deptcode == ddlUnit.SelectedValue)==0)
            {
                ddlUnit.SelectedValue = "";
            }
            ddlUnit.DataBind();
        }
        catch
        {

        }
        
    }
}