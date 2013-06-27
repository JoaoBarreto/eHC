<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/LayoutMasterPage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="UserInterface.Webform3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" runat="server">
   
    
     <form id="form1" runat="server" class="tableUtente">
         <table style="width: 100%">
             <tr class="indexStyle1">
                 <td colspan="4" style="height: 16px">&nbsp;</td>
             </tr>
             <tr class="indexStyle1">
                 <td colspan="2" style="height: 16px"></td>
                 <td colspan="2" class="indexStyle1" style="text-align:center; height: 16px;">Informação de consultas</td>
             </tr>
             <tr>
                 <td style="width: 474px; height: 33px;" class="h1"><img src="App_themes/eHC_default/logo_ehc.png">Sistema em fase de testes.</td>
                 <td style="width: 197px; height: 33px;" class="date"><img src="App_themes/eHC_default/date.png"> May 19, 2013 <img src="App_themes/eHC_default/user.png"> Admin</td>
                 <td class="indexStyle1" style="height: 33px; text-align:right; width: 101px; vertical-align:central">User </td>
                 <td style="height: 33px">
        <asp:DropDownList ID="DropDownList1" runat="server" Height="25px" Width="98px" Font-Bold="False" Font-Names="Arial">
            <asp:ListItem Value="idMedico">Medico</asp:ListItem>
            <asp:ListItem Value="idUtente">Utente</asp:ListItem>
        </asp:DropDownList>
                 </td>
             </tr>
             <tr>
                 <td colspan="2" style="height: 22px">
                     <hr />
                 </td>
                 <td class="indexStyle1" style="width: 101px; text-align:right; vertical-align:central; height: 25px;">
        <asp:Label ID="Label1" runat="server" Text="Nrº"></asp:Label>
                     </td>
                 <td class="indexStyle1" style="height: 22px">
                 <asp:TextBox ID="TextBox1" runat="server" Width="100px"></asp:TextBox>
                     <br/>
                 </td>
             </tr>
             <tr>
                 <td style="height: 9px;" colspan="2">
                     
                     <div class="indexStyle2">
                         O sistema eHC desenhado e desenvolvido pela While True Systems, encontra-se em fase de testes. Agradecemos que todos os bugs sejam reportados à equipa de testes. Obrigado.
                     </div>
                     <br />
                 </td>
                 <td style="width: 101px; height: 9px;"></td>
                 <td style="height: 9px; vertical-align:top" class="indexStyle2">
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Pesquisar" Width="99px" Height="22px" ValidationGroup="NumericValidate"/>
                     <br />
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1"  ErrorMessage="Insira um número." ForeColor="Red"
     ValidationExpression="^[0-9]*$" ValidationGroup="NumericValidate" EnableClientScript="False"></asp:RegularExpressionValidator>
                 </td>
             </tr>
             <tr>
                 <td colspan="2" style="height: 18px"></td>
                 <td colspan="2" style="height: 18px"></td>
             </tr>
             <tr>
                 <td colspan="2">&nbsp;</td>
                 <td colspan="2">&nbsp;</td>
             </tr>
             <tr>
                 <td colspan="2">&nbsp;</td>
                 <td colspan="2">&nbsp;</td>
             </tr>
         </table>
         <br />
    </form>



</asp:Content>
