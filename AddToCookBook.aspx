<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="AddToCookBook.aspx.cs" Inherits="client_gui.AddToCookBook" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">  
       <form id="form1" runat="server">
        <table>
            <tr>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Width="120px"></asp:TextBox>
            </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Add To CookBook" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
        
             <tr>
            <td colspan="2">
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </td>
               
            </tr>

             
    </form>
</asp:Content> 

