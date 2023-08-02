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
    //院區
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
    //部門
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
    //成員
    private string _deptTeacherName = "";
    public string DeptTeacherName
    {
        get
        {
            return _deptTeacherName;
        }
        set
        {
            _deptTeacherName = value;
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

    public V_departmentDto SelectDept
    {
        get
        {
            if (ViewState[this.ID + "DeptList"] != null)
            {
                if (rCBDept.SelectedValue != null && rCBDept.SelectedValue != "")
                {

                    List<V_departmentDto> list = ViewState[this.ID + "DeptList"] as List<V_departmentDto>;
                    V_departmentDto dep = list.Where(c => c.Deptcode == rCBDept.SelectedValue && c.Hospcode == rCBDept.SelectedValue).FirstOrDefault();
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
        rCBDept.SelectedValue = "";
    }

    public void Select(string hospcode, string deptcode)
    {
        rCBHosp.SelectedValue = hospcode;
        BindDept();
        rCBDept.SelectedValue = deptcode;
    }

    private void BindHosp()
    {
        List<HospDto> hosplist = service.GetHosp();
        rCBHosp.DataTextField = "hospname";
        rCBHosp.DataValueField = "hospcode";
        rCBHosp.DataSource = hosplist;
        rCBHosp.DataBind();
    }

    private void BindDept()
    {
        List<V_departmentDto> list = service.GetDepts(rCBHosp.SelectedValue);
        ViewState[this.ID + "DeptList"] = list;
        if (WithEmptyDept)
        {
            V_departmentDto nullitem = new V_departmentDto();
            nullitem.Deptcode = "";
            nullitem.Deptname = EmptyDeptName;
            nullitem.Hospcode = rCBHosp.SelectedValue;
            nullitem.Hospname = rCBHosp.Text;
            list.Insert(0, nullitem);
        }
        rCBDept.DataValueField = "deptcode";
        rCBDept.DataTextField = "DisplayName";
        rCBDept.DataSource = list;
        rCBDept.DataBind();

    }

    protected void rCBDept_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {

    }
}