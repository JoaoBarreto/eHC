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
    public partial class WebForm1 : System.Web.UI.Page
    {
        const string linkToConsulta = "~/Consulta_Atual/Consulta.aspx?idConsulta=";
        const string mode = "&mode=4";
        const string type = "&type=1";
        const string defaultLabelText = "Consultas de ";
        Utente utente;

        protected void Page_Load(object sender, EventArgs e)
        {
            int idUtente = int.Parse(Request.QueryString["idUtente"]);
            utente = EHC_Manager.selectUtenteByIDUtente(idUtente);
            lbName.Text = defaultLabelText + utente.nome;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(linkToConsulta + GridView1.SelectedRow.Cells[0].Text + mode+type);
        }

        protected void buttonAdicionarEspecialidade_Click(object sender, EventArgs e)
        {
            lbEspecialidadesSelecionadas.Items.Add(dDLListEspecialidades.SelectedValue);
            dDLListEspecialidades.Items.RemoveAt(dDLListEspecialidades.SelectedIndex);
            filtrarListaDasConsultas(lbEspecialidadesSelecionadas.Items);
        }

        private void filtrarListaDasConsultas(ListItemCollection listItemCollection)
        {
            foreach (GridViewRow tt in GridView1.Rows)
            {
                tt.Visible = true;
            }
            foreach (GridViewRow tt in GridView1.Rows)
            {
                string foundText;
                try
                {
                    foundText = listItemCollection.FindByValue(tt.Cells[7].Text).Value;
                     
                }
                catch (Exception e)
                {
                    tt.Visible = false;
                }
              
               
                        
            }
        }

        protected void buttonRemoverEspecialidade_Click(object sender, EventArgs e)
        {
            if (lbEspecialidadesSelecionadas.SelectedIndex != -1)
            {
                dDLListEspecialidades.Items.Add(lbEspecialidadesSelecionadas.SelectedValue);
                lbEspecialidadesSelecionadas.Items.RemoveAt(lbEspecialidadesSelecionadas.SelectedIndex);
                if (dDLListEspecialidades.Items.Count != 0)
                    filtrarListaDasConsultas(dDLListEspecialidades.Items);
                else
                {
                    foreach (GridViewRow tt in GridView1.Rows)
                    {
                        tt.Visible = true;
                    }
                }

            }
        }

        protected void buttonRemoverTodasAsEspecialidades_Click(object sender, EventArgs e)
        {
            foreach (ListItem each in lbEspecialidadesSelecionadas.Items)
            {
                dDLListEspecialidades.Items.Add(each.Text);
            }
            lbEspecialidadesSelecionadas.Items.Clear();
            foreach (GridViewRow tt in GridView1.Rows)
            {
                tt.Visible = true;
            }
        }

        protected void GridView1_SelectedIndexChanged2(object sender, EventArgs e)
        {
            Response.Redirect(linkToConsulta + GridView1.SelectedRow.Cells[1].Text + mode + type);
        }

       

    }
}