<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JobFormEdit.aspx.cs" Inherits="JobFormEdit" %>

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
                            <asp:Label ID="Label13" runat="server" Text="表單："></asp:Label>
                        </td>
                        <td>

                            <telerik:RadComboBox ID="cbTemplate" Runat="server" Width="400px">
                            </telerik:RadComboBox>

                        </td>
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
        DataObjectTypeName="KMU.EduActivity.ApplicationLayer.DTO.V_CodeRefDto" >
        <SelectParameters>
            <asp:Parameter DefaultValue="EduAct_JobSerial" Name="codetype" />
        </SelectParameters>
    </asp:ObjectDataSource>
    
    </form>
</body>
</html>
