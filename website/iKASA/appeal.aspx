<%@ Page Language="C#" AutoEventWireup="true" CodeFile="appeal.aspx.cs" Inherits="iKASA_appeal" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <script src="//code.jquery.com/jquery-1.10.2.js"></script>

</head>
<body>
    <style>
body{
    font-family:微軟正黑體!important;
}
    p.MsoNormal
	{margin-bottom:.0001pt;
	line-height:133%;
	font-size:11.0pt;
	font-family:"Microsoft JhengHei";
	        margin-left: 0cm;
            margin-right: 0cm;
            margin-top: 0cm;
        }
 table.MsoNormalTable
	{line-height:133%;
	font-size:11.0pt;
	font-family:"Microsoft JhengHei";
        }
    </style>
    <form id="form1" runat="server">
        <p class="MsoNormal" style="margin-top:5.4pt;margin-right:0cm;margin-bottom:14.0pt;
margin-left:50.2pt;text-indent:-36.0pt;line-height:150%;mso-list:l0 level1 lfo2;
border:none;mso-padding-alt:31.0pt 31.0pt 31.0pt 31.0pt;mso-border-shadow:yes">
            <![if !supportLists]><b style="mso-bidi-font-weight:normal"><span lang="EN-US" style="font-size:14.0pt;
line-height:150%;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:
&quot;Times New Roman&quot;;color:black"><span style="mso-list:Ignore">1、<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span></b><![endif]><b style="mso-bidi-font-weight:normal"><span lang="EN-US" style="font-size:14.0pt;line-height:150%;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;color:black">申訴與輔導機制</span></b></p>
        <p class="MsoNormal" style="margin-top:14.0pt;line-height:150%;border:none;
mso-padding-alt:31.0pt 31.0pt 31.0pt 31.0pt;mso-border-shadow:yes">
            <b style="mso-bidi-font-weight:normal"><span lang="EN-US" style="font-size:12.0pt;
line-height:150%;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:
&quot;Times New Roman&quot;;color:black">住院醫師之抱怨及申訴管道</span></b></p>
        <p class="MsoNormal" style="margin-left:18.0pt;text-indent:-18.0pt;line-height:
150%;mso-list:l1 level1 lfo1;border:none;mso-padding-alt:31.0pt 31.0pt 31.0pt 31.0pt;
mso-border-shadow:yes">
            <![if !supportLists]><span lang="EN-US" style="font-size:
12.0pt;line-height:150%;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:
&quot;Times New Roman&quot;;color:black"><span style="mso-list:Ignore">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><![endif]><span lang="EN-US" style="font-size:12.0pt;line-height:150%;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;color:black">急診部內抱怨及申訴管道</span></p>
        <p class="MsoNormal" style="margin-left:48.0pt;text-indent:-24.0pt;line-height:
150%;mso-list:l1 level2 lfo1;border:none;mso-padding-alt:31.0pt 31.0pt 31.0pt 31.0pt;
mso-border-shadow:yes">
            <![if !supportLists]><span lang="EN-US" style="font-size:
12.0pt;line-height:150%;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:
&quot;Times New Roman&quot;;color:black"><span style="mso-list:Ignore">(1)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><![endif]><span lang="EN-US" style="font-size:12.0pt;line-height:150%;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;color:black">導師會談：每位住院醫師皆有專屬導師，提供生活及學習輔導，每月固定會談一次，住院醫師可向導師反應所遭遇之困難及各種不合理事項，由導師循管道向計畫主持人及院方反應。</span><span lang="EN-US" style="font-size:12.0pt;line-height:150%;color:black"></span></p>
        <p class="MsoNormal" style="margin-left:48.0pt;text-indent:-24.0pt;line-height:
150%;mso-list:l1 level2 lfo1;border:none;mso-padding-alt:31.0pt 31.0pt 31.0pt 31.0pt;
mso-border-shadow:yes">
            <![if !supportLists]><span lang="EN-US" style="font-size:
