<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EduTermEdit.aspx.cs" Inherits="EduTermEdit" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<%@ Register src="VsSelector.ascx" tagname="VsSelector" tagprefix="uc1" %>

<%@ Register src="TreeViewComboBox.ascx" tagname="TreeViewComboBox" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 116px;
        }
    </style>
</head>
<body>
<script type="text/javascript">
    function GetRadWindow() {
        var oWindow = null;
        if (window.radWindow) oWindow = window.radWindow;
        else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
        return oWindow;
    }

    function CloseWindow(bool) {
        var oArg = new Object();
        oArg.NeedRefresh = bool;
        var oWnd = GetRadWindow();
        oWnd.close(oArg);
    }

</script>

    <form id="form1" runat="server">
    <div>
    <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
    </telerik:RadScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td class="style1" align="right">
                            <asp:Label ID="Label11" runat="server" Text="學年度："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="tbEduYear" runat="server" MaxLength="3"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1" align="right">
                            <asp:Label ID="Label12" runat="server" Text="職稱："></asp:Label>
                        </td>
                        <td>

                            <uc1:TreeViewComboBox ID="TreeViewComboBox1" runat="server" 
                                AllowSelectParent="False" AutoPostBack="False" Enabled="True" 
                                TreeDataFieldID="code" TreeDataFieldParentID="ParentCodeRefID" 
                                TreeDataSourceID="dsJobCode" TreeDataTextField="Name" />

                        </td>
                    </tr>
                    <tr>
                        <td class="style1" align="right">
                            <asp:Label ID="Label13" runat="server" Text="院區："></asp:Label>
                        </td>
                        <td>

                            <telerik:RadComboBox ID="ddlHospital" Runat="server" DataSourceID="dsHospital" 
                                DataTextField="name" DataValueField="code" Filter="Contains">
                            </telerik:RadComboBox>

                        </td>
                    </tr>
                    <tr>
                        <td class="style1" align="right">
                            <asp:Label ID="Label14" runat="server" Text="部門："></asp:Label>
                        </td>
                        <td>
  
                            <telerik:RadComboBox ID="ddlDepartment" Runat="server" Filter="Contains">
                            </telerik:RadComboBox>
  
                        </td>
                    </tr>

                    <tr>
                        <td class="style1" align="right">
                            <asp:Label ID="Label1" runat="server" Text="課程代碼：" Visible="False"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="tbEduStopCode" runat="server" Visible="False"></asp:TextBox>
                            &nbsp;<asp:HyperLink ID="HyperLink1" Visible="False" runat="server" 
                                NavigateUrl="~/DepartmentQuery.aspx" Target="_blank">單位代碼表</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1" align="right">
                            <asp:Label ID="Label2" runat="server" Text="名稱："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1" align="right">
                            <asp:Label ID="Label3" runat="server" Text="課程日期："></asp:Label>
                        </td>
                        <td>
                        <table>
                        <tr>
                        <td><telerik:RadDatePicker ID="rdpDateFrom" Runat="server"></telerik:RadDatePicker></td>
                        <td>~</td>
                        <td><telerik:RadDatePicker ID="rdpDateTo" Runat="server"></telerik:RadDatePicker></td>
                        </tr>
                        </table>
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="style1" align="right">
                            <asp:Label ID="Label4" runat="server" Text="歸屬類別："></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rblType" runat="server" 
            RepeatDirection="Horizontal" 
            onselectedindexchanged="rblType_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem Selected="True">科別</asp:ListItem>
                                <asp:ListItem>護士站</asp:ListItem>
                                <asp:ListItem>醫師</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1" align="right">
                            <asp:Label ID="Label5" runat="server" Text="單位/VS："></asp:Label>
                        </td>
                        <td>
                        <asp:UpdatePanel ID="upVS" runat="server">
                        <ContentTemplate>
                        <uc1:VsSelector ID="rcbVS" runat="server" />
                        </ContentTemplate>
                        </asp:UpdatePanel>
                            
                            <div runat="server" id="divUnit">
                                <telerik:RadComboBox ID="ddlUnit" Runat="server" Filter="Contains">
                                </telerik:RadComboBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1" align="right">
                            <asp:Label ID="Label8" runat="server" Text="科導師："></asp:Label>
                        </td>
                        <td>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                        <uc1:VsSelector ID="rcbTeacher" runat="server" />
                        </ContentTemplate>
                        </asp:UpdatePanel>
                            
                        </td>
                    </tr>
                   <tr>
                        <td class="style1" align="right">
                            <asp:Label ID="Label10" runat="server" Text="總醫師："></asp:Label>
                        </td>
                        <td>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                        <uc1:VsSelector ID="rcbCR" runat="server" />
                        </ContentTemplate>
                        </asp:UpdatePanel>
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="style1" align="right">
                            <asp:Label ID="Label9" runat="server" Text="EBM窗口老師："></asp:Label>
                        </td>
                        <td>
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                        <uc1:VsSelector ID="rcbEBM" runat="server" />
                        </ContentTemplate>
                        </asp:UpdatePanel>
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="style1" align="right">
                            <asp:Label ID="Label17" runat="server" Text="計劃主持人："></asp:Label>
                        </td>
                        <td>
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                        <uc1:VsSelector ID="rcbProjM" runat="server" />
                        </ContentTemplate>
                        </asp:UpdatePanel>
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="style1" align="right">
                            <asp:Label ID="Label18" runat="server" Text="教學長："></asp:Label>
                        </td>
                        <td>
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                        <uc1:VsSelector ID="rcbTMaster" runat="server" />
                        </ContentTemplate>
                        </asp:UpdatePanel>
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="style1" align="right">
                            <asp:Label ID="Label19" runat="server" Text="護理長："></asp:Label>
                        </td>
                        <td>
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                        <ContentTemplate>
                        <uc1:VsSelector ID="rcbNurseD" runat="server" />
                        </ContentTemplate>
                        </asp:UpdatePanel>
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="style1" align="right">
                            <asp:Label ID="Label6" runat="server" Text="人數："></asp:Label>
                        </td>
                        <td>
                            <telerik:RadNumericTextBox ID="rntbStudentCount" Runat="server" Height="21px" 
            Width="49px">
                                <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                            </telerik:RadNumericTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1" align="right">
                            <asp:Label ID="Label7" runat="server" Text="說明："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="tbDes" runat="server" Width="336px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1" align="right">
                            <asp:Label ID="Label15" runat="server" Text="醫學系開課序號："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="tbSchoolSeq1" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1" align="right">
                            <asp:Label ID="Label16" runat="server" Text="後醫系開課序號："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="tbSchoolSeq2" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1" align="right">
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style1" align="right">
                        </td>
                        <td>
                            <asp:Button ID="btnSubmit" runat="server" Text="儲存" Width="60px" 
            onclick="btnSubmit_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="取消" Width="54px" 
            onclientclick="CloseWindow(false);" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnSubmit" />
            </Triggers>
        </asp:UpdatePanel>
    </div>

    <asp:ObjectDataSource ID="dsJobCode" runat="server" SelectMethod="GetCodeRefsStatic" 
        TypeName="KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService" 
        DataObjectTypeName="KMU.EduActivity.ApplicationLayer.DTO.V_CodeRefDto" 
        onselected="dsJobCode_Selected">
        <SelectParameters>
            <asp:Parameter DefaultValue="EduAct_JobSerial" Name="codetype" />
        </SelectParameters>
    </asp:ObjectDataSource>
    
    <asp:ObjectDataSource ID="dsHospital" runat="server" SelectMethod="GetCodeRefsStatic" 
        TypeName="KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService" 
        DataObjectTypeName="KMU.EduActivity.ApplicationLayer.DTO.V_CodeRefDto">
        <SelectParameters>
            <asp:Parameter DefaultValue="EduAct_Hospital" Name="codetype" />
        </SelectParameters>
    </asp:ObjectDataSource>
    
    </form>
</body>
</html>
