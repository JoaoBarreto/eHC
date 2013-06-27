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
    public class elementoPrescritoDAL
    {
        public static LinkedList<ElementosPrescritos> selectElementosPrescritosPorUtente(int idUtente)
        {
            // Comando
            string commString = "SELECT dbo.ElementosPrescritos.*, dbo.PrescricaoElementosPrescritos.Quantidade FROM dbo.ElementosPrescritos INNER JOIN dbo.PrescricaoElementosPrescritos INNER JOIN dbo.Prescricao ON dbo.PrescricaoElementosPrescritos.IdPrescricao = dbo.Prescricao.IdPrescricao ON dbo.ElementosPrescritos.IdElemento = dbo.PrescricaoElementosPrescritos.IdElemento INNER JOIN dbo.Diagnostico ON dbo.Prescricao.IdPrescricao = dbo.Diagnostico.IdPrescricao INNER JOIN dbo.Utente INNER JOIN dbo.Consulta ON dbo.Utente.IdUtente = dbo.Consulta.IdUtente ON dbo.Diagnostico.IdConsulta = dbo.Consulta.IdConsulta where UTente.idUtente ="+idUtente+ " and Consulta.IdUtente = "+idUtente ;
            // Criar Ligacao
            SqlConnection connection = new SqlConnection(DAL.Default.connectionString);
            //Enviar comando
            SqlCommand command = new SqlCommand(commString, connection);
            // Cria Lista
            LinkedList<ElementosPrescritos> elementosList = new LinkedList<ElementosPrescritos>();
            try
            {
                // Abrir Ligação
                connection.Open();

                // Fecha Stream
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    ElementosPrescritos elemento = new ElementosPrescritos();
                    // Primeira coluna - 0
                    if (!reader.IsDBNull(0))
                        elemento.idElemento = reader.GetInt32(0);
                    if (!reader.IsDBNull(1))
                        elemento.nome = reader.GetString(1);
                    if (!reader.IsDBNull(2))
                        elemento.quantidade = reader.GetInt32(2);

                    elementosList.AddLast(elemento);

                }
            }
            catch (SqlException e)
            {

            }
            // Fecha a ligação
            connection.Close();
            return elementosList;
        }

        public static ElementosPrescritos selectElementoPrescritoByName(string nomeElementoPrescrito)
        {
            // Comando
            
            string commString = "SELECT * FROM ElementosPrescritos where Nome = '"+nomeElementoPrescrito+"'";
             
            // Criar Ligacao
            SqlConnection connection = new SqlConnection(DAL.Default.connectionString);
            //Enviar comando
            SqlCommand command = new SqlCommand(commString, connection);
            // Cria Lista
            ElementosPrescritos elemento = new ElementosPrescritos();

            // Abrir Ligação
            connection.Open();

            // Fecha Stream
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                // Primeira coluna - 0
                if (!reader.IsDBNull(0))
                    elemento.idElemento = reader.GetInt32(0);
                if (!reader.IsDBNull(1))
                    elemento.nome = reader.GetString(1);
            }


            // Fecha a ligação
            connection.Close();
            return elemento;


        }
    }
}
