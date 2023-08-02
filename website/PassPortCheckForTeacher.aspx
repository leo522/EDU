<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PassPortCheckForTeacher.aspx.cs" Inherits="PassPortCheckForTeacher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">


        .auto-style5 {
            font-family: 微軟正黑體;
            font-weight: bold;
        }

        .auto-style6 {
            font-size: medium;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <b style="font-family: 微軟正黑體">
                <asp:Label ID="Label2" runat="server" Text="臨床照護分級學習護照導師考核介面" Font-Bold="True" Font-Size="XX-Large" ForeColor="Blue" CssClass="auto-style5"></asp:Label>
            &nbsp;&nbsp;
    <asp:Label ID="Label3" runat="server" CssClass="auto-style6" Font-Bold="True" Font-Size="Large" Text="待審核資料共:"></asp:Label>
&nbsp;<asp:Label ID="lblDataCount" runat="server" CssClass="auto-style6" Font-Bold="True" ForeColor="Red"></asp:Label>
&nbsp;<asp:Label ID="Label4" runat="server" CssClass="auto-style6" Font-Bold="True" Font-Size="Large" Text="筆"></asp:Label>
    <br />
    <hr />
    <br />
    <asp:GridView ID="gvCheckForTeacher" runat="server" AutoGenerateColumns="False" CssClass="bold" DataSourceID="SqlDataSource1" style="font-family: 微軟正黑體" OnRowCommand="gvCheckForTeacher_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="applicationID" InsertVisible="False" SortExpression="applicationID" Visible="False">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("applicationID") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblApplicationIDAuto" runat="server" Text='<%# Bind("applicationID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="applicationDate" DataFormatString="{0:D}" HeaderText="申請日期" ReadOnly="True" SortExpression="applicationDate">
            <HeaderStyle Font-Bold="True" Font-Size="Medium" Height="50px" HorizontalAlign="Center" Width="100px" />
            <ItemStyle Font-Bold="True" Font-Size="Small" Height="50px" HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="applicationMemberNumber" HeaderText="職編" SortExpression="applicationMemberNumber">
            <HeaderStyle Font-Bold="True" Font-Size="Medium" HorizontalAlign="Center" Width="50px" />
            <ItemStyle Font-Bold="True" Font-Size="Small" HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="empname" HeaderText="姓名" SortExpression="empname">
            <HeaderStyle Font-Bold="True" Font-Size="Medium" HorizontalAlign="Center" Width="50px" />
            <ItemStyle Font-Bold="True" Font-Size="Small" HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="itemName" HeaderText="考核項目" SortExpression="itemName">
            <HeaderStyle Font-Bold="True" Font-Size="Medium" HorizontalAlign="Center" Width="180px" />
            <ItemStyle Font-Bold="True" Font-Size="Small" />
            </asp:BoundField>
            <asp:BoundField DataField="checkOrder" HeaderText="考核順序" SortExpression="checkOrder">
            <HeaderStyle Font-Bold="True" Font-Size="Medium" HorizontalAlign="Center" Width="70px" />
            <ItemStyle Font-Bold="True" Font-Size="Small" HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="implementDate" DataFormatString="{0:D}" HeaderText="實作日期" SortExpression="implementDate">
            <HeaderStyle Font-Bold="True" Font-Size="Medium" HorizontalAlign="Center" Width="100px" />
            <ItemStyle Font-Bold="True" Font-Size="Small" HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="implementPlace" HeaderText="實作地點" SortExpression="implementPlace">
            <HeaderStyle Font-Bold="True" Font-Size="Medium" HorizontalAlign="Center" Width="70px" />
            <ItemStyle Font-Bold="True" Font-Size="Small" HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="考核結果" SortExpression="checkResult">
                <EditItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("checkResult") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:RadioButton ID="rdBtnPass" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#009900" GroupName="checkResult" Text="PASS" />
                    <br />
                    <asp:RadioButton ID="rdBtnFail" runat="server" BorderStyle="None" Font-Bold="True" Font-Size="Medium" ForeColor="Red" GroupName="checkResult" Text="FAIL" />
                </ItemTemplate>
                <HeaderStyle Font-Bold="True" Font-Size="Medium" HorizontalAlign="Center" Width="70px" />
                <ItemStyle Font-Bold="True" Font-Size="Small" HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:BoundField DataField="checkStatus" HeaderText="checkStatus" SortExpression="checkStatus" Visible="False" />
            <asp:BoundField DataField="checkDate" HeaderText="checkDate" SortExpression="checkDate" Visible="False" />
            <asp:TemplateField HeaderText="學員備註訊息" SortExpression="studentRemark">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("studentRemark") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" BorderStyle="None" Height="48px" ReadOnly="True" Text='<%# Bind("studentRemark") %>' TextMode="MultiLine" Width="180px"></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle Font-Bold="True" Font-Size="Medium" HorizontalAlign="Center" Width="180px" Wrap="True" />
                <ItemStyle Font-Bold="True" Font-Size="Small" Width="180px" />
            </asp:TemplateField>
            <asp:ButtonField ButtonType="Button" HeaderText="送出結果" Text="送出" CommandName="submitResult">
            <HeaderStyle Font-Bold="True" Font-Size="Medium" HorizontalAlign="Center" Width="70px" />
            <ItemStyle Font-Bold="True" Font-Size="Small" ForeColor="#CC0066" HorizontalAlign="Center" Width="60px" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="lblEmpCode" runat="server" Visible="False"></asp:Label>
    </b>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:www_EduActivityConnectionString2 %>" SelectCommand="select applicationID,applicationDate,applicationMemberNumber,emp.empname ,itemName,checkOrder,implementDate,implementPlace,checkResult,checkStatus,checkDate,studentRemark
from PassPortCheckItem
inner join PassPortStudentApplicationItem as teacherCheck

on PassPortCheckItem.itemCode=teacherCheck.itemCode
inner join V_KmuEmp as emp
on teacherCheck.applicationMemberNumber = emp.empcode

where teacherCheck.designationTeacherNumber=@empcode and teacherCheck.checkStatus='1'

order by teacherCheck.applicationDate asc">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblEmpCode" Name="empcode" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:Label ID="lblCheckResult" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblCheckStatus" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblCheckDate" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblApplicationID" runat="server" Visible="False"></asp:Label>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:www_EduActivityConnectionString2 %>" DeleteCommand="DELETE FROM [PassPortStudentApplicationItem] WHERE [applicationID] = @applicationID" InsertCommand="INSERT INTO [PassPortStudentApplicationItem] ([checkResult], [checkStatus], [checkDate]) VALUES (@checkResult, @checkStatus, @checkDate)" SelectCommand="SELECT [checkResult], [checkStatus], [checkDate], [applicationID] FROM [PassPortStudentApplicationItem]" UpdateCommand="UPDATE [PassPortStudentApplicationItem] SET [checkResult] = @checkResult, [checkStatus] = @checkStatus, [checkDate] = @checkDate WHERE [applicationID] = @applicationID">
        <DeleteParameters>
            <asp:Parameter Name="applicationID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="checkResult" Type="Boolean" />
            <asp:Parameter Name="checkStatus" Type="String" />
            <asp:Parameter DbType="Date" Name="checkDate" />
        </InsertParameters>
        <UpdateParameters>
            <asp:ControlParameter ControlID="lblCheckResult" Name="checkResult" PropertyName="Text" Type="Boolean" />
            <asp:ControlParameter ControlID="lblCheckStatus" Name="checkStatus" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="lblCheckDate" DbType="Date" Name="checkDate" PropertyName="Text" />
            <asp:ControlParameter ControlID="lblApplicationID" Name="applicationID" PropertyName="Text" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>

