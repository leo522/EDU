<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.master" AutoEventWireup="true" CodeFile="PassPortForNurseEmpty.aspx.cs" Inherits="PassPortForNurseEmpty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
.slash{
background: linear-gradient(25deg, transparent 49.5%, #212121 49.5%, transparent 50.5%, transparent 50.5%);
}
        .auto-style1 {
            width: 100%;
        }

        .auto-style3 {
            height: 17px;
        }

        .auto-style4 {
        }

        .auto-style5 {
            font-family: 微軟正黑體;
            font-weight: bold;
        }

        .auto-style2 {
            font-family: 微軟正黑體;
            font-weight: bold;
            font-size: x-large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table cellpadding="0" cellspacing="0" class="auto-style1">
        <tr>
            <td class="auto-style3">
                <asp:Label ID="Label2" runat="server" Text="臨床照護分級學習護照查詢系統" Font-Bold="true" Font-Size="XX-Large" ForeColor="#0000ff" CssClass="auto-style5"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <hr />
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                <div id="panControl" runat="server">
                <asp:Label ID="Label1" runat="server" Text="請輸入人員職編:" CssClass="auto-style5" Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:TextBox ID="txtSearchEmpCode" runat="server" Style="margin-left: 0px" CssClass="auto-style5" Font-Bold="true" Font-Size="Large"></asp:TextBox>
                &nbsp;
                <div style="display: none">
                    <asp:DropDownList ID="ddlJobCode" runat="server" Font-Bold="True" Font-Size="Large" Width="188px" Height="29px" DataSourceID="SqlDataSource1" DataTextField="jobcode" DataValueField="jobcode">
                    </asp:DropDownList>
                </div>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dsEduActivity %>" SelectCommand="SELECT [empcode], [empname], [jobcode] FROM [V_KmuEmp] WHERE ([empcode] = @empcode)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtSearchEmpCode" Name="empcode" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                &nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server" Text="開始查詢" CssClass="auto-style5" Width="100px" Font-Bold="true" Font-Size="Large" OnClick="btnSearch_Click" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnResetText" runat="server" Text="清除重填" CssClass="auto-style5" Width="100px" Font-Bold="true" Font-Size="Large" OnClick="btnResetText_Click" />
                    </div>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                <div style="float: left;">
                    <asp:FormView ID="FormView1" runat="server" DataKeyNames="empcode" DataSourceID="SqlDataSource1" Style="font-size: large; font-weight: 700; font-family: 微軟正黑體" Width="200px">
                        <EditItemTemplate>
                            empcode:
                        <asp:Label ID="empcodeLabel1" runat="server" Text='<%# Eval("empcode") %>' />
                            <br />
                            empname:
                        <asp:TextBox ID="empnameTextBox" runat="server" Text='<%# Bind("empname") %>' />
                            <br />
                            jobcode:
                        <asp:TextBox ID="jobcodeTextBox" runat="server" Text='<%# Bind("jobcode") %>' />
                            <br />
                            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="更新" />
                            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消" />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            empcode:
                        <asp:TextBox ID="empcodeTextBox" runat="server" Text='<%# Bind("empcode") %>' />
                            <br />
                            empname:
                        <asp:TextBox ID="empnameTextBox" runat="server" Text='<%# Bind("empname") %>' />
                            <br />
                            jobcode:
                        <asp:TextBox ID="jobcodeTextBox" runat="server" Text='<%# Bind("jobcode") %>' />
                            <br />
                            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="插入" />
                            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消" />
                        </InsertItemTemplate>
                        <ItemTemplate>
                            職員姓名:
                        <asp:Label ID="empnameLabel" runat="server" Text='<%# Bind("empname") %>' style="color: #0000FF" />
                            <br />

                        </ItemTemplate>
                    </asp:FormView>
                </div>
                <div style="float: left;">
                    <asp:FormView ID="FormView2" runat="server" DataKeyNames="empcode" DataSourceID="SqlDataSource1" Style="font-size: large; font-weight: 700; font-family: 微軟正黑體">
                        <EditItemTemplate>
                            empcode:
                            <asp:Label ID="empcodeLabel1" runat="server" Text='<%# Eval("empcode") %>' />
                            <br />
                            empname:
                            <asp:TextBox ID="empnameTextBox" runat="server" Text='<%# Bind("empname") %>' />
                            <br />
                            jobcode:
                            <asp:TextBox ID="jobcodeTextBox" runat="server" Text='<%# Bind("jobcode") %>' />
                            <br />
                            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="更新" />
                            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消" />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            empcode:
                            <asp:TextBox ID="empcodeTextBox" runat="server" Text='<%# Bind("empcode") %>' />
                            <br />
                            empname:
                            <asp:TextBox ID="empnameTextBox" runat="server" Text='<%# Bind("empname") %>' />
                            <br />
                            jobcode:
                            <asp:TextBox ID="jobcodeTextBox" runat="server" Text='<%# Bind("jobcode") %>' />
                            <br />
                            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="插入" />
                            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消" />
                        </InsertItemTemplate>
                        <ItemTemplate>
                            職稱代碼:
                            <asp:Label ID="jobcodeLabel" runat="server" Text='<%# Bind("jobcode") %>' style="color: #FF0000" />
                            <br />
                        </ItemTemplate>
                    </asp:FormView>
                </div>
                <div style="float: left"></div>

                <asp:HiddenField ID="hfTeamcode" runat="server" /> <%--職員姓名--%>
                <asp:HiddenField ID="hfJobcode" runat="server" /> <%--職稱代碼--%>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                <hr />
            </td>
        </tr>
        <tr>
            <td>
            <table width="100%">
                <tr>
                    <td>
<span lang="EN-US" style="font-size:12.0pt;
font-family:標楷體">A、</span>
                    </td>
                    <td>
                            <span style="font-size:12.0pt;font-family:標楷體">受訓醫師在臨床照護督導共分為三級， O觀察模擬Observation and Simulation、S督導支援Supervision(S1：在其執行臨床照護時，督導教師共同在旁逐步完成或必要時給予協助 ； S2：在其執行臨床照護後，督導教師重新確認執行情形 ； S3：在其執行臨床照護後，必要時知會教師確認執行情形)、I獨立作業Independent。</span>

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
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                <table cellpadding="0" cellspacing="1" style="width:950px">
                    <tr class="auto-style2">
                        <td align="center" class="auto-style3" style="border: 2px solid #990033; height: 50px; background-color: #FFCCCC; color: darkblue" colspan="8">非技術項目</td>
                    </tr>
                    <tr class="auto-style2">
                        <td align="center" class="auto-style3" style="border: 2px solid #990033; width: 50px; height: 50px; background-color: #CCCCFF; color: darkblue">項次</td>
                        <td style="border: 2px solid #990033; width: 200px; height: 50px; background-color: #CCCCFF; color: darkblue" align="center">項目名稱</td>
                        <td style="border: 2px solid #990033; width: 50px; height: 50px;background-color:#FFCC99;color:darkblue" align="center">最高<br />
                            分級</td>      
                        <td style="border: 2px solid #990033; width: 50px; height: 50px; background-color: #FFCC99; color: darkblue" align="center">目前<br />
                            分級</td>
                        <td style="border: 2px solid #990033; width: 200px; height: 50px; background-color: #ffffcc; color: darkblue" align="center">1</td>
                        <td style="border: 2px solid #990033; width: 200px; height: 50px; background-color: #ccffcc; color: darkblue" align="center">2</td>
                        <td style="border: 2px solid #990033; width: 200px; height: 50px; background-color: #CCFFFF; color: darkblue" align="center">3</td>
                        <td style="border: 2px solid #990033; width: 100px; height: 50px;background-color:#FFCC99;color:darkblue" align="center">通過<br />
                            狀態</td>   
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvCheckForNurse" runat="server" AutoGenerateColumns="False" DataKeyNames="itemCode" DataSourceID="SqlDataSource2" ShowHeader="False" BorderColor="#990033" OnRowDataBound="gvCheckForNurse_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="itemCode" SortExpression="itemCode" ItemStyle-HorizontalAlign="Center" ItemStyle-Height="75px" ItemStyle-BackColor="#ffffcc">

                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("rownum") %>' Width="45px" Font-Bold="true" Font-Size="Large" ForeColor="#cc0000"></asp:Label>
                            </ItemTemplate>

                            <ItemStyle HorizontalAlign="Center" BackColor="#FFFFCC" Height="75px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="itemName" SortExpression="itemName" ItemStyle-HorizontalAlign="Center" ItemStyle-Height="75px" ItemStyle-BackColor="#ccffff">

                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("itemName") %>' Width="175px" Font-Bold="true" Font-Size="Large" ForeColor="#000099"></asp:Label>
                            </ItemTemplate>

                            <ItemStyle HorizontalAlign="Center" BackColor="#CCFFFF" Height="75px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="TopauthorizeLevel" HeaderText="TopauthorizeLevel" SortExpression="TopauthorizeLevel">
                            <ItemStyle Width="50px" Height="75px" HorizontalAlign="Center" Font-Size="Large" Font-Bold="true" ForeColor="#990033"/>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="authorizeLevel" SortExpression="authorizeLevel" ItemStyle-HorizontalAlign="Center" ItemStyle-Height="75px">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("authorizeLevel") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("authorizeLevel") %>'></asp:Label>
                                <asp:HiddenField ID="hfIsDisplay" runat="server" Value='<%# Eval("isdisplay") %>' />                                
                            </ItemTemplate>
                            <ControlStyle Width="50px" Font-Bold="true" Font-Size="Large" ForeColor="#990033" />

                            <ItemStyle HorizontalAlign="Center" Height="75px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0" class="auto-style1">
                                    <tr>
                                        <td>
                                            <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCheckStatus" runat="server" BackColor="#FFFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099" Text='<%# Eval("checkStatus") %>' Width="165px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCheckDate" runat="server" Text='<%# Eval("checkDate", "{0:D}") %>' Width="165px" BackColor="#FFFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCheckResult" runat="server" BackColor="#FFFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099" Text='<%# Eval("checkResult") %>' Width="165px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCheckTeacher" runat="server" Text='<%# Eval("empname") %>' Width="165px" BackColor="#FFFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099"></asp:Label>
                                        </td>
                                    </tr>
                        <tr>
                            <td align="center">
                                <asp:HyperLink ID="viewData1" runat="server" Target="_blank" Text="查詢內容" NavigateUrl='<%# "~/PassPortView.aspx?applicationid="+ Eval("applicationid1") %>'></asp:HyperLink>
                                <asp:HiddenField ID="hfbtnShow1" runat="server" Value='<%# Eval("allowsend1") %>' />
                            </td>
                        </tr>
                                            </table>
                                        </td>
                                    </tr>

                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" class="auto-style1">
                        <tr>
                            <td class="<%# Eval("PassDiv2") %>">
                                <table>

<%--                        <tr>
                            <td>
                                <asp:Label ID="lbCheckOrder2" runat="server" BackColor="#CCFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099" Text='<%# Eval("checkOrder2") %>' Width="165px"></asp:Label>
                            </td>
                        </tr>--%>
                        <tr>
                            <td>
                                <asp:Label ID="lblCheckStatus1" runat="server" BackColor="#CCFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099" Text='<%# Eval("checkStatus1") %>' Width="165px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCheckDate1" runat="server" Text='<%# Eval("checkDate1", "{0:D}") %>' Width="165px" BackColor="#CCFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCheckResult1" runat="server" BackColor="#CCFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099" Text='<%# Eval("checkResult1") %>' Width="165px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCheckTeacher1" runat="server" Text='<%# Eval("empname1") %>' Width="165px" BackColor="#CCFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:HyperLink ID="viewData2" runat="server" Target="_blank" Text="查詢內容" NavigateUrl='<%# "~/PassPortView.aspx?applicationid="+ Eval("applicationid2") %>'></asp:HyperLink>
                                <asp:HiddenField ID="hfbtnShow2" runat="server" Value='<%# Eval("allowsend2") %>' />
                            </td>
                        </tr>
                                </table>
                            </td>
                        </tr>

                    </table>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" class="auto-style1">
                        <tr>
                            <td class="<%# Eval("PassDiv3") %>">
                                <table>
<%--                        <tr>
                            <td>
                                <asp:Label ID="lbCheckOrder3" runat="server" BackColor="#CCFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099" Text='<%# Eval("checkOrder3") %>' Width="165px"></asp:Label>
                            </td>
                        </tr>--%>
                        <tr>
                            <td>
                                <asp:Label ID="lblCheckStatus2" runat="server" BackColor="#FFCCCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099" Text='<%# Eval("checkStatus2") %>' Width="165px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCheckDate2" runat="server" Text='<%# Eval("checkDate2", "{0:D}") %>' BackColor="#FFCCCC" Width="165px" Font-Bold="True" Font-Size="Medium" ForeColor="#000099"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCheckResult2" runat="server" Text='<%# Eval("checkResult2") %>' Width="165px" Font-Bold="True" Font-Size="Medium" ForeColor="#000099" BackColor="#FFCCCC"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCheckTeacher2" runat="server" Text='<%# Eval("empname2") %>' Width="165px" Font-Bold="True" Font-Size="Medium" ForeColor="#000099" BackColor="#FFCCCC"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:HyperLink ID="viewData3" runat="server" Target="_blank" Text="查詢內容" NavigateUrl='<%# "~/PassPortView.aspx?applicationid="+ Eval("applicationid3") %>'></asp:HyperLink>
                                <asp:HiddenField ID="hfbtnShow3" runat="server" Value='<%# Eval("allowsend3") %>' />
                            </td>
                        </tr>
                                </table>
                            </td>
                        </tr>

                    </table>
                </ItemTemplate>

<ControlStyle BackColor="#CCFFFF"></ControlStyle>
            </asp:TemplateField>
                        <asp:BoundField DataField="PassStatus" HeaderText="PassStatus" SortExpression="PassStatus">
                            <ItemStyle Width="88px" Height="75px" HorizontalAlign="Center" Font-Size="Large" Font-Bold="true" ForeColor="#990033"/>
                        </asp:BoundField>     
                    </Columns>
                </asp:GridView>
                <br />
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:dsEduActivity %>" SelectCommand="SELECT  PassPortCheckItem.itemCode ,PassPortCheckItem.itemName,
                case 
                when PassPortJobTitleItem.authenticateFrequency = 1 and appItem1.checkResult = 1 then PassPortJobTitleItem.authorizeLevel
                when PassPortJobTitleItem.authenticateFrequency = 2 and appItem2.checkResult = 1 then PassPortJobTitleItem.authorizeLevel
                when PassPortJobTitleItem.authenticateFrequency = 3 and appItem3.checkResult = 1 then PassPortJobTitleItem.authorizeLevel
                when isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel) = 'S0' and (appItem1.checkResult = 0 or appItem1.checkResult is null) then '--'
                when isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel) = 'S0' and appItem2.checkResult = 1 then 'S2'
                when isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel) = 'S0' and appItem1.checkResult = 1 then 'S1'
                else isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel)
                end
