using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer;
using DataTransferObject;

namespace BusinessLogicLayer
{
    public class elementoPrescritoBLL
    {
        public static LinkedList<ElementosPrescritos> selectElementosPrescritoPorUtente(int idUtente)
        {
            return elementoPrescritoDAL.selectElementosPrescritosPorUtente(idUtente);
        }

        public static ElementosPrescritos selectElementoPrescritoByName(string nomeElementoPrescrito)
        {
            return elementoPrescritoDAL.selectElementoPrescritoByName(nomeElementoPrescrito);
        }
    }
}
