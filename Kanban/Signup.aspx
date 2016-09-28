<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="Kanban.Signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="CSS/KanbanStyle.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="divNewT">
            <div class="divNewT1">
                <asp:Button CssClass="btnC" ID="ButtonClose" runat="server" Text="Close" Height="27px" />
                <asp:Label ID="lblID" runat="server" Text="Sign up"></asp:Label>
            </div>
            <br />
            <br />
            <div class="divComment">
                <asp:Label ID="lblUN" runat="server" Text="User Name:"></asp:Label>
                <br />
                <asp:TextBox ID="txtUN" runat="server"></asp:TextBox>
                <asp:CustomValidator ID="ValidateUN" runat="server" ControlToValidate="txtUN" ErrorMessage="Username has already been taken" OnServerValidate="ValidateUN_ServerValidate" Display="Dynamic"></asp:CustomValidator>
                <asp:RequiredFieldValidator ID="ValidateUsername" runat="server" ControlToValidate="txtUN" ErrorMessage="Please enter a username"></asp:RequiredFieldValidator>
                <br />
                <br />


                <asp:Label ID="lblEm" runat="server" Text="E-mail:"></asp:Label>
                <br />
                <asp:TextBox ID="txtEm" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="ValidateEmail" runat="server" ControlToValidate="txtEm" ErrorMessage="Please check your email again" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtEm" ErrorMessage="Please give your email here" Display="Dynamic"></asp:RequiredFieldValidator>
                <br />
                <br />


                <asp:Label ID="lblPWD" runat="server" Text="Password:"></asp:Label>
                <br />
                <asp:TextBox ID="txtpwd" runat="server" TextMode="Password"></asp:TextBox>
                <asp:Label ID="lbl_p" runat="server" Text="(*require 8-12 characters)"></asp:Label>
                <asp:CustomValidator ID="ValidatePW" runat="server" ControlToValidate="txtpwd" ErrorMessage="Your password should be between 8-12 characters" OnServerValidate="ValidatePW_ServerValidate" Display="Dynamic"></asp:CustomValidator>
                <asp:RequiredFieldValidator ID="ValidatePassword" runat="server" ControlToValidate="txtpwd" ErrorMessage="Please give your password here" Display="Dynamic"></asp:RequiredFieldValidator>
                <br />
                <br />


                <asp:Label ID="lblrp" runat="server" Text="Repeat password"></asp:Label>
                <br />
                <asp:TextBox ID="txtrp" runat="server" TextMode="Password"></asp:TextBox>
                <asp:CompareValidator runat="server" ID="ValidateRepeatpw" ControlToValidate="txtrp" ControlToCompare="txtpwd" Operator="Equal" Display="Dynamic" Text="Please repeat your password"></asp:CompareValidator>
                <asp:RequiredFieldValidator ID="ValidateRepeatPasswprd" runat="server" ControlToValidate="txtpwd" ErrorMessage="Please repeat your password here" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <br />
            <asp:Button CssClass="NewTAdd" ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click1" />
        </div>
    </form>
</body>
</html>


