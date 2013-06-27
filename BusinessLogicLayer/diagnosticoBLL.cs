using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject;
using DataAcessLayer;

namespace BusinessLogicLayer
{
    public class diagnosticoBLL
    {
        public static LinkedList<Diagnostico> selectDiagnostico()
        {
            return diagnosticoDAL.selectDiagnostico();
        }

        public static LinkedList<Diagnostico> selectDiagnosticoByIDUtente(int idUtente)
        {
            return diagnosticoDAL.selectDiagnosticoByIDUtente(idUtente);
        }

        public static LinkedList<Diagnostico_Doenca> selectDoencaByDiagnostico(int idDiagnostico)
        {
            return diagnosticoDAL.selectDoencaByDiagnostico(idDiagnostico);
        }



        public static int insertDiagnosticoConsulta(Diagnostico diagnostico)
        {               
               return diagnosticoDAL.insertDiagnosticoConsulta(diagnostico);
            
        }

        public static int countDiagnosticos()
        {
            return diagnosticoDAL.countDiagnosticos();
        }

        public static int insertDiagnosticoDoenca(int idDoenca, int idConsulta)
        {
           return diagnosticoDAL.insertDiagnosticoDoenca(idDoenca, idConsulta);
        }

        public static void apagarDiagnosticoDoenca(int idDiagnostico)
        {
            diagnosticoDAL.apagarDiagnosticoDoenca(idDiagnostico);
        }

        public static void apagarDiagnostico(int idDiagnostico)
        {
            diagnosticoDAL.apagarDiagnostico(idDiagnostico);
        }

        public static Diagnostico selectDiagnosticoByIDConsulta(int idConsulta)
        {
            return diagnosticoDAL.selectDiagnosticoByIDConsulta(idConsulta);
        }
    }
}
