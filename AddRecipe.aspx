<%@ Page Language="C#"  MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddRecipe.aspx.cs" Inherits="client_gui.AddRecipe" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">  
      <form id="form1" runat="server">
        <div>
           <table align="center" class="style1" style="border: thin solid #008080" >
            <tr>
                <td colspan="3" 
                    style="border-bottom: thin solid #008080; font-weight: 700; text-align: center;">
                    Add Recipe</td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
                <tr>
                <td class="style6">
                    Enter Recipe Name:
                </td>
                <td class="style4">
                    <asp:TextBox ID="txtrecipename" runat="server" Width="120px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtrecipename" ErrorMessage="Enter name!!" ForeColor="Red" 
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
                    </tr>
                <tr>
                <td class="style6">
                    Enter Recipe Des:
                </td>
                <td class="style4">
                    <asp:TextBox ID="txtrecipeDes" runat="server" Width="204px" Height="109px" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtrecipeDes" ErrorMessage="Enter Description!!" ForeColor="Red" 
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
                </tr>
               
            <tr>  
                <td class="style1">  
                    Upload Your Image[.png]:</td>  
                <td class="style2">  
                    <asp:FileUpload ID="FileUpload1" runat="server" />  
                </td>  
                <td>  
                  </td>  
            </tr>  
               <tr>
                   <td>

                   </td>
                   <td>
                       <asp:Button ID="Submit" runat="server" Text="Button" OnClick="Submit_Click" />
                   </td>
               </tr>
               
               </table>
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </div>
    </form>
</asp:Content> 

  

