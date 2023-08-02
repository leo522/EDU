<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PassPortDetailPageCopy.aspx.cs" Inherits="PassPortDetailPage" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
.slash{
background: linear-gradient(25deg, transparent 49.5%, #212121 49.5%, transparent 50.5%, transparent 50.5%);
}
        p.MsoNormal {
            margin-bottom: .0001pt;
            font-size: 12.0pt;
            font-family: "Times New Roman",serif;
            margin-left: 0cm;
            margin-right: 0cm;
            margin-top: 0cm;
        }

        .新增樣式1 {
            border: medium dashed #0000FF;
        }

        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            font-family: 微軟正黑體;
            font-weight: bold;
            font-size: x-large;
        }

        .auto-style3 {
            height: 50px;
            width: 50px;
        }
        .auto-style4 {
            height: 21px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:Label ID="lblTital" runat="server" Style="font-size: xx-large; font-weight: 700; font-family: 微軟正黑體; color: #0000CC" Text="臨床照護分級學習護照"></asp:Label>
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
                    <td>
                        <span lang="EN-US" style="font-size:12.0pt;
font-family:標楷體">A、</span>
                    </td>
                    <td>

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
    <div>
        <table>
            <tr>
                <td colspan="2" style="background-color:aqua">
                    <asp:Label ID="Label2" runat="server" Font-Size="Medium" Text="完成率資訊"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Font-Size="Medium" ForeColor="Red" Text="未完成："></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbNotComplete" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label4" runat="server" Font-Size="Medium" ForeColor="Blue" Text="審核中："></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:Label ID="lbWait" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Blue"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Font-Size="Medium" Text="已完成："></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbComplete" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <table class="auto-style1" cellpadding="0" cellspacing="1">
        <tr class="auto-style2">
            <td align="center" class="auto-style3" style="border: 2px solid #990033; width: 50px; height: 50px; background-color:#FFCC99;color:darkblue">職稱</td>
            <td style="border: 2px solid #990033; width: 190px; height: 50px;background-color:#00FFCC;color:red" align="center">
                <asp:Label ID="lblObject" runat="server" Font-Size="Medium"></asp:Label>
            </td>

            <td colspan="2" style="border: 2px solid #990033; width: 100px; height: 100px;background-color:#FFCC99;color:darkblue" align="center" rowspan="2">最高<br />
                分級</td>            
            <td colspan="2" style="border: 2px solid #990033; width: 100px; height: 100px;background-color:#FFCC99;color:darkblue" align="center" rowspan="2">目前<br />
                分級</td>         
            <td style="border: 2px solid #990033; width: 600px; height: 50px;background-color:#FFCCCC;color:red" align="center" colspan="3">學習紀錄簽核</td>
            <td colspan="2" style="border: 2px solid #990033; width: 100px; height: 100px;background-color:#FFCC99;color:darkblue" align="center" rowspan="2">通過<br />
                狀態</td>         
        </tr>
        <tr class="auto-style2">
            <td align="center" class="auto-style3" style="border: 2px solid #990033; width: 50px; height: 50px;background-color:#CCCCFF;color:darkblue">項次</td>
            <td style="border: 2px solid #990033; width: 200px; height: 50px;background-color:#CCCCFF;color:darkblue" align="center">非技術項目名稱</td>
            <td style="border: 2px solid #990033; width: 150px; height: 50px;background-color:#ffffcc;color:darkblue" align="center">1</td>
            <td style="border: 2px solid #990033; width: 150px; height: 50px;background-color:#ccffcc;color:darkblue" align="center">2</td>
            <td style="border: 2px solid #990033; width: 150px; height: 50px;background-color:#CCFFFF;color:darkblue" align="center">3</td>
        </tr>
    </table>
    <asp:GridView ID="gvPassPortDetail" runat="server" AutoGenerateColumns="False" DataKeyNames="itemCode" DataSourceID="SqlDataSource1" ShowHeader="False" OnRowDataBound="gvPassPortDetail_RowDataBound" OnRowCommand="gvPassPortDetail_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="itemCode" SortExpression="itemCode">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("itemCode") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblRowNum" runat="server" Text='<%# Bind("rownum") %>'></asp:Label>
                    <asp:Label ID="lblItemCode" runat="server" Visible="false" Text='<%# Bind("itemCode") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle BackColor="#FFFFCC" Font-Bold="True" Font-Size="Large" ForeColor="#CC0000" Height="75px" HorizontalAlign="Center" Width="53px" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="itemName" SortExpression="itemName">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("itemName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("itemName") %>' Font-Size="Medium"></asp:Label>
                </ItemTemplate>
                <ItemStyle BackColor="#CCFFFF" Font-Bold="True" Font-Size="Large" ForeColor="Blue" Height="75px" HorizontalAlign="Center" Width="203px" />
            </asp:TemplateField>
            <asp:BoundField DataField="TopauthorizeLevel" HeaderText="TopauthorizeLevel" SortExpression="TopauthorizeLevel">
                <ItemStyle Width="68px" Height="75px" HorizontalAlign="Center" Font-Size="Large" Font-Bold="true" ForeColor="#990033"/>
            </asp:BoundField>
            <asp:BoundField DataField="authorizeLevel" HeaderText="authorizeLevel" SortExpression="authorizeLevel">
                <ItemStyle Width="68px" Height="75px" HorizontalAlign="Center" Font-Size="Large" Font-Bold="true" ForeColor="#990033"/>
            </asp:BoundField>
            <asp:TemplateField>
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" class="auto-style1">
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCheckStatus" runat="server" BackColor="#FFFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099" Text='<%# Eval("checkStatus") %>' Width="153px"></asp:Label>
                                            <asp:Label ID="lblCheckDate" runat="server" Text='<%# Eval("checkDate", "{0:D}") %>' Width="153px" BackColor="#FFFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCheckResult" runat="server" BackColor="#FFFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099" Text='<%# Eval("checkResult") %>' Width="153px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblDesignationTeacherNumber" runat="server" Text='<%# Eval("empname") %>' Width="153px" BackColor="#FFFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:HyperLink ID="viewData1" runat="server" Target="_blank" Text="查詢內容" NavigateUrl='<%#"~/PassPortView.aspx?applicationid="+ Eval("applicationid1") %>'></asp:HyperLink>
                                            <asp:HiddenField ID="hfbtnShow1" runat="server" Value='<%# Eval("allowsend1") %>' />
                                            <asp:Button ID="btnSendCheck1" runat="server" Text="送出" Visible="false" OnClick="btnSendCheck3_Click" />
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
                                <asp:Label ID="lbCheckOrder2" runat="server" BackColor="#CCFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099" Text='<%# Eval("checkOrder2") %>' Width="153px"></asp:Label>
                            </td>
                        </tr>--%>
                        <tr>
                            <td>
                                <asp:Label ID="lblCheckStatus1" runat="server" BackColor="#CCFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099" Text='<%# Eval("checkStatus1") %>' Width="153px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCheckDate1" runat="server" Text='<%# Eval("checkDate1", "{0:D}") %>' Width="153px" BackColor="#CCFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCheckResult1" runat="server" BackColor="#CCFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099" Text='<%# Eval("checkResult1") %>' Width="153px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDesignationTeacherNumber1" runat="server" Text='<%# Eval("empname1") %>' Width="153px" BackColor="#CCFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:HyperLink ID="viewData2" runat="server" Target="_blank" Text="查詢內容" NavigateUrl='<%#"~/PassPortView.aspx?applicationid="+ Eval("applicationid2") %>'></asp:HyperLink>
                                <asp:HiddenField ID="hfbtnShow2" runat="server" Value='<%# Eval("allowsend2") %>' />
                                <asp:Button ID="btnSendCheck2" runat="server" Text="送出" Visible="false" OnClick="btnSendCheck3_Click" />
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
                                <asp:Label ID="lbCheckOrder3" runat="server" BackColor="#CCFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099" Text='<%# Eval("checkOrder3") %>' Width="153px"></asp:Label>
                            </td>
                        </tr>--%>
                        <tr>
                            <td>
                                <asp:Label ID="lblCheckStatus2" runat="server" BackColor="#FFCCCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099" Text='<%# Eval("checkStatus2") %>' Width="153px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCheckDate2" runat="server" Text='<%# Eval("checkDate2", "{0:D}") %>' BackColor="#FFCCCC" Width="153px" Font-Bold="True" Font-Size="Medium" ForeColor="#000099"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCheckResult2" runat="server" Text='<%# Eval("checkResult2") %>' Width="153px" Font-Bold="True" Font-Size="Medium" ForeColor="#000099" BackColor="#FFCCCC"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDesignationTeacherNumber2" runat="server" Text='<%# Eval("empname2") %>' Width="153px" Font-Bold="True" Font-Size="Medium" ForeColor="#000099" BackColor="#FFCCCC"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:HyperLink ID="viewData3" runat="server" Target="_blank" Text="查詢內容" NavigateUrl='<%#"~/PassPortView.aspx?applicationid="+ Eval("applicationid3") %>'></asp:HyperLink>
                                <asp:HiddenField ID="hfbtnShow3" runat="server" Value='<%# Eval("allowsend3") %>' />
                                <asp:Button ID="btnSendCheck3" runat="server" Text="送出" Visible="false" OnClick="btnSendCheck3_Click" />
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
                <ItemStyle Width="68px" Height="75px" HorizontalAlign="Center" Font-Size="Large" Font-Bold="true" ForeColor="#990033"/>
            </asp:BoundField>            

        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dsEduActivity %>" SelectCommand="SELECT  PassPortCheckItem.itemCode ,PassPortCheckItem.itemName,
case 
when PassPortJobTitleItem.authenticateFrequency = 1 and appItem1.checkResult = 1 then PassPortJobTitleItem.authorizeLevel
when PassPortJobTitleItem.authenticateFrequency = 2 and appItem2.checkResult = 1 then PassPortJobTitleItem.authorizeLevel
when PassPortJobTitleItem.authenticateFrequency = 3 and appItem3.checkResult = 1 then PassPortJobTitleItem.authorizeLevel
when isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel) = 'S0' and (appItem1.checkResult = 0 or appItem1.checkResult is null) then '--'
when isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel) = 'S0' and appItem2.checkResult = 1 then 'S2'
when isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel) = 'S0' and appItem1.checkResult = 1 then 'S1'
else isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel)
end as authorizeLevel,
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
 
