using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject;

namespace BusinessLogicLayer
{
    public class EHC_Manager
    {
        /* consultaBLL
         */
        public static LinkedList<Consulta> selectConsulta()
        {
            return consultaBLL.selectConsulta();
        }

        public static Consulta selectConsultaByIDConsulta(int idConsulta)
        {
            return consultaBLL.selectConsultaByIDConsulta(idConsulta);
        }

        public static int updateEstadoConsulta(int idConsulta, int estado)
        {
            return consultaBLL.updateEstadoConsulta(idConsulta, estado);
        }

        public static LinkedList<Consulta> selectConsultaByIDMedico(int idMedico)
        {
            return consultaBLL.selectConsultaByIDMedico(idMedico);
        }

        public static LinkedList<Consulta> selectConsultaByIDUtente(int idUtente)
        {
            return consultaBLL.selectConsultaByIDUtente(idUtente);
        }

        public static LinkedList<Especialidade> selectEspecialidadesComConsultaDoUtente(int idUtente)
        {
            return consultaBLL.selectEspecialidadesComConsultaDoUtente(idUtente);
        }


        /* elementoPRescritoBLL
         */
        public static LinkedList<ElementosPrescritos> selectElementosPrescritoPorUtente(int idUtente)
        {
            return elementoPrescritoBLL.selectElementosPrescritoPorUtente(idUtente);
        }

        public static ElementosPrescritos selectElementoPrescritoByName(string nomeElementoPrescrito)
        {
            return elementoPrescritoBLL.selectElementoPrescritoByName(nomeElementoPrescrito);
        }

        /* fichaClinicaBLL
         */
        public static void apagarFichaClinicaDiagnostico(int idDiagnostico)
        {
            fichaClinicaBLL.apagarFichaClinicaDiagnostico(idDiagnostico);
        }

        /* prescricaoBLL
         */

        public static int inserirPrescricao(int idPrescricao)
        {
            return prescricaoBLL.inserirPrescricao(idPrescricao);
        }

        public static LinkedList<ElementosPrescritos> selectPrescricaoByIDDiagnostico(int idDiagnostico)
        {
            return prescricaoBLL.selectPrescricaoByIDDiagnostico(idDiagnostico);
        }

        public static int inserirPrescricaoElementosPrescritos(PrescricaoElementosPrescritos resultPrescricaoElementosPrescritos)
        {
            return prescricaoBLL.inserirPrescricaoElementosPrescritos(resultPrescricaoElementosPrescritos);
        }

        public static void apagarPrescricaoElementosPrescritos(int idPrescricao)
        {
            prescricaoBLL.apagarPrescricaoElementosPrescritos(idPrescricao);
        }

        public static void apagarPrescricao(int idPrescricao)
        {
            prescricaoBLL.apagarPrescricao(idPrescricao);
        }

        /* utenteBLL
         */

        public static LinkedList<Utente> selectUtente()
        {
            return utenteBLL.selectUtente();
        }

        public static Utente selectUtenteByIDConsulta(int IdConsulta)
        {
            return utenteBLL.selectUtenteByIDConsulta(IdConsulta);
        }

        public static Utente selectUtenteByIDUtente(int idUtente)
        {
            return utenteBLL.selectUtenteByIDUtente(idUtente);
        }

        /* doencaBLL
         */

        public static LinkedList<Doenca> selectDoenca()
        {
            return doencaBLL.selectDoenca();
        }

        public static Doenca selectDoencaByNome(string each)
        {
            return doencaBLL.selectDoencaByNome(each);
        }

        /* diagnosticoBLL
         */

        public static LinkedList<Diagnostico> selectDiagnostico()
        {
            return diagnosticoBLL.selectDiagnostico();
        }

        public static LinkedList<Diagnostico> selectDiagnosticoByIDUtente(int idUtente)
        {
            return diagnosticoBLL.selectDiagnosticoByIDUtente(idUtente);
        }

        public static LinkedList<Diagnostico_Doenca> selectDoencaByDiagnostico(int idDiagnostico)
        {
            return diagnosticoBLL.selectDoencaByDiagnostico(idDiagnostico);
        }



        public static int insertDiagnosticoConsulta(Diagnostico diagnostico)
        {
            return diagnosticoBLL.insertDiagnosticoConsulta(diagnostico);

        }

        public static int countDiagnosticos()
        {
            return diagnosticoBLL.countDiagnosticos();
        }

        public static int insertDiagnosticoDoenca(int idDoenca, int idConsulta)
        {
            return diagnosticoBLL.insertDiagnosticoDoenca(idDoenca, idConsulta);
        }

        public static void apagarDiagnosticoDoenca(int idDiagnostico)
        {
            diagnosticoBLL.apagarDiagnosticoDoenca(idDiagnostico);
        }

        public static void apagarDiagnostico(int idDiagnostico)
        {
            diagnosticoBLL.apagarDiagnostico(idDiagnostico);
        }

        public static Diagnostico selectDiagnosticoByIDConsulta(int idConsulta)
        {
            return diagnosticoBLL.selectDiagnosticoByIDConsulta(idConsulta);
        }

        /* medicoBLL
        */

        public static Medico selectMedicoByIdEmpregado(int idEmpregado)
        {
            return medicoBLL.selectMedicoByIdEmpregado(idEmpregado);
        }
    }
    }

