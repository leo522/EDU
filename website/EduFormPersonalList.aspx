<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EduFormPersonalList.aspx.cs" Inherits="EduFormPersonalList" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<%@ Register src="VsSelector.ascx" tagname="VsSelector" tagprefix="uc1" %>

<%@ Register src="UserControls/EduTermSelect.ascx" tagname="EduTermSelect" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>

        <telerik:RadGrid ID="rgData" runat="server" AutoGenerateColumns="False" 
            CellSpacing="0" GridLines="None" AllowMultiRowSelection="True" Culture="zh-TW" OnItemCreated="rgData_ItemCreated" OnNeedDataSource="rgData_NeedDataSource1">
            <MasterTableView DataKeyNames="INSTANCE_ID,TargetType,TargetID">
                <RowIndicatorColumn Visible="False">
                </RowIndicatorColumn>
                <Columns>
                    <telerik:GridBoundColumn DataField="INSTANCE_ID" FilterControlAltText="Filter INSTANCE_ID column" HeaderText="代碼" UniqueName="INSTANCE_ID">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="EduTermName" FilterControlAltText="Filter EduTermName column" HeaderText="課程" UniqueName="EduTermName">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="INSTANCE_NAME" FilterControlAltText="Filter INSTANCE_NAME column" HeaderText="表單" UniqueName="INSTANCE_NAME">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="TargetName" FilterControlAltText="Filter TargetName column" HeaderText="填寫人" UniqueName="TargetName">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="TargetTypeName" FilterControlAltText="Filter TargetTypeName column" HeaderText="填寫身分" UniqueName="TargetTypeName">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="EvalTargetName" FilterControlAltText="Filter EvalTargetName column" HeaderText="考核對象" UniqueName="EvalTargetName">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CreateDate" 
                        FilterControlAltText="Filter CreateDate column" HeaderText="發送日" 
                        UniqueName="CreateDate">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ExpireDate" FilterControlAltText="Filter ExpireDate column" HeaderText="逾期日" UniqueName="ExpireDate">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="StatusName" FilterControlAltText="Filter StatusName column" HeaderText="狀態" UniqueName="StatusName">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="BeforeFormStatus" FilterControlAltText="Filter BeforeFormStatus column" HeaderText="前置表單狀態" UniqueName="BeforeFormStatus">
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" UniqueName="TemplateColumn">
                        <ItemTemplate>
                            <asp:HyperLink ID="linkView" runat="server" Text="查看"></asp:HyperLink>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>

    </div>
</asp:Content>

