using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer;
using DataTransferObject;

namespace BusinessLogicLayer
{
    public class utenteBLL
    {
        public static LinkedList<Utente> selectUtente()
        {
            return utenteDAL.selectUtente();
        }

        public static Utente selectUtenteByIDConsulta(int IdConsulta)
        {
            return utenteDAL.selectUtenteByIDConsulta(IdConsulta);
        }

        public static Utente selectUtenteByIDUtente(int idUtente)
        {
            return utenteDAL.selectUtenteByIDUtente(idUtente);
        }
    }
}
