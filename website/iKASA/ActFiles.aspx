<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ActFiles.aspx.cs" Inherits="iKASA_ActFiles" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<%@ Register src="~/DeptSelector.ascx" tagname="DeptSelector" tagprefix="uc3" %>

<%@ Register src="~/VsSelector.ascx" tagname="VsSelector" tagprefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

        <script src="//code.jquery.com/jquery-1.10.2.js"></script>
</head>
<body>

    <script>
        function deletefile(fileid) {
            $('#<%=hdFileID.ClientID %>').val(fileid);
            __doPostBack('lbPostBack', '');
        }

    </script>

<style>
body{
    font-family:微軟正黑體!important;
}

table { 
  border:1px solid #000; 
  border-collapse:collapse;
} 
th { 
  background-color: #009FCC;
  padding:3px;
  border:1px solid #000;
  color:#fff;
} 

td { 
    text-align:center;
  border:1px solid #000;
  padding:2px;
} 

</style>


    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js">
                </asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>

                    <asp:LinkButton ID="lbPostBack" runat="server" OnClick="lbPostBack_Click"></asp:LinkButton>
                    <asp:HiddenField ID="hdFileID" runat="server" />

        <asp:Panel ID="panAdmin" runat="server" GroupingText="新增檔案">
            <asp:Label ID="Label1" runat="server" Text="標題："></asp:Label>
            <asp:TextBox ID="tbTitle" runat="server" Width="202px"></asp:TextBox>
            <asp:Label ID="Label4" runat="server" Text="日期："></asp:Label>
            <telerik:RadDatePicker ID="rdpActDate" Runat="server">
            </telerik:RadDatePicker>
            <br />
            <asp:Label ID="Label2" runat="server" Text="說明："></asp:Label>
            <asp:TextBox ID="tbDescription" runat="server" Width="402px"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="選擇檔案："></asp:Label>
            <asp:FileUpload ID="fu_file" runat="server" />
            <br />
            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="新增" />
        </asp:Panel>

        <div>
            <table width="100%">
                <tr>
                    <td>
                        <div id="htmlContent">



                            <asp:Literal ID="liContent" runat="server"></asp:Literal>



                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
