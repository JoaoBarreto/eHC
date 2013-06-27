using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using DataTransferObject;

namespace UserInterface.Consulta_Antiga
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        private const string linkToConsultasAnteriores = "~/Consulta_Atual/Consulta.aspx?idDiagnostico=";
        const string idConsultaString = "idConsulta=";
        const string linkToConsulta = "~/Consulta_Atual/Consulta.aspx?idConsulta=";
        const string linkToUtente = "~/Ficha_Utente/Utente.aspx?idUtente=";
        const string linkToMedico = "~/Ficha_Medico/Medico.aspx?idMedico=";
        const string mode = "&mode=";
        const string typeString = "&type=";

        private int idDiagnostico;
        private int idConsultaAnterior;
        private string medicoResponsavel;
        private Consulta consulta;
        private Utente utente;

        protected void Page_Load(object sender, EventArgs e)
        {
            getDados();
            lMedico.Text += medicoResponsavel;
            lUtente.Text += utente.nome;
            getDiagnostico(idDiagnostico);
            getDoencas(idDiagnostico);
            getPrescrições(idDiagnostico);
        }

      

        protected void Voltar_Click(object sender, EventArgs e)
        {
            Response.Redirect(linkToConsulta + idConsultaAnterior + mode + Request.QueryString["mode"] + typeString + Request.QueryString["type"]);
        }

        private void getDados()
        {
            if (Request.QueryString["idDiagnostico"] != null)
            {
                idDiagnostico = int.Parse(Request.QueryString["idDiagnostico"]);
                idConsultaAnterior = int.Parse(Request.QueryString["idConsulta"]);
                consulta = EHC_Manager.selectConsultaByIDConsulta(idDiagnostico);
                utente = utenteBLL.selectUtenteByIDConsulta(idDiagnostico);
                medicoResponsavel = EHC_Manager.selectMedicoByIdEmpregado(consulta.idEmpregado).nome;
            }
        }

        private void getDiagnostico(int idConsulta)
        {
            Diagnostico diagnostico = diagnosticoBLL.selectDiagnosticoByIDConsulta(idConsulta);
            tbDiagnostico.Text = diagnostico.diagnostico;
        }

        private void getPrescrições(int idConsulta)
        {
            LinkedList<ElementosPrescritos> prescricoes = prescricaoBLL.selectPrescricaoByIDDiagnostico(idConsulta);
            foreach (ElementosPrescritos each in prescricoes)
            {
                string temp = each.nome + " " + each.quantidade;
                lbPrescricao.Items.Add(temp);
            }
        }

        private void getDoencas(int idConsulta)
        {
            LinkedList<Diagnostico_Doenca> doenca = diagnosticoBLL.selectDoencaByDiagnostico(idConsulta);

            foreach (Diagnostico_Doenca each in doenca)
            {
                lbDoencas.Items.Add(each.doenca);
            }

        }

        protected void tbDiagnostico_TextChanged(object sender, EventArgs e)
        {

        }
    }
}