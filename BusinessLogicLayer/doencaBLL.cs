using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer;
using DataTransferObject;

namespace BusinessLogicLayer
{
   public class doencaBLL
    {
        public static LinkedList<Doenca> selectDoenca()
        {
            return doencaDAL.selectDoenca();
        }

        public static Doenca selectDoencaByNome(string each)
        {
            return doencaDAL.selectDoencaByNome(each);
        }
    }
}
