<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormCompleteDetail.aspx.cs" Inherits="FormCompleteDetail" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
            CellSpacing="0" Culture="zh-TW" GridLines="None" 
            onneeddatasource="RadGrid1_NeedDataSource">
            <MasterTableView>
                <Columns>
                    <telerik:GridBoundColumn DataField="emp_code" 
                        FilterControlAltText="Filter emp_code column" HeaderText="填寫人職編" 
                        UniqueName="emp_code">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="emp_name" 
                        FilterControlAltText="Filter emp_name column" HeaderText="填寫人姓名" 
                        UniqueName="emp_name">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="statusname" 
                        FilterControlAltText="Filter statusname column" HeaderText="填寫狀態" 
                        UniqueName="statusname">
                    </telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
    
    </div>
    </form>
</body>
</html>
