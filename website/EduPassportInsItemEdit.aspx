<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EduPassportInsItemEdit.aspx.cs" Inherits="EduPassportInsItemEdit" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<%@ Register src="UserControls/EduPassportInsItemControl.ascx" tagname="EduPassportInsItemControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}
    .RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}
    .RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Blue" Text="護照名稱："></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbPassportName" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Blue"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Blue" Text="項目："></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbItemName" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Blue"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Blue" Text="項目說明："></asp:Label>
                </td>
                <td>

                    <asp:Literal ID="liDesc" runat="server"></asp:Literal>

                </td>
            </tr>
        </table>
        
        
    </div>
    <div>
        <asp:Panel ID="panDisplayTeacher" runat="server">
            <div>
            <asp:Label ID="Label8" runat="server" Text="送審時間："></asp:Label>
            <asp:Label ID="lbSubmitTime" runat="server"></asp:Label>
            </div>

            <div>
            <asp:Label ID="Label4" runat="server" Text="審核老師："></asp:Label>
            <asp:Label ID="lbTeacherName" runat="server"></asp:Label>
                </div>
            <div>
            <asp:Label ID="Label5" runat="server" Text="目前狀態："></asp:Label>
            <asp:Label ID="lbCurrentStatus" runat="server"></asp:Label>
            </div>
            <div>
            <asp:Label ID="Label9" runat="server" Text="審核日期："></asp:Label>
            <asp:Label ID="lbModifyDate" runat="server"></asp:Label>
            </div>
        </asp:Panel>
    </div>
    <div>
        <asp:Panel ID="panSelectTeacher" runat="server">
            <asp:Label ID="Label3" runat="server" Text="審核老師："></asp:Label>
            <telerik:RadComboBox ID="rCBHosp" runat="server" AutoPostBack="True" Culture="zh-TW" DataSourceID="SqlDataSource1" DataTextField="hospname" DataValueField="hospcode" MarkFirstMatch="True" Skin="Sunset">
            </telerik:RadComboBox>
            <telerik:RadComboBox ID="rCBTeacherName" runat="server" Culture="zh-TW" Skin="Sunset" DataSourceID="dsHigher" MarkFirstMatch="True" AllowCustomText="True" DataTextField="displayItem" DataValueField="empcode" Filter="Contains" Width="300px">
            </telerik:RadComboBox>
            &nbsp;<asp:CheckBox ID="cbAdminConfirm" runat="server" Text="由臨教部審核" Visible="False" />
        </asp:Panel>
    </div>
    <table width="98%">
        <tr>
            <td>
    <div>
                <uc1:EduPassportInsItemControl ID="EditContrlS" runat="server" DisplayOnly="False" />
    </div>
    <div>

                <uc1:EduPassportInsItemControl ID="EditContrlT" runat="server" DisplayOnly="False" />

    </div>
    <div>
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnPreSave" runat="server" Text="暫存" />
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="送出" />
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="取消送出" />
                </td>
                <td>
                    <asp:Panel ID="panReject" runat="server">
                        
                        <asp:Label ID="Label6" runat="server" Text="駁回理由："></asp:Label>
                        <asp:TextBox ID="tbRejectReason" runat="server" Width="182px"></asp:TextBox>
                        <asp:Button ID="btnReject" runat="server" OnClick="tbReject_Click" Text="駁回" />
                    </asp:Panel>
                </td>
                <td>
                    
                    <asp:Button ID="btnExit" runat="server" OnClick="btnExit_Click" Text="回上一頁" />
                </td>
            </tr>
        </table>

    </div>
            </td>
            <td align="right" valign="top">

                <asp:Panel ID="panRejectHistory" runat="server" Visible="false">
                    <table width="100%">
                        <tr>
                            <td align="center" style="background-color:blue; color:white">
                                <b>駁回紀錄</b>
                            </td>
                        </tr>
                        <tr>
                            <td>

                                <telerik:RadGrid ID="rgRejectReason" runat="server" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None">
                                    <MasterTableView>
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="RejectTime" FilterControlAltText="Filter RejectTime column" HeaderText="駁回時間" UniqueName="RejectTime">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="EmpName" FilterControlAltText="Filter EmpName column" HeaderText="駁回者" UniqueName="EmpName">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Reason" FilterControlAltText="Filter Reason column" HeaderText="駁回原因" UniqueName="Reason">
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>

                            </td>
                        </tr>
                    </table>
                </asp:Panel>

            </td>
        </tr>
    </table>

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dsEduActivity %>" SelectCommand="SELECT DISTINCT [hospname], [hospcode] FROM [V_KmuEmp]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="dsHigher" runat="server" ConnectionString="<%$ ConnectionStrings:dsEduActivity %>" SelectCommand="SELECT DISTINCT a.empcode + a.empname+ '('+isnull(c.deptname,'')+')' AS displayItem, a.empcode 
FROM V_KmuEmp a left join v_kmujob j on a.jobcode = j.job_code_x left join v_departments c on c.hospcode = a.hospcode and c.deptcode = a.loccode WHERE 
((a.hospcode = @hospcode) and j.JOB_KIND in ('1','3','4') 
                    --and (a.NONORG_ID in ('1','5','6') or a.nonorg_id is null ) 
                    AND (a.enddate IS NULL OR a.enddate &gt;= GETDATE())
AND (a.jobcode IN (select TitleCode from PassPortDocGrade where Grade &gt; 
isnull((select Grade from PassPortDocGrade where TitleCode = @jobocde),0) ) or (not exists (select * from PassPortDocGrade where TitleCode = @jobocde) and j.JOB_KIND in ('1','4') ) )  ) 
or a.empcode in ('900197')">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="rCBHosp" Name="hospcode" PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter ControlID="hfJobCode" Name="jobocde" PropertyName="Value" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:HiddenField ID="hfJobCode" runat="server" />
            </asp:Content>

