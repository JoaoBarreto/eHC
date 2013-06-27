using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserInterface
{
    public partial class Webform3 : System.Web.UI.Page
    {
        const string linkToUtente = "~/Ficha_Utente/Utente.aspx?idUtente=";
        const string linkToMedico = "~/Ficha_Medico/Medico.aspx?idMedico=";
        protected void Page_Load(object sender, EventArgs e)
        {
       
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                if (DropDownList1.SelectedItem.Value == "idMedico")
                {
                    Response.Redirect(linkToMedico + TextBox1.Text);
                }
                else
                    if (DropDownList1.SelectedItem.Value == "idUtente")
                    {
                        Response.Redirect(linkToUtente + TextBox1.Text);
                    }
            }
            else  TextBox1.Text = "";
        }
    }
}