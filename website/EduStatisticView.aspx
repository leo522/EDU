<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EduStatisticView.aspx.cs" Inherits="EduStatisticView" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>


<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=7.2.13.1016, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
.RadGrid_Default{border:1px solid #828282;background-color:white;color:#333;font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid_Default{border:1px solid #828282;background-color:white;color:#333;font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid_Default .rgMasterTable{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid_Default .rgMasterTable{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid table.rgMasterTable tr .rgExpandCol{padding-left:0;padding-right:0;text-align:center}.RadGrid table.rgMasterTable tr .rgExpandCol{padding-left:0;padding-right:0;text-align:center}.RadGrid_Default .rgHeader{color:#333}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{cursor:default}.RadGrid_Default .rgHeader{color:#333}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{cursor:default}
    .RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <script>
    function post_to_url(path, params, method) {
        method = method || "post"; // Set method to post by default, if not specified.

        // The rest of this code assumes you are not using a library.
        // It can be made less wordy if you use one.
        var form = document.createElement("form");
        form.setAttribute("method", method);
        form.setAttribute("action", path);

        for (var key in params) {
            var hiddenField = document.createElement("input");
            hiddenField.setAttribute("type", "hidden");
            hiddenField.setAttribute("name", key);
            hiddenField.setAttribute("value", params[key]);

            form.appendChild(hiddenField);
        }

        document.body.appendChild(form);    // Not entirely sure if this is necessary
        form.submit();
    }

</script>
    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" 
            SelectedIndex="0" Skin="WebBlue" Visible="False">
        <Tabs>
            <telerik:RadTab runat="server" PageViewID="RadPageView1" Selected="True" 
                Text="表單發送清單">
            </telerik:RadTab>
            <telerik:RadTab runat="server" PageViewID="RadPageView2" Text="明細">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <telerik:RadMultiPage ID="RadMultiPage1" Runat="server" BorderColor="Black" 
            BorderStyle="Solid" BorderWidth="1px" SelectedIndex="0" Width="100%">
        <telerik:RadPageView ID="RadPageView1" runat="server" Selected="True">
    <table>
        <tr>
            <td>
        <asp:Label ID="Label5" runat="server" Text="職稱："></asp:Label>
                </td>
            <td>
                    <telerik:RadDropDownTree ID="rddtJobCode" runat="server" DataFieldID="Code" DataFieldParentID="ParentCodeRefid" DataSourceID="dsJobCode" DataTextField="name" DataValueField="code" CheckBoxes="CheckChildNodes">
                    </telerik:RadDropDownTree>
                </td>
            <td>
                <asp:Label ID="Label31" runat="server" Text="院區："></asp:Label>
            </td>
            <td>
                <telerik:RadComboBox ID="ddlHospital" Runat="server" AllowCustomText="True" CheckBoxes="True" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:Label ID="Label29" runat="server" Text="部門："></asp:Label>
            </td>
            <td>
                <telerik:RadComboBox ID="ddlUnit" Runat="server" AllowCustomText="True" CheckBoxes="True" Filter="Contains">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="表單："></asp:Label>
            </td>
            <td>
                <telerik:RadComboBox ID="rcbTemplateID" Runat="server" Width="300px" CheckBoxes="True" EnableCheckAllItemsCheckBox="True" AllowCustomText="True" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td></td>
            <td>
                <asp:CheckBox ID="cbFinish" runat="server" Text="僅列出完成表單" />
            </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label30" runat="server" Text="時間："></asp:Label>
            </td>
            <td colspan="3">
                   <table>
                        <tr>
                            <td>                    <telerik:RadDatePicker ID="rdpSDate" Runat="server" Width="150px">
                    </telerik:RadDatePicker></td>
                            <td>~</td>
                            <td>                    <telerik:RadDatePicker ID="rdpEDate" Runat="server" Width="150px">
                    </telerik:RadDatePicker></td>
                        </tr>
                    </table>
            </td>
            <td></td>
            <td>
                <asp:Button ID="btnQuery" runat="server" onclick="btnQuery_Click" Text="查詢" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="4">
                <asp:Button ID="btnDepFinishRate" runat="server" OnClick="btnDepFinishRate_Click" Text="單位完成率統計" />
                <asp:CheckBox ID="cbSplit" runat="server" Text="分開統計完成率" />
                <asp:CheckBox ID="cbExpireOnly" runat="server" Text="僅統計逾期表單" />
            </td>

            <td>&nbsp;</td>
        </tr>
    </table>
            <asp:Panel ID="panList" runat="server" GroupingText="表單清單">
                <telerik:RadGrid ID="rgHistory" runat="server" 
                    AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None" 
                    onitemcreated="rgHistory_ItemCreated">
                    <ExportSettings>
                        <Pdf>
                            <PageHeader>
                                <LeftCell Text="" />
                                <MiddleCell Text="" />
                                <RightCell Text="" />
                            </PageHeader>
                            <PageFooter>
                                <LeftCell Text="" />
                                <MiddleCell Text="" />
                                <RightCell Text="" />
                            </PageFooter>
                        </Pdf>
                    </ExportSettings>
                    <ClientSettings>
                        <Selecting AllowRowSelect="True" />
                    </ClientSettings>
                    <MasterTableView DataKeyNames="TEMPLATE_ID,RootEduTermID">
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                            Visible="False">
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn Created="True" 
                            FilterControlAltText="Filter ExpandColumn column" Visible="True">
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" 
                                UniqueName="column">
                            </telerik:GridClientSelectColumn>
                            <telerik:GridHyperLinkColumn AllowSorting="False" 
                                DataNavigateUrlFields="EduTermDetailUrl" DataTextField="RootEduTermName" 
                                FilterControlAltText="Filter RootEduTermName column" 
                                UniqueName="RootEduTermName">
                            </telerik:GridHyperLinkColumn>
                            <telerik:GridBoundColumn DataField="TEMPLATE_NAME" 
                                FilterControlAltText="Filter TEMPLATE_NAME column" HeaderText="表單名稱" 
                                UniqueName="TEMPLATE_NAME">
                            </telerik:GridBoundColumn>
                            <telerik:GridDateTimeColumn DataField="ExecuteDate" 
                                FilterControlAltText="Filter ExecuteDate column" HeaderText="執行日期" 
                                UniqueName="ExecuteDate" Visible="False">
                            </telerik:GridDateTimeColumn>
                            <telerik:GridBoundColumn DataField="FinishRateStr" 
                                FilterControlAltText="Filter FinishRateStr column" HeaderText="完成比" 
                                UniqueName="FinishRateStr" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridHyperLinkColumn AllowSorting="False" 
                                DataNavigateUrlFields="CompleteDetailUrl" DataTextField="FinishRateStr" 
                                FilterControlAltText="Filter FinishRate column" HeaderText="完成比" 
                                Target="_blank" UniqueName="FinishRate">
                            </telerik:GridHyperLinkColumn>
                            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" 
                                UniqueName="Query">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnQuery" runat="server" OnClick="lbtnStatistic_Click" 
                                        Text="查詢統計"></asp:LinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" 
                                UniqueName="Download">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDownload" runat="server" OnClick="lbtnDownload_Click" 
                                        Text="下載已填表單"></asp:LinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                            </EditColumn>
                        </EditFormSettings>
                        <BatchEditingSettings EditType="Cell" />
                        <PagerStyle PageSizeControlType="RadComboBox" />
                    </MasterTableView>
                    <PagerStyle PageSizeControlType="RadComboBox" />
                    <FilterMenu EnableImageSprites="False">
                    </FilterMenu>
                </telerik:RadGrid>
            </asp:Panel>


            <asp:Label ID="lbEduTermID" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lbTemplateid" runat="server" Visible="False"></asp:Label>


</telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView2" runat="server" Selected="False">
        <div>
            <asp:BulletedList ID="BulletedList1" runat="server">
            </asp:BulletedList>
        </div>
            <div>

                <asp:Button ID="btnExport" runat="server" onclick="btnExport_Click" Text="匯出Excel" />

            </div>
        <div style="overflow:auto;">
        <telerik:RadGrid ID="rgDetailList" runat="server" 
                onneeddatasource="rgDetailList_NeedDataSource">
            </telerik:RadGrid>
            <br />
            <asp:ObjectDataSource ID="dsTermCode" runat="server" SelectMethod="GetEduTeams" 
                TypeName="KMU.EduActivity.ApplicationLayer.DTO.EduTeamDto">
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="dsJobCode" runat="server" DataObjectTypeName="KMU.EduActivity.ApplicationLayer.DTO.V_CodeRefDto" SelectMethod="GetCodeRefsStatic" TypeName="KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService">
                <SelectParameters>
                    <asp:Parameter DefaultValue="EduAct_JobSerial" Name="codetype" />
                </SelectParameters>
            </asp:ObjectDataSource>
         </div>
        </telerik:RadPageView>
</telerik:RadMultiPage>
</asp:Content>

