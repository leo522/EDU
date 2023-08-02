<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" ValidateRequest="false" CodeFile="InstanceDetial.aspx.cs" Inherits="InstanceDetial" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
.RadGrid_Default{border:1px solid #828282;background-color:white;color:#333;font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}
.RadGrid_Default{border:1px solid #828282;background-color:white;color:#333;font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid_Default .rgMasterTable{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid_Default .rgMasterTable{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid table.rgMasterTable tr .rgExpandCol{padding-left:0;padding-right:0;text-align:center}.RadGrid table.rgMasterTable tr .rgExpandCol{padding-left:0;padding-right:0;text-align:center}.RadGrid .rgHeader{cursor:default}
        .RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid_Default .rgHeader{color:#333}.RadGrid .rgHeader{cursor:default}.RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid_Default .rgHeader{color:#333}



    </style>

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">    
    
<script language="javascript" type="text/javascript">

    function printDiv() {

        var divToPrint = document.getElementById('<%= htmlContent.ClientID %>');

        var newWin = window.open('about:blank', 'PrintWindow', config = 'width=1024,height=768');

        newWin.document.write('<html><body">' + divToPrint.innerHTML + '</body></html>');

        newWin.document.close();
        newWin.focus();
        newWin.print();
        newWin.close();

        //setTimeout(function () { newWin.close(); }, 10);

    }


</script>
<div>
<IFRAME id="frmUserInfo" scrolling="no" runat="server" height="210px" width="800px">
</IFRAME >
    <br />
    <asp:HyperLink ID="btnQueryEvalTarget" runat="server" Text="查詢學習歷程" Visible ="false" Target="_blank" NavigateUrl=" "></asp:HyperLink>
    
</div>
    <asp:Panel runat="server" ID="panReturnLog" GroupingText="退回記錄" Visible="false">
        <telerik:RadGrid ID="rgReturnLog" runat="server" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None">
            <MasterTableView>
                <Columns>
                    <telerik:GridBoundColumn DataField="Return_time" FilterControlAltText="Filter Return_time column" HeaderText="退回時間" UniqueName="Return_time">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="EmpName" FilterControlAltText="Filter EmpName column" HeaderText="退回者" UniqueName="EmpName">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Return_reason" FilterControlAltText="Filter Return_reason column" HeaderText="退回原因" UniqueName="Return_reason">
                    </telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
    </asp:Panel>


    <div id="htmlContent" runat="server">
    
    </div>
    <div align="center">
        <asp:Button ID="btnAttachment" runat="server" Text="管理附件" Visible="False" />
    </div>
    <br />
    <div>
        <asp:Panel ID="panChoiceTeacher" runat="server" Visible ="false" GroupingText="請選擇老師後再送出">
            <iframe id="frameChoiceTeacher" width="100%" height="80px" frameborder="1" scrolling="no" runat="server"></iframe>
        </asp:Panel>
    </div>
    &nbsp;
    <asp:RadioButtonList ID="rblIsPass" runat="server" RepeatDirection="Horizontal" Visible="False">
        <asp:ListItem Value="true">通過</asp:ListItem>
        <asp:ListItem Value="false">不通過</asp:ListItem>
    </asp:RadioButtonList>
    <asp:Button ID="btn_submit" runat="server" onclick="btn_submit_Click" 
        Text="送出" />
    <asp:Button ID="btn_presave" runat="server" onclick="btn_submit_Click" 
        Text="暫存" />
    <asp:Label ID="lbReturn" runat="server" Text="退回原因:" Visible="False"></asp:Label>
    <asp:TextBox ID="tbReturnReason" runat="server" Visible="False" Width="210px"></asp:TextBox>
    <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="退回上一階" Visible="False" />
    <asp:Button ID="btnReturnToFirst" runat="server" OnClick="btnReturnToFirst_Click" Text="退回整份表單" Visible="False" />
    <asp:Button ID="btnTakeBack" runat="server" OnClick="btnTakeBack_Click" Text="取消送出" Visible="False" />
    <asp:Button ID="btnPrint" OnClientClick="printDiv();return false;" 
        runat="server" Text="列印" />
    <input type="button" id="cancel" value="回首頁" name="cancel" onclick="window.history.back();"/>

    </asp:Content>