12.0pt;line-height:150%;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:
&quot;Times New Roman&quot;;color:black"><span style="mso-list:Ignore">(2)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><![endif]><span lang="EN-US" style="font-size:12.0pt;line-height:150%;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;color:black">教學檢討會議：每月舉行教學檢討會議，學員可適時反應學習與工作上遭遇的問題。</span><span lang="EN-US" style="font-size:12.0pt;line-height:150%;color:black"></span></p>
        <p class="MsoNormal" style="margin-left:48.0pt;text-indent:-24.0pt;line-height:
150%;mso-list:l1 level2 lfo1;border:none;mso-padding-alt:31.0pt 31.0pt 31.0pt 31.0pt;
mso-border-shadow:yes">
            <![if !supportLists]><span lang="EN-US" style="font-size:
12.0pt;line-height:150%;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:
&quot;Times New Roman&quot;;color:black"><span style="mso-list:Ignore">(3)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><![endif]><span lang="EN-US" style="font-size:12.0pt;line-height:150%;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;color:black">部門主管座談會：半年一次，由主管與住院醫師會談討論學習情況。</span><span lang="EN-US" style="font-size:12.0pt;line-height:150%;color:black"></span></p>
        <p class="MsoNormal" style="margin-left:18.0pt;text-indent:-18.0pt;line-height:
150%;mso-list:l1 level1 lfo1;border:none;mso-padding-alt:31.0pt 31.0pt 31.0pt 31.0pt;
mso-border-shadow:yes">
            <![if !supportLists]><span lang="EN-US" style="font-size:
12.0pt;line-height:150%;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:
&quot;Times New Roman&quot;;color:black"><span style="mso-list:Ignore">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><![endif]><span lang="EN-US" style="font-size:12.0pt;line-height:150%;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;color:black">院方抱怨及<a href="http://www.kmuh.org.tw/web/kmuhdept/staff/%E5%93%A1%E5%B7%A5%E7%94%B3%E8%A8%B4%E8%A9%95%E8%AD%B0%E5%A7%94%E5%93%A1%E6%9C%83%E8%A8%AD%E7%BD%AE%E8%BE%A6%E6%B3%95.aspx">申訴管道</a></span></p>
        <p class="MsoNormal" style="margin-left:48.0pt;text-indent:-24.0pt;line-height:
150%;mso-list:l1 level2 lfo1;border:none;mso-padding-alt:31.0pt 31.0pt 31.0pt 31.0pt;
mso-border-shadow:yes">
            <![if !supportLists]><span lang="EN-US" style="font-size:
12.0pt;line-height:150%;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:
&quot;Times New Roman&quot;;color:black"><span style="mso-list:Ignore">(1)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><![endif]><span lang="EN-US" style="font-size:12.0pt;line-height:150%;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;color:black">學習滿意度調查：每月一次，由住院醫師於網路上填寫對各科室之教育訓練和臨床工作滿意度，並提出具體建議。調查結果於全院住院醫師工作小組會議進行檢討，每季一次，並呈報相關單位及院長。</span><span lang="EN-US" style="font-size:12.0pt;line-height:150%;color:black"></span></p>
        <p class="MsoNormal" style="margin-left:48.0pt;text-indent:-24.0pt;line-height:
150%;mso-list:l1 level2 lfo1;border:none;mso-padding-alt:31.0pt 31.0pt 31.0pt 31.0pt;
mso-border-shadow:yes">
            <![if !supportLists]><span lang="EN-US" style="font-size:
12.0pt;line-height:150%;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:
&quot;Times New Roman&quot;;color:black"><span style="mso-list:Ignore">(2)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><![endif]><span lang="EN-US" style="font-size:12.0pt;line-height:150%;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;color:black">全院住院醫師座談會：每季一次，由本院臨床教育訓練部住院醫師訓練室主任主持，聽取住院醫師在工作和學習上之抱怨與建議，並呈報相關單位及院長。</span><span lang="EN-US" style="font-size:12.0pt;line-height:150%;color:black"></span></p>
        <p class="MsoNormal" style="margin-left:48.0pt;text-indent:-24.0pt;line-height:
