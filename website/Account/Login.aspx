<%@ Page Title="登入" Language="C#" MasterPageFile="~/SiteNoAjax.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Account_Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <h2>
        登入
    </h2>
    <p>
        請輸入您的使用者名稱和密碼。
        <!--<asp:HyperLink ID="RegisterHyperLink" runat="server" EnableViewState="false">註冊</asp:HyperLink> (如果您沒有帳戶)-->
        (帳號密碼同整合版入口網站密碼)</p>
    <asp:Login ID="LoginUser" runat="server" EnableViewState="false" 
        RenderOuterTable="false" onauthenticate="LoginUser_Authenticate">
        <LayoutTemplate>
    <asp:Panel ID="panemain" runat="server" DefaultButton ="LoginButton">
            <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="LoginUserValidationGroup"/>
            <div class="accountInfo">
                <fieldset class="login">
                    <legend></legend>
                    <p>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Logo.jpg" />
                    </p>
                    <p>
                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">帳號:</asp:Label>
                        <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                             CssClass="failureNotification" ErrorMessage="必須提供帳號。" ToolTip="必須提供帳號。" 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">密碼:</asp:Label>
                        <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                             CssClass="failureNotification" ErrorMessage="必須提供密碼。" ToolTip="必須提供密碼。" 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:CheckBox ID="RememberMe" runat="server" Visible="False"/>
                        <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline" Visible="False">記住登入資訊(公用電腦請勿勾選)</asp:Label>
                    </p>
                </fieldset>
                <p class="submitButton">
                    <asp:Button ID="LoginButton" runat="server" Text="確定"  CommandName="Login"
                        ValidationGroup="LoginUserValidationGroup" onclick="LoginButton_Click"/>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" CssClass="failureNotification"
                        ErrorMessage="請由院內網站登入" onservervalidate="CustomValidator1_ServerValidate"  ToolTip="請由院內網站登入" 
                        ValidationGroup="LoginUserValidationGroup"></asp:CustomValidator>
                </p>
            </div>
</asp:Panel>
        </LayoutTemplate>
    </asp:Login>


</asp:Content>