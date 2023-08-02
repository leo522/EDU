<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ScoreSettingAdd.aspx.cs" Inherits="ScoreSettingAdd" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="TreeViewComboBox.ascx" tagname="TreeViewComboBox" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}
.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;zoom:1;display:-moz-inline-stack;display:inline-block;display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px/16px "Segoe UI",Arial,Helvetica,sans-serif}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox input{height:auto;box-shadow:none;outline:0}.RadComboBox input{height:auto;box-shadow:none;outline:0}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.2.717.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}
        .RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.3.1114.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<script type="text/javascript">
    function ElementClick(btn, id, hiddenid, postback) {
        var lbtn = document.getElementById(btn);
        if (lbtn != null) {
            theform = document.forms["form1"];
            var hidden = document.getElementById(hiddenid);
            hidden.value = id;

            if (postback) {
                lbtn.click();
            }
        }
    }
</script>
    <table>
        <tr>
            <td>
        
        <asp:Label ID="Label10" runat="server" Text="設定名稱："></asp:Label>
        
            </td>
            <td>
        
                <asp:TextBox ID="tbSettingName" runat="server" Width="221px"></asp:TextBox>
        
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
        
        <asp:Label ID="Label9" runat="server" Text="部門："></asp:Label>
        
            </td>
            <td>
        
        <telerik:RadComboBox ID="ddlUnit" Runat="server" Filter="Contains" Width="300px">
        </telerik:RadComboBox>
        
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
        <asp:Label ID="Label5" runat="server" Text="職稱："></asp:Label>
            </td>
            <td>
        
        <uc1:TreeViewComboBox ID="tvcbJobs" runat="server" 
            AllowSelectParent="False" AutoPostBack="False" Enabled="True" 
            TreeDataFieldID="code" TreeDataFieldParentID="ParentCodeRefID" 
            TreeDataSourceID="dsJobCode" TreeDataTextField="Name" Width="300px" />
        
                <asp:ImageButton ID="btnAddJobCode" runat="server" ImageUrl="~/Images/add.jpg" ToolTip="新增" OnClick="btnAddJobCode_Click" />
        
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <telerik:RadGrid ID="rgJob" runat="server" AutoGenerateColumns="False" AutoGenerateDeleteColumn="True" CellSpacing="0" GridLines="None" Width="400px" OnDeleteCommand="rgJob_DeleteCommand">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn DataField="JobName" FilterControlAltText="Filter JobName column" HeaderText="職稱" UniqueName="JobName">
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
        <asp:Label ID="Label11" runat="server" Text="分數項目："></asp:Label>
            </td>
            <td>
                <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1" SelectedIndex="0">
                    <Tabs>
                        <telerik:RadTab runat="server" PageViewID="rpvForm" Selected="True" Text="表單">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" PageViewID="rpvUserDefine" Text="自訂分數">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage ID="RadMultiPage1" Runat="server" SelectedIndex="0" Width="436px">
                    <telerik:RadPageView ID="rpvForm" runat="server" Width="700px">
                        <asp:Label ID="Label7" runat="server" Text="表單："></asp:Label>
                        <telerik:RadComboBox ID="rcbTemplateID" Runat="server" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="rcbTemplateID_SelectedIndexChanged">
                        </telerik:RadComboBox>
                        <asp:LinkButton ID="lbtnPostBack" runat="server" onclick="lbtnPostBack_Click"></asp:LinkButton>
                        <br />
                        <asp:Panel ID="Panel1" runat="server" Height="200" ScrollBars="Auto">
                            <div id="htmlContent" runat="server">
                            </div>
                        </asp:Panel>
                        <div>
                            <asp:Label ID="Label13" runat="server" Text="選取項目："></asp:Label>
                            <asp:Label ID="lbSelectedFormElement" runat="server"></asp:Label>
    <input id="HiddenID" runat="server" type="hidden" />
   
    <input id="HiddenName" runat="server" type="hidden" />

    <input id="HiddenType" runat="server" type="hidden" />

    <input id="HiddenDisplayname" runat="server" type="hidden" />
                        </div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="rpvUserDefine" runat="server">
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="分數比例："></asp:Label>
                <telerik:RadNumericTextBox ID="rntbPercent" Runat="server" Width="60px">
<NegativeStyle Resize="None"></NegativeStyle>

<NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>

<EmptyMessageStyle Resize="None"></EmptyMessageStyle>

<ReadOnlyStyle Resize="None"></ReadOnlyStyle>

<FocusedStyle Resize="None"></FocusedStyle>

<DisabledStyle Resize="None"></DisabledStyle>

<InvalidStyle Resize="None"></InvalidStyle>

<HoveredStyle Resize="None"></HoveredStyle>

<EnabledStyle Resize="None"></EnabledStyle>
                </telerik:RadNumericTextBox>
                <asp:Label ID="Label14" runat="server" Text="%"></asp:Label>
        
            </td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Label ID="Label12" runat="server" Text="項目名稱："></asp:Label>
                <asp:TextBox ID="tbValueName" runat="server" Width="140px"></asp:TextBox>
