using KMU.EduActivity.ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_EduPassportInsItemControl : System.Web.UI.UserControl
{
    public bool DisplayOnly
    {
        get
        {
            return Convert.ToBoolean(ViewState[this.ClientID + "_DisplayOnly"]);
        }
        set
        {
            ViewState[this.ClientID + "_DisplayOnly"] = value;
            RefreshControl();
        }
    }

    private List<EduPassportInsItemDetDto> _dataSource = null;
    public List<EduPassportInsItemDetDto> DataSource
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

    
    public List<EduPassportInsItemDetDto> EditedData
    {
        get
        {
            return ViewState[this.ClientID + "_EditedData"] as List<EduPassportInsItemDetDto>;
        }
        set
        {
            ViewState[this.ClientID + "_EditedData"] = value;
        }

    }


    public void RefreshControl()
    {
        if (DataSource != null)
        {
            string html = "";

            html += "<table style=\"border-collapse: collapse; width: 580px; \" border=\"0\" bordercolor=\"#000000\" cellspacing=\"0\" cellpadding=\"0\">";

            EditedData = new List<EduPassportInsItemDetDto>();

            foreach (EduPassportInsItemDetDto dto in DataSource)//.Where(c => c.FieldTarget == TargetType))
            {
                html += "<tr style=\"border-bottom: 1px #C0C0C0 solid;\">";

                html += "<td width='50%'>" + dto.FieldDesc + "：</td>";
                html += "<td>";

                string readonlytext = "";
                if (DisplayOnly)
                {
                    //readonlytext = " readonly ";
                    html += dto.FieldValue;
                }
                else
                {

                    string id = dto.IItemID + "_" + dto.IITDetID.ToString();
                    string valuestr = dto.FieldValue;

                    

                    if (Request.Form[id] != null)
                    {
                        valuestr = Request.Form[id];
                        dto.FieldValue = valuestr;
                        EditedData.Add(dto);
                    }
                    switch(dto.FieldType)
                    {
                        case "單行":
                            html += "<input type='text' id='" + id + "' " + readonlytext + " value='" + valuestr + "' name='" + id + "' size='15'>";
                            break;
                        case "單行(數字)":
                            html += "<input type='text' id='" + id + "' " + readonlytext + " value='" + valuestr + "' name='" + id + "' size='15' onkeyup='return onlyNum(this);' style='ime-mode:Disabled'>";
                            break;

                        case "日期":
                            html += "<input type='text' id='" + id + "' " + readonlytext + " value='" + valuestr + "' onchange='checkInputDate(this);' name='" + id + "' size='15' style='ime-mode:Disabled'>";
                            html += "<img src=\"Images/t_calendar.gif\" alt=\"選擇日期\" onclick=\"displayDatePicker('" + id + "', false,'ymd','/');\" />";
                            break;
                        case "多行":
                            html += "<textarea cols='35' rows='3' " + readonlytext + " id='" + id + "' name='" + id + "'>" + valuestr + "</textarea>";
                            break;
                        case "單選":
                            html += "<select id='" + id + "' name='" + id + "' " + readonlytext + ">";
                            string[] options = dto.SelectOptions.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (string opt in options)
                            {
                                html += "<option value='" + opt + "'";
                                if(opt == valuestr)
                                {
                                    html += " selected ";
                                }
                                html += ">" + opt + "</option>";
                            }
                            html += "</select>";
                            break;
                        case "多選":
                            int itemcount = 0;
                            string[] optionsmulti = dto.SelectOptions.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                            string[] valuesmulti = new string[0];
                            if (valuestr != null)
                            {
                                valuesmulti = valuestr.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                            }
                            foreach (string opt in optionsmulti)
                            {
                                html += "<input type='checkbox' name='" + id + "' value='" + opt + "' ";
                                if(valuesmulti.Contains(opt))
                                {
                                    html += " checked ";
                                }
                                html += "/>" + opt;
                                itemcount++;
                                if (itemcount == 4)
                                {
                                    html += "</br>";
                                    itemcount = 0;
                                }
                            }
                            break;
                        default:
                            html += "<input type='text' id='" + id + "' " + readonlytext + " value='" + valuestr + "' name='" + id + "' size='15'>";
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

function checkInputDate(obj){
        if( !isValidDate($(obj).val()) ){
            alert('日期格式錯誤，請重新輸入！');
            $(obj).val('');
        }
}

function isValidDate(dateString){
        // First check for the pattern

        var regex_date = /^\d{4}\/\d{1,2}\/\d{1,2}$/;
        if(!regex_date.test(dateString)){
            return false;
        }
        
        // Parse the date parts to integers

        var parts   = dateString.split('/');
        var day     = parseInt(parts[2], 10);
        var month   = parseInt(parts[1], 10);
        var year    = parseInt(parts[0], 10);

        // Check the ranges of month and year

        if( (year < 1000) || (year > 3000) || (month == 0) || (month > 12) ){
            return false;
        }
        
        // Set dates for each month and adjust for leap years

        var monthLength = [ 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 ];
        if(year % 400 == 0 || (year % 100 != 0 && year % 4 == 0)){
            monthLength[1] = 29;
        }

        // Check the range of the day

        return day > 0 && day <= monthLength[month - 1];
}


</script>
";
            System.Web.UI.Page executingPage = HttpContext.Current.Handler as System.Web.UI.Page;
            ScriptManager.RegisterStartupScript(executingPage, executingPage.GetType(), "onlyNum", onlyNumScript, false);

            RefreshControl();
        }
    }
}