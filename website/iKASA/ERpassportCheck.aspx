<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="ERpassportCheck.aspx.cs" Inherits="iKASA_ERpassportCheck" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <script src="//code.jquery.com/jquery-1.10.2.js"></script>

  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
  <link rel="stylesheet" href="/resources/demos/style.css" />
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
</head>
<body style="height:400px">
    <style>
body{
    font-family:微軟正黑體!important;
}
    </style>

    <form id="form1" runat="server">
    
        <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
        </telerik:RadScriptManager>
    
                <telerik:RadGrid ID="RadGrid3" runat="server" AllowMultiRowSelection="True" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None" OnNeedDataSource="RadGrid3_NeedDataSource" OnItemCommand="RadGrid3_ItemCommand">
                    <ClientSettings>
                        <Selecting AllowRowSelect="True" />
                    </ClientSettings>
                    <MasterTableView DataKeyNames="ID,EvalID">
                        <Columns>
                            <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" UniqueName="column">
                            </telerik:GridClientSelectColumn>
                            <telerik:GridBoundColumn DataField="EmpName" FilterControlAltText="Filter EmpName column" HeaderText="送審者" UniqueName="EmpName">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="EvalType" FilterControlAltText="Filter EvalType column" HeaderText="類別" UniqueName="EvalType">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="IN_DATE" FilterControlAltText="Filter ENTER_DATE column" HeaderText="日期" UniqueName="IN_DATE" DataFormatString="{0:yyyy/MM/dd}">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DEPT_NAME" FilterControlAltText="Filter DEPT_NAME column" HeaderText="科別" UniqueName="DEPT_NAME">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CHART_NO" FilterControlAltText="Filter CHARTNO column" HeaderText="病歷號" UniqueName="CHART_NO">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DISEASE_CLASS" FilterControlAltText="Filter DISEASE_CLASS column" HeaderText="檢傷級數" UniqueName="DISEASE_CLASS">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="icd_name" FilterControlAltText="Filter icd_name column" HeaderText="診斷" UniqueName="icd_name">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="procedure" FilterControlAltText="Filter procedure column" HeaderText="procedure" UniqueName="procedure">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn UniqueName="TemplateColumn1" FilterControlAltText="Filter TemplateColumn1 column">
                                <ItemTemplate>
                                    <asp:Button ID="btnSubmit" runat="server" Text="審核" CommandName="SubmitItem" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            
                        </Columns>
                        
                    </MasterTableView>
                    
                </telerik:RadGrid>

    </form>
</body>
</html>
