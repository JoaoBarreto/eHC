<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/LayoutMasterPage.Master" AutoEventWireup="true" CodeBehind="Medico.aspx.cs" Inherits="UserInterface.Ficha_Medico.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" runat="server">
    <form id="form1" runat="server">
        <table cellpadding="0" cellspacing="0" style="width: 74%">
            <tr>
                <td>
            <table style="width: 88%">
                <tr>
                    <td class="indexStyle3">
                        Por favor, escolha a consulta:</td>
                </tr>
                <tr>
                    <td class="indexStyle3">
            <asp:Label ID="lbNomeMedico" runat="server" Text="Medico: "></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="indexStyle3">
                        <hr>
                    </td>
                </tr>
                </table>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="719px">
            <Columns>
                <asp:BoundField DataField="idSala" HeaderText="idSala" SortExpression="idSala" Visible="False" />
                <asp:BoundField DataField="idConsulta" HeaderText="Nrº Consulta" SortExpression="idConsulta" />
                <asp:BoundField DataField="idEmpregado" HeaderText="idEmpregado" SortExpression="idEmpregado" Visible="False" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="idUtente" HeaderText="idUtente" SortExpression="idUtente" />
                <asp:BoundField DataField="designacaoSala" HeaderText="Sala" SortExpression="designacaoSala" />
                <asp:BoundField DataField="nomeUtente" HeaderText="Utente" SortExpression="nomeUtente" />
                <asp:BoundField DataField="estado" HeaderText="Estado" SortExpression="estado" />
                <asp:BoundField DataField="data" HeaderText="Data" SortExpression="data" />
                <asp:BoundField DataField="especialidade" HeaderText="Especialidade" SortExpression="especialidade" Visible="False" />
                 <asp:CommandField ButtonType="Button" SelectText="Consultar Consulta" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
                </td>
            </tr>
        </table>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="selectConsultaByIDMedico" TypeName="BusinessLogicLayer.EHC_Manager">
            <SelectParameters>
                <asp:QueryStringParameter Name="idMedico" QueryStringField="idMedico" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
</asp:Content>
