using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BusinessLogicLayer;
using DataTransferObject;

namespace UserInterface.Ficha_Medico
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        const string linkToConsulta = "~/Consulta_Atual/Consulta.aspx?idConsulta=";
        const string mode = "&mode=";
        const string type ="&type=2";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            int idMedico = int.Parse(Request.QueryString["idMedico"]);
            Medico medico = medicoBLL.selectMedicoByIdEmpregado(idMedico);
            lbNomeMedico.Text = "" + medico.nome;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(linkToConsulta + GridView1.SelectedRow.Cells[1].Text + mode + GridView1.SelectedRow.Cells[6].Text + type);
        }
    }
}