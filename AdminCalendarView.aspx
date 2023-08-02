<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminCalendarView.aspx.cs" Inherits="AdminCalendarView" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" 
                Name="Telerik.Web.UI.Common.Core.js">
            </asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" 
                Name="Telerik.Web.UI.Common.jQuery.js">
            </asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" 
                Name="Telerik.Web.UI.Common.jQueryInclude.js">
            </asp:ScriptReference>
        </Scripts>
    </telerik:RadScriptManager>
<asp:Menu ID="Menu1" runat="server" BorderStyle="Groove" BorderWidth="1px" Orientation="Horizontal">
    <Items>
        <asp:MenuItem Text="行事曆查詢" Value="CV"></asp:MenuItem>
        <asp:MenuItem Selected="True" Text="List View" Value="LV"></asp:MenuItem>
    </Items>
    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="3px" />
    <StaticSelectedStyle BackColor="#999999" Font-Bold="True" />
</asp:Menu>
<p>
    &nbsp;</p>
    <table>
        <tr>
            <td>
<asp:Label ID="ThemeKeyword" runat="server" Text="會議主題:"></asp:Label>
            </td>
            <td>

<asp:TextBox ID="ThemeKeywordText" runat="server" Style="padding: 0px 25px 0px 0px;"></asp:TextBox>
            </td>
            <td>
<asp:Label ID="SeminarDate" runat="server" Text="會議日期:"></asp:Label>
            </td>
            <td>
<telerik:RadDatePicker ID="SeminarDateFrom" runat="server" Culture="Chinese (Taiwan)"
    Width="161px">
    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
    </Calendar>
    <DateInput DisplayDateFormat="yyyy/MM/dd" DateFormat="yyyy/MM/dd" LabelWidth="40%">
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
            <td>
-
            </td>
            <td>
<telerik:RadDatePicker ID="SeminarDateTo" runat="server" Culture="zh-TW">
    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
    </Calendar>
    <DateInput DisplayDateFormat="yyyy/MM/dd" DateFormat="yyyy/MM/dd" LabelWidth="40%">
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
            <td>


<asp:Button ID="QueryButton" runat="server" Text="查詢" 
    onclick="QueryButton_Click" />
            </td>
        </tr>
    </table>




<br />
<br />
<asp:Button ID="AddSeminar" runat="server" onclick="AddSeminar_Click" 
    Text="新增研討會" />
    <br />
    <br />
    <asp:Label ID="Labelsearchfile" runat="server"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" 
        onrowdatabound="GridView1_RowDataBound" AutoGenerateColumns="False"
        >
        <Columns>
            <asp:BoundField DataField="SeminarID" HeaderText="SeminarID" />
            <asp:BoundField DataField="ThemeDes" HeaderText="會議主題" />
            <asp:BoundField DataField="SeminarWhere" HeaderText="會議地點" />
            <asp:BoundField DataField="SeminarTimeFrom" HeaderText="會議開始時間" />
            <asp:BoundField DataField="SeminarTimeTo" HeaderText="會議結束時間" />
            <asp:BoundField DataField="SeminarCharge" HeaderText="報名費用" />
            <asp:TemplateField HeaderText="修改會議">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Button ID="Buttonfix" runat="server" Text="修改" OnClick="btn_Click" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="報名審核">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Button ID="Buttonregister" runat="server" onclick="Buttonregister_Click" 
                        Text="審核" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="投稿審核">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Button ID="Buttonsubmit" runat="server" onclick="Buttonsubmit_Click" 
                        Text="審核" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="匯出名單">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Button ID="Buttonprint" runat="server" onclick="Buttonprint_Click" 
                        Text="匯出" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="報名">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Button ID="Buttonappl" runat="server" onclick="Buttonapply_Click" 
                        Text="報名" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <p>
        <asp:GridView ID="GridView2" runat="server" Visible="False">
        </asp:GridView>
        <asp:GridView ID="GridView3" runat="server" Visible="False">
        </asp:GridView>
</p>

</asp:Content>