150%;mso-list:l1 level2 lfo1;border:none;mso-padding-alt:31.0pt 31.0pt 31.0pt 31.0pt;
mso-border-shadow:yes">
            <![if !supportLists]><span lang="EN-US" style="font-size:
12.0pt;line-height:150%;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:
&quot;Times New Roman&quot;;color:black"><span style="mso-list:Ignore">(3)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><![endif]><span lang="EN-US" style="font-size:12.0pt;line-height:150%;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;color:black">可於臨床教育訓練部之教學管理系統提出書面意見。此外，<a href="mailto:headoffice@ms.kmuh.org.tw">院長信箱</a>均受理住院醫師之抱怨及申訴。</span><span lang="EN-US" style="font-size:12.0pt;line-height:150%;color:black"></span></p>
        <p class="MsoNormal" style="margin-left:18.0pt;text-indent:-18.0pt;line-height:
150%;mso-list:l1 level1 lfo1;border:none;mso-padding-alt:31.0pt 31.0pt 31.0pt 31.0pt;
mso-border-shadow:yes">
            <![if !supportLists]><span lang="EN-US" style="font-size:
12.0pt;line-height:150%;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:
&quot;Times New Roman&quot;;color:black"><span style="mso-list:Ignore">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><![endif]><span lang="EN-US" style="font-size:12.0pt;line-height:150%;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;color:black">輔導機制</span></p>
        <p class="MsoNormal" style="margin-left:48.0pt;text-indent:-24.0pt;line-height:
150%;mso-list:l1 level2 lfo1;border:none;mso-padding-alt:31.0pt 31.0pt 31.0pt 31.0pt;
mso-border-shadow:yes">
            <![if !supportLists]><span lang="EN-US" style="font-size:
12.0pt;line-height:150%;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:
&quot;Times New Roman&quot;;color:black"><span style="mso-list:Ignore">(1)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><![endif]><span lang="EN-US" style="font-size:12.5pt;line-height:150%;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;color:black">導師(含主持人)每月一次與住院醫師會談，瞭解學員在生活、工作、學習及生涯規劃上所遭遇之各項困難，並予以協助。若學員在受訓時有心理異常情況甚至壓力重大到對藥物、酒精成癮，當科總醫師、護理站、臨床教師等與其共事之人員皆可進行住院醫師重大異常事件通報，再由教學長、導師或行政總醫師啟動『</span><span style="font-size:12.5pt;line-height:150%;font-family:DFKai-SB;mso-fareast-font-family:
DFKai-SB;mso-bidi-font-family:DFKai-SB;color:black">住院醫師加強輔導機制</span><span lang="EN-US" style="font-size:12.5pt;line-height:150%;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;color:black">』，藉由員工關懷小組的專業人員進行了解狀況與輔導。</span><span lang="EN-US" style="font-size:12.0pt;line-height:150%;color:black"></span></p>
        <p class="MsoNormal" style="margin-top:0cm;margin-right:0cm;margin-bottom:14.0pt;
margin-left:48.0pt;text-indent:-24.0pt;line-height:150%;mso-pagination:widow-orphan;
mso-list:l1 level2 lfo1;border:none;mso-padding-alt:31.0pt 31.0pt 31.0pt 31.0pt;
mso-border-shadow:yes">
            <![if !supportLists]><span lang="EN-US" style="font-size:
