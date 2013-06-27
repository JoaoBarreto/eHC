using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer;
using DataTransferObject;

namespace BusinessLogicLayer
{
    public class fichaClinicaBLL
    {

        public static void apagarFichaClinicaDiagnostico(int idDiagnostico)
        {
            fichaClinicaDAL.apagarFichaClinicaDiagnostico(idDiagnostico);
        }
    }
}