&nbsp;<asp:Button ID="btnAdd0" runat="server" OnClick="btnAdd0_Click" Text="加入臨床科分數" />
                <asp:Button ID="btnAdd1" runat="server" OnClick="btnAdd0_Click" Text="加入臨教部分數" />
        
            </td>
            <td></td>
        </tr>

        <tr>
            <td></td>
            <td>
                <table width="100%">
                    <tr>
                        <td width="50%" align="center">

                            <asp:Label ID="Label15" runat="server" BackColor="#00CCFF" Height="100%" Text="臨床科分數" Width="100%"></asp:Label>

                        </td>
                        <td width="50%" align="center">

                            <asp:Label ID="Label16" runat="server" BackColor="#00CCFF" Height="100%" Text="臨教部分數" Width="100%"></asp:Label>

                        </td>
                    </tr>
                    <tr>
                        <td align="center">

                            <asp:Label ID="Label17" runat="server" Text="臨床科分數佔比："></asp:Label>
                <telerik:RadNumericTextBox ID="rntbPercent0" Runat="server" Width="60px">
<NegativeStyle Resize="None"></NegativeStyle>

<NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>

<EmptyMessageStyle Resize="None"></EmptyMessageStyle>

<ReadOnlyStyle Resize="None"></ReadOnlyStyle>

<FocusedStyle Resize="None"></FocusedStyle>

<DisabledStyle Resize="None"></DisabledStyle>

<InvalidStyle Resize="None"></InvalidStyle>

<HoveredStyle Resize="None"></HoveredStyle>

<EnabledStyle Resize="None"></EnabledStyle>
                </telerik:RadNumericTextBox>

                        </td>
                        <td align="center">

                            <asp:Label ID="Label18" runat="server" Text="臨教部分數佔比："></asp:Label>
                <telerik:RadNumericTextBox ID="rntbPercent1" Runat="server" Width="60px">
<NegativeStyle Resize="None"></NegativeStyle>

<NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>

<EmptyMessageStyle Resize="None"></EmptyMessageStyle>

<ReadOnlyStyle Resize="None"></ReadOnlyStyle>

<FocusedStyle Resize="None"></FocusedStyle>

<DisabledStyle Resize="None"></DisabledStyle>

<InvalidStyle Resize="None"></InvalidStyle>

<HoveredStyle Resize="None"></HoveredStyle>

<EnabledStyle Resize="None"></EnabledStyle>
                </telerik:RadNumericTextBox>

                        </td>
                    </tr>
                    <tr>
                        <td>
                <telerik:RadGrid ID="rgFeilds" runat="server" AutoGenerateColumns="False" AutoGenerateDeleteColumn="True" CellSpacing="0" GridLines="None" Width="400px" OnDeleteCommand="rgFeilds_DeleteCommand">
                    <MasterTableView DataKeyNames="ValueType,ValueID,ValueParameter">
                        <Columns>
                            <telerik:GridBoundColumn DataField="ValueType" FilterControlAltText="Filter JobName column" HeaderText="項目類別" UniqueName="ValueType">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ValueName" FilterControlAltText="Filter ValueName column" HeaderText="項目名稱" UniqueName="ValueName">
                            </telerik:GridBoundColumn>
                            <telerik:GridNumericColumn DataField="ScorePercent" DataFormatString="{0}%" DecimalDigits="0" FilterControlAltText="Filter ScorePercent column" HeaderText="分數比例" UniqueName="ScorePercent">
                            </telerik:GridNumericColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
                        </td>
                        <td>

                <telerik:RadGrid ID="rgFeilds2" runat="server" AutoGenerateColumns="False" AutoGenerateDeleteColumn="True" CellSpacing="0" GridLines="None" Width="400px" OnDeleteCommand="rgFeilds_DeleteCommand">
                    <MasterTableView DataKeyNames="ValueType,ValueID,ValueParameter">
                        <Columns>
                            <telerik:GridBoundColumn DataField="ValueType" FilterControlAltText="Filter JobName column" HeaderText="項目類別" UniqueName="ValueType">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ValueName" FilterControlAltText="Filter ValueName column" HeaderText="項目名稱" UniqueName="ValueName">
                            </telerik:GridBoundColumn>
                            <telerik:GridNumericColumn DataField="ScorePercent" DataFormatString="{0}%" DecimalDigits="0" FilterControlAltText="Filter ScorePercent column" HeaderText="分數比例" UniqueName="ScorePercent">
                            </telerik:GridNumericColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>

                        </td>
                    </tr>
                </table>

            </td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="儲存設定" OnClick="btnSave_Click" />
&nbsp;
                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="回清單" />
            </td>
            <td></td>
        </tr>
    </table>

    <asp:ObjectDataSource ID="dsJobCode" runat="server" SelectMethod="GetCodeRefsStatic" 
        TypeName="KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService" 
        DataObjectTypeName="KMU.EduActivity.ApplicationLayer.DTO.V_CodeRefDto">
        <SelectParameters>
            <asp:Parameter DefaultValue="EduAct_JobSerial" Name="codetype" />
        </SelectParameters>
    </asp:ObjectDataSource>
    
    </asp:Content>

