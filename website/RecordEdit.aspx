<%@ Page MaintainScrollPositionOnPostback="true" Title="" Language="C#" MasterPageFile="~/SiteNoAjax.master" AutoEventWireup="true" CodeFile="RecordEdit.aspx.cs" Inherits="RecordEdit" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<%@ Register src="DeptSelector.ascx" tagname="DeptSelector" tagprefix="uc3" %>

<%@ Register src="VsSelector.ascx" tagname="VsSelector" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;-webkit-appearance:none}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}
        .auto-style1 {
            height: 23px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<script language="javascript" type="text/javascript">

    Telerik.Web.UI.Editor.ClipboardImagesProvider.prototype.supportsClipboardData = function (event) {
        //alert("不支援直接貼圖，請利用功能列右方的圖片管理功能插入圖片");
        return false;
    }


    function OnClientPasteHtml(editor, args) {
        var value = args.get_value();
        if (value.indexOf("data:") >= 0) {
            var strippedContent = value.replace(/\<img .+?\>/ig, "");

            alert("不支援直接貼圖，請利用功能列右方的圖片管理功能插入圖片");
            args.set_value(strippedContent);
        }
        
    }


    function printDiv() {

        
        var lb = document.getElementById('<%= lbID.ClientID%>');
        var newWin = window.open('RecordPrint.aspx?InstanceID=' + lb.innerText, 'PrintWindow', config = 'width=1024,height=768');

        //newWin.focus();
        //newWin.print();
        //newWin.close();

        //setTimeout(function () { newWin.close(); }, 30);

    }

</script>
    <asp:Panel ID="panAll" runat="server">
        <div style="display:none"> 
        <asp:Label ID="lbID" runat="server"></asp:Label>
    </div>
    <table width="100%">
        <tr>
            <td valign="top">
                <asp:Panel ID="panMain" runat="server">
    <table>
        <tr>
            <td class="auto-style1">

                <asp:Label ID="Label3" runat="server" Text="會議主題："></asp:Label>

            </td>
            <td class="auto-style1">

                <asp:TextBox ID="tbTitle" runat="server" Width="393px"></asp:TextBox>

            </td>
            <td class="auto-style1">

            </td>
            <td class="auto-style1">

            </td>

        </tr>
        <tr>
            <td>

                <asp:Label ID="Label5" runat="server" Text="會議科別"></asp:Label>

            </td>
            <td colspan="3">
                                    <uc3:DeptSelector ID="DeptSelector1" runat="server" WithEmptyDept="true" />
                                    </td>
        </tr>
        <tr>
            <td>

                <asp:Label ID="Label4" runat="server" Text="會議時間："></asp:Label>

            </td>
            <td colspan="3">
                <table>
                    <tr>
                        <td>
                            
                            <telerik:RadDateTimePicker ID="rdtpSdate" Runat="server" Width="190px" Culture="es-US">
                                <TimeView CellSpacing="-1" Culture="es-US" Interval="00:30:00">
                                </TimeView>
                                <TimePopupButton HoverImageUrl="" ImageUrl="" />
                                <Calendar EnableWeekends="True" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                </Calendar>
                                <DateInput DateFormat="yyyy/MM/dd HH:mm" DisplayDateFormat="yyyy/MM/dd HH:mm" LabelWidth="40%">
                                    <EmptyMessageStyle Resize="None" />
                                    <ReadOnlyStyle Resize="None" />
                                    <FocusedStyle Resize="None" />
                                    <DisabledStyle Resize="None" />
                                    <InvalidStyle Resize="None" />
                                    <HoveredStyle Resize="None" />
                                    <EnabledStyle Resize="None" />
                                </DateInput>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                            </telerik:RadDateTimePicker>
                            
                        </td>
                        <td>
                            ~
                        </td>
                        <td>

                            <telerik:RadDateTimePicker ID="rdtpEdate" Runat="server" Width="190px" Culture="en-US">
                                <TimeView CellSpacing="-1" Interval="00:30:00">
                                </TimeView>
                                <TimePopupButton HoverImageUrl="" ImageUrl="" />
                                <Calendar EnableWeekends="True" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                </Calendar>
                                <DateInput DateFormat="yyyy/MM/dd HH:mm" DisplayDateFormat="yyyy/MM/dd HH:mm" LabelWidth="40%">
                                    <EmptyMessageStyle Resize="None" />
                                    <ReadOnlyStyle Resize="None" />
                                    <FocusedStyle Resize="None" />
                                    <DisabledStyle Resize="None" />
                                    <InvalidStyle Resize="None" />
                                    <HoveredStyle Resize="None" />
                                    <EnabledStyle Resize="None" />
                                </DateInput>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                            </telerik:RadDateTimePicker>

                        </td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td colspan="4">

                <asp:CheckBox ID="cbIsPublic" runat="server" Text="公開 (若選擇公開，本記錄簽核完成後所有系統用戶皆可查閱會議記錄內容)" />

            </td>
        </tr>
    </table>
                    </asp:Panel>
            </td>
            <td align="right">
                <table>
                    <tr>
                        <td align="center" valign="bottom">
                            <asp:Label Visible="False" ID="Label6" runat="server" Text="簽到請掃描QR Code" BackColor="Aqua" Font-Bold="True" Font-Size="Medium"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="top">
                             <asp:Image ID="imgSignIn" runat="server" Visible="False" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    <div>

        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

    </div>
    <div>
        <asp:Panel GroupingText="簽到名單" runat="server" ID="panSignIn">
                    <asp:UpdatePanel ID="upSignIn" runat="server">
                        <ContentTemplate>
            <div>
                <asp:Panel runat="server" ID="panAddSignIn">
<telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" 
            SelectedIndex="0" Skin="WebBlue">
        <Tabs>
            <telerik:RadTab runat="server" PageViewID="RadPageView1" 
                Text="新增對象" Selected="True">
            </telerik:RadTab>
            <telerik:RadTab runat="server" PageViewID="RadPageView2" Text="出席者上傳">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>

<telerik:RadMultiPage ID="RadMultiPage1" Runat="server" BorderColor="Black" 
            BorderStyle="Solid" BorderWidth="1px" SelectedIndex="0" Width="98%">
        <telerik:RadPageView ID="RadPageView1" runat="server" Selected="True">
                    <div>
                    <uc1:VsSelector ID="empSelectorSignIn" runat="server" />
                    <asp:Button ID="btnAddTargetEmp" runat="server" onclick="btnAddTargetEmp_Click" Text="新增" />
                        </div>
                    <div>

                        <asp:Label ID="lbActType" runat="server" Text="活動職類："></asp:Label>
                        <asp:RadioButtonList ID="rblActType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblActType_SelectedIndexChanged" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="0">醫師</asp:ListItem>
                            <asp:ListItem Value="1798">醫事</asp:ListItem>
                        </asp:RadioButtonList>

                        <asp:Label ID="Label24" runat="server" Text="角色："></asp:Label>
                        <asp:RadioButtonList ID="rcbRole" runat="server" DataTextField="Name" DataValueField="Code" RepeatDirection="Horizontal">
                        </asp:RadioButtonList>

                    </div>
                    <div>

                        <asp:Label ID="lbSigninMsg" runat="server"></asp:Label>

                    </div>

        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView2" runat="server" Selected="false">
            <asp:HyperLink ID="HyperLink1" runat="server" Font-Size="Medium" 
                NavigateUrl="~/sample.xls">範例下載</asp:HyperLink>
            &nbsp;
            <asp:LinkButton ID="lbRoleTypeList" runat="server" OnClick="lbRoleTypeList_Click">角色代碼表</asp:LinkButton>
            <br />
            <br />
            <asp:Label ID="Label30" runat="server" Text="選擇檔案："></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" ViewStateMode="Enabled" />
            <br />
            <asp:Button ID="btnUpload" runat="server" onclick="btnUpload_Click" Text="上傳" />
            <br />
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </telerik:RadPageView>
        </telerik:RadMultiPage>
                </asp:Panel>
            </div>
        <iframe id="frameSignIn" width="100%" height="80px" frameborder="1" scrolling="yes" runat="server"></iframe>
</ContentTemplate>
                        </asp:UpdatePanel>
        </asp:Panel>
    </div>
        <div>

            <asp:Panel ID="panRead" runat="server" GroupingText="補閱名單">
                    <asp:UpdatePanel ID="upRead" runat="server">
                        <ContentTemplate>

                <asp:Panel ID="panAddRead" runat="server">

                    <asp:Label ID="Label32" runat="server" Font-Bold="True" ForeColor="Red" Text="*會議記錄為未公開時，可經由設定補閱名單讓未參與會議的人員可於會議記錄管理中找到本會議記錄進行檢視"></asp:Label>
                    <br />

                    <uc1:VsSelector ID="VsSelector2" runat="server" />
                    <asp:Button ID="btnAddRead" runat="server" OnClick="btnAddRead_Click" Text="加入名單" />
                    &nbsp;
                    <asp:Button ID="btnRemoveRead" runat="server" OnClick="btnRemoveRead_Click" Text="移出名單" />
                </asp:Panel>
                <div>
                    <telerik:RadGrid ID="rgRead" runat="server" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None">
                        <ClientSettings>
                            <Selecting AllowRowSelect="True" />
                        </ClientSettings>
                        <MasterTableView DataKeyNames="InstanceID,Reader">
                            <Columns>
                                <telerik:GridBoundColumn DataField="Reader" FilterControlAltText="Filter Reader column" HeaderText="職編" UniqueName="Reader">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="EmpName" FilterControlAltText="Filter EmpName column" HeaderText="人員姓名" UniqueName="EmpName">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FirstReadTime" FilterControlAltText="Filter ViewTime column" HeaderText="初次檢視時間" UniqueName="FirstReadTime" Visible="False">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>
            </asp:Panel>

        </div>


        <div>
            <asp:Panel runat="server" ID="panRejectLog" GroupingText="退回記錄">

                <telerik:RadGrid ID="rgReject" runat="server" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None">
                    <ClientSettings>
                        <Selecting AllowRowSelect="True" />
                    </ClientSettings>
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn DataField="EmpName" FilterControlAltText="Filter EmpName column" HeaderText="退回人" UniqueName="EmpName">
                                <HeaderStyle Width="150px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="RejectTime" FilterControlAltText="Filter ViewTime column" HeaderText="退回時間" UniqueName="RejectTime">
                                <HeaderStyle Width="180px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="RejectReason" FilterControlAltText="Filter ViewMemo column" HeaderText="退回原因" UniqueName="RejectReason">
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>

            </asp:Panel>
        </div>
        <div>
            <asp:Panel runat="server" ID="panSign" GroupingText="簽核">
                    <asp:UpdatePanel ID="upSign" runat="server">
                        <ContentTemplate>
                <asp:Panel runat="server" ID="panAddSign" Visible="False">
                    <asp:RadioButtonList ID="RadioButtonList2" AutoPostBack="true" runat="server" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged" RepeatDirection="Horizontal" Visible="False">
                        <asp:ListItem Value="0">依序簽核</asp:ListItem>
                        <asp:ListItem Value="1">平行簽核</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:Label ID="Label31" runat="server" Font-Bold="True" ForeColor="Red" Text="*平行簽核代表所有簽核人可同時進行會議記錄簽核，為維持記錄資料正確性，設定為平行簽核時簽核人無法修改會議記錄內容" Visible="False"></asp:Label>
                    <asp:Label ID="Label34" runat="server" Font-Bold="True" ForeColor="Red" Text="*為維持記錄資料正確性，設定為同簽核次序的平行簽核人無法修改會議記錄內容"></asp:Label>
                    <br />
                    <uc1:VsSelector ID="VsSelector1" runat="server" />
                    <br />
                    <asp:Label ID="Label33" runat="server" Text="簽核次序："></asp:Label>
                    <telerik:RadNumericTextBox ID="RadNumericTextBox1" Runat="server" MaxValue="999999" MinValue="0" Width="60px">
                        <NegativeStyle Resize="None" />
                        <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                        <EmptyMessageStyle Resize="None" />
                        <ReadOnlyStyle Resize="None" />
                        <FocusedStyle Resize="None" />
                        <DisabledStyle Resize="None" />
                        <InvalidStyle Resize="None" />
                        <HoveredStyle Resize="None" />
                        <EnabledStyle Resize="None" />
                    </telerik:RadNumericTextBox>
                    <br />
                    <asp:Button ID="btnAddSign" runat="server" Text="加入簽核者" OnClick="btnAddSign_Click" />
                    &nbsp;
                    <asp:Button ID="btnRemoveSign" runat="server" Text="移除簽核者" OnClick="btnRemoveSign_Click" />
                    &nbsp;
                    <asp:Button ID="btnMoveUp" runat="server" Text="上移" OnClick="btnMoveUp_Click" Visible="False" />
                    &nbsp;<asp:Button ID="btnMoveDown" runat="server" Text="下移" OnClick="btnMoveDown_Click" Visible="False" />

                </asp:Panel>
                <div>

                    <telerik:RadGrid ID="rgSign" runat="server" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None">
                        <ClientSettings>
                            <Selecting AllowRowSelect="True" />
                        </ClientSettings>
                        <MasterTableView DataKeyNames="SN">
                            <Columns>
                                <telerik:GridBoundColumn DataField="ViewOrder" FilterControlAltText="Filter ViewOrder column" HeaderText="順序" UniqueName="ViewOrder">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="EmpName" FilterControlAltText="Filter EmpName column" HeaderText="簽核人" UniqueName="EmpName">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ViewStatus" FilterControlAltText="Filter ViewStatus column" HeaderText="簽核狀態" UniqueName="ViewStatus">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ViewTime" FilterControlAltText="Filter ViewTime column" HeaderText="簽核時間" UniqueName="ViewTime">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ViewMemo" FilterControlAltText="Filter ViewMemo column" HeaderText="備註" UniqueName="ViewMemo">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>

                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                <asp:Panel runat="server" ID="panViewerSign" Visible="False">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="簽核備註："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="tbSignMemo" runat="server" Height="54px" TextMode="MultiLine" Width="481px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnSignAgree" runat="server" Text="簽核" OnClick="btnSignAgree_Click" />
                                &nbsp;&nbsp;
                                <asp:Button ID="btnSignReject" runat="server" Text="退回" OnClick="btnSignReject_Click" />
                            </td>
                            
                        </tr>
                    </table>
                </asp:Panel>

            </asp:Panel>
        </div>
    <div>
        
        <asp:Button ID="btnPreSave" runat="server" Text="儲存" OnClick="btnPreSave_Click" />
&nbsp;&nbsp;
        <asp:Button ID="btnSubmit" runat="server" Text="確認完成" OnClick="btnSubmit_Click" OnClientClick="if(!checkConfirm()){return false;}"/>

        &nbsp;&nbsp;
        <asp:Button ID="btnSendSign" runat="server" OnClick="btnSendSign_Click" Text="確認送審" OnClientClick="if(!checkConfirm()){return false;}" Visible="False" />
        &nbsp;&nbsp;
<asp:Button ID="btnPrint" runat="server" Text="列印"  OnClientClick="printDiv();return false;" />        
        &nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="刪除" Visible="False" />
&nbsp;</div>
        </asp:Panel>
    <script>
        function checkConfirm()
        {
            var ctrl = document.getElementById('<%= cbIsPublic.ClientID %>');
            var msg = "";
            if(ctrl.checked)
            {
                msg = "你目前選擇將本會議記錄公開，公開的會議記錄所有使用者皆可查閱會議記錄內容，確定送出?";
            }
            else
            {
                msg = "你目前選擇不公開本會議記錄，不公開的會議記錄僅參與會議者及簽核者可查閱會議記錄內容，確定送出?";
            }

            return confirm(msg);

        }
    </script>
</asp:Content>

