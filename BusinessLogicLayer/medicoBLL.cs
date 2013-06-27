using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer;
using DataTransferObject;

namespace BusinessLogicLayer
{
    public class medicoBLL
    {
        public static Medico selectMedicoByIdEmpregado(int idEmpregado)
        {
            return medicoDAL.selectMedicoByIdEmpregado(idEmpregado);
        }
    }
}