--PassPortJobTitleItem.authorizeLevel 
                    as authorizeLevel,
--end as authorizeLevel,
PassPortJobTitleItem.authorizeLevel as TopauthorizeLevel,
case 
when PassPortJobTitleItem.authenticateFrequency = 1 and appItem1.checkResult = 1 then '通過'
when PassPortJobTitleItem.authenticateFrequency = 2 and appItem2.checkResult = 1 then '通過'
when PassPortJobTitleItem.authenticateFrequency = 3 and appItem3.checkResult = 1 then '通過'
when PassPortJobTitleItem.authorizeLevel = 'I' and isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel) = 'I' then '通過'
when appitem1.itemcode is null then '未評核'
else '評核中'
end as PassStatus,
case 
when PassPortJobTitleItem.authenticateFrequency in (1) --and appItem2.checkStatus is null 
                    and not (PassPortJobTitleItem.authorizeLevel = 'I' and isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel) = 'I') then 'slash'
end as PassDiv2,
case 
when PassPortJobTitleItem.authenticateFrequency in (1,2) --and appItem3.checkStatus is null 
                    and not (PassPortJobTitleItem.authorizeLevel = 'I' and isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel) = 'I') then 'slash'
end as PassDiv3,
appItem1.checkDate,
        case 
        when appItem1.checkStatus is null and PassPortJobTitleItem.authorizeLevel = 'I' and isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel) = 'I' then '已達最高等級'
        else appItem1.checkStatus
        end as checkStatus
        ,isnull(emp1.empname,case 
        when appItem1.checkStatus ='2' then '臨教部審核通過'
        else ''
        end) as empname,appItem1.checkResult,appItem1.teacherremark,isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel)+' 第'+cast(appItem1.checkOrder as varchar)+'次' as checkOrder1 , 
