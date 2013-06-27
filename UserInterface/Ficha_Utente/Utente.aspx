<%@ Page Language="C#" MasterPageFile="~/Master_Pages/LayoutMasterPage.Master" AutoEventWireup="true" CodeBehind="Utente.aspx.cs" Inherits="UserInterface.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" runat="server">
    <form id="form1" runat="server">
        <div style="margin-left: 160px; width: 484px;">
            <table style="width: 100%">
                <tr>
                    <td class="indexStyle3" colspan="3">
                        Por favor, aplique o filtro de especialidade:</td>
                </tr>
                <tr>
                    <td class="indexStyle3" colspan="3">
            <asp:Label ID="lbName" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="indexStyle3" colspan="3">
                        <hr>
                    </td>
                </tr>
                <tr>
                    <td style="height: 23px">
            <asp:DropDownList ID="lbEspecialidadesSelecionadas" runat="server" Width="297px" Height="24px"></asp:DropDownList>
                    </td>
                    <td style="height: 23px; vertical-align:central">
            <asp:DropDownList ID="dDLListEspecialidades" runat="server"  DataSourceID="ObjectDataSource2" DataTextField="especialidade" DataValueField="especialidade" style="margin-left: 99px" Height="24px" Width="130px">
            </asp:DropDownList>
                    </td>
                    <td style="height: 23px; vertical-align:central">
            <asp:Button ID="buttonAdicionarEspecialidade" runat="server" Text="Filtrar" OnClick="buttonAdicionarEspecialidade_Click" Height="20px" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 860px">
            <asp:Button ID="buttonRemoverEspecialidade" runat="server" Text="Remover"  OnClick="buttonRemoverEspecialidade_Click" />
            <asp:Button ID="buttonRemoverTodasAsEspecialidades" runat="server" Text="Remover tudo" OnClick="buttonRemoverTodasAsEspecialidades_Click" />
                    </td>
                    <td colspan="2" style="width: 192px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1" colspan="3"><hr></td>
                </tr>
            </table>
        </div>
&nbsp;<br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource3" OnSelectedIndexChanged="GridView1_SelectedIndexChanged2" Width="777px">
            <Columns>
                <asp:BoundField DataField="idSala" HeaderText="idSala" SortExpression="idSala" Visible="False" />
                <asp:BoundField DataField="idConsulta" HeaderText="Nrº Consulta" SortExpression="idConsulta" />
                <asp:BoundField DataField="idEmpregado" HeaderText="idEmpregado" SortExpression="idEmpregado" Visible="False" />
                <asp:BoundField DataField="idUtente" HeaderText="idUtente" SortExpression="idUtente" Visible="False" />
                <asp:BoundField DataField="designacaoSala" HeaderText="Sala" SortExpression="designacaoSala" />
                <asp:BoundField DataField="nomeUtente" HeaderText="Utente" SortExpression="nomeUtente" Visible="False" />
                 <asp:BoundField DataField="nomeEmpregado" HeaderText="Medico" SortExpression="nomeEmpregado" />
                <asp:BoundField DataField="especialidade" HeaderText="Especialidade" SortExpression="especialidade" />
                <asp:BoundField DataField="estado" HeaderText="Estado da Consulta" SortExpression="estado" />
                <asp:BoundField DataField="observacoes" HeaderText="Observações" SortExpression="observacoes" />
                <asp:BoundField DataField="data" HeaderText="Data" SortExpression="data" />
                <asp:CommandField ButtonType="Button" SelectText="Consultar Consulta" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="selectConsultaByIDUtente" TypeName="BusinessLogicLayer.EHC_Manager">
            <SelectParameters>
                <asp:QueryStringParameter Name="idUtente" QueryStringField="idUtente" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="selectEspecialidadesComConsultaDoUtente" TypeName="BusinessLogicLayer.EHC_Manager">
            <SelectParameters>
                <asp:QueryStringParameter Name="idUtente" QueryStringField="idUtente" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
 </form>
</asp:Content>