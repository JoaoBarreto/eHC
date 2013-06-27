using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
   public class Consulta
    {
        public int idSala { get; set; }
        public int idConsulta { get; set; }
        public int idEmpregado { get; set; }
        public int idUtente { get; set; }
        public int estado { get; set; }
        public string observacoes { get; set; }
        public DateTime data { get; set; }
        public enum estadoEnum { porConfirmar, confirmado, aberto, pendente, fechado, cancelado }
        public string especialidade { get; set; }
        public string designacaoSala { get; set; }
        public string nomeUtente { get; set; }
        public string nomeEmpregado { get; set; }
    }
}