appItem2.checkDate,
        case 
        when PassPortJobTitleItem.authenticateFrequency in (1) then 'N/A'
        when appItem2.checkStatus is null and PassPortJobTitleItem.authorizeLevel = 'I' and isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel) = 'I' then '已達最高等級'
        else appItem2.checkStatus
        end as checkStatus
        ,isnull(emp2.empname,case 
        when appItem2.checkStatus ='2' then '臨教部審核通過'
        else ''
        end) as empname,appItem2.checkResult,appItem2.teacherremark,isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel)+' 第'+cast(appItem2.checkOrder as varchar)+'次' as checkOrder2,
appItem3.checkDate,
        case 
        when PassPortJobTitleItem.authenticateFrequency in (1,2) then 'N/A'
        when appItem3.checkStatus is null and PassPortJobTitleItem.authorizeLevel = 'I' and isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel) = 'I' then '已達最高等級'
        else appItem3.checkStatus
        end as checkStatus
        ,isnull(emp3.empname,case 
        when appItem3.checkStatus ='2' then '臨教部審核通過'
        else ''
        end) as empname,appItem3.checkResult,appItem3.teacherremark,isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel)+' 第'+cast(appItem3.checkOrder as varchar)+'次' as checkOrder3
,row_number() over(order by PassPortCheckItem.itemCode) as rownum, 
case 
when PassPortJobTitleItem.authorizeLevel = isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel) and PassPortJobTitleItem.authorizeLevel='I' then 0
when PassPortJobTitleItem.authenticateFrequency &gt;= 1 and appItem1.applicationID is null then 1 
else 0 end as allowsend1,
case 
when PassPortJobTitleItem.authorizeLevel = isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel) and PassPortJobTitleItem.authorizeLevel='I' then 0
when PassPortJobTitleItem.authenticateFrequency &gt;=2 and appItem1.checkstatus ='2' then 1 
else 0 end as allowsend2,
case 
when PassPortJobTitleItem.authorizeLevel = isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel) and PassPortJobTitleItem.authorizeLevel='I' then 0
when PassPortJobTitleItem.authenticateFrequency &gt;=3 and appItem2.checkstatus ='2' then 1 
else 0 end as allowsend3,
case 
when PassPortJobTitleItem.authorizeLevel = isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel) and PassPortJobTitleItem.authorizeLevel in ('I') then 0
else 1 end as isdisplay,appItem1.applicationid as applicationid1,appItem2.applicationid as applicationid2,appItem3.applicationid as applicationid3


