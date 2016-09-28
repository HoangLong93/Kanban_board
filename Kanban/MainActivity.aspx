<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainActivity.aspx.cs" Inherits="Kanban.MainActivity2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" type="text/css" href="CSS/font-awesome-4.2.0/css/font-awesome.min.css" />
    <link rel="stylesheet" type="text/css" href="CSS/style.css" />
    <title></title>
    <meta charset="utf-8" />
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.2/jquery-ui.js"></script>
    <script>
        $(function () {
            $(".deletetask").click( {
                handler: function (event, ui) {
                    if (confirm('Are you sure to delete this?')) {
                 //       alert("just clicked " + $(this).attr('data-ID'))
                        $(this).parent().slideUp()
                        var id = $(this).attr('data-ID')
                        $.ajax({
                            type: "POST",
                            url: "Handler1.ashx",
                            dataType: "json",
                            data: { "id": id , "action" : "delete"},
                        })
                    }
                }
            });
        });
    </script>
    <script>
        $(function () {
            $("#sortable1, #sortable2, #sortable3, #sortable4, #sortable5").sortable({
                connectWith: ".sortable",
                delay: 0,
                stop: function (event, ui) {
                    alert("Position: " + ui.item.parent().attr('data-ID') + " ID: " + ui.item.attr('data-ID'));
                    var status = ui.item.parent().attr('data-ID')
                    var id = ui.item.attr('data-ID')
                    $.ajax({
                        type: "POST",
                        url: "Handler1.ashx",
                        dataType: "json",
                        data: { "id": id, "status": status, "action": "update" },
                    })
                }

            });
            // Ajax

            // End of Ajax
            $(".sortable").disableSelection();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table style="width: 100%">
            <tr>
                <th>
                    <div class="table_header">
                        <asp:Button runat="server" ID="btnAddtask1" Text="+" CssClass="btnadd" PostBackUrl="~/AddNewTask.aspx?swimlane=1" />Product Backlog</div>
                </th>
                <th>
                    <div class="table_header">
                        <asp:Button runat="server" ID="btnAddtask2" Text="+" CssClass="btnadd" PostBackUrl="~/AddNewTask.aspx?swimlane=2" />Sprint Backlog</div>
                </th>
                <th>
                    <div class="table_header">
                        <asp:Button runat="server" ID="btnAddtask3" Text="+" CssClass="btnadd" PostBackUrl="~/AddNewTask.aspx?swimlane=3" />To Do</div>
                </th>
                <th>
                    <div class="table_header">
                        <asp:Button runat="server" ID="btnAddtask4" Text="+" CssClass="btnadd" PostBackUrl="~/AddNewTask.aspx?swimlane=4" />Work in Progress</div>
                </th>
                <th>
                    <div class="table_header">
                        <asp:Button runat="server" ID="btnAddtask5" Text="+" CssClass="btnadd" PostBackUrl="~/AddNewTask.aspx?swimlane=5" />Done</div>
                </th>
            </tr>
            <tr>
                <td>
                    <div id="div1">
                        <asp:Panel ID="Panel1" runat="server">
                        </asp:Panel>



                    </div>
                </td>
                <td>
                    <div id="div2">
                        <asp:Panel ID="Panel2" runat="server">
                        </asp:Panel>
                    </div>
                </td>
                <td>
                    <div id="div3">
                        <asp:Panel ID="Panel3" runat="server">
                        </asp:Panel>
                    </div>
                </td>
                <td>
                    <div id="div4">
                        <asp:Panel ID="Panel4" runat="server">
                        </asp:Panel>
                    </div>
                </td>
                <td>
                    <div id="div5">
                        <asp:Panel ID="Panel5" runat="server">
                        </asp:Panel>
                    </div>
                </td>
            </tr>
        </table>





    </form>
</body>
</html>