left JOIN  (select *,ROW_NUMBER() OVER (PARTITION BY itemcode, ApplicationMemberNumber ORDER BY checkresult desc, checkDate ) AS realCheckOrder from (select *,ROW_NUMBER() OVER (PARTITION BY itemcode, ApplicationMemberNumber, checkOrder ORDER BY checkresult desc, applicationid) AS rn from PassPortStudentApplicationItem) aa where rn = 1 --and checkorder in (1,2,3) 
        ) as appItem1 
ON PassPortCheckItem.itemCode=appItem1.itemCode and appItem1.realcheckorder = 1 and appItem1.ApplicationMemberNumber = @empcode and appItem1.rn = 1

left join V_KmuEmp as emp1
on appItem1.designationTeacherNumber = emp1.empcode

left JOIN  (select *,ROW_NUMBER() OVER (PARTITION BY itemcode, ApplicationMemberNumber ORDER BY checkresult desc, checkDate ) AS realCheckOrder from (select *,ROW_NUMBER() OVER (PARTITION BY itemcode, ApplicationMemberNumber, checkOrder ORDER BY checkresult desc, applicationid) AS rn from PassPortStudentApplicationItem) aa where rn = 1 --and checkorder in (1,2,3) 
        ) as appItem2 
ON PassPortCheckItem.itemCode=appItem2.itemCode and appItem2.realcheckorder = 2 and appItem2.ApplicationMemberNumber = @empcode and appItem2.rn = 1

