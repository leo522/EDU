﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DepartmentQuery.aspx.cs" Inherits="DepartmentQuery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="code" HeaderText="代碼" />
                <asp:BoundField DataField="name" HeaderText="名稱" />
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
