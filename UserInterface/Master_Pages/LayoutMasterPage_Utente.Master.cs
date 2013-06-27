using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DataTransferObject;
using BusinessLogicLayer;

namespace UserInterface
{
    public partial class Site2 : System.Web.UI.MasterPage
    {

        private int idConsulta;
        private Utente utente;
        private Consulta consulta;

        protected void Page_Load(object sender, EventArgs e)
        {
            titleElement.InnerHtml = "eHC - While True Systems";
            builtTextBoxs();
        }


        private void builtTextBoxs()
        {
            // Nr - Consulta:
            //lbIdConsulta.Text = "" + idConsulta;
                      
            if (Request.QueryString["idConsulta"] != null)
            {
                idConsulta = int.Parse(Request.QueryString["idConsulta"]);
                utente = utenteBLL.selectUtenteByIDConsulta(idConsulta);
                consulta = consultaBLL.selectConsultaByIDConsulta(idConsulta);
            }
            
            // Estado Consulta 
            //string value;
            //Array values = Enum.GetValues(typeof(Consulta.estadoEnum));
            //value = values.GetValue(Convert.ToInt32(consulta.estado)).ToString();
            //  lbEstadoConsulta.Text = "" + value;
            // Nome Utente
            imgUtente.ImageUrl = utente.fotografia;
            lbNomeUtente.Text = "" + utente.nome;
            lbMoradaUtente.Text = "" + utente.morada;
            lbCodPostal.Text = "" + utente.codigoPostal;
            lbTelefone.Text = "" + utente.telefone;
            lbEmail.Text = "" + utente.email;
        }
    }
}