left join V_KmuEmp as emp2
on appItem2.designationTeacherNumber = emp2.empcode

left JOIN  (select *,ROW_NUMBER() OVER (PARTITION BY itemcode, ApplicationMemberNumber ORDER BY checkresult desc, checkDate ) AS realCheckOrder from (select *,ROW_NUMBER() OVER (PARTITION BY itemcode, ApplicationMemberNumber, checkOrder ORDER BY checkresult desc, applicationid) AS rn from PassPortStudentApplicationItem) aa where rn = 1 --and checkorder in (1,2,3) 
        ) as appItem3 
ON PassPortCheckItem.itemCode=appItem3.itemCode and appItem3.realcheckorder = 3 and appItem3.ApplicationMemberNumber = @empcode and appItem3.rn = 1

left join V_KmuEmp as emp3
on appItem3.designationTeacherNumber = emp3.empcode

left join PassPortSpecialList as speciallist
on speciallist.itemcode = PassPortCheckItem.itemcode and speciallist.empcode = @empcode

where [PassPortJobTitleItem].jobtitlecode =@jobcode 
and PassPortCheckItem.topTeamCode = dbo.fn_GetTopTeamCode(@topteamcode)  and PassPortCheckItem.ItemGroup = 1

order by PassPortCheckItem.itemCode" OnSelecting="SqlDataSource1_Selecting">
        <SelectParameters>
            <asp:ControlParameter ControlID="hfEmpcode" Name="empcode" PropertyName="Value" />
            <asp:ControlParameter ControlID="hfJobcode" Name="jobcode" PropertyName="Value" />
            <asp:ControlParameter ControlID="hfTeamcode" Name="topteamcode" PropertyName="Value" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />

