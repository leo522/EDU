<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PassPortForCheckPage.aspx.cs" Inherits="PassPortForCheckPage" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Src="DeptSelector.ascx" TagName="DeptSelector" TagPrefix="uc1" %>

<%@ Register Src="DeptSelectorForPassPort.ascx" TagName="DeptSelectorForPassPort" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .auto-style2 {
            font-weight: bold;
            font-size: medium;
        }

        .auto-style3 {
            font-family: 微軟正黑體;
        }

        .auto-style4 {
            height: 31px;
        }

        .auto-style5 {
            height: 20px;
        }

        .auto-style6 {
            height: 21px;
        }

        .auto-style7 {
            height: 29px;
        }

        .auto-style9 {
            font-weight: bold;
            font-size: large;
        }
        .auto-style10
        {
            height: 36px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Style="font-size: large; font-weight: 700; font-family: 微軟正黑體" Text="技術名稱:"></asp:Label>
                <asp:Label ID="lblItemName" runat="server" Style="font-size: large; font-weight: 700; font-family: 微軟正黑體; color: #0000FF"></asp:Label>
                <asp:Label ID="lblItemCode" runat="server" Style="font-size: large; font-weight: 700; font-family: 微軟正黑體; color: #0000FF" Visible="False"></asp:Label>
                <asp:Label ID="lblApplicationMemberNumber" runat="server" Style="font-size: large; font-weight: 700; font-family: 微軟正黑體; color: #0000FF" Visible="False"></asp:Label>
            </td>
            <td rowspan="15" align="left" valign="top">
                <asp:Panel runat="server" ID="panRejectLog">
                <div style="width:220px; height:auto">
                    <h2>駁回記錄</h2>
                </div>
                    
                <div><asp:Literal ID="liRejectLog" runat="server"></asp:Literal></div>
                </asp:Panel>

            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Style="font-size: large; font-weight: 700; font-family: 微軟正黑體" Text="順序次數:"></asp:Label>
                <asp:Label ID="lblCheckTimes" runat="server" Style="font-size: large; font-weight: 700; font-family: 微軟正黑體; color: #FF0000"></asp:Label>
                <asp:Label ID="lblCheckStatus" runat="server" Style="font-size: large; font-weight: 700; font-family: 微軟正黑體; color: #FF0000" Visible="False"></asp:Label>
                <asp:Label ID="lblApplicationDate" runat="server" Style="font-size: large; font-weight: 700; font-family: 微軟正黑體; color: #FF0000" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style6"></td>
        </tr>
        <tr>
            <td class="auto-style5">
                <asp:Label ID="Label7" runat="server" Style="font-size: large; font-weight: 700" Text="考核導師:"></asp:Label>
                <telerik:RadComboBox ID="rCBHosp" runat="server" AutoPostBack="True" Culture="zh-TW" DataSourceID="SqlDataSource1" DataTextField="hospname" DataValueField="hospcode" MarkFirstMatch="True" Skin="Sunset">
                </telerik:RadComboBox>
                <telerik:RadComboBox ID="rCBTeacherName" runat="server" Culture="zh-TW" Skin="Sunset" DataSourceID="SqlDataSource3" MarkFirstMatch="True" AllowCustomText="True" DataTextField="displayItem" DataValueField="empcode" Filter="Contains" Width="300px">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style6"></td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Label ID="Label2" runat="server" Style="font-size: large; font-weight: 700" Text="實作日期:"></asp:Label>
                <telerik:RadDatePicker ID="rDPImplementDate" runat="server" Font-Bold="True" Font-Size="X-Large" Skin="Sunset" CssClass="auto-style3" Width="206px" Culture="zh-TW">
                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" EnableWeekends="True" Skin="Sunset"></Calendar>

                    <DateInput DisplayDateFormat="yyyy/MM/dd" DateFormat="yyyy/MM/dd" LabelWidth="60%">
                        <EmptyMessageStyle Resize="None"></EmptyMessageStyle>

                        <ReadOnlyStyle Resize="None"></ReadOnlyStyle>

                        <FocusedStyle Resize="None"></FocusedStyle>

                        <DisabledStyle Resize="None"></DisabledStyle>

                        <InvalidStyle Resize="None"></InvalidStyle>

                        <HoveredStyle Resize="None"></HoveredStyle>

                        <EnabledStyle Resize="None"></EnabledStyle>
                    </DateInput>

                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
        </tr>
        <tr>
            <td class="auto-style6"></td>
        </tr>
        <tr>
            <td class="auto-style7">
                <asp:Label ID="Label6" runat="server" Style="font-size: large; font-weight: 700" Text="實作地點:"></asp:Label>
                <telerik:RadTextBox ID="rtxtImplementPlace" runat="server" EmptyMessage="輸入實作地點" LabelWidth="64px" Resize="None" Skin="WebBlue" Width="180px">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <div style="float: left;">
                    <asp:Label ID="Label8" runat="server" Style="font-family: 微軟正黑體;" Text="施作對象:" Height="25px" CssClass="auto-style9"></asp:Label>
                </div>

                
                    <span class="auto-style9">&nbsp;&nbsp;&nbsp;&nbsp;
                    </span>
                    <asp:RadioButton ID="rdBtnImplementObject1" runat="server" Font-Bold="True" Font-Size="Large" GroupName="rdBtnImplementObject" Text="教具" Style="color: #009900" Height="25px" CssClass="auto-style9" AutoPostBack="True" OnCheckedChanged="rdBtnImplementObject1_CheckedChanged" />
                

                
                    <span class="auto-style9">&nbsp;&nbsp;&nbsp;&nbsp;
                    </span>
                    <asp:RadioButton ID="rdBtnImplementObject2" runat="server" Font-Bold="True" Font-Size="Large" GroupName="rdBtnImplementObject" Text="病人" Style="color: #FF5050" Height="25px" CssClass="auto-style9" AutoPostBack="True" OnCheckedChanged="rdBtnImplementObject2_CheckedChanged" />
                
                
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblHistoryNumber" runat="server" Style="font-size: large; font-weight: 700" Text="病歷號碼:"></asp:Label>
                <telerik:RadTextBox ID="txtCaseHistoryNumber" runat="server" LabelWidth="64px" Resize="None" Skin="WebBlue" Width="180px" Font-Bold="True" style="color: #0000FF; vertical-align: medium; font-size: large; font-weight: 700; font-family: 微軟正黑體" Font-Size="Medium">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblImplementModel" runat="server" Style="font-size: large; font-weight: 700; font-family: 微軟正黑體; color: #FF0000" Visible="False"></asp:Label>
                <asp:Label ID="lblCaseHistoryNumber" runat="server" Style="font-size: large; font-weight: 700; font-family: 微軟正黑體; color: #FF0000" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label3" runat="server" Style="font-size: large; font-weight: 700" Text="意見與回饋:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:TextBox ID="txtRemark" runat="server" Height="117px" Style="font-size: medium; font-weight: 700; font-family: 微軟正黑體;" TextMode="MultiLine" Width="650px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label1" runat="server" Style="font-size: large; font-weight: 700" Text="教師回饋:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:TextBox ID="TeacherRemark" runat="server" Height="117px" Style="font-size: medium; font-weight: 700; font-family: 微軟正黑體;" TextMode="MultiLine" Width="650px"></asp:TextBox>                

            </td>
        </tr>
        <tr>
            <td colspan="2">
                <hr />
            </td>
        </tr>
        <tr>
            <td class="auto-style10" colspan="2">
                <asp:Button ID="btnConfirm" runat="server" Text="確認送出" CssClass="auto-style2" OnClick="btnConfirm_Click" />
                &nbsp;&nbsp;
                <asp:Button ID="btnBackPage" runat="server" Text="回上一頁" CssClass="auto-style2" OnClick="btnBackPage_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
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
                <asp:SqlDataSource ID="dsVS" runat="server" ConnectionString="<%$ ConnectionStrings:dsEduActivity %>" SelectCommand="SELECT DISTINCT empcode + empname AS displayItem, empcode 
FROM V_KmuEmp WHERE (hospcode = @hospcode) 
AND jobcode IN ('VS','VST') 
AND (enddate IS NULL OR enddate &gt;= GETDATE())
">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="rCBHosp" Name="hospcode" PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:dsEduActivity %>" DeleteCommand="DELETE FROM [PassPortStudentApplicationItem] WHERE [applicationID] = @applicationID" InsertCommand="INSERT INTO [PassPortStudentApplicationItem] ([itemCode], [applicationMemberNumber], [checkOrder], [designationTeacherNumber], [implementPlace], [implementDate], [applicationDate], [isFinalCheck], [checkResult], [checkStatus], [checkDate], [studentRemark], [implementObject], [caseHistoryNumber], [teacherRemark],JobCode) VALUES (@itemCode, @applicationMemberNumber, @checkOrder, @designationTeacherNumber, @implementPlace, @implementDate, @applicationDate, @isFinalCheck, @checkResult, @checkStatus, @checkDate, @studentRemark, @implementObject, @caseHistoryNumber, @teacherRemark,@JobCode)" SelectCommand="SELECT * FROM [PassPortStudentApplicationItem]" UpdateCommand="UPDATE [PassPortStudentApplicationItem] SET [itemCode] = @itemCode, [applicationMemberNumber] = @applicationMemberNumber, [checkOrder] = @checkOrder, [designationTeacherNumber] = @designationTeacherNumber, [implementPlace] = @implementPlace, [implementDate] = @implementDate, [applicationDate] = @applicationDate, [isFinalCheck] = @isFinalCheck, [checkResult] = @checkResult, [checkStatus] = @checkStatus, [checkDate] = @checkDate, [studentRemark] = @studentRemark, [implementObject] = @implementObject, [caseHistoryNumber] = @caseHistoryNumber, [teacherRemark] = @teacherRemark WHERE [applicationID] = @applicationID">
                    <DeleteParameters>
                        <asp:Parameter Name="applicationID" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:ControlParameter ControlID="lblItemCode" Name="itemCode" PropertyName="Text" Type="Int32" />
                        <asp:ControlParameter ControlID="lblApplicationMemberNumber" Name="applicationMemberNumber" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="lblCheckTimes" Name="checkOrder" PropertyName="Text" Type="Int32" />
                        <asp:ControlParameter ControlID="rCBTeacherName" Name="designationTeacherNumber" PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter ControlID="rtxtImplementPlace" Name="implementPlace" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="rDPImplementDate" DbType="Date" Name="implementDate" PropertyName="SelectedDate" />
                        <asp:ControlParameter ControlID="lblApplicationDate" DbType="Date" Name="applicationDate" PropertyName="Text" />
                        <asp:Parameter Name="isFinalCheck" Type="Boolean" />
                        <asp:Parameter Name="checkResult" Type="Boolean" />
                        <asp:ControlParameter ControlID="lblCheckStatus" Name="checkStatus" PropertyName="Text" Type="String" />
                        <asp:Parameter DbType="Date" Name="checkDate" />
                        <asp:ControlParameter ControlID="txtRemark" Name="studentRemark" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="lblImplementModel" Name="implementObject" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="lblCaseHistoryNumber" Name="caseHistoryNumber" PropertyName="Text" Type="String" />
                        <asp:Parameter Name="teacherRemark" Type="String" />
                        <asp:ControlParameter ControlID="hfJobCode" Name="JobCode" PropertyName="Value" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="itemCode" Type="Int32" />
                        <asp:Parameter Name="applicationMemberNumber" Type="String" />
                        <asp:Parameter Name="checkOrder" Type="Int32" />
                        <asp:Parameter Name="designationTeacherNumber" Type="String" />
                        <asp:Parameter Name="implementPlace" Type="String" />
                        <asp:Parameter DbType="Date" Name="implementDate" />
                        <asp:Parameter DbType="Date" Name="applicationDate" />
                        <asp:Parameter Name="isFinalCheck" Type="Boolean" />
                        <asp:Parameter Name="checkResult" Type="Boolean" />
                        <asp:Parameter Name="checkStatus" Type="String" />
                        <asp:Parameter DbType="Date" Name="checkDate" />
                        <asp:Parameter Name="studentRemark" Type="String" />
                        <asp:Parameter Name="implementObject" Type="String" />
                        <asp:Parameter Name="caseHistoryNumber" Type="String" />
                        <asp:Parameter Name="teacherRemark" Type="String" />
                        <asp:Parameter Name="applicationID" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
                <asp:HiddenField ID="hfJobCode" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>

