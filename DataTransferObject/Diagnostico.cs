using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
     public class Diagnostico
    {
        public int idDiagnostico { get; set; }
        public int idConsulta { get; set; }
        public string diagnostico{ get; set; }
        public DateTime data { get; set; }
        public int idPrescricao { get; set; }
    }
}
