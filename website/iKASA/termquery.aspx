<%@ Page Language="C#" AutoEventWireup="true" CodeFile="termquery.aspx.cs" Inherits="iKASA_termquery" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}
    .RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}
    .RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadPicker{vertical-align:middle}.rdfd_{position:absolute}.RadPicker .rcTable{table-layout:auto}.RadPicker .RadInput{vertical-align:baseline}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput .riTextBox{height:17px}
        </style>
</head>
<body>
    <script>
        function ReadIns(insid)
        {
            $('#<%=hdInsID.ClientID %>').val(insid);
            __doPostBack('lbPostBack', '');
        }

    </script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css"/>
<script src="//code.jquery.com/jquery-1.10.2.js"></script>
<script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <style type="text/css">  
body{
    font-family:微軟正黑體!important;
}
        .RadMenu_Default .rmText  
        {  
            font-size:medium !important;  
        }  
        </style> 
    <asp:Label ID="lbscript" runat="server"></asp:Label>
    <form id="form1" runat="server">
    <div>
    
        <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
        </telerik:RadScriptManager>
    
        <telerik:RadMultiPage ID="rmp" Runat="server" Width="99%">
            <telerik:RadPageView ID="rpvList" runat="server" Selected ="true">
                <div>
                    <asp:LinkButton ID="lbPostBack" runat="server" OnClick="lbPostBack_Click"></asp:LinkButton>
                    <asp:HiddenField ID="hdInsID" runat="server" />
                    <telerik:RadTreeList ExpandCollapseMode="client" Font-Names="微軟正黑體" Skin="Silk" OnNeedDataSource="RadTreeList1_NeedDataSource" ID="RadTreeList1" runat="server" AutoGenerateColumns="False" Culture="zh-TW" DataKeyNames="EduTermID" ParentDataKeyNames="ParentEduTermID" Font-Size="Medium">
                        <DetailTemplate>
                            <asp:Literal ID="LiDet" runat="server" Text='<%# Eval("DetStr") %>'></asp:Literal>
                        </DetailTemplate>
                        <ExportSettings>
                            <Excel PageLeftMargin="0.7in" PageRightMargin="0.7in">
                            </Excel>
                            <Pdf PageHeight="11in" PageWidth="8.5in">
                            </Pdf>
                        </ExportSettings>
                        <EditFormSettings EditFormType="AutoGenerated">
                        </EditFormSettings>
                        <ValidationSettings CommandsToValidate="PerformInsert,Update" />
                        <Columns>
                            <telerik:TreeListBoundColumn DataField="TermName" HeaderText="課程名稱" ItemStyle-Font-Bold="true" UniqueName="TermName">
                                <ItemStyle Font-Bold="True" />
                            </telerik:TreeListBoundColumn>
                            <telerik:TreeListBoundColumn DataField="TermRange" HeaderText="時間範圍" ItemStyle-Font-Bold="true" UniqueName="TermRange">
                                <ItemStyle Font-Bold="True" />
                            </telerik:TreeListBoundColumn>
                        </Columns>
                        <PagerStyle PageSizeControlType="RadComboBox" />
                        <HeaderStyle Font-Names="微軟正黑體" Font-Size="Medium" />
                        <ItemStyle Font-Names="微軟正黑體" Font-Size="Medium" />
                        <AlternatingItemStyle Font-Names="微軟正黑體" Font-Size="Medium" />
                        <FooterItemStyle Font-Names="微軟正黑體" Font-Size="Medium" />
                    </telerik:RadTreeList>
                </div>
            </telerik:RadPageView>
            <telerik:RadPageView ID="rpvItems" runat="server">
                <asp:Button ID="btnInsReturnMain" runat="server" OnClick="btnInsReturnMain_Click" Text="回清單" />
        <div id="htmlContent" runat="server">
    
        </div>
        <div align="center">
            <asp:Button ID="btnAttachment" runat="server" Text="表單附件" Visible="False" />
        </div>               

            </telerik:RadPageView>

        </telerik:RadMultiPage>   
    </div>
    </form>
</body>
</html>