FROM [PassPortCheckItem] 

INNER JOIN [PassPortJobTitleItem] 
ON PassPortCheckItem.itemCode=PassPortJobTitleItem.itemCode
 
left JOIN   (select *,ROW_NUMBER() OVER (PARTITION BY itemcode, ApplicationMemberNumber ORDER BY checkresult desc, checkDate ) AS realCheckOrder from (select *,ROW_NUMBER() OVER (PARTITION BY itemcode, ApplicationMemberNumber, checkOrder ORDER BY checkresult desc, applicationid) AS rn from PassPortStudentApplicationItem) aa where rn = 1 --and checkorder in (1,2,3) 
                    ) as appItem1 
ON PassPortCheckItem.itemCode=appItem1.itemCode and appItem1.realcheckorder = 1 and appItem1.ApplicationMemberNumber = @empcode and appItem1.rn = 1

left join V_KmuEmp as emp1
on appItem1.designationTeacherNumber = emp1.empcode

left JOIN   (select *,ROW_NUMBER() OVER (PARTITION BY itemcode, ApplicationMemberNumber ORDER BY checkresult desc, checkDate ) AS realCheckOrder from (select *,ROW_NUMBER() OVER (PARTITION BY itemcode, ApplicationMemberNumber, checkOrder ORDER BY checkresult desc, applicationid) AS rn from PassPortStudentApplicationItem) aa where rn = 1 --and checkorder in (1,2,3) 
                    ) as appItem2 
