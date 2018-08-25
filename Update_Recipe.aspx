<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Update_Recipe.aspx.cs" Inherits="client_gui.Update_Recipe" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">  
      <form id="form1" runat="server">
        <div>
            <table>
            <tr>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Width="120px"></asp:TextBox>
            </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" />
                </td>
            </tr>
       
                <tr>
            <td colspan="2">
                
            <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
            </tr>
             
             </table>
             <table align="center" class="style1" style="border: thin solid #008080" accesskey="hidden">
            <tr>
                <td colspan="3" 
                    style="border-bottom: thin solid #008080; font-weight: 700; text-align: center;" class="auto-style2">
                    Recipe</td>
            </tr>
            <tr>
                <td class="auto-style5">
                    &nbsp;</td>
                <td class="auto-style1">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
                <tr>
                <td class="auto-style5">
                    Enter Recipe Name:
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtrecipename" runat="server" Width="120px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                    </tr>
                <tr>
                <td class="auto-style5">
                    Enter Recipe Des:
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtrecipeDes" runat="server" Width="204px" Height="109px" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                </td>
                </tr>
               <tr>  
                   <td class="auto-style5">
                       Image:
                   </td>
                   <td>
                   <asp:Image ID="Image1" runat="server" Height="168px" Width="214px" />
                       </td>
               </tr>
                 <tr>  
                  
                   </td>
                   <td class="auto-style5">
                       <asp:Button ID="Button2" runat="server" Text="Update" OnClick="Button2_Click" />
                       </td>
               </tr>
               </table>
        </div>
    </form>
</asp:Content> 


<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPlaceHolder1">
    s<style type="text/css">         .auto-style5 {
             width: 296px;
         }
     </style>
</asp:Content>
 


