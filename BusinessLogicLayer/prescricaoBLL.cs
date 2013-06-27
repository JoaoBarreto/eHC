using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer;
using DataTransferObject;

namespace BusinessLogicLayer
{
    public class prescricaoBLL
    {
        public static int inserirPrescricao(int idPrescricao)
        {
            return prescricaoDAL.inserirPrescricao(idPrescricao);
        }

        public static LinkedList<ElementosPrescritos> selectPrescricaoByIDDiagnostico(int idDiagnostico)
        {
            return prescricaoDAL.selectPrescricaoByIDDiagnostico(idDiagnostico);
        }

        public static int inserirPrescricaoElementosPrescritos(PrescricaoElementosPrescritos resultPrescricaoElementosPrescritos)
        {
           return prescricaoDAL.inserirPrescricaoElementosPrescritos(resultPrescricaoElementosPrescritos);
        }

        public static void apagarPrescricaoElementosPrescritos(int idPrescricao)
        {
            prescricaoDAL.apagarPrescricaoElementosPrescritos(idPrescricao);
        }

        public static void apagarPrescricao(int idPrescricao)
        {
            prescricaoDAL.apagarPrescricao(idPrescricao);
        }
    }
}