<table class="auto-style1" cellpadding="0" cellspacing="1">
        <tr class="auto-style2">
            <td align="center" class="auto-style3" style="border: 2px solid #990033; width: 50px; height: 50px; background-color:#FFCC99;color:darkblue">職稱</td>
            <td style="border: 2px solid #990033; width: 190px; height: 50px;background-color:#00FFCC;color:red" align="center">
                <asp:Label ID="lblObject2" runat="server" Font-Size="Medium"></asp:Label>
            </td>

            <td colspan="2" style="border: 2px solid #990033; width: 100px; height: 100px;background-color:#FFCC99;color:darkblue" align="center" rowspan="2">最高<br />
                分級</td>            
            <td colspan="2" style="border: 2px solid #990033; width: 100px; height: 100px;background-color:#FFCC99;color:darkblue" align="center" rowspan="2">目前<br />
                分級</td>         
            <td style="border: 2px solid #990033; width: 600px; height: 50px;background-color:#FFCCCC;color:red" align="center" colspan="3">學習紀錄簽核</td>
            <td colspan="2" style="border: 2px solid #990033; width: 100px; height: 100px;background-color:#FFCC99;color:darkblue" align="center" rowspan="2">通過<br />
                狀態</td>         
        </tr>
        <tr class="auto-style2">
            <td align="center" class="auto-style3" style="border: 2px solid #990033; width: 50px; height: 50px;background-color:#CCCCFF;color:darkblue">項次</td>
            <td style="border: 2px solid #990033; width: 200px; height: 50px;background-color:#CCCCFF;color:darkblue" align="center">技術項目名稱</td>
            <td style="border: 2px solid #990033; width: 150px; height: 50px;background-color:#ffffcc;color:darkblue" align="center">1</td>
            <td style="border: 2px solid #990033; width: 150px; height: 50px;background-color:#ccffcc;color:darkblue" align="center">2</td>
            <td style="border: 2px solid #990033; width: 150px; height: 50px;background-color:#CCFFFF;color:darkblue" align="center">3</td>
        </tr>
    </table>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="itemCode" DataSourceID="SqlDataSource2" ShowHeader="False" OnRowDataBound="gvPassPortDetail_RowDataBound" OnRowCommand="gvPassPortDetail_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="itemCode" SortExpression="itemCode">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("itemCode") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblRowNum" runat="server" Text='<%# Bind("rownum") %>'></asp:Label>
                    <asp:Label ID="lblItemCode" runat="server" Visible="false" Text='<%# Bind("itemCode") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle BackColor="#FFFFCC" Font-Bold="True" Font-Size="Large" ForeColor="#CC0000" Height="75px" HorizontalAlign="Center" Width="53px" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="itemName" SortExpression="itemName">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("itemName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("itemName") %>' Font-Size="Medium"></asp:Label>
                </ItemTemplate>
                <ItemStyle BackColor="#CCFFFF" Font-Bold="True" Font-Size="Large" ForeColor="Blue" Height="75px" HorizontalAlign="Center" Width="203px" />
            </asp:TemplateField>
            <asp:BoundField DataField="TopauthorizeLevel" HeaderText="TopauthorizeLevel" SortExpression="TopauthorizeLevel">
                <ItemStyle Width="68px" Height="75px" HorizontalAlign="Center" Font-Size="Large" Font-Bold="true" ForeColor="#990033"/>
            </asp:BoundField>
            <asp:BoundField DataField="authorizeLevel" HeaderText="authorizeLevel" SortExpression="authorizeLevel">
                <ItemStyle Width="68px" Height="75px" HorizontalAlign="Center" Font-Size="Large" Font-Bold="true" ForeColor="#990033"/>
            </asp:BoundField>
            <asp:TemplateField>
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" class="auto-style1">
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCheckStatus" runat="server" BackColor="#FFFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099" Text='<%# Eval("checkStatus") %>' Width="153px"></asp:Label>
                                            <asp:Label ID="lblCheckDate" runat="server" Text='<%# Eval("checkDate", "{0:D}") %>' Width="153px" BackColor="#FFFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCheckResult" runat="server" BackColor="#FFFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099" Text='<%# Eval("checkResult") %>' Width="153px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblDesignationTeacherNumber" runat="server" Text='<%# Eval("empname") %>' Width="153px" BackColor="#FFFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:HyperLink ID="viewData1" runat="server" Target="_blank" Text="查詢內容" NavigateUrl='<%#"~/PassPortView.aspx?applicationid="+ Eval("applicationid1") %>'></asp:HyperLink>
                                            <asp:HiddenField ID="hfbtnShow1" runat="server" Value='<%# Eval("allowsend1") %>' />
                                            <asp:Button ID="btnSendCheck1" runat="server" Text="送出" Visible="false" OnClick="btnSendCheck3_Click" />
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
                                <asp:Label ID="lbCheckOrder2" runat="server" BackColor="#CCFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099" Text='<%# Eval("checkOrder2") %>' Width="153px"></asp:Label>
                            </td>
                        </tr>--%>
                        <tr>
                            <td>
                                <asp:Label ID="lblCheckStatus1" runat="server" BackColor="#CCFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099" Text='<%# Eval("checkStatus1") %>' Width="153px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCheckDate1" runat="server" Text='<%# Eval("checkDate1", "{0:D}") %>' Width="153px" BackColor="#CCFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCheckResult1" runat="server" BackColor="#CCFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099" Text='<%# Eval("checkResult1") %>' Width="153px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDesignationTeacherNumber1" runat="server" Text='<%# Eval("empname1") %>' Width="153px" BackColor="#CCFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:HyperLink ID="viewData2" runat="server" Target="_blank" Text="查詢內容" NavigateUrl='<%#"~/PassPortView.aspx?applicationid="+ Eval("applicationid2") %>'></asp:HyperLink>
                                <asp:HiddenField ID="hfbtnShow2" runat="server" Value='<%# Eval("allowsend2") %>' />
                                <asp:Button ID="btnSendCheck2" runat="server" Text="送出" Visible="false" OnClick="btnSendCheck3_Click" />
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
                                <asp:Label ID="lbCheckOrder3" runat="server" BackColor="#CCFFCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099" Text='<%# Eval("checkOrder3") %>' Width="153px"></asp:Label>
                            </td>
                        </tr>--%>
                        <tr>
                            <td>
                                <asp:Label ID="lblCheckStatus2" runat="server" BackColor="#FFCCCC" Font-Bold="True" Font-Size="Medium" ForeColor="#000099" Text='<%# Eval("checkStatus2") %>' Width="153px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCheckDate2" runat="server" Text='<%# Eval("checkDate2", "{0:D}") %>' BackColor="#FFCCCC" Width="153px" Font-Bold="True" Font-Size="Medium" ForeColor="#000099"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCheckResult2" runat="server" Text='<%# Eval("checkResult2") %>' Width="153px" Font-Bold="True" Font-Size="Medium" ForeColor="#000099" BackColor="#FFCCCC"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDesignationTeacherNumber2" runat="server" Text='<%# Eval("empname2") %>' Width="153px" Font-Bold="True" Font-Size="Medium" ForeColor="#000099" BackColor="#FFCCCC"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:HyperLink ID="viewData3" runat="server" Target="_blank" Text="查詢內容" NavigateUrl='<%#"~/PassPortView.aspx?applicationid="+ Eval("applicationid3") %>'></asp:HyperLink>
                                <asp:HiddenField ID="hfbtnShow3" runat="server" Value='<%# Eval("allowsend3") %>' />
                                <asp:Button ID="btnSendCheck3" runat="server" Text="送出" Visible="false" OnClick="btnSendCheck3_Click" />
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
                <ItemStyle Width="68px" Height="75px" HorizontalAlign="Center" Font-Size="Large" Font-Bold="true" ForeColor="#990033"/>
            </asp:BoundField>            

        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:dsEduActivity %>" SelectCommand="SELECT  PassPortCheckItem.itemCode ,PassPortCheckItem.itemName,
