<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EduScore.aspx.cs" Inherits="iKASA_EduScore" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
body{
    font-family:微軟正黑體!important;
}
table { 
  border:1px solid #000; 
  border-collapse:collapse;
} 
th { 
  background-color: #009FCC;
  padding:3px;
  border:1px solid #000;
  color:#fff;
} 

td { 
  border:1px solid #000;
  padding:2px;
} 

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Literal ID="liContent" runat="server"></asp:Literal>
    
    </div>
    </form>
</body>
</html>
