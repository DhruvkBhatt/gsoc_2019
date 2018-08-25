<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="Login.aspx.cs" Inherits="client_gui.Login" %>

 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">  
     <%-- <style type="text/css">
        .style1
        {
            width: 391px;
        }
        .style2
        {
            width: 131px;
        }
        .style3
        {
            width: 79px;
        }
        .auto-style1 {
            width: 186px;
        }
        .auto-style2 {
            height: 8px;
        }
        .auto-style3 {
            width: 79px;
            height: 9px;
        }
        .auto-style4 {
            width: 186px;
            height: 9px;
        }
        .auto-style5 {
            height: 9px;
        }
          .auto-style6 {
              width: 431px;
              height: 381px;
          }
    </style>--%>
</asp:Content> 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">  
       <form id="form1" runat="server">
    <div>
    
        <table align="center">
            <tr>
                <td colspan="3" 
                    style="text-align: center; font-weight: 700; border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #008080;" class="auto-style2">
                    &nbsp;Login</td>
            </tr>
            
            <tr>
                <td >
                    UserName :</td>
                <td>
                    <asp:TextBox ID="txtusername" runat="server" Width="120px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtusername" ErrorMessage="Please, enter username" 
                        ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td ">
                    Password :</td>
                <td >
                    <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" Width="120px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtpassword" ErrorMessage="Please, enter password" 
                        ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td >
                    <asp:CheckBox ID="chkBoxRememberMe" runat="server" Text="RememberMe" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td >
                    &nbsp;</td>
                <td >
                    <asp:Button ID="btnlogin" runat="server" onclick="btnlogin_Click" 
                        Text="Login" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td >
                    &nbsp;</td>
                <td colspan="2">
                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</asp:Content>
