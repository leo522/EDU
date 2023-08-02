<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<script type="text/javascript" src="jsdatepicker/nsftoolsDatepicker.js"></script>
<link href="jsdatepicker/nsftoolsDatepicker.css" rel="stylesheet" type="text/css" />

    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server" Width="614px"></asp:TextBox>
        <asp:Button ID="btnReCalc" runat="server" OnClick="btnReCalc_Click" Text="重算" />
        <br />
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="重算All" />
        <br />
        <asp:TextBox ID="tbFTListID" runat="server"></asp:TextBox>
        <asp:Button ID="btnSendForm" runat="server" OnClick="btnSendForm_Click" Text="發送表單" />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="重建SQL" />
        <br />
        <br />
        <asp:TextBox ID="tbFixTemplateID" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="修正template" />
        <br />
        <asp:TextBox ID="tbFixInstance" runat="server"></asp:TextBox>
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="修正instance" />
        <br />
        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="修正data" />
        <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="test" />
        <br />
        <br />
    </div>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <input type="checkbox" id="1" name="test" value="1" />1
        <input type="checkbox" id="2" name="test" value="2" />2
        <input type="checkbox" id="3" name="test" value="3" />3
        <input type="checkbox" id="4" name="test" value="4" />4
        <input type="test" id ="5" name="5" onkeydown="return false;" />
        <img src="Images/t_calendar.gif" alt="選擇日期" onclick="displayDatePicker('5', false,'ymd','/');" />
        <input type="submit" name="kkk" id="aaa" value="aaa" />
        <br />
        <br />
        <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="修正healthtime" />
        <br />
        <asp:Button ID="Button9" runat="server" OnClick="Button9_Click" Text="修正temp有onclick" />
        <br />
        <br />
        <br />
        <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="testdate" />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="物料碼："></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" Text="物料名稱"></asp:Label>
        <asp:Button ID="Button10" runat="server" Text="查詢" />
        <br />
        <br />
        <asp:Button ID="Button11" runat="server" Text="新增版次" />
        <br />
        <table style="border:solid; border-width:thick">
            <thead>
                <tr  style="border:solid; border-width:thin; background-color:aqua">
                    <th></th>
                    <th>版本</th>
                    <th>生效日</th>
                    <th>停用日</th>
                    <th>產品特性</th>
                    <th>副作用</th>
                    <th>應注意事項</th>
                    <th>與現有健保品項差異 說明與療效比較</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td><img src="Images/edit.gif" /></td>
                    <td style="border-bottom:solid" >1</td>
                    <td style="border-bottom:solid">2020/1/1</td>
                    <td style="border-bottom:solid">2020/12/31</td>
                    <td style="border-bottom:solid">用於導管治療或導管攝影檢查術後止血功能，有
別於傳統術後因加壓止造成的疼痛與起居不便。</td>
                    <td style="border-bottom:solid">可能會有過敏反應、異物反應、水腫 </td>
                    <td style="border-bottom:solid">服用抗凝血藥物或凝血不易的病人建議平躺時
間需延長 3~4 小時，有必要時可配合加壓沙袋。
手術後 2~3 小時內的病人可側翻，但傷口部位的
腳請放鬆伸直，不可彎曲。</td>
                    <td style="border-bottom:solid">
產品特性：
以徒手加壓，另輔以砂袋，來達到止血作用
副作用：
易再滲血
應注意事項：
需長時間臥床(約 24 小時)，以避免再出血
                    </td>
                </tr>
                <tr>
                    <td><img src="Images/edit.gif" /></td>
                    <td>2</td>
                    <td>2021/1/1</td>
                    <td></td>
                    <td>用於導管治療或導管攝影檢查術後止血功能，有
別於傳統術後因加壓止造成的疼痛與起居不便。</td>
                    <td>可能會有過敏反應、異物反應 </td>
                    <td>服用抗凝血藥物或凝血不易的病人建議平躺時
間需延長 3~4 小時，有必要時可配合加壓沙袋。</td>
                    <td>
產品特性：
以徒手加壓，另輔以砂袋，來達到止血作用
副作用：
易再滲血
應注意事項：
需長時間臥床(約 24 小時)，以避免再出血
                    </td>
                </tr>
            </tbody>
        </table>
        <br />
        <br />
        <br />
    </form>
</body>
</html>
