<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="OutstandingPerformanceManager.aspx.cs" Inherits="OutstandingPerformanceAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="iconPic/all.css" rel="stylesheet" />
    <link href="css/Outstanding.css" rel="stylesheet" />
    <link href="jquery-ui/jquery-ui.theme.min.css" rel="stylesheet" />
    <script type="text/javascript" src="jQuery/jquery-3.6.4.min.js"></script>
    <script type="text/javascript" src="jquery-ui/jquery-ui.js"></script>
    <link href="bootstrap-5.3.0/css/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" src="bootstrap-5.3.0/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="Sweet/sweetalert2.all.min.js"></script>
    <script type="text/javascript" src="Sweet/sweetalert2.all.min.js"></script>

    <script runat="server">
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "傑出表現(管理者)";
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="位置"></asp:Label>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">首頁</asp:HyperLink>
    <asp:Label ID="Label2" runat="server" Text="&gt;"></asp:Label>
    <asp:HyperLink ID="HyperLink2" runat="server">個人專區</asp:HyperLink>
    <asp:Label ID="Label3" runat="server" Text="&gt;我的傑出表現(管理者)" ></asp:Label>

    <div>
        <asp:Panel ID="Panel1" runat="server" GroupingText="申請資料來源"></asp:Panel>
        <asp:RadioButtonList ID="RBSource" runat="server" RepeatDirection="Horizontal" CssClass="listItemSpacing">
            <asp:ListItem Text="學校" Value="學校" />
            <asp:ListItem Text="醫院" Value="醫院" />
            <asp:ListItem Text="使用者" Value="使用者" />
        </asp:RadioButtonList>
    </div><hr />

    <div>
        <asp:Panel ID="Panel2" runat="server" GroupingText="功能"></asp:Panel>
        <div>
            <label for="EmpCode" style="margin-bottom: 10px;">員編：</label>
            <input id="txtEmpCode" name="Empcode" type="text" style="width: 100px;" runat="server"/>

            <label for="EmpName">姓名：</label>
            <input id="txtEmpname" name="Empname" type="text" style="width: 150px;" runat="server"/>
            
            <asp:Button ID="btnSearch" runat="server" style="margin-bottom: 10px;" Text="查詢" OnClick="btnSearch_Click" />
            <asp:Label ID="Msg" runat="server" Text="(員編與姓名，請選擇一項輸入進行查詢)"></asp:Label>
        </div>

        <asp:Button ID="btnAddPerson" runat="server" style="background-color: #02F78E; color: black; margin-bottom: 10px;" Text="加入人員" OnClick="btnAddPerson_Click" />
        <asp:DropDownList ID="PersonDropDownList" runat="server" style="width: 230px; margin-bottom: 10px;">
            <asp:ListItem Text="請選擇要加入的人員" Value="" Selected="true"></asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="AddPersonMsg" runat="server" Text="" ForeColor="Blue" EnableViewState="false" EnableHtml="true"></asp:Label>

        <asp:Button ID="btnRemovePerson" runat="server" style="background-color: red; color: white; margin-bottom: 10px;" Text="移除人員" OnClick="btnRemovePerson_Click" />
        <asp:DropDownList ID="RemoveDropDownList" runat="server" style="width: 250px; margin-bottom: 10px;" AppendDataBoundItems="true">
            <asp:ListItem Text="請選擇要移除的人員" Value="" Selected="true"></asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="RemovePersonMsg" runat="server" Text="" ForeColor="Blue" EnableViewState="false" EnableHtml="true"></asp:Label>

        <asp:RadioButtonList ID="RBIdentity" runat="server" RepeatDirection="Horizontal" CssClass="listItemSpacing" style="margin-top: 10px; margin-bottom: 10px;">
            <asp:ListItem Text="使用者匯入" Value="使用者匯入" />
            <asp:ListItem Text="管理者匯入" Value="管理者匯入" />
        </asp:RadioButtonList>
            <asp:Label ID="Label4" runat="server" Text="審查進度："></asp:Label>
            <asp:Label ID="LbMessage" runat="server" Text=""></asp:Label><br />       
    </div><hr />

    <div>
        <asp:Panel ID="Panel3" runat="server" GroupingText="傑出資料申請/上傳項目" style="display: block;"></asp:Panel>
        <hr />

        <div>
            <label for="Competition">活動名稱 / 參賽主題-獎項：</label>
            <input name="Competition" type="text" placeholder="實證醫學-金獎" required/>
            <asp:Label ID="Participant" runat="server" Text=""></asp:Label><%--顯示參與人員--%>
        </div><hr />

        <div class="form-Organrow">
            <label for="Organization">主辦單位：</label>
            <input name="Organization" type="text" placeholder="醫策會" required title="此欄位為必填項目"/>
        </div> <hr />

        <div class="form-Daterow">
            <label for="EventDate">活動日期：</label>
            <input name="EventDateTime" type="date" required title="此欄位為必填項目"/>
        </div><hr />

        <div>
            <label for="Genre">申請類型：</label>
            <asp:RadioButtonList ID="RBType" runat="server" RepeatDirection="Horizontal" CssClass="listItemSpacing">
                <asp:ListItem Text="教學類(如EBM、擬真等)" Value="教學類" />
                <asp:ListItem Text="研究類(如口頭報告、海報發表等)" Value="研究類" />
                <asp:ListItem Text="其它" Value="其它" />
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="RFVType" runat="server" ControlToValidate="RBType" ValidationGroup="validationGroup" ErrorMessage="請選擇一個類型" Text="*"  CssClass="validationErrorMessage" Display="Dynamic"></asp:RequiredFieldValidator>
        </div><hr />

        <div class="form-Supportingrow">
            <asp:Label ID="SupportingData" runat="server" Text="佐證資料(圖片或文件檔)："></asp:Label>
            <asp:FileUpload ID="FileSupportUpload" runat="server" Multiple="true"/>
            <%--<asp:Button ID="BtnUpload" runat="server" class="btn btn-danger" Text="上傳佐證資料" />--%>
            <asp:Button ID="btnSave" runat="server" class="btn btn-primary" Text="存檔" Style="float: right;" OnClick="btnSave_Click" />
        </div><hr />

        <div>
            <label for="ReviewStatus">審查結果：</label>
            <%--<asp:Button ID="btnSerachReview" runat="server" Text="查詢審查結果" Style="float: right;" class="btn btn-primary" CssClass="SerachReviewButton" OnClick="btnSerachReview_Click"/>--%>
            <asp:Label ID="ReviewStatusLabel" runat="server" Text=""></asp:Label><br/>
            <label for="Reason">原因：</label>
            <asp:Label ID="ReasonLabel" runat="server" Text=""></asp:Label>
        </div><hr />
     </div>
</asp:Content>

