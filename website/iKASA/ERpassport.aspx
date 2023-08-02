<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="ERpassport.aspx.cs" Inherits="iKASA_ERpassport" %>

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

    <script>
        function ReturnPage()
        {
            var multiPage = $find("<%=rmp.ClientID %>");
            multiPage.set_selectedIndex(1);
            
        }
    </script>
    <form id="form1" runat="server">
    
        <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
        </telerik:RadScriptManager>
    
        <telerik:RadMultiPage ID="rmp" Runat="server" Width="95%">
            <telerik:RadPageView ID="rpvList" runat="server">

                <asp:Panel ID="panCount" runat="server" GroupingText="統計資訊">
                    <table width="98%" style="border:1px solid #000; border-collapse:collapse;">
                        <tr>
                            <th style="  background-color: #009FCC;padding:3px;border:1px solid #000;color:#fff;"></th>
                            <th style="  background-color: #009FCC;padding:3px;border:1px solid #000;color:#fff;">急診內科</th>
                            <th style="  background-color: #009FCC;padding:3px;border:1px solid #000;color:#fff;">急診外傷科</th>
                            <th style="  background-color: #009FCC;padding:3px;border:1px solid #000;color:#fff;">急診兒科</th>
                            <th style="  background-color: #009FCC;padding:3px;border:1px solid #000;color:#fff;">總數</th>
                        </tr>
                        <tr>
                            <td style="  text-align:left;border:1px solid #000; padding:2px;">需求例數</td>
                            <td style="  text-align:right;border:1px solid #000; padding:2px;">
                                <asp:Label ID="lbReq0100" runat="server" Text="N/A"></asp:Label>
                            </td>
                            <td style="  text-align:right;border:1px solid #000; padding:2px;">
                                <asp:Label ID="lbReq0200" runat="server">500</asp:Label>
                            </td>
                            <td style="  text-align:right;border:1px solid #000; padding:2px;">
                                <asp:Label ID="lbReq0300" runat="server">250</asp:Label>
                            </td>
                            <td style="  text-align:right;border:1px solid #000; padding:2px;">
                                <asp:Label ID="lbReqAll" runat="server">5000</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="  text-align:left;border:1px solid #000; padding:2px;">已完成例數</td>
                            <td style="  text-align:right;border:1px solid #000; padding:2px;">
                                <asp:Label ID="lbCount0100" runat="server"></asp:Label>
                            </td>
                            <td style="  text-align:right;border:1px solid #000; padding:2px;">
                                <asp:Label ID="lbCount0200" runat="server"></asp:Label>
                            </td>
                            <td style="  text-align:right;border:1px solid #000; padding:2px;">
                                <asp:Label ID="lbCount0300" runat="server"></asp:Label>
                            </td>
                            <td style="  text-align:right;border:1px solid #000; padding:2px;">
                                <asp:Label ID="lbCountAll" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Button ID="btnToGet" runat="server" OnClick="btnToGet_Click" Text="進入收案畫面" />
                <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="全部匯出" />
                <asp:Button ID="btnSaveAll" runat="server" Text="全部儲存" OnClick="btnSaveAll_Click" />
                <asp:Button ID="btnDelAll" runat="server" ForeColor="Red" Text="刪除所有選取案例" OnClientClick="if(!confirm('刪除後無法恢復僅可重新收案，確定刪除選取資料?')) return false;" OnClick="btnDelAll_Click" />
                <br />
                <asp:Label ID="Label3" runat="server" Text="選擇匯入檔案："></asp:Label>
                <asp:FileUpload ID="fuImport" runat="server" />
                <asp:Button ID="btnImport" runat="server" OnClick="btnImport_Click" Text="匯入" />
                <br />
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/docs/病歷資料匯入.xlsx">下載範例</asp:HyperLink>
                <asp:Label ID="Label17" runat="server" Font-Bold="True" ForeColor="Red" Text="*範例檔第一行欄位名稱請勿刪除或修改"></asp:Label>
                <br />
                <asp:Label ID="lbMsg" runat="server"></asp:Label>
                <telerik:RadGrid ID="RadGrid3" runat="server" AllowMultiRowSelection="True" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None" OnNeedDataSource="RadGrid3_NeedDataSource" OnDeleteCommand="RadGrid3_DeleteCommand" OnUpdateCommand="RadGrid3_UpdateCommand" OnItemCommand="RadGrid3_ItemCommand" OnItemDataBound="RadGrid3_ItemDataBound" AllowPaging="True">
                    <ClientSettings>
                        <Selecting AllowRowSelect="True" />
                    </ClientSettings>
                    <MasterTableView DataKeyNames="ID">
                        <Columns>
                            <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" UniqueName="column">
                            </telerik:GridClientSelectColumn>
                            <telerik:GridBoundColumn DataField="IN_DATE" FilterControlAltText="Filter ENTER_DATE column" HeaderText="日期" UniqueName="IN_DATE" DataFormatString="{0:yyyy/MM/dd}">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DEPT_NAME" FilterControlAltText="Filter DEPT_NAME column" HeaderText="科別" UniqueName="DEPT_NAME">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CHART_NO" FilterControlAltText="Filter CHARTNO column" HeaderText="病歷號" UniqueName="CHART_NO">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DISEASE_CLASS" FilterControlAltText="Filter DISEASE_CLASS column" HeaderText="檢傷級數" UniqueName="DISEASE_CLASS">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="icd_code" FilterControlAltText="Filter icd_code column" HeaderText="診斷碼" UniqueName="icd_code" Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn DataField="icd_Name" HeaderText="診斷" UniqueName="icd_name">
                                <ItemTemplate>
                                    
                                    <asp:TextBox ID="tbICDName" Wrap="true" TextMode="MultiLine" runat="server" Columns="30" Height="40px"></asp:TextBox>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="procedure" FilterControlAltText="Filter procedure column" HeaderText="procedure" UniqueName="procedure">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlProcedure" runat="server" >
                                        <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="Endo">Endo</asp:ListItem>
                                            <asp:ListItem Value="CVC">CVC</asp:ListItem>
                                            <asp:ListItem Value="chest tube">chest tube</asp:ListItem>
                                            <asp:ListItem Value="Pig Tail">Pig Tail</asp:ListItem>
                                            <asp:ListItem Value="Lumbar puncture">Lumbar puncture</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            
                            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn1 column" UniqueName="TemplateColumn1">
                                <ItemTemplate>
                                    <asp:Button ID="btnSave" runat="server" Text="儲存" CommandName="SaveChange" />
                                    <asp:Button ID="btnSubmitDOPS" runat="server" Text="DOPS" CommandName="SubmitItemDOPS" />
                                    <asp:Button ID="btnSubmitEPA" runat="server" Text="EPA" CommandName="SubmitItemEPA" />
                                    <asp:Button ID="btnDelete" runat="server" Text="刪除" OnClientClick="if(!confirm('刪除後無法恢復僅可重新收案，確定刪除本筆資料?')) return false;" CommandName="Delete" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            
                        </Columns>
                        
                    </MasterTableView>
                    
                </telerik:RadGrid>

            </telerik:RadPageView>
            <telerik:RadPageView ID="rpvSearch" runat="server" Visible="False">
                <asp:Button ID="btnToList" runat="server" OnClick="btnToList_Click" Text="回清單" />
                <br />
                <asp:Label ID="Label1" runat="server" Text="病摘記錄時間："></asp:Label>
                <telerik:RadDatePicker ID="rdpSdate" Runat="server">
                </telerik:RadDatePicker>
                <telerik:RadDatePicker ID="rdpEdate" Runat="server">
                </telerik:RadDatePicker>
                <asp:Button ID="btnQuery" runat="server" OnClick="btnQuery_Click" Text="搜尋" />
                <br />
                <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None" AllowMultiRowSelection="True">
                    <ClientSettings>
                        <Selecting AllowRowSelect="True" />
                    </ClientSettings>
                    <MasterTableView DataKeyNames="SERIALNO">
                        <Columns>
                            <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" UniqueName="column">
                            </telerik:GridClientSelectColumn>
                            <telerik:GridBoundColumn DataField="CHARTNO" FilterControlAltText="Filter CHARTNO column" HeaderText="病歷號" UniqueName="CHARTNO">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="NOTE_DATE" FilterControlAltText="Filter NOTE_DATE column" HeaderText="病摘日期" UniqueName="NOTE_DATE">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CREATE_DATE" FilterControlAltText="Filter CREATE_DATE column" HeaderText="建立日期" UniqueName="CREATE_DATE">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DEPT_NAME" FilterControlAltText="Filter DEPT_NAME column" HeaderText="科別" UniqueName="DEPT_NAME">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" UniqueName="TemplateColumn">
                                <ItemTemplate>
                                    <asp:Button ID="btnShowDetail" runat="server" Text="檢視內容" OnClick="btnShowDetail_Click" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </telerik:RadPageView>
            <telerik:RadPageView ID="rpvDetail" runat="server" Visible="False">
                <asp:Button ID="btnReturn" runat="server" Text="回上一頁" OnClientClick="ReturnPage();return false;" />
                <br />
                <asp:Literal ID="liDetail" runat="server"></asp:Literal>
            </telerik:RadPageView>
            <telerik:RadPageView ID="rpvERSearch" runat="server">
                <asp:Button ID="btnToList0" runat="server" OnClick="btnToList_Click" Text="回清單" />
                <br />
                <asp:Label ID="Label2" runat="server" Text="記錄時間："></asp:Label>
                <telerik:RadDatePicker ID="rdpSdate0" Runat="server">
                </telerik:RadDatePicker>
                <telerik:RadDatePicker ID="rdpEdate0" Runat="server">
                </telerik:RadDatePicker>
                <asp:Label ID="Label18" runat="server" Text="病歷號："></asp:Label>
                <asp:TextBox ID="tbChartNo" runat="server"></asp:TextBox>
                <asp:Button ID="btnQuery0" runat="server" OnClick="btnQuery0_Click" Text="搜尋" />
                <br />
                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="選取項目收案" />
                <telerik:RadGrid ID="RadGrid2" runat="server" AllowMultiRowSelection="True" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None">
                    <ClientSettings>
                        <Selecting AllowRowSelect="True" />
                    </ClientSettings>
                    <MasterTableView DataKeyNames="SERIALNO">
                        <Columns>
                            <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" UniqueName="column">
                            </telerik:GridClientSelectColumn>
                            <telerik:GridBoundColumn DataField="ENTER_DATE" FilterControlAltText="Filter ENTER_DATE column" HeaderText="日期" UniqueName="ENTER_DATE">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="noon_no" FilterControlAltText="Filter noon_no column" HeaderText="午別" UniqueName="noon_no" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DEPT_NAME" FilterControlAltText="Filter DEPT_NAME column" HeaderText="科別" UniqueName="DEPT_NAME">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CHART_NO" FilterControlAltText="Filter CHARTNO column" HeaderText="病歷號" UniqueName="CHART_NO">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PATIENT_NAME" FilterControlAltText="Filter PATIENT_NAME column" HeaderText="姓名" UniqueName="PATIENT_NAME">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DISEASE_CLASS" FilterControlAltText="Filter DISEASE_CLASS column" HeaderText="檢傷及數" UniqueName="DISEASE_CLASS">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="icd_code" FilterControlAltText="Filter icd_code column" HeaderText="診斷碼" UniqueName="icd_code" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="chinese_name" FilterControlAltText="Filter chinese_name column" HeaderText="診斷" UniqueName="chinese_name">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="procedure" UniqueName="TemplateColumn">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlProcedure" runat="server" >
                                        <asp:ListItem Value=""></asp:ListItem>
                    <asp:ListItem Value="Endo">Endo</asp:ListItem>
                    <asp:ListItem Value="CVC">CVC</asp:ListItem>
                    <asp:ListItem Value="chest tube">chest tube</asp:ListItem>
                    <asp:ListItem Value="Pig Tail">Pig Tail</asp:ListItem>
                    <asp:ListItem Value="Lumbar puncture">Lumbar puncture</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
                
                <br />
            </telerik:RadPageView>
        </telerik:RadMultiPage>
    </form>
</body>
</html>