ON PassPortCheckItem.itemCode=appItem2.itemCode and appItem2.realcheckorder = 2 and appItem2.ApplicationMemberNumber = @empcode and appItem1.rn = 1

left join V_KmuEmp as emp2
on appItem2.designationTeacherNumber = emp2.empcode

left JOIN  (select *,ROW_NUMBER() OVER (PARTITION BY itemcode, ApplicationMemberNumber ORDER BY checkresult desc, checkDate ) AS realCheckOrder from (select *,ROW_NUMBER() OVER (PARTITION BY itemcode, ApplicationMemberNumber, checkOrder ORDER BY checkresult desc, applicationid) AS rn from PassPortStudentApplicationItem) aa where rn = 1 --and checkorder in (1,2,3) 
                    ) as appItem3 
ON PassPortCheckItem.itemCode=appItem3.itemCode and appItem3.realcheckorder = 3 and appItem3.ApplicationMemberNumber = @empcode and appItem1.rn = 1

left join V_KmuEmp as emp3
on appItem3.designationTeacherNumber = emp3.empcode

left join PassPortSpecialList as speciallist
on speciallist.itemcode = PassPortCheckItem.itemcode and speciallist.empcode = @empcode

where [PassPortJobTitleItem].jobtitlecode =@jobcode
and PassPortCheckItem.topTeamCode = dbo.fn_GetTopTeamCode(@topteamcode)  and PassPortCheckItem.ItemGroup = 1
order by PassPortCheckItem.itemCode">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtSearchEmpCode" Name="empcode" PropertyName="Text" />
                        <asp:ControlParameter ControlID="hfJobcode" Name="jobcode" PropertyName="Value" /> <%--職稱代碼--%>
                        <asp:ControlParameter ControlID="hfTeamcode" Name="topteamcode" PropertyName="Value" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>

