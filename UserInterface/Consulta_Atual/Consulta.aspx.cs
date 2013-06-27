using BusinessLogicLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace UserInterface
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private const string linkToConsultasAnteriores = "~/Consultas_Anteriores/ConsultaAnterior.aspx?idDiagnostico=";
        const string idConsultaString = "idConsulta=";
        const string linkToConsulta = "~/Consulta_Atual/Consulta.aspx?idConsulta=";
        const string linkToUtente = "~/Ficha_Utente/Utente.aspx?idUtente=";
        const string linkToMedico = "~/Ficha_Medico/Medico.aspx?idMedico=";
        const string mode = "&mode=";
        const string typeString = "&type=";
        private int idConsulta;
        private Utente utente;
        private Medico medico;
        private Consulta consulta;
        const int consultaFechada = 4;
        const int consultaPendente = 3;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                dadosUtente();
                builtTextBoxs();
                permissoesDeEscrita(idConsulta);
                builtFichaClinica();
                buitExamesRecentes();
            }
        }

        private void dadosUtente()
        {
            if (Request.QueryString["idConsulta"] != null)
            {
                idConsulta = int.Parse(Request.QueryString["idConsulta"]);
                utente = utenteBLL.selectUtenteByIDConsulta(idConsulta);
                consulta = consultaBLL.selectConsultaByIDConsulta(idConsulta);
                medico = medicoBLL.selectMedicoByIdEmpregado(consulta.idEmpregado);
            }
        }

        private void permissoesDeEscrita(int idConsulta)
        {
            // OPCAO 4 - CONSULTA FECHADA
            if (Request.QueryString["mode"] == "4")
            {           
                btAddDoenca.Enabled = false;
                btRemoveDoenca.Enabled = false;
                tbDiagnostico.Enabled = false;
                btSubmeter.Enabled = false;
                btGuardar.Enabled = false;
                btEscolher.Enabled = false;
                btRemover.Enabled = false;
               
                
            }
            if (Request.QueryString["mode"] == "4" || Request.QueryString["mode"] == "3")
            {
                buscarDiagnostico(idConsulta);
                buscarDoencas(idConsulta);
                buscarPrescrições(idConsulta);
            }
        }



        private void buscarPrescrições(int idConsulta)
        {
            LinkedList<ElementosPrescritos> prescricoes = prescricaoBLL.selectPrescricaoByIDDiagnostico(idConsulta);
            foreach (ElementosPrescritos each in prescricoes)
            {
                string temp = each.nome + " " + each.quantidade;
                lbPrescricao.Items.Add(temp);
            }
        }

        private void buscarDoencas(int idConsulta)
        {
            LinkedList<Diagnostico_Doenca> doenca = diagnosticoBLL.selectDoencaByDiagnostico(idConsulta);

            foreach (Diagnostico_Doenca each in doenca)
            {
                listbDoencasAdicionadas.Items.Add(each.doenca);
            }

        }

        private void buscarDiagnostico(int idConsulta)
        {
            Diagnostico diagnostico = diagnosticoBLL.selectDiagnosticoByIDConsulta(idConsulta);
         //   if(diagnostico.First != null)
          //  {
               
                tbDiagnostico.Text += diagnostico.diagnostico;
           // }
        }

        private void buitExamesRecentes()
        {
            LinkedList<ElementosPrescritos> listElementos = elementoPrescritoBLL.selectElementosPrescritoPorUtente(utente.idUtente);

            foreach (ElementosPrescritos each in listElementos)
            {
                listbExames.Items.Add(each.nome);
            }
        }

        private void builtTextBoxs()
        {
            // Nr - Consulta:
            lbIdConsulta.Text = "" + idConsulta;

            // Estado Consulta 
            string value;
            Array values = Enum.GetValues(typeof(Consulta.estadoEnum));
            value = values.GetValue(Convert.ToInt32(consulta.estado)).ToString();
            lbEstadoConsulta.Text = "" + value;
            // Nome Utente
            lbNomeUtente.Text = "" + utente.nome;
            lbNomeMedico.Text = "" + medico.nome;
        }

        private void builtFichaClinica()
        {
            // Saca diagnosticos do cliente
            LinkedList<Diagnostico> listDiagnostico = diagnosticoBLL.selectDiagnosticoByIDUtente(utente.idUtente);
            foreach (Diagnostico each in listDiagnostico)
            {
                if (each.idDiagnostico != consulta.idConsulta)
                {
                    // Saca as doenças daquela diagnostico
                    LinkedList<Diagnostico_Doenca> tempDoencas = diagnosticoBLL.selectDoencaByDiagnostico(each.idDiagnostico);

                    string temp = "";

                    foreach (Diagnostico_Doenca each1 in tempDoencas)
                    {
                        temp += each1.doenca + " | ";
                    }

                    temp += " - " + each.data + "< Nr Diagnostico " + each.idDiagnostico + " >";
                    listbDiagnosticos.Items.Add(temp);
                }
            }
        }

        protected void btAddDoenca_Click(object sender, EventArgs e)
        {
            if (listBDoencas.SelectedItem != null)
            {
                listbDoencasAdicionadas.Items.Add(listBDoencas.SelectedItem.Value);
                listBDoencas.Items.Remove(listBDoencas.SelectedItem.Value);
            }
        }

        protected void btRemoveDoenca_Click(object sender, EventArgs e)
        {
            if (listbDoencasAdicionadas.SelectedItem != null)
            {
                listBDoencas.Items.Add(listbDoencasAdicionadas.SelectedItem.Value);
                listbDoencasAdicionadas.Items.Remove(listbDoencasAdicionadas.SelectedItem.Value);
            }
        }


        protected void btVerDiagnostico_Click(object sender, EventArgs e)
        {
            dadosUtente();
            if (listbDiagnosticos.SelectedIndex != -1)
            {
                string[] split = listbDiagnosticos.SelectedItem.Value.Split();
                string nrDiagnostico = split[split.Length - 2];
                Response.Redirect(linkToConsultasAnteriores + nrDiagnostico + "&" + idConsultaString + idConsulta + mode + Request.QueryString["mode"] + typeString + Request.QueryString["type"]);
            }
        }

        protected void btSubmeter_Click(object sender, EventArgs e)
        {
            inserirDiagnosticoPrescricaoDoencasBaseDados();
            alterarEstadoDaConsulta(idConsulta, consultaFechada);
            dadosUtente();
            int type = int.Parse(Request.QueryString["type"]);
            string link="";
            int idFinal=-1;
            if (type == 1)
            {
                link = linkToUtente;
                idFinal = consulta.idUtente;
            }
            else if(type == 2)
            {
                link = linkToMedico;
                idFinal = consulta.idEmpregado;
            }
            Response.Redirect(link + idFinal);
            
        }

        private void inserirDiagnosticoPrescricaoDoencasBaseDados()
        {
            dadosUtente();
            apagarInformacaoConsultaUtente(idConsulta, consulta.idUtente, idConsulta, utente.idFichaClinica, idConsulta);
            LinkedList<ElementosPrescritos> elementosPrescricao = new LinkedList<ElementosPrescritos>();
            List<String> listText = new List<string>();
            adicionaPrescricoesNaListStrings(listText);
            adicionaElementosPrescritosAtravesDasStrings(elementosPrescricao, listText);
            List<string> elementosDoencas = listaDoencas();
            inserirPrescricaoEAdicionarElementosPrescritos(idConsulta, elementosPrescricao);  
            inserirDiagnostico(idConsulta);
            inserirDoencas(idConsulta, elementosDoencas);
        }

        private void apagarInformacaoConsultaUtente(int idConsulta, int idUtente, int idDiagnostico, int idFichaClinica, int idPrescricao)
        {
            
            diagnosticoBLL.apagarDiagnosticoDoenca(idDiagnostico);
            prescricaoBLL.apagarPrescricaoElementosPrescritos(idPrescricao);
            fichaClinicaBLL.apagarFichaClinicaDiagnostico(idDiagnostico);
            diagnosticoBLL.apagarDiagnostico(idDiagnostico);
            prescricaoBLL.apagarPrescricao(idPrescricao);     
            
        }

        private static void adicionaElementosPrescritosAtravesDasStrings(LinkedList<ElementosPrescritos> elementosPrescricao, List<String> listText)
        {
            foreach (string each in listText)
            {
                ElementosPrescritos elemento = new ElementosPrescritos();
                string[] split = each.Split();
                elemento.nome = split[0];
                if (split.Length == 2)
                {
                    elemento.quantidade = int.Parse(split[1]);
                }
                elementosPrescricao.AddLast(elemento);
            }
        }

        private void adicionaPrescricoesNaListStrings(List<String> listText)
        {
            for (int i = 0; i < lbPrescricao.Items.Count; i++)
            {
                listText.Add(lbPrescricao.Items[i].ToString());
            }
        }

        private List<string> listaDoencas()
        {
            List<string> elementosDoencas = new List<string>();
            for (int i = 0; i < listbDoencasAdicionadas.Items.Count; i++)
            {
                elementosDoencas.Add(listbDoencasAdicionadas.Items[i].ToString());
            }
            return elementosDoencas;
        }


        private void inserirDiagnosticoDoenca(Doenca doenca, int idDiagnostico)
        {
            diagnosticoBLL.insertDiagnosticoDoenca(doenca.idDoenca, idDiagnostico);

        }

        private void inserirDoencas(int idDiagnostico, List<string> elementosDoencas)
        {
            foreach (string each in elementosDoencas)
            {
                Doenca doenca = doencaBLL.selectDoencaByNome(each);
                inserirDiagnosticoDoenca(doenca, idDiagnostico);
            }
        }

        private void inserirDiagnostico(int idConsulta1)
        {
            Diagnostico diagnostico = new Diagnostico();
            string diagnosticoTexto = tbDiagnostico.Text;
            diagnostico.idDiagnostico = idConsulta1;
            diagnostico.idConsulta = idConsulta1;
            diagnostico.diagnostico = diagnosticoTexto;
            diagnostico.idPrescricao = idConsulta1;
            diagnosticoBLL.insertDiagnosticoConsulta(diagnostico);
        }

        protected void btRemover_Click(object sender, EventArgs e)
        {
            if (lbPrescricao.SelectedItem != null)
            {
                lbPrescricao.Items.Remove(lbPrescricao.SelectedItem.Value);
            }
        }

        private void alterarEstadoDaConsulta(int idConsulta, int estado)
        {
            consultaBLL.updateEstadoConsulta(idConsulta, estado);
        }

        private void inserirPrescricaoEAdicionarElementosPrescritos(int idDiagnostico, LinkedList<ElementosPrescritos> elementosPrescricao)
        {
            // COLOQUEI IDPRESCRICAO = IDDIAGNOSTICO!
            prescricaoBLL.inserirPrescricao(idDiagnostico);

            foreach (ElementosPrescritos each in elementosPrescricao)
            {
                ElementosPrescritos dboElementoPrescrito = elementoPrescritoBLL.selectElementoPrescritoByName(each.nome);
                PrescricaoElementosPrescritos resultPrescricaoElementosPrescritos = new PrescricaoElementosPrescritos();
                resultPrescricaoElementosPrescritos.idElementosPrescritos = dboElementoPrescrito.idElemento;
                resultPrescricaoElementosPrescritos.idPrescricao = idDiagnostico;
                resultPrescricaoElementosPrescritos.quantidade = each.quantidade;
                prescricaoBLL.inserirPrescricaoElementosPrescritos(resultPrescricaoElementosPrescritos);
            }

        }

        protected void btEscolher_Click(object sender, EventArgs e)
        {
            lbPrescricao.Items.Add("Aspegic 100");
        }

        protected void btGuardar_Click(object sender, EventArgs e)
        {
            inserirDiagnosticoPrescricaoDoencasBaseDados();
            consultaBLL.updateEstadoConsulta(idConsulta, consultaPendente);
            
            int type = int.Parse(Request.QueryString["type"]);
          
            Response.Redirect(linkToConsulta + idConsulta + mode + consultaPendente+typeString+type);
        }

        protected void btVoltar_Click(object sender, EventArgs e)
        {
            dadosUtente();
            int type = int.Parse(Request.QueryString["type"]);
            string link = "";
            int idFinal = -1;
            if (type == 1)
            {
                link = linkToUtente;
                idFinal = consulta.idUtente;
            }
            else if (type == 2)
            {
                link = linkToMedico;
                idFinal = consulta.idEmpregado;
            }
            Response.Redirect(link + idFinal);
        }

    }

}