case 
when PassPortJobTitleItem.authenticateFrequency = 1 and appItem1.checkResult = 1 then PassPortJobTitleItem.authorizeLevel
when PassPortJobTitleItem.authenticateFrequency = 2 and appItem2.checkResult = 1 then PassPortJobTitleItem.authorizeLevel
when PassPortJobTitleItem.authenticateFrequency = 3 and appItem3.checkResult = 1 then PassPortJobTitleItem.authorizeLevel
when isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel) = 'S0' and (appItem1.checkResult = 0 or appItem1.checkResult is null) then '--'
when isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel) = 'S0' and appItem2.checkResult = 1 then 'S2'
when isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel) = 'S0' and appItem1.checkResult = 1 then 'S1'
else isnull(speciallist.DefaultLevel,PassPortJobTitleItem.exauthorizeLevel)
end as authorizeLevel,
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
 
left JOIN  (select *,ROW_NUMBER() OVER (PARTITION BY itemcode, ApplicationMemberNumber ORDER BY checkresult desc, checkDate ) AS realCheckOrder from (select *,ROW_NUMBER() OVER (PARTITION BY itemcode, ApplicationMemberNumber, checkOrder ORDER BY checkresult desc, applicationid) AS rn from PassPortStudentApplicationItem) aa where rn = 1 --and checkorder in (1,2,3) 
        ) as appItem1 
