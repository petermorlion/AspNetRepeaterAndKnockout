<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="KnockoutRepeater.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Knockout and Repeaters</title>
    <script src="Scripts/jquery-1.7.1.min.js"></script>
    <script src="Scripts/knockout-2.2.1.js"></script>
    <script src="Scripts/knockout.mapping-latest.js"></script>
    <script src="Scripts/customersViewModel.js"></script>
    <script type="text/javascript">
        $(function () {
            var json = $('[id$=modelHiddenField]').val();
            var model = $.parseJSON(json);
            var viewModel = new CustomersViewModel(model);
            ko.applyBindings(viewModel);
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HiddenField runat="server" ID="modelHiddenField"/>
        <asp:Repeater runat="server" id="customersRepeater">
            <HeaderTemplate>
                <table>
                    <thead>
                        <th>First name</th>
                        <th>Last Name</th>
                        <th>Exclusive member</th>
                        <th>Fee</th>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                            <tr data-bind="with: customers()[<%# Container.ItemIndex %>]">
                                <td><asp:Literal runat="server" ID="firstNameLiteral"></asp:Literal><input type="text" data-bind="value: firstName"/><span data-bind="text: firstName"></span></td>
                                <td><asp:Literal runat="server" ID="lastNameLiteral"></asp:Literal></td>
                                <td><input type="checkbox" id="exclusiveMemberCheckBox" runat="server" data-bind="checked: exclusiveMember" /></td>
                                <td data-bind="text: fee"></td>
                            </tr>
            </ItemTemplate>
            <FooterTemplate>
                        </tbody>
                    </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