<tr>
            <td class="auto-style4">
                <table cellpadding="0" cellspacing="1" style="width:950px">
                    <tr class="auto-style2">
                        <td align="center" class="auto-style3" style="border: 2px solid #990033; height: 50px; background-color: #FFCCCC; color: darkblue" colspan="8">技術項目</td>
                    </tr>
                    <tr class="auto-style2">
                        <td align="center" class="auto-style3" style="border: 2px solid #990033; width: 50px; height: 50px; background-color: #CCCCFF; color: darkblue">項次</td>
                        <td style="border: 2px solid #990033; width: 200px; height: 50px; background-color: #CCCCFF; color: darkblue" align="center">項目名稱</td>
                        <td style="border: 2px solid #990033; width: 50px; height: 50px;background-color:#FFCC99;color:darkblue" align="center">最高<br />
                            分級</td>      
                        <td style="border: 2px solid #990033; width: 50px; height: 50px; background-color: #FFCC99; color: darkblue" align="center">目前<br />
                            分級</td>
                        <td style="border: 2px solid #990033; width: 200px; height: 50px; background-color: #ffffcc; color: darkblue" align="center">1</td>
                        <td style="border: 2px solid #990033; width: 200px; height: 50px; background-color: #ccffcc; color: darkblue" align="center">2</td>
                        <td style="border: 2px solid #990033; width: 200px; height: 50px; background-color: #CCFFFF; color: darkblue" align="center">3</td>
                        <td style="border: 2px solid #990033; width: 100px; height: 50px;background-color:#FFCC99;color:darkblue" align="center">通過<br />
                            狀態</td>   
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="itemCode" DataSourceID="SqlDataSource3" ShowHeader="False" BorderColor="#990033" OnRowDataBound="gvCheckForNurse_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="itemCode" SortExpression="itemCode" ItemStyle-HorizontalAlign="Center" ItemStyle-Height="75px" ItemStyle-BackColor="#ffffcc">

                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("rownum") %>' Width="45px" Font-Bold="true" Font-Size="Large" ForeColor="#cc0000"></asp:Label>
                            </ItemTemplate>

                            <ItemStyle HorizontalAlign="Center" BackColor="#FFFFCC" Height="75px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="itemName" SortExpression="itemName" ItemStyle-HorizontalAlign="Center" ItemStyle-Height="75px" ItemStyle-BackColor="#ccffff">

                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("itemName") %>' Width="175px" Font-Bold="true" Font-Size="Large" ForeColor="#000099"></asp:Label>
                            </ItemTemplate>

                            <ItemStyle HorizontalAlign="Center" BackColor="#CCFFFF" Height="75px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="TopauthorizeLevel" HeaderText="TopauthorizeLevel" SortExpression="TopauthorizeLevel">
                            <ItemStyle Width="50px" Height="75px" HorizontalAlign="Center" Font-Size="Large" Font-Bold="true" ForeColor="#990033"/>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="authorizeLevel" SortExpression="authorizeLevel" ItemStyle-HorizontalAlign="Center" ItemStyle-Height="75px">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("authorizeLevel") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("authorizeLevel") %>'></asp:Label>
                                <asp:HiddenField ID="hfIsDisplay" runat="server" Value='<%# Eval("isdisplay") %>' />                                
                            </ItemTemplate>
                            <ControlStyle Width="50px" Font-Bold="true" Font-Size="Large" ForeColor="#990033" />

                            <ItemStyle HorizontalAlign="Center" Height="75px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0" class="auto-style1">
                                    <tr>
                                        <td>
                                            <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCheckStatus" runat="server" BackColor="#FFFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099" Text='<%# Eval("checkStatus") %>' Width="165px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCheckDate" runat="server" Text='<%# Eval("checkDate", "{0:D}") %>' Width="165px" BackColor="#FFFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCheckResult" runat="server" BackColor="#FFFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099" Text='<%# Eval("checkResult") %>' Width="165px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCheckTeacher" runat="server" Text='<%# Eval("empname") %>' Width="165px" BackColor="#FFFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099"></asp:Label>
                                        </td>
                                    </tr>
                        <tr>
                            <td align="center">
                                <asp:HyperLink ID="viewData1" runat="server" Target="_blank" Text="查詢內容" NavigateUrl='<%# "~/PassPortView.aspx?applicationid="+ Eval("applicationid1") %>'></asp:HyperLink>
                                <asp:HiddenField ID="hfbtnShow1" runat="server" Value='<%# Eval("allowsend1") %>' />
                            </td>
                        </tr>
                                            </table>
                                        </td>
                                    </tr>

                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" class="auto-style1">
                        <tr>
                            <td class="<%# Eval("PassDiv2") %>">
                                <table>

<%--                        <tr>
                            <td>
                                <asp:Label ID="lbCheckOrder2" runat="server" BackColor="#CCFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099" Text='<%# Eval("checkOrder2") %>' Width="165px"></asp:Label>
                            </td>
                        </tr>--%>
                        <tr>
                            <td>
                                <asp:Label ID="lblCheckStatus1" runat="server" BackColor="#CCFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099" Text='<%# Eval("checkStatus1") %>' Width="165px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCheckDate1" runat="server" Text='<%# Eval("checkDate1", "{0:D}") %>' Width="165px" BackColor="#CCFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCheckResult1" runat="server" BackColor="#CCFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099" Text='<%# Eval("checkResult1") %>' Width="165px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCheckTeacher1" runat="server" Text='<%# Eval("empname1") %>' Width="165px" BackColor="#CCFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:HyperLink ID="viewData2" runat="server" Target="_blank" Text="查詢內容" NavigateUrl='<%# "~/PassPortView.aspx?applicationid="+ Eval("applicationid2") %>'></asp:HyperLink>
                                <asp:HiddenField ID="hfbtnShow2" runat="server" Value='<%# Eval("allowsend2") %>' />
                            </td>
                        </tr>
                                </table>
                            </td>
                        </tr>

                    </table>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" class="auto-style1">
                        <tr>
                            <td class="<%# Eval("PassDiv3") %>">
                                <table>
