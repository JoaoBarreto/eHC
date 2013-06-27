<%@ Page Language="C#" MasterPageFile="~/Master_Pages/LayoutMasterPage_Utente.Master" AutoEventWireup="true" CodeBehind="Consulta.aspx.cs" Inherits="UserInterface.WebForm2"%>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" runat="server"> 
    <form id="form1" runat="server">
        
        <table>
	<tr>
		<td id="dadosUtente_Consulta" style="width: 25%; height: 38px;" class="tableUtente">

            Consulta nº: <asp:Label ID="lbIdConsulta" runat="server" Text="lbIdConsulta"></asp:Label>
            <br />
            Medico:
            <asp:Label ID="lbNomeMedico" runat="server" Text="nomeMedico"></asp:Label>
            <br />
		    Utente: <asp:Label ID="lbNomeUtente" runat="server" Text="lbNomeUtente"></asp:Label>
          
		</td>
		<td style="width: 3%; height: 38px;">      </td>
		<td  style="width: 14%; height: 38px;">    </td>
		<td style="width: 3%; height: 38px;">     </td>
		<td id="EstadoConsulta" class="tableUtente" style="height: 38px">Estado: <asp:Label ID="lbEstadoConsulta" runat="server" Text="lbEstadoConsulta"></asp:Label>.</td>
	</tr>
	<tr>
		<td colspan="5" class="indexStyle3"><hr><br/>Ficha Clinica:<br />
            <asp:ListBox ID="listbDiagnosticos" runat="server" Width="100%"></asp:ListBox>
            <br />
            <asp:Button ID="btVerDiagnostico" runat="server" style="text-align: left" Text="Ver" OnClick="btVerDiagnostico_Click" />
            <br />
            <br />
            Exames recentes:<br />
            <asp:ListBox ID="listbExames" runat="server" Width="100%"></asp:ListBox>  <br />
            <asp:Button ID="btExames" runat="server" Text="Ver" /> <br />
	        <tr>
		<td style="width: 25%;" class="indexStyle3"> Diagnostico:</td>
		<td style="width: 3%; " rowspan="2"></td>
		<td style="width: 14%; " class="indexStyle3">
             Doenças:</td>
		<td style="width: 3%; text-align: center;">
            <br />
        </td>
		<td >
            </td></tr><tr>
		<td style="width: 25%; height: 19px;">
         <asp:TextBox ID="tbDiagnostico" runat="server" Height="90px" Width="370px" TextMode="MultiLine" style="resize:none"></asp:TextBox>
        </td>
		<td style="width: 14%; height: 19px;">
         <asp:ListBox ID="listbDoencasAdicionadas" runat="server" Height="95px" Width="150px"></asp:ListBox>
       </td>
		<td style="width: 3%; text-align: center; height: 19px;"> <br />
            <asp:Button ID="btAddDoenca" runat="server" Text="<<" OnClick="btAddDoenca_Click" /><br />
            <asp:Button ID="btRemoveDoenca" runat="server" Text=">>" OnClick="btRemoveDoenca_Click" />
        </td>
		<td class="auto-style1" >
            <asp:ListBox ID="listBDoencas" runat="server" Height="95px" Width="150px" DataSourceID="ObjectDataSource1" DataTextField="descricao" DataValueField="descricao"></asp:ListBox>
            </td>
	</tr>


        </td>
	</tr>
	<tr>
		<td colspan="5" class="indexStyle3">
            <asp:RequiredFieldValidator ID="RequiredFieldFirstName" runat="server" Text="* Campo de preenchimento obrigatório." ControlToValidate="tbDiagnostico" ForeColor="Red"></asp:RequiredFieldValidator>

		</td>
	</tr>
	<tr>
		<td colspan="5" class="indexStyle3">Prescrição:</td>
	</tr>
	<tr>
		<td colspan="5" class="auto-style1">
            <asp:Listbox ID="lbPrescricao" runat="server" Height="102px" Width="258px"></asp:Listbox>
            <br />
            <asp:Button ID="btEscolher" runat="server" Text="Escolher" OnClick="btEscolher_Click" />&nbsp;
            <asp:Button ID="btRemover" runat="server" Text="Remover" OnClick="btRemover_Click" />
        </td>
	</tr>
	<tr>
		<td colspan="5">
            <br />
            <asp:Button ID="btGuardar" runat="server" Text="Guardar" OnClick="btGuardar_Click" />&nbsp;
            <asp:Button ID="btSubmeter" runat="server" Text="Submeter" OnClick="btSubmeter_Click" />&nbsp;
            <asp:Button ID="btImprimir" runat="server" Text="Imprimir" />
            &nbsp;
           
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="selectDoenca" TypeName="BusinessLogicLayer.EHC_Manager"></asp:ObjectDataSource>
        </td>
	</tr>
	<tr>
		<td colspan="5">
            &nbsp;</td>
	</tr>
</table>
   </form>
</asp:Content>