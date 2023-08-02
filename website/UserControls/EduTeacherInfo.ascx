<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EduTeacherInfo.ascx.cs" Inherits="UserControl_EduTeacherInfo" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<p>
<table width="95%">
    <tr>
        <td align="center">
            <asp:Label ID="lbCourseName" runat="server" BackColor="#003366" Height="100%" Width="100%" Font-Size="Large" ForeColor="White"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>

            <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="0" GridLines="None" OnNeedDataSource="RadGrid1_NeedDataSource" Width="100%">
                <MasterTableView>
                    <RowIndicatorColumn Visible="False">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Created="True">
                    </ExpandCollapseColumn>
                </MasterTableView>
                <HeaderStyle Font-Size="Medium" />
                <ItemStyle Font-Size="Medium" />
            </telerik:RadGrid>

        </td>
    </tr>
</table>
</p>