<%--                        <tr>
                            <td>
                                <asp:Label ID="lbCheckOrder3" runat="server" BackColor="#CCFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099" Text='<%# Eval("checkOrder3") %>' Width="165px"></asp:Label>
                            </td>
                        </tr>--%>
                        <tr>
                            <td>
                                <asp:Label ID="lblCheckStatus2" runat="server" BackColor="#FFCCCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099" Text='<%# Eval("checkStatus2") %>' Width="165px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCheckDate2" runat="server" Text='<%# Eval("checkDate2", "{0:D}") %>' BackColor="#FFCCCC" Width="165px" Font-Bold="True" Font-Size="Medium" ForeColor="#000099"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCheckResult2" runat="server" Text='<%# Eval("checkResult2") %>' Width="165px" Font-Bold="True" Font-Size="Medium" ForeColor="#000099" BackColor="#FFCCCC"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCheckTeacher2" runat="server" Text='<%# Eval("empname2") %>' Width="165px" Font-Bold="True" Font-Size="Medium" ForeColor="#000099" BackColor="#FFCCCC"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:HyperLink ID="viewData3" runat="server" Target="_blank" Text="查詢內容" NavigateUrl='<%# "~/PassPortView.aspx?applicationid="+ Eval("applicationid3") %>'></asp:HyperLink>
                                <asp:HiddenField ID="hfbtnShow3" runat="server" Value='<%# Eval("allowsend3") %>' />
                            </td>
                        </tr>
                                </table>
                            </td>
                        </tr>

                    </table>
                </ItemTemplate>

<ControlStyle BackColor="#CCFFFF"></ControlStyle>
            </asp:TemplateField>
                        <asp:BoundField DataField="PassStatus" HeaderText="PassStatus" SortExpression="PassStatus">
                            <ItemStyle Width="88px" Height="75px" HorizontalAlign="Center" Font-Size="Large" Font-Bold="true" ForeColor="#990033"/>
                        </asp:BoundField>     
                    </Columns>
                </asp:GridView>
                <br />
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:dsEduActivity %>" SelectCommand="SELECT  PassPortCheckItem.itemCode ,PassPortCheckItem.itemName,
case 
when PassPortJobTitleItem.authenticateFrequency = 1 and appItem1.checkResult = 1 then PassPortJobTitleItem.authorizeLevel
when PassPortJobTitleItem.authenticateFrequency = 2 and appItem2.checkResult = 1 then PassPortJobTitleItem.authorizeLevel
when PassPortJobTitleItem.authenticateFrequency = 3 and appItem3.checkResult = 1 then PassPortJobTitleItem.authorizeLevel
when isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel) = 'S0' and (appItem1.checkResult = 0 or appItem1.checkResult is null) then '--'
when isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel) = 'S0' and appItem2.checkResult = 1 then 'S2'
when isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel) = 'S0' and appItem1.checkResult = 1 then 'S1'
else isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel)
end
--PassPortJobTitleItem.authorizeLevel 
                    as authorizeLevel,
--end as authorizeLevel,
PassPortJobTitleItem.authorizeLevel as TopauthorizeLevel,
case 
when PassPortJobTitleItem.authenticateFrequency = 1 and appItem1.checkResult = 1 then '通過'
when PassPortJobTitleItem.authenticateFrequency = 2 and appItem2.checkResult = 1 then '通過'
when PassPortJobTitleItem.authenticateFrequency = 3 and appItem3.checkResult = 1 then '通過'
when PassPortJobTitleItem.authorizeLevel = 'I' and isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel) = 'I' then '通過'
when appitem1.itemcode is null then '未評核'
else '評核中'
end as PassStatus,
case 
when PassPortJobTitleItem.authenticateFrequency in (1) --and appItem2.checkStatus is null 
                    and not (PassPortJobTitleItem.authorizeLevel = 'I' and isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel) = 'I') then 'slash'
end as PassDiv2,
case 
when PassPortJobTitleItem.authenticateFrequency in (1,2) --and appItem3.checkStatus is null 
                    and not (PassPortJobTitleItem.authorizeLevel = 'I' and isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel) = 'I') then 'slash'
end as PassDiv3,
appItem1.checkDate,
        case 
        when appItem1.checkStatus is null and PassPortJobTitleItem.authorizeLevel = 'I' and isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel) = 'I' then '已達最高等級'
        else appItem1.checkStatus
        end as checkStatus
        ,isnull(emp1.empname,
        case 
        when appItem1.checkStatus ='2' then '臨教部審核通過'
        else ''
        end) as empname,appItem1.checkResult,appItem1.teacherremark,isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel)+' 第'+cast(appItem1.checkOrder as varchar)+'次' as checkOrder1 , 
appItem2.checkDate,
        case 
        when PassPortJobTitleItem.authenticateFrequency in (1) then 'N/A'
        when appItem2.checkStatus is null and PassPortJobTitleItem.authorizeLevel = 'I' and isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel) = 'I' then '已達最高等級'
        else appItem2.checkStatus
        end as checkStatus
        ,isnull(emp2.empname,
        case 
        when appItem2.checkStatus ='2' then '臨教部審核通過'
        else ''
        end) as empname ,appItem2.checkResult,appItem2.teacherremark,isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel)+' 第'+cast(appItem2.checkOrder as varchar)+'次' as checkOrder2,