12.5pt;line-height:150%;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:
&quot;Times New Roman&quot;;color:black"><span style="mso-list:Ignore">(2)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><![endif]><span style="font-size:12.5pt;line-height:150%;font-family:DFKai-SB;mso-fareast-font-family:
DFKai-SB;mso-bidi-font-family:DFKai-SB;color:black">住院醫師加強輔導機制：</span><span lang="EN-US" style="font-size:12.5pt;line-height:150%;color:black"></span></p>
        <div align="center">
            <table border="1" cellpadding="0" cellspacing="0" class="MsoNormalTable" style="border-collapse:collapse;mso-table-layout-alt:fixed;border:none;
 mso-border-alt:solid black .5pt;mso-padding-alt:0cm 5.4pt 0cm 5.4pt;
 mso-border-insideh:.5pt solid black;mso-border-insidev:.5pt solid black" width="623">
                <tr style="mso-yfti-irow:0;mso-yfti-firstrow:yes;height:12.9pt">
                    <td style="width:304.75pt;border:solid black 1.0pt;
  mso-border-alt:solid black .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:12.9pt" valign="top" width="406">
                        <p align="center" class="MsoNormal" style="margin-top:3.0pt;margin-right:0cm;
  margin-bottom:3.0pt;margin-left:0cm;text-align:center;line-height:141%">
                            <b style="mso-bidi-font-weight:normal"><span style="font-family:&quot;新細明體&quot;,&quot;serif&quot;;
  mso-ascii-font-family:&quot;Microsoft JhengHei&quot;;mso-fareast-font-family:新細明體;
  mso-fareast-theme-font:minor-fareast;mso-hansi-font-family:&quot;Microsoft JhengHei&quot;">流程</span><span lang="EN-US"></span></b></p>
                    </td>
                    <td style="width:162.85pt;border:solid black 1.0pt;
  border-left:none;mso-border-left-alt:solid black .5pt;mso-border-alt:solid black .5pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:12.9pt" valign="top" width="217">
                        <p align="center" class="MsoNormal" style="margin-top:3.0pt;margin-right:0cm;
  margin-bottom:3.0pt;margin-left:0cm;text-align:center;line-height:141%">
                            <b style="mso-bidi-font-weight:normal"><span style="font-family:&quot;新細明體&quot;,&quot;serif&quot;;
  mso-ascii-font-family:&quot;Microsoft JhengHei&quot;;mso-fareast-font-family:新細明體;
  mso-fareast-theme-font:minor-fareast;mso-hansi-font-family:&quot;Microsoft JhengHei&quot;">權責</span><span lang="EN-US"></span></b></p>
                    </td>
                </tr>
                <tr style="mso-yfti-irow:1;mso-yfti-lastrow:yes;height:396.4pt">
                    <td style="width:304.75pt;border:solid black 1.0pt;
  border-top:none;mso-border-top-alt:solid black .5pt;mso-border-alt:solid black .5pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:396.4pt" valign="top" width="406">
                        <p class="MsoNormal" style="margin-top:1.2pt;margin-right:0cm;margin-bottom:
  1.2pt;margin-left:0cm;line-height:125%">
                            <b style="mso-bidi-font-weight:normal"><span lang="EN-US" style="mso-no-proof:yes">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/iKASA/appear_flow.png" />
                            <span lang="EN-US"><b style="mso-bidi-font-weight:normal"></b></span>
                        </p>
                    </td>
                    <td style="width:162.85pt;border-top:none;border-left:
  none;border-bottom:solid black 1.0pt;border-right:solid black 1.0pt;
  mso-border-top-alt:solid black .5pt;mso-border-left-alt:solid black .5pt;
  mso-border-alt:solid black .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:396.4pt" valign="top" width="217">
                        <p align="center" class="MsoNormal" style="text-align:center;line-height:normal">
                            <span lang="EN-US"></span></p>
                        <p align="center" class="MsoNormal" style="margin-top:1.2pt;margin-right:0cm;
  margin-bottom:1.2pt;margin-left:0cm;text-align:center;line-height:125%">
                            <span style="font-family:&quot;新細明體&quot;,&quot;serif&quot;;mso-ascii-font-family:&quot;Microsoft JhengHei&quot;;
  mso-fareast-font-family:新細明體;mso-fareast-theme-font:minor-fareast;mso-hansi-font-family:
  &quot;Microsoft JhengHei&quot;">當科總醫師、護理站、臨床教師等與其共事之人員</span><span lang="EN-US"></span></p>
                        <p align="center" class="MsoNormal" style="text-align:center;line-height:normal">
                            <span lang="EN-US"></span></p>
                        <p align="center" class="MsoNormal" style="margin-top:1.2pt;margin-right:0cm;
  margin-bottom:1.2pt;margin-left:0cm;text-align:center;line-height:125%">
                            <span style="font-family:&quot;新細明體&quot;,&quot;serif&quot;;mso-ascii-font-family:&quot;Microsoft JhengHei&quot;;
  mso-fareast-font-family:新細明體;mso-fareast-theme-font:minor-fareast;mso-hansi-font-family:
  &quot;Microsoft JhengHei&quot;">教學長、</span><span lang="EN-US"><br />
                            </span><span style="font-family:&quot;新細明體&quot;,&quot;serif&quot;;mso-ascii-font-family:&quot;Microsoft JhengHei&quot;;
  mso-fareast-font-family:新細明體;mso-fareast-theme-font:minor-fareast;mso-hansi-font-family:
  &quot;Microsoft JhengHei&quot;">行政總醫師、生活</span><span lang="EN-US">/</span><span style="font-family:&quot;新細明體&quot;,&quot;serif&quot;;mso-ascii-font-family:&quot;Microsoft JhengHei&quot;;
  mso-fareast-font-family:新細明體;mso-fareast-theme-font:minor-fareast;mso-hansi-font-family:
  &quot;Microsoft JhengHei&quot;">科導師</span><span lang="EN-US"></span></p>
                        <p align="center" class="MsoNormal" style="text-align:center;line-height:normal">
                            <span lang="EN-US"></span></p>
                        <p align="center" class="MsoNormal" style="margin-top:1.2pt;margin-right:0cm;
  margin-bottom:1.2pt;margin-left:0cm;text-align:center;line-height:125%">
                            <span style="font-family:&quot;新細明體&quot;,&quot;serif&quot;;mso-ascii-font-family:&quot;Microsoft JhengHei&quot;;
  mso-fareast-font-family:新細明體;mso-fareast-theme-font:minor-fareast;mso-hansi-font-family:
  &quot;Microsoft JhengHei&quot;">當科總醫師、護理站、</span><span lang="EN-US"><br />
                            </span><span style="font-family:&quot;新細明體&quot;,&quot;serif&quot;;mso-ascii-font-family:&quot;Microsoft JhengHei&quot;;
  mso-fareast-font-family:新細明體;mso-fareast-theme-font:minor-fareast;mso-hansi-font-family:
  &quot;Microsoft JhengHei&quot;">臨床教師等與其共事之人員</span><span lang="EN-US"></span></p>
                        <p align="center" class="MsoNormal" style="margin-top:1.2pt;margin-right:0cm;
  margin-bottom:1.2pt;margin-left:0cm;text-align:center;line-height:125%">
                            <span lang="EN-US"></span></p>
                        <p align="center" class="MsoNormal" style="margin-top:1.2pt;margin-right:0cm;
  margin-bottom:1.2pt;margin-left:0cm;text-align:center;line-height:125%">
                            <span style="font-family:&quot;新細明體&quot;,&quot;serif&quot;;mso-ascii-font-family:&quot;Microsoft JhengHei&quot;;
  mso-fareast-font-family:新細明體;mso-fareast-theme-font:minor-fareast;mso-hansi-font-family:
  &quot;Microsoft JhengHei&quot;">教學長、科部教育訓練委員會</span><span lang="EN-US"></span></p>
                        <p align="center" class="MsoNormal" style="margin-top:1.2pt;margin-right:0cm;
  margin-bottom:1.2pt;margin-left:0cm;text-align:center;line-height:125%">
                            <span lang="EN-US"></span></p>
                        <p align="center" class="MsoNormal" style="margin-top:1.2pt;margin-right:0cm;
  margin-bottom:1.2pt;margin-left:0cm;text-align:center;line-height:125%">
                            <span style="font-family:&quot;新細明體&quot;,&quot;serif&quot;;mso-ascii-font-family:&quot;Microsoft JhengHei&quot;;
  mso-fareast-font-family:新細明體;mso-fareast-theme-font:minor-fareast;mso-hansi-font-family:
  &quot;Microsoft JhengHei&quot;">生活導師、當科臨床教師、</span><span lang="EN-US"><br />
                            </span><span style="font-family:&quot;新細明體&quot;,&quot;serif&quot;;mso-ascii-font-family:&quot;Microsoft JhengHei&quot;;
  mso-fareast-font-family:新細明體;mso-fareast-theme-font:minor-fareast;mso-hansi-font-family:
  &quot;Microsoft JhengHei&quot;;color:black">當科總醫師、行政總醫師等</span><span lang="EN-US" style="color:black"><br />
                            </span><span style="font-family:&quot;新細明體&quot;,&quot;serif&quot;;mso-ascii-font-family:&quot;Microsoft JhengHei&quot;;
  mso-fareast-font-family:新細明體;mso-fareast-theme-font:minor-fareast;mso-hansi-font-family:
  &quot;Microsoft JhengHei&quot;;color:black">當科主動轉介<u>員工關懷小組</u></span><span lang="EN-US" style="color:black"></span></p>
                        <p align="center" class="MsoNormal" style="margin-top:1.2pt;margin-right:0cm;
  margin-bottom:1.2pt;margin-left:0cm;text-align:center;line-height:125%">
                            <span lang="EN-US" style="color:black"></span></p>
                        <p align="center" class="MsoNormal" style="margin-top:1.2pt;margin-right:0cm;
  margin-bottom:1.2pt;margin-left:0cm;text-align:center;line-height:125%">
                            <span style="font-family:&quot;新細明體&quot;,&quot;serif&quot;;mso-ascii-font-family:&quot;Microsoft JhengHei&quot;;
  mso-fareast-font-family:新細明體;mso-fareast-theme-font:minor-fareast;mso-hansi-font-family:
  &quot;Microsoft JhengHei&quot;;color:black">教學長、科部教育訓練委員會、臨教部</span><span lang="EN-US" style="color:black"></span></p>
                        <p align="center" class="MsoNormal" style="margin-top:1.2pt;margin-right:0cm;
  margin-bottom:1.2pt;margin-left:0cm;text-align:center;line-height:125%">
                            <span lang="EN-US" style="color:black"></span></p>
                        <p align="center" class="MsoNormal" style="margin-top:6.0pt;margin-right:0cm;
  margin-bottom:1.2pt;margin-left:0cm;text-align:center;line-height:125%">
                            <span style="font-family:&quot;新細明體&quot;,&quot;serif&quot;;mso-ascii-font-family:&quot;Microsoft JhengHei&quot;;
  mso-fareast-font-family:新細明體;mso-fareast-theme-font:minor-fareast;mso-hansi-font-family:
  &quot;Microsoft JhengHei&quot;;color:black">科部提報醫教會</span><span lang="EN-US" style="color:black">/</span><span style="font-family:&quot;新細明體&quot;,&quot;serif&quot;;
  mso-ascii-font-family:&quot;Microsoft JhengHei&quot;;mso-fareast-font-family:新細明體;
  mso-fareast-theme-font:minor-fareast;mso-hansi-font-family:&quot;Microsoft JhengHei&quot;;
  color:black">人事評議委員會</span><span lang="EN-US" style="color:black"><br style="mso-special-character:line-break" />
</span>
                        </p>
                        <p align="center" class="MsoNormal" style="margin-top:1.2pt;margin-right:0cm;
  margin-bottom:1.2pt;margin-left:0cm;text-align:center;line-height:125%">
                            <span style="font-family:&quot;新細明體&quot;,&quot;serif&quot;;mso-ascii-font-family:&quot;Microsoft JhengHei&quot;;
  mso-fareast-font-family:新細明體;mso-fareast-theme-font:minor-fareast;mso-hansi-font-family:
  &quot;Microsoft JhengHei&quot;;color:black">臨床科部、臨床教育訓練部、人力資源室、當事人</span><span lang="EN-US"></span></p>
                    </td>
                </tr>
            </table>
        </div>
        <p class="MsoNormal">
            <span lang="EN-US"></span></p>
    </form>
</body>
</html>
