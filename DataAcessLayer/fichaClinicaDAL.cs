using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; // Dados SQL
using System.Data.SqlClient; // CLiente SQL
using DataTransferObject;

namespace DataAcessLayer
{
    public class fichaClinicaDAL
    {
        public static void apagarFichaClinicaDiagnostico(int idDiagnostico)
        {

            string commString = "DELETE FROM FichaClinicaDiagnostico where idDiagnostico=" + idDiagnostico;
            // Criar Ligacao
            SqlConnection connection = new SqlConnection(DAL.Default.connectionString);
            //Enviar comando
            SqlCommand command = new SqlCommand(commString, connection);

            // Abrir Ligação
            connection.Open();
            // Fecha Stream
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            // Fecha a ligação
            connection.Close();
        }   
    }
}
