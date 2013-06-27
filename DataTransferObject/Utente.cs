using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class Utente
    {
        public int idUtente { get; set; }
        public int idFichaClinica { get; set; }
        public string morada { get; set; }
        public int telefone { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public DateTime dataNascimento { get; set; }
        public string codigoPostal { get; set; }
		public string fotografia { get; set; }
    }
}
