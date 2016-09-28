<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Kanban.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="CSS/KanbanStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="divNewT">
            <div class="divNewT1">
                <asp:Button CssClass="btnC" ID="ButtonClose" runat="server" Text="Close" Height="27px" />
                <asp:Label ID="lblID" runat="server" Text="Log In"></asp:Label>

            </div>
            <br />
            <br />
            <div class="divComment">
                <asp:Label ID="lblUN" runat="server" Text="User Name"></asp:Label>
                <br />

                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Style="margin-left: 30px" ErrorMessage="Please enter your username" ControlToValidate="txtUserName" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:Label ID="lblpwd" runat="server" Text="Password"></asp:Label>
                <br />
                <asp:TextBox ID="txtpwd" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter your password" Style="margin-left: 30px" ControlToValidate="txtpwd" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:Panel ID="Panel1" runat="server" Width="500px">
                </asp:Panel>
            </div>
            <asp:Button CssClass="NewTAdd" ID="btnSubmit" runat="server" Text="Log In" Height="42px" Width="86px" OnClick="btnSubmit_Click" />
        </div>
    </form>
</body>
</html>
