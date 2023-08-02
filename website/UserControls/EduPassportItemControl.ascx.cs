using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_EduPassportItemControl : System.Web.UI.UserControl
{
    private string _targetType = "";
    public string TargetType
    {
        get
        {
            return _targetType;
        }
        set
        {
            _targetType = value;
            RefreshControl();
        }
    }

    private bool _displayOnly = false;
    public bool DisplayOnly
    {
        get
        {
            return _displayOnly;
        }
        set
        {
            _displayOnly = value;
            RefreshControl();
        }
    }

    private List<EduPassportItemDetDto> _dataSource = null;
    public List<EduPassportItemDetDto> DataSource
    {
        get
        {
            return _dataSource;
        }
        set
        {
            _dataSource = value;
            RefreshControl();
        }
    }


    public void RefreshControl()
    {
        if (TargetType != "" && DataSource != null)
        {
            string html = "";

            html += "<table>";

            foreach (EduPassportItemDetDto dto in DataSource.Where(c => c.FieldTarget == TargetType))
            {
                html += "<tr>";
                
                html += "<td>" + dto.FieldDesc + "：</td>";
                html += "<td>";
                if (DisplayOnly)
                {

                }
                else
                {

                    string id = dto.ItemID + "_" + dto.ID.ToString();
                    switch(dto.FieldType)
                    {
                        case "單行":
                            html += "<input type='text' id='" + id + "' name='" + id + "' size='15'>";
                            break;
                        case "單行(數字)":
                            html += "<input type='text' id='" + id + "' name='" + id + "' size='15'  onkeyup='return onlyNum(this);' style='ime-mode:Disabled'>";
                            break;
                        case "日期":
                            html += "<input type='text' id='" + id + "' name='" + id + "' size='15'>";
                            html += "<img src=\"Images/t_calendar.gif\" alt=\"選擇日期\" onclick=\"displayDatePicker('" + id + "', false,'ymd','/');\" />";
                            break;
                        case "多行":
                            html += "<textarea cols='35' rows='3' id='" + id + "' name='" + id + "'></textarea>";
                            break;
                        case "單選":
                            html += "<select id='" + id + "' name='" + id + "'>";
                            string[] options = dto.SelectOptions.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (string opt in options)
                            {
                                html += "<option value='" + opt + "'>" + opt + "</option>";
                            }
                            html += "</select>";
                            break;
                        case "多選":
                            int itemcount = 0;
                            string[] optionsmulti = dto.SelectOptions.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (string opt in optionsmulti)
                            {
                                html += "<input type='checkbox' name='" + id + "' value='" + opt + "' />" + opt;
                                itemcount++;
                                if (itemcount == 4)
                                {
                                    html += "</br>";
                                    itemcount = 0;
                                }
                            }

                            break;
                        default:
                            html += "<input type='text' id='" + id + "' name='" + id + "' size='15'>";
                            break;

                    }
                    
                }
                html += "</td>";
                html += "</tr>";
            }

            html += "</table>";

            liContent.Text = html;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string onlyNumScript = @"
<script language=javascript>
function onlyNum(e)
{
    if (!/^\d+[.]?\d*$/.test(e.value))
    {
        e.value = /^\d+[.]?\d*/.exec(e.value);
        
    }
    return false;
}
</script>
";
            System.Web.UI.Page executingPage = HttpContext.Current.Handler as System.Web.UI.Page;
            ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType(), "onlyNum", onlyNumScript, false);
        }
    }
}