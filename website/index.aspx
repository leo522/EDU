<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>


<input name="validate" type="hidden" id="validate" value="CheckAccount" /><input name="sysurl" type="hidden" id="sysurl" value="http://mr.server.kmuh.org.tw/KMUGKPI_V2/Home/AutoLogin" /><input name="loginID" type="hidden" id="loginID" value="980793" /><input name="userid" type="hidden" id="userid" value="0980793" /><input name="empcode" type="hidden" id="empcode" value="980793" /><input name="txtID" type="hidden" id="txtID" value="980793" /><input name="psnNo" type="hidden" id="psnNo" value="980793" /><input name="psnName" type="hidden" id="psnName" value="張志銘" /><input name="deptNo" type="hidden" id="deptNo" value="7000" /><input name="deptName" type="hidden" id="deptName" value="資訊室" /><input name="locNo" type="hidden" id="locNo" value="7080" /><input name="locName" type="hidden" id="locName" value="經營及行政管理組" /><input name="jobNo" type="hidden" id="jobNo" value="PROGMD" /><input name="jobName" type="hidden" id="jobName" value="初級程式設計師" /><input name="jobNoP" type="hidden" id="jobNoP" /><input name="pwd" type="hidden" id="pwd" value="S7437" /><input name="txtPasswd" type="hidden" id="txtPasswd" value="S7437" /><input name="pwd6" type="hidden" id="pwd6" value="S12350" /><input name="sysid" type="hidden" id="sysid" value="523" /><input name="l_local" type="hidden" id="l_local" value="H" /><input name="areaCode" type="hidden" id="areaCode" value="S" /><input name="areaStatus" type="hidden" id="areaStatus" /><input name="areaName" type="hidden" id="areaName" value="附院" /><input name="psnflag" type="hidden" id="psnflag" value="PSN" /><input name="txtrights" type="hidden" id="txtrights" value="3" /><input name="pwr" type="hidden" id="pwr" /><input name="timeStamp" type="hidden" id="timeStamp" value="333b09b85f7e341997468d7b7cab4853f0914c969e3c6d6243a8c2efc06280792763987bc0e24eec" />    
        <asp:LinkButton ID="LinkButton1" runat="server" 
            PostBackUrl="~/Account/Login.aspx">LinkButton</asp:LinkButton>
    </div>
    </form>
</body>
</html>
