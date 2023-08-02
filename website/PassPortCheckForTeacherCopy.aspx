<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PassPortCheckForTeacherCopy.aspx.cs" Inherits="PassPortCheckForTeacher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">


        .auto-style5 {
            font-family: 微軟正黑體;
            font-weight: bold;
        }

        .auto-style6 {
            font-size: medium;
        }
        .auto-style7 {
            font-weight: bold;
            font-size: medium;
            text-align: left;
            color: #993333;
        }
        .auto-style8 {
            font-size: large;
        }
        .auto-style9 {
            text-align: center;
        }
        .auto-style10 {
            font-weight: bold;
            font-size: medium;
            text-align: left;
            color: blue;
        }
        .auto-style11 {
            font-size: medium;
            color: blue;
        }
    p.MsoNormal
	{margin-bottom:.0001pt;
	font-size:12.0pt;
	font-family:"新細明體","serif";
	        margin-left: 0cm;
            margin-right: 0cm;
            margin-top: 0cm;
        }
p.110
	{margin-top:6.0pt;
	margin-right:1.0cm;
	margin-bottom:0cm;
	margin-left:67.9pt;
	margin-bottom:.0001pt;
	text-align:justify;
	text-indent:-23.1pt;
	layout-grid-mode:char;
	font-size:10.0pt;
	font-family:"Arial","sans-serif";
	}
        .auto-style12 {
            height: 37px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <b style="font-family: 微軟正黑體">
                <asp:Label ID="Label2" runat="server" Text="臨床照護分級 - 臨床導師考核介面" Font-Bold="True" Font-Size="XX-Large" ForeColor="Blue" CssClass="auto-style5"></asp:Label>
            &nbsp;&nbsp;
    <asp:Label ID="Label3" runat="server" CssClass="auto-style6" Font-Bold="True" Font-Size="Large" Text="待審核資料共:"></asp:Label>
&nbsp;<asp:Label ID="lblDataCount" runat="server" CssClass="auto-style6" Font-Bold="True" ForeColor="Red"></asp:Label>
&nbsp;<asp:Label ID="Label4" runat="server" CssClass="auto-style6" Font-Bold="True" Font-Size="Large" Text="筆"></asp:Label>
        </b>
    <br />
    <br />
        <div>
            <table>
                <tr>
                    <td colspan="2">
                        <b>
                            <span style="font-family:標楷體; font-size:large">
                        臨床分級說明</span>
                            </b>
                            </td>
                    <td>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style12">
                        <span lang="EN-US" style="font-size:12.0pt;
font-family:標楷體">A、</span>
                    </td>
                    <td class="auto-style12">

                            <span style="font-size:12.0pt;font-family:標楷體">受訓醫師在臨床照護督導共分為三級， O觀察模擬Observation and Simulation、S督導支援Supervision(S1：在其執行臨床照護時，督導教師共同在旁逐步完成或必要時給予協助 ； S2：在其執行臨床照護後，督導教師重新確認執行情形 ； S3：在其執行臨床照護後，必要時知會教師確認執行情形)、I獨立作業Independent，每一臨床分級需經過三次評核後才可進入下一分級。</span>

                    </td>
                </tr>

                <tr>
                    <td>
<span lang="EN-US" style="font-size:12.0pt;
font-family:標楷體">B、</span>
                    </td>
                    <td>
                            <span style="font-size:12.0pt;font-family:標楷體">目前住院醫師職級為S督導支援Supervision，為『督導醫師在其執行臨床照護前已給予明確指導，過程中督導醫師在場提供督導，或督導醫師能隨時支援。並經臨床指導教師審核確認。』</span>
                    </td>
                </tr>

                <tr>
                    <td>
                        <span lang="EN-US" style="font-size:12.0pt;font-family:標楷體">C、</span>
                    </td>
                    <td>
                            <span style="font-size:12.0pt;font-family:標楷體">請督導醫師審核住院醫師所提出確認程序，給予審核與回饋。</span>
                    </td>
                </tr>

            </table>

        </div>
    <br />
    <asp:GridView ID="gvCheckForTeacher" runat="server" AutoGenerateColumns="False" CssClass="bold" DataSourceID="SqlDataSource1" style="font-family: 微軟正黑體" OnRowCommand="gvCheckForTeacher_RowCommand" ShowHeader="False" Width="960px">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <table style="width:100%;">
                        <tr>
                            <td style="border: 1px solid #990033;width:150px" class="auto-style9">
                                <asp:Label ID="Label5" runat="server" CssClass="auto-style8" Text="技能項目"></asp:Label>
                            </td>
                            <td style="border: 1px solid #990033;width:80px" class="auto-style9"><b style="font-family: 微軟正黑體">
                                <asp:Label ID="Label6" runat="server" CssClass="auto-style8" Text="職稱"></asp:Label>
                                </b></td>
                            <td style="border: 1px solid #990033;width:80px" class="auto-style9"><b style="font-family: 微軟正黑體">
                                <asp:Label ID="Label7" runat="server" CssClass="auto-style8" Text="姓名"></asp:Label>
                                </b></td>
                            <td style="border: 1px solid #990033;width:80px" class="auto-style9"><b style="font-family: 微軟正黑體">
                                <asp:Label ID="Label8" runat="server" CssClass="auto-style8" Text="審核等級"></asp:Label>
                                </b></td>
                            <td style="border: 1px solid #990033;width:150px" class="auto-style9"><b style="font-family: 微軟正黑體">
                                <asp:Label ID="Label9" runat="server" CssClass="auto-style8" Text="實作日期"></asp:Label>
                                </b></td>
                            <td style="border: 1px solid #990033;width:150px" class="auto-style9"><b style="font-family: 微軟正黑體">
                                <asp:Label ID="Label10" runat="server" CssClass="auto-style8" Text="實作地點"></asp:Label>
                                </b></td>
                            <td style="border: 1px solid #990033;width:270px" class="auto-style9"><b style="font-family: 微軟正黑體">
                                <asp:Label ID="Label11" runat="server" CssClass="auto-style8" Text="學員回饋訊息"></asp:Label>
                                </b></td>
                        </tr>
                        <tr>
                            <td style="border: 1px solid #990033;" class="auto-style9">
                                <asp:Label ID="lblApplicationDate" runat="server" CssClass="auto-style11" Text='<%# Eval("ItemName", "{0:D}") %>'></asp:Label>
                            </td>
                            <td style="border: 1px solid #990033;" class="auto-style9">
                                <asp:Label ID="lblJobCode" runat="server" CssClass="auto-style11" Text='<%# Eval("jobcode") %>'></asp:Label>
                                
                            </td>
                            <td style="border: 1px solid #990033;" class="auto-style9">
                                <asp:Label ID="lblApplicationNumber" runat="server" CssClass="auto-style11" Text='<%# Eval("applicationMemberNumber") %>'></asp:Label><br />
                                <asp:Label ID="lblApplicationName" runat="server" CssClass="auto-style11" Text='<%# Eval("empname") %>'></asp:Label>
                                
                            </td>
                            <td style="border: 1px solid #990033;" class="auto-style9">
                                <asp:Label ID="lblCheckOrder" runat="server" CssClass="auto-style11" Text='<%# Eval("AuthorizeLevel") %>'></asp:Label>
                            </td>
                            <td style="border: 1px solid #990033;" class="auto-style9">
                                <asp:Label ID="lblImplementDate" runat="server" CssClass="auto-style11" Text='<%# Eval("implementDate", "{0:D}") %>'></asp:Label>
                            </td>
                            <td style="border: 1px solid #990033;" class="auto-style9">
                                <asp:Label ID="lblImplementPlace" runat="server" CssClass="auto-style11" Text='<%# Eval("implementPlace") %>'></asp:Label>
                            </td>
                            <td style="border: 1px solid #990033;">
                                <asp:TextBox ID="txtStudentRemark" runat="server" CssClass="auto-style10" Text='<%# Bind("studentRemark") %>' TextMode="MultiLine" ReadOnly="True" Width="270px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="border: 1px solid #990033;width:150px" class="auto-style9"><b style="font-family: 微軟正黑體">
                                <asp:Label ID="Label14" runat="server" CssClass="auto-style8" Text="施作對象"></asp:Label>
                                </b></td>
                            <td colspan="2" style="border: 1px solid #990033;width:160px" class="auto-style9"><b style="font-family: 微軟正黑體">
                                <asp:Label ID="Label15" runat="server" CssClass="auto-style8" Text="病歷號碼"></asp:Label>
                                </b></td>
                            <td colspan="2" style="border: 1px solid #990033;width:230px"><b style="font-family: 微軟正黑體">
                                <asp:Label ID="Label12" runat="server" CssClass="auto-style8" Text="簽核"></asp:Label>
                                </b></td>
                            <td colspan="2" style="border: 1px solid #990033;width:420px"><b style="font-family: 微軟正黑體">
                                <asp:Label ID="Label13" runat="server" CssClass="auto-style8" Text="臨床老師考核回饋訊息(非必填)"></asp:Label>
                                </b></td>
                        </tr>
                        <tr>
                            <td style="border: 1px solid #990033;width:150px;text-align:center">
                                <asp:Label ID="lblImplementObjectAuto" runat="server" CssClass="auto-style11" Text='<%# Eval("implementObject") %>'></asp:Label>
                                <br />
                            </td>
                            <td colspan="2" style="border: 1px solid #990033;width:160px;text-align:center">
                                <b style="font-family: 微軟正黑體">
                                <asp:Label ID="lblCaseHistoryNumber" runat="server" CssClass="auto-style11" Text='<%# Eval("caseHistoryNumber") %>' ForeColor="Red"></asp:Label>
                                </b>
                            </td>
                            <td colspan="2" style="border: 1px solid #990033;width:230px"><b style="font-family: 微軟正黑體">
                                <asp:RadioButton ID="rdBtnPass" runat="server" CssClass="auto-style6" ForeColor="#009933" GroupName="rdBtnListCheckResult" Text="通過" Width="150px" />
                                <asp:RadioButton ID="rdBtnFail" runat="server" CssClass="auto-style6" ForeColor="Red" GroupName="rdBtnListCheckResult" Text="退回" Width="150px" />
                                </b></td>
                            <td colspan="2" style="border: 1px solid #990033;width:420px"><b style="font-family: 微軟正黑體">
                                <asp:TextBox ID="txtTeacherRemark" runat="server" CssClass="auto-style7" TextMode="MultiLine" Width="410px"></asp:TextBox>
                                </b></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:ButtonField ButtonType="Button" Text="送出"  ControlStyle-ForeColor="#cc0066" ControlStyle-Font-Bold="true" ControlStyle-Height="30px" ControlStyle-Width="50px" CommandName="submitResult">
<ControlStyle Font-Bold="True" ForeColor="#CC0066" Height="30px" Width="50px"></ControlStyle>
            </asp:ButtonField>
            <asp:TemplateField HeaderText="applicationID" SortExpression="applicationID" Visible="False">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("applicationID") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblApplicationIDAuto" runat="server" Text='<%# Bind("applicationID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="checkStatus" HeaderText="checkStatus" ReadOnly="True" SortExpression="checkStatus" Visible="False" />
            <asp:BoundField DataField="checkDate" HeaderText="checkDate" ReadOnly="True" SortExpression="checkDate" Visible="False" />
        </Columns>
    </asp:GridView>
    <asp:GridView ID="gvFinalCheckForTeacher" runat="server" AutoGenerateColumns="False" CssClass="bold" DataSourceID="dsFinalCheck" style="font-family: 微軟正黑體" OnRowCommand="gvCheckForTeacher_RowCommand" ShowHeader="False" Width="960px">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <table style="width:100%;">
                        <tr>
                            <td style="border: 1px solid #990033;width:150px" class="auto-style9">
                                <asp:Label ID="Label16" runat="server" CssClass="auto-style8" Text="技能項目"></asp:Label>
                            </td>
                            <td style="border: 1px solid #990033;width:80px" class="auto-style9"><b style="font-family: 微軟正黑體">
                                <asp:Label ID="Label17" runat="server" CssClass="auto-style8" Text="職稱"></asp:Label>
                                </b></td>
                            <td style="border: 1px solid #990033;width:80px" class="auto-style9"><b style="font-family: 微軟正黑體">
                                <asp:Label ID="Label18" runat="server" CssClass="auto-style8" Text="姓名"></asp:Label>
                                </b></td>
                            <td style="border: 1px solid #990033;width:80px" class="auto-style9"><b style="font-family: 微軟正黑體">
                                <asp:Label ID="Label19" runat="server" CssClass="auto-style8" Text="審核等級"></asp:Label>
                                </b></td>
                            <td colspan="3" style="border: 1px solid #990033;width:570px" class="auto-style9"><b style="font-family: 微軟正黑體">
                                <table>
                                    <tr>
                                        <td style="border: 1px solid #990033;width:190px" class="auto-style9">
                                            <asp:Label ID="Label20" runat="server" CssClass="auto-style8" Text="第一次評核"></asp:Label>
                                        </td>
                                        <td style="border: 1px solid #990033;width:190px" class="auto-style9">
                                            <asp:Label ID="Label21" runat="server" CssClass="auto-style8" Text="第二次評核"></asp:Label>
                                        </td>
                                        <td style="border: 1px solid #990033;width:190px" class="auto-style9">
                                            <asp:Label ID="Label22" runat="server" CssClass="auto-style8" Text="第三次評核"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                </b></td>
                        </tr>
                        <tr>
                            <td style="border: 1px solid #990033;" class="auto-style9">
                                <asp:Label ID="lblApplicationDate" runat="server" CssClass="auto-style11" Text='<%# Eval("ItemName", "{0:D}") %>'></asp:Label>
                            </td>
                            <td style="border: 1px solid #990033;" class="auto-style9">
                                <asp:Label ID="lblJobCode" runat="server" CssClass="auto-style11" Text='<%# Eval("jobcode") %>'></asp:Label>
                                
                            </td>
                            <td style="border: 1px solid #990033;" class="auto-style9">
                                <asp:Label ID="lblApplicationNumber" runat="server" CssClass="auto-style11" Text='<%# Eval("applicationMemberNumber") %>'></asp:Label><br />
                                <asp:Label ID="lblApplicationName" runat="server" CssClass="auto-style11" Text='<%# Eval("empname") %>'></asp:Label>
                                
                            </td>
                            <td style="border: 1px solid #990033;" class="auto-style9">
                                <asp:Label ID="lblCheckOrder" runat="server" CssClass="auto-style11" Text='<%# Eval("AuthorizeLevel") %>'></asp:Label>
                            </td>
                            <td colspan="3" style="border: 1px solid #990033;" class="auto-style9">
                                <table>
                                    <tr>
                                        <td style="border: 1px solid #990033;width:190px" class="auto-style9">
                                            <asp:Label ID="lblcheckOrder1" runat="server" CssClass="auto-style11" Text='<%# Eval("checkOrder1") %>'></asp:Label><br />
                                            <asp:Label ID="lblcheckResult1" runat="server" CssClass="auto-style11" Text='<%# Eval("checkResult1") %>'></asp:Label><br />
                                            評核人：<asp:Label ID="lblTeacher1" runat="server" CssClass="auto-style11" Text='<%# Eval("Teacher1") %>'></asp:Label>
                                        </td>
                                        <td style="border: 1px solid #990033;width:190px" class="auto-style9">
                                            <asp:Label ID="lblcheckOrder2" runat="server" CssClass="auto-style11" Text='<%# Eval("checkOrder2") %>'></asp:Label><br />
                                            <asp:Label ID="lblcheckResult2" runat="server" CssClass="auto-style11" Text='<%# Eval("checkResult2") %>'></asp:Label><br />
                                            評核人：<asp:Label ID="lblTeacher2" runat="server" CssClass="auto-style11" Text='<%# Eval("Teacher2") %>'></asp:Label>
                                        </td>
                                        <td style="border: 1px solid #990033;width:190px" class="auto-style9">
                                            <asp:Label ID="lblcheckOrder3" runat="server" CssClass="auto-style11" Text='<%# Eval("checkOrder3") %>'></asp:Label><br />
                                            <asp:Label ID="lblcheckResult3" runat="server" CssClass="auto-style11" Text='<%# Eval("checkResult3") %>'></asp:Label><br />
                                            評核人：<asp:Label ID="lblTeacher3" runat="server" CssClass="auto-style11" Text='<%# Eval("Teacher3") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" style="border: 1px solid #990033;width:540px"><b style="font-family: 微軟正黑體">
                                <asp:Label ID="Label25" runat="server" CssClass="auto-style8" Text="是否晉級"></asp:Label>
                                </b></td>
                            <td colspan="2" style="border: 1px solid #990033;width:420px"><b style="font-family: 微軟正黑體">
                                <asp:Label ID="Label26" runat="server" CssClass="auto-style8" Text="臨床老師考核回饋訊息(非必填)"></asp:Label>
                                </b></td>
                        </tr>
                        <tr>

                            <td colspan="5" style="border: 1px solid #990033;width:540px"><b style="font-family: 微軟正黑體">
                                <asp:RadioButton ID="rdBtnPass" runat="server" CssClass="auto-style6" ForeColor="#009933" GroupName="rdBtnListCheckResult" Text="通過" Width="150px" />
                                <asp:RadioButton ID="rdBtnFail" runat="server" CssClass="auto-style6" ForeColor="Red" GroupName="rdBtnListCheckResult" Text="未通過" Width="150px" />
                                </b></td>
                            <td colspan="2" style="border: 1px solid #990033;width:420px"><b style="font-family: 微軟正黑體">
                                <asp:TextBox ID="txtTeacherRemark" runat="server" CssClass="auto-style7" TextMode="MultiLine" Width="410px"></asp:TextBox>
                                </b></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:ButtonField ButtonType="Button" Text="送出"  ControlStyle-ForeColor="#cc0066" ControlStyle-Font-Bold="true" ControlStyle-Height="30px" ControlStyle-Width="50px" CommandName="submitResult">
<ControlStyle Font-Bold="True" ForeColor="#CC0066" Height="30px" Width="50px"></ControlStyle>
            </asp:ButtonField>
            <asp:TemplateField HeaderText="applicationID" SortExpression="applicationID" Visible="False">
                <EditItemTemplate>
                    <asp:Label ID="Label27" runat="server" Text='<%# Eval("applicationID") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblApplicationIDAuto" runat="server" Text='<%# Bind("applicationID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="checkStatus" HeaderText="checkStatus" ReadOnly="True" SortExpression="checkStatus" Visible="False" />
            <asp:BoundField DataField="checkDate" HeaderText="checkDate" ReadOnly="True" SortExpression="checkDate" Visible="False" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="lblEmpCode" runat="server" Visible="False"></asp:Label>
    </b>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dsEduActivity %>" SelectCommand="select applicationID,applicationDate,applicationMemberNumber,emp.empname ,itemName,checkOrder,implementDate,implementPlace,checkResult,checkStatus,checkDate,studentRemark,implementObject,caseHistoryNumber,emp.jobcode,titem.authorizeLevel
from PassPortCheckItem
inner join PassPortStudentApplicationItem as teacherCheck
on PassPortCheckItem.itemCode=teacherCheck.itemCode
inner join V_KmuEmp as emp
on teacherCheck.applicationMemberNumber = emp.empcode 
left join PassPortJobTitleItem titem
on PassPortCheckItem.itemCode = titem.itemCode 
and titem.jobTitleCode = emp.jobcode
where teacherCheck.designationTeacherNumber=@empcode and teacherCheck.checkStatus='1' and (isfinalcheck  is null or isfinalcheck = 0)
order by teacherCheck.applicationDate asc">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblEmpCode" Name="empcode" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsFinalCheck" runat="server" ConnectionString="<%$ ConnectionStrings:dsEduActivity %>" SelectCommand="select distinct teacherCheck.applicationID,teacherCheck.applicationDate,teacherCheck.applicationMemberNumber,emp.empname ,PassPortCheckItem.itemName,teacherCheck.checkOrder,teacherCheck.implementDate,teacherCheck.implementPlace,teacherCheck.checkResult,teacherCheck.checkStatus,teacherCheck.checkDate,teacherCheck.studentRemark,teacherCheck.implementObject,teacherCheck.caseHistoryNumber,emp.jobcode,titem.authorizeLevel,
titem.exAuthorizeLevel+cast(appItem1.checkOrder as varchar) as checkOrder1, case when appItem1.checkResult = 1 then '通過' else '未通過' end as checkResult1, emp1.empname as Teacher1,
titem.exAuthorizeLevel+cast(appItem2.checkOrder as varchar) as checkOrder2, case when appItem2.checkResult = 1 then '通過' else '未通過' end as checkResult2, emp1.empname as Teacher2,
titem.exAuthorizeLevel+cast(appItem3.checkOrder as varchar) as checkOrder3, case when appItem3.checkResult = 1 then '通過' else '未通過' end as checkResult3, emp1.empname as Teacher3
from PassPortCheckItem
inner join PassPortStudentApplicationItem as teacherCheck
on PassPortCheckItem.itemCode=teacherCheck.itemCode
inner join V_KmuEmp as emp
on teacherCheck.applicationMemberNumber = emp.empcode 
left join PassPortJobTitleItem titem
on PassPortCheckItem.itemCode = titem.itemCode 
and titem.jobTitleCode = emp.jobcode

left JOIN  [PassPortStudentApplicationItem] as appItem1 
ON PassPortCheckItem.itemCode=appItem1.itemCode and appItem1.checkorder = 1 and appItem1.ApplicationMemberNumber = teacherCheck.applicationMemberNumber

left join V_KmuEmp as emp1
on appItem1.designationTeacherNumber = emp1.empcode

left JOIN  [PassPortStudentApplicationItem] as appItem2 
ON PassPortCheckItem.itemCode=appItem2.itemCode and appItem2.checkorder = 2 and appItem2.ApplicationMemberNumber = teacherCheck.applicationMemberNumber

left join V_KmuEmp as emp2
on appItem2.designationTeacherNumber = emp2.empcode

left JOIN  [PassPortStudentApplicationItem] as appItem3 
ON PassPortCheckItem.itemCode=appItem3.itemCode and appItem3.checkorder = 3 and appItem3.ApplicationMemberNumber = teacherCheck.applicationMemberNumber

left join V_KmuEmp as emp3
on appItem3.designationTeacherNumber = emp3.empcode

where teacherCheck.designationTeacherNumber=@empcode and teacherCheck.checkStatus='1' and teacherCheck.isfinalcheck = 1
order by teacherCheck.applicationDate asc">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblEmpCode" Name="empcode" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:Label ID="lblCheckResult" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblCheckStatus" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblCheckDate" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblApplicationID" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblTeacherRemark" runat="server" Visible="False"></asp:Label>
    <br />
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:dsEduActivity %>" DeleteCommand="DELETE FROM [PassPortStudentApplicationItem] WHERE [applicationID] = @applicationID" InsertCommand="INSERT INTO [PassPortStudentApplicationItem] ([checkResult], [checkStatus], [checkDate], [teacherRemark]) VALUES (@checkResult, @checkStatus, @checkDate, @teacherRemark)" SelectCommand="SELECT [applicationID], [checkResult], [checkStatus], [checkDate], [teacherRemark] FROM [PassPortStudentApplicationItem]" UpdateCommand="UPDATE [PassPortStudentApplicationItem] SET [checkResult] = @checkResult, [checkStatus] = @checkStatus, [checkDate] = @checkDate, [teacherRemark] = @teacherRemark WHERE [applicationID] = @applicationID">
        <DeleteParameters>
            <asp:Parameter Name="applicationID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="checkResult" Type="Boolean" />
            <asp:Parameter Name="checkStatus" Type="String" />
            <asp:Parameter DbType="Date" Name="checkDate" />
            <asp:Parameter Name="teacherRemark" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:ControlParameter ControlID="lblCheckResult" Name="checkResult" PropertyName="Text" Type="Boolean" />
            <asp:ControlParameter ControlID="lblCheckStatus" Name="checkStatus" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="lblCheckDate" DbType="Date" Name="checkDate" PropertyName="Text" />
            <asp:ControlParameter ControlID="lblTeacherRemark" Name="teacherRemark" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="lblApplicationID" Name="applicationID" PropertyName="Text" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>

