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
    public class medicoDAL
    {
        public static Medico selectMedicoByIdEmpregado(int idEmpregado)
        {

            // Comando
            string commString = "SELECT * FROM Empregado where IDEmpregado=" + idEmpregado;
            // Criar Ligacao
            SqlConnection connection = new SqlConnection(DAL.Default.connectionString);
            //Enviar comando
            SqlCommand command = new SqlCommand(commString, connection);
            // Cria Lista
            Medico medico = new Medico();
            try
            {
                // Abrir Ligação
                connection.Open();

                // Fecha Stream
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    // Primeira coluna - 0   
                    medico.idMedico = reader.GetInt32(0);
                    medico.nome = reader.GetString(1);
                    
                }

            }
            catch (SqlException e)
            {

            }
            // Fecha a ligação
            connection.Close();
            return medico;
        }
    }
}