appItem3.checkDate,
        case 
        when PassPortJobTitleItem.authenticateFrequency in (1,2) then 'N/A'
        when appItem3.checkStatus is null and PassPortJobTitleItem.authorizeLevel = 'I' and isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel) = 'I' then '已達最高等級'
        else appItem3.checkStatus
        end as checkStatus
        ,isnull(emp3.empname,
        case 
        when appItem3.checkStatus ='2' then '臨教部審核通過'
        else ''
        end) as empname,appItem3.checkResult,appItem3.teacherremark,isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel)+' 第'+cast(appItem3.checkOrder as varchar)+'次' as checkOrder3
,row_number() over(order by PassPortCheckItem.itemCode) as rownum, 
case 
when PassPortJobTitleItem.authorizeLevel = isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel) and PassPortJobTitleItem.authorizeLevel='I' then 0
when PassPortJobTitleItem.authenticateFrequency &gt;= 1 and appItem1.applicationID is null then 1 
else 0 end as allowsend1,
case 
when PassPortJobTitleItem.authorizeLevel = isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel) and PassPortJobTitleItem.authorizeLevel='I' then 0
when PassPortJobTitleItem.authenticateFrequency &gt;=2 and appItem1.checkstatus ='2' then 1 
else 0 end as allowsend2,
case 
when PassPortJobTitleItem.authorizeLevel = isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel) and PassPortJobTitleItem.authorizeLevel='I' then 0
when PassPortJobTitleItem.authenticateFrequency &gt;=3 and appItem2.checkstatus ='2' then 1 
else 0 end as allowsend3,
case 
when PassPortJobTitleItem.authorizeLevel = isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel) and PassPortJobTitleItem.authorizeLevel in ('I') then 0
else 1 end as isdisplay,appItem1.applicationid as applicationid1,appItem2.applicationid as applicationid2,appItem3.applicationid as applicationid3

FROM [PassPortCheckItem] 

INNER JOIN [PassPortJobTitleItem] 
ON PassPortCheckItem.itemCode=PassPortJobTitleItem.itemCode
 
left JOIN   (select *,ROW_NUMBER() OVER (PARTITION BY itemcode, ApplicationMemberNumber ORDER BY checkresult desc, checkDate ) AS realCheckOrder from (select *,ROW_NUMBER() OVER (PARTITION BY itemcode, ApplicationMemberNumber, checkOrder ORDER BY checkresult desc, applicationid) AS rn from PassPortStudentApplicationItem) aa where rn = 1 --and checkorder in (1,2,3) 
                    ) as appItem1 
ON PassPortCheckItem.itemCode=appItem1.itemCode and appItem1.realcheckorder = 1 and appItem1.ApplicationMemberNumber = @empcode and appItem1.rn = 1

left join V_KmuEmp as emp1
on appItem1.designationTeacherNumber = emp1.empcode

left JOIN   (select *,ROW_NUMBER() OVER (PARTITION BY itemcode, ApplicationMemberNumber ORDER BY checkresult desc, checkDate ) AS realCheckOrder from (select *,ROW_NUMBER() OVER (PARTITION BY itemcode, ApplicationMemberNumber, checkOrder ORDER BY checkresult desc, applicationid) AS rn from PassPortStudentApplicationItem) aa where rn = 1 --and checkorder in (1,2,3) 
                    ) as appItem2 
ON PassPortCheckItem.itemCode=appItem2.itemCode and appItem2.realcheckorder = 2 and appItem2.ApplicationMemberNumber = @empcode and appItem1.rn = 1

left join V_KmuEmp as emp2
on appItem2.designationTeacherNumber = emp2.empcode

left JOIN  (select *,ROW_NUMBER() OVER (PARTITION BY itemcode, ApplicationMemberNumber ORDER BY checkresult desc, checkDate ) AS realCheckOrder from (select *,ROW_NUMBER() OVER (PARTITION BY itemcode, ApplicationMemberNumber, checkOrder ORDER BY checkresult desc, applicationid) AS rn from PassPortStudentApplicationItem) aa where rn = 1 --and checkorder in (1,2,3) 
                    ) as appItem3 
ON PassPortCheckItem.itemCode=appItem3.itemCode and appItem3.realcheckorder = 3 and appItem3.ApplicationMemberNumber = @empcode and appItem1.rn = 1

left join V_KmuEmp as emp3
on appItem3.designationTeacherNumber = emp3.empcode

left join PassPortSpecialList as speciallist
on speciallist.itemcode = PassPortCheckItem.itemcode and speciallist.empcode = @empcode

where [PassPortJobTitleItem].jobtitlecode =@jobcode
and PassPortCheckItem.topTeamCode = dbo.fn_GetTopTeamCode(@topteamcode) and PassPortCheckItem.ItemGroup = 2
order by PassPortCheckItem.itemCode">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtSearchEmpCode" Name="empcode" PropertyName="Text" />
                        <asp:ControlParameter ControlID="hfJobcode" Name="jobcode" PropertyName="Value" />
                        <asp:ControlParameter ControlID="hfTeamcode" Name="topteamcode" PropertyName="Value" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>

    </table>
</asp:Content>

