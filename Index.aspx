<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AddUpdateEmployee.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 450px;
            border: 5px black ridge;
        }

        .auto-style2 {
            width: 200px;
        }

        .auto-style3 {
            width: 200px;
            height: 37px;
        }

        .auto-style4 {
            height: 40px;
            text-align: center;
        }

        #GridView1 {
            width: 550px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Status" style="color: crimson; font-size:x-large;" runat="server" Text="Index"></asp:Label>
            <table cellpadding="4" cellspacing="4" class="auto-style1" align="center">
                <tr>
                    <td colspan="2">
                        <h1 style="text-align:center">EMPLOYEE TABLE &nbsp;</h1>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">ID:</td>
                    <td>
                        <asp:TextBox ID="idtxt" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="Validate" runat="server" ControlToValidate="idtxt" ErrorMessage="ID is Required" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">FIRST NAME:</td>
                    <td>
                        <asp:TextBox ID="firstnametxt" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="Validate" ControlToValidate="firstnametxt" ErrorMessage="Firstname is Required" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">LAST NAME:</td>
                    <td>
                        <asp:TextBox ID="lastnametxt" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="Validate" ControlToValidate="lastnametxt" ErrorMessage="Lastname is Required" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">AGE:</td>
                    <td>
                        <asp:TextBox ID="agetxt" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="Validate" ControlToValidate="agetxt" ErrorMessage="Age is Required" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">MOBILE NO:</td>
                    <td>
                        <asp:TextBox ID="mobilenotxt" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="mobilenotxt" ValidationGroup="Validate" ErrorMessage="Mobile No is Required" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">PROFILE PIC:</td>
                    <td class="auto-style4">
                        <asp:Image ID="GetImage" Height="70" Width="70" Visible="false" runat="server" />
                        <br />
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                        <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4" colspan="2">
                        <asp:Button ID="insertbtn" runat="server" Text="INSERT" BorderColor="Green" ValidationGroup="Validate" BackColor="Green" ForeColor="White" OnClick="insertbtn_Click" />
                        <asp:Button ID="updatebtn" runat="server" Text="UPDATE" BorderColor="Blue" ValidationGroup="Validate" BackColor="Blue" ForeColor="White" OnClick="updatebtn_Click" />
                        <asp:Button ID="deletebtn" runat="server" Text="DELETE" BorderColor="Red" BackColor="Red" ForeColor="White" OnClick="deletebtn_Click" />
                        <asp:Button ID="resetbtn" runat="server" Text="RESET" BorderColor="Orange" BackColor="Orange" ForeColor="White" OnClick="resetbtn_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4" colspan="2">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Validate" BackColor="Silver" ForeColor="Red" />
                    </td>
                </tr>
            </table>
            <br />
            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="labelID" Text='<%# Eval("id") %>'></asp:Label></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="First Name">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="labelFirstname" Text='<%# Eval("firstname") %>'></asp:Label></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Last Name">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="labelLastname" Text='<%# Eval("lastname") %>'></asp:Label></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Age">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="labelAge" Text='<%# Eval("age") %>'></asp:Label></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mobile No">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="labelMobile" Text='<%# Eval("mobileno") %>'></asp:Label></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Profile Pic">
                        <ItemTemplate>
                            <asp:Image ID="Image1" Height="100" Width="100" ImageUrl='<%# Eval("profilepic") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
