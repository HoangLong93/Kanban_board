<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNewTask.aspx.cs" Inherits="Kanban.AddNewTask" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
     <link  href="CSS/KanbanStyle.css" rel="stylesheet" type="text/css"/>
    <link rel="stylesheet" type="text/css" href="CSS/font-awesome-4.2.0/css/font-awesome.min.css" />
    <link rel="stylesheet" type="text/css" href="CSS/style.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class ="divNewT" >

       <div class ="divNewT1" >
            <asp:Button CssClass="btnC"  ID="Button1" runat="server" Text="Close" Height="27px" />
           <asp:Label ID="Label1" runat="server" Text="Task Details"></asp:Label>
          
       </div>

        <br/>
        <br/>

        <div class="divNewT2">
            <asp:Label CssClass ="lblTF"  ID="Label4" runat="server" Text="Task fields"></asp:Label>
         
            <br/>
            <br/>
            <asp:Label ID="Label5" runat="server" Text="Color:"></asp:Label>

            
            <br/>
            <asp:DropDownList ID="DropDownListColor" runat="server" Height="16px" Width="64px">
                <asp:ListItem Text="red" Value ="1"></asp:ListItem>
                <asp:ListItem Text="Blue" Value ="2"></asp:ListItem>
                <asp:ListItem Text="Green" Value ="3"></asp:ListItem>
                <asp:ListItem Text="Yellow" Value ="4"></asp:ListItem>
                <asp:ListItem Text="Pink" Value ="5"></asp:ListItem>
            </asp:DropDownList>
            <br/>
            <br/>
            <asp:Label ID="Label7" runat="server" Text="Complexity:"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label8" runat="server" Text="Assignee:"></asp:Label>
            <br/>
            <asp:TextBox ID="TextBoxComplexity" runat="server" Width="94px" CssClass="marginright50" Text="0"></asp:TextBox>
            <asp:DropDownList ID="DropDownListAssignee" runat="server">
            </asp:DropDownList>
            <br/>
            <br/>
            <asp:Label ID="Label9" runat="server" Text="Estimation Hours:"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label10" runat="server" Text="Column"></asp:Label>
            :<br/>
            <asp:TextBox ID="TextBoxDeadline" runat="server" Width="98px" CssClass="marginright50"></asp:TextBox>
            <asp:DropDownList ID="DropDownListColumn" runat="server">
                <asp:ListItem Text="Backlog" Value ="1"></asp:ListItem>
                <asp:ListItem Text="Sprint" Value ="2"></asp:ListItem>
                <asp:ListItem Text="To do" Value ="3"></asp:ListItem>
                <asp:ListItem Text="Doing" Value ="4"></asp:ListItem>
                <asp:ListItem Text="Done" Value ="5"></asp:ListItem>
            </asp:DropDownList>
            <br/>
            <br/>
        </div>

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <div class ="divNewT3" >
            <asp:Label ID="Label2" runat="server" Text="Title"></asp:Label>
            <br/>
            <asp:TextBox runat="server" ID="txtTitle" Width="259px"></asp:TextBox><br />
            <asp:RequiredFieldValidator runat="server" ID="ValidateTitle" ControlToValidate="txtTitle" ErrorMessage="Please insert task title!" Display="Dynamic"></asp:RequiredFieldValidator>
            <br/>
            <br/>
            <asp:Label ID="Label3" runat="server" Text="Description"></asp:Label>
            <br/>
            <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" Height="97px" Width="263px"></asp:TextBox>
        </div>

        <br/>
        
        <asp:Button CssClass ="NewTAdd"  ID="ButtonAddTask" runat="server" Text="Add Task" Height="34px" Width="103px" OnClick="ButtonAddTask_Click"/>
        
      </div>
    </form>
</body>
</html>