ON PassPortCheckItem.itemCode=appItem1.itemCode and appItem1.realcheckorder = 1 and appItem1.ApplicationMemberNumber = @empcode and appItem1.rn = 1

left join V_KmuEmp as emp1
on appItem1.designationTeacherNumber = emp1.empcode

left JOIN  (select *,ROW_NUMBER() OVER (PARTITION BY itemcode, ApplicationMemberNumber ORDER BY checkresult desc, checkDate ) AS realCheckOrder from (select *,ROW_NUMBER() OVER (PARTITION BY itemcode, ApplicationMemberNumber, checkOrder ORDER BY checkresult desc, applicationid) AS rn from PassPortStudentApplicationItem) aa where rn = 1 --and checkorder in (1,2,3) 
        ) as appItem2 
ON PassPortCheckItem.itemCode=appItem2.itemCode and appItem2.realcheckorder = 2 and appItem2.ApplicationMemberNumber = @empcode and appItem2.rn = 1

left join V_KmuEmp as emp2
on appItem2.designationTeacherNumber = emp2.empcode

left JOIN  (select *,ROW_NUMBER() OVER (PARTITION BY itemcode, ApplicationMemberNumber ORDER BY checkresult desc, checkDate ) AS realCheckOrder from (select *,ROW_NUMBER() OVER (PARTITION BY itemcode, ApplicationMemberNumber, checkOrder ORDER BY checkresult desc, applicationid) AS rn from PassPortStudentApplicationItem) aa where rn = 1 --and checkorder in (1,2,3) 
        ) as appItem3 
ON PassPortCheckItem.itemCode=appItem3.itemCode and appItem3.realcheckorder = 3 and appItem3.ApplicationMemberNumber = @empcode and appItem3.rn = 1

left join V_KmuEmp as emp3
on appItem3.designationTeacherNumber = emp3.empcode

left join PassPortSpecialList as speciallist
on speciallist.itemcode = PassPortCheckItem.itemcode and speciallist.empcode = @empcode

where [PassPortJobTitleItem].jobtitlecode =@jobcode 
and PassPortCheckItem.topTeamCode = dbo.fn_GetTopTeamCode(@topteamcode)  and PassPortCheckItem.ItemGroup = 2

order by PassPortCheckItem.itemCode" OnSelecting="SqlDataSource1_Selecting">
        <SelectParameters>
            <asp:ControlParameter ControlID="hfEmpcode" Name="empcode" PropertyName="Value" />
            <asp:ControlParameter ControlID="hfJobcode" Name="jobcode" PropertyName="Value" />
            <asp:ControlParameter ControlID="hfTeamcode" Name="topteamcode" PropertyName="Value" />
        </SelectParameters>
    </asp:SqlDataSource>




    <asp:HiddenField ID="hfJobcode" runat="server" />
    <asp:HiddenField ID="hfEmpcode" runat="server" />
    <asp:HiddenField ID="hfTeamcode" runat="server" />
    <br />
</asp:Content>
