﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EduMemberTeacherSetting.aspx.cs" Inherits="EduMemberTeacherSetting" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<%@ Register src="VsSelector.ascx" tagname="VsSelector" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}
        </style>
</head>
<body>
<script type="text/javascript">

</script>

    <form id="form1" runat="server">
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
    <div>
    
<asp:Panel ID="CoursePanel" runat="server" GroupingText="課程">
<table width="100%">
<tr>
<td>
    <asp:Label ID="Label9" runat="server" Text="課程代碼："></asp:Label>
    <asp:Label ID="lblEduStopCode" runat="server"></asp:Label>
    </td>
<td>
    <asp:Label ID="Label10" runat="server" Text="名稱："></asp:Label>
    <asp:Label ID="lblName" runat="server"></asp:Label>
    </td>
<td>
    <asp:Label ID="Label11" runat="server" Text="訓練日期："></asp:Label>
    <asp:Label ID="lblDate" runat="server"></asp:Label>
    </td>
<td>
    <asp:Label ID="Label12" runat="server" Text="人數："></asp:Label>
    <asp:Label ID="lblMemberCount" runat="server"></asp:Label>
    </td>
</tr>
</table>

</asp:Panel>
        <br />
    <table width="100%">
    <tr>
    <td colspan="2">
        <asp:Label ID="Label14" runat="server" Text="設定教師類型："></asp:Label>
        <telerik:RadComboBox ID="rcbTeacherType" Runat="server" AutoPostBack="True" 
            onselectedindexchanged="rcbTeacherType_SelectedIndexChanged">
        </telerik:RadComboBox>
        </td>
    </tr>
        <tr>
            <td colspan="2">
                <table>
                    <tr>
                        <td>
                            1.
                            <asp:Button ID="btnDownloadSample" runat="server" Text="下載匯入格式" OnClick="btnDownloadSample_Click" />
                        </td>
                        <td>
                            2.
                            <asp:Label ID="Label15" runat="server" Text="選擇檔案："></asp:Label>
                        </td>
                        <td>
                            <asp:FileUpload ID="fuImportFile" runat="server" />
                        </td>
                        <td>
                            3.
                            <asp:Button ID="btnImport" runat="server" Text="匯入" OnClientClick="if(!confirm('匯入設定將會覆蓋原有設定，是否確定匯入?')) return false;" OnClick="btnImport_Click" />
                        </td>
                    </tr>
                </table>
                <div>
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </div>
                
                
                
                


            </td>
        </tr>
    <tr>
        <td colspan="2">
        <asp:Label ID="Label13" runat="server" Text="老師 : "></asp:Label>
                            <uc1:VsSelector ID="rcbVs" runat="server" />
        <br />
        <br />
        <asp:Button ID="btnSet" runat="server" Text="設定老師" onclick="btnSet_Click" />
        &nbsp;&nbsp;
        <asp:Button ID="btnAddTeacher" runat="server" Text="新增老師" onclick="btnAddTeacher_Click" />
        &nbsp; &nbsp;
        <asp:Button ID="btnClear" runat="server" onclick="btnClear_Click" 
            Text="取消老師設定" />

        </td>
    </tr>
        <tr>
            <td colspan="2">
        <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
            CellSpacing="0" Culture="zh-TW" GridLines="None" 
            onneeddatasource="RadGrid1_NeedDataSource" AllowMultiRowSelection="True">
            <ClientSettings>
                <Selecting AllowRowSelect="True" />
            </ClientSettings>
            <MasterTableView>
                <Columns>
                    <telerik:GridClientSelectColumn FilterControlAltText="Filter column1 column" 
                        UniqueName="column1">
                    </telerik:GridClientSelectColumn>
                    <telerik:GridBoundColumn DataField="MemberName" 
                        FilterControlAltText="Filter MemberName column" HeaderText="學員" 
                        UniqueName="MemberName">
                    </telerik:GridBoundColumn>
                    
                    <telerik:GridBoundColumn DataField="TeacherNameStr" FilterControlAltText="Filter TeacherStr column" HeaderText="老師" UniqueName="TeacherNameStr">
                    </telerik:GridBoundColumn>
                    
                    <telerik:GridDateTimeColumn DataField="TeacherCreateDate" DataFormatString="{0:yyyy/MM/dd}" FilterControlAltText="Filter TeacherCreateDate column" HeaderText="設定日期" UniqueName="TeacherCreateDate">
                    </telerik:GridDateTimeColumn>
                    
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
            </td>
        </tr>
    <tr>
    <td width="35%">

        </td>
    <td width="65%" valign="top">

        </td>
    </tr>
    </table>
    </div>
    <asp:ObjectDataSource ID="odsVs" runat="server" 
        DataObjectTypeName="KMU.EduActivity.ApplicationLayer.DTO.SelectKmuVsDto" 
        SelectMethod="GetKmuVsWithEmpty" 
        TypeName="KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService" 
        onselecting="odsVs_Selecting">
    </asp:ObjectDataSource>
    </form>
</body>
</html>
