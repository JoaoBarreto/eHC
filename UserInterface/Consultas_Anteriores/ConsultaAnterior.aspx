<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/LayoutMasterPage_Utente.Master" AutoEventWireup="true" CodeBehind="ConsultaAnterior.aspx.cs" Inherits="UserInterface.Consulta_Antiga.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" runat="server">
    <form id="form1" runat="server">
      
        <table class="indexStyle3">
            <tr>
                <td style="width: 417px; height: 19px;">
                    <asp:Label ID="lMedico" runat="server" Text="Médico Responsável : "></asp:Label>
                    <br />
                    <asp:Label ID="lUtente" runat="server" Text="Utente : "></asp:Label>
                </td>
                <td style="width: 60px; height: 19px;"></td>
                <td style="height: 19px"></td>
            </tr>
            <tr>
                <td style="height: 13px;" colspan="3"><hr></td>
            </tr>
            <tr>
                <td style="width: 417px">&nbsp;</td>
                <td style="width: 60px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 417px">Diagnóstico:</td>
                <td style="width: 60px">&nbsp;</td>
                <td>Doenças Diagnosticadas:</td>
            </tr>
            <tr>
                <td style="width: 417px">
                    <asp:TextBox ID="tbDiagnostico" runat="server" Height="130px" Width="416px" Enabled="False" OnTextChanged="tbDiagnostico_TextChanged" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td style="width: 60px">&nbsp;</td>
                <td>
                    <asp:ListBox ID="lbDoencas" runat="server" Height="130px" Width="162px"></asp:ListBox>
                </td>
            </tr>
            <tr>
                <td style="width: 417px">&nbsp;</td>
                <td style="width: 60px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 417px">Prescrição:</td>
                <td style="width: 60px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 417px">
                    <asp:ListBox ID="lbPrescricao" runat="server" Height="128px" Width="411px"></asp:ListBox>
                </td>
                <td style="width: 60px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 417px">&nbsp;</td>
                <td style="width: 60px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3" style="align-content:center">
                    <asp:Button ID="Voltar" runat="server" OnClick="Voltar_Click" Text="Voltar" Width="60px" />
                </td>
            </tr>
        </table>
      
    </form>
</asp:Content>
