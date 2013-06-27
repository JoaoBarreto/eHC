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
    public class utenteDAL
    {
        public static LinkedList<Utente> selectUtente()
        {
            // Comando
            string commString = "SELECT * FROM Utente";
            // Criar Ligacao
            SqlConnection connection = new SqlConnection(DAL.Default.connectionString);
            //Enviar comando
            SqlCommand command = new SqlCommand(commString, connection);
            // Cria Lista
            LinkedList<Utente> utenteList = new LinkedList<Utente>();
            try
            {
                // Abrir Ligação
                connection.Open();

                // Fecha Stream
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);


                while (reader.Read())
                {
                    Utente utente = new Utente();
                    // Primeira coluna - 0
                    if (!reader.IsDBNull(0))
                        utente.idUtente = reader.GetInt32(0);
                    if (!reader.IsDBNull(1))
                        utente.idFichaClinica = reader.GetInt32(1);
                    if (!reader.IsDBNull(2))
                        utente.nome = reader.GetString(2);
                    if (!reader.IsDBNull(3))
                        utente.morada = reader.GetString(3);
                    if (!reader.IsDBNull(4))
                    utente.telefone = reader.GetInt32(4);
                    if (!reader.IsDBNull(5))
                    utente.email = reader.GetString(5);
                    if (!reader.IsDBNull(6))
                    utente.dataNascimento = reader.GetDateTime(6);
                    if (!reader.IsDBNull(7))
                    utente.codigoPostal = reader.GetString(7);
					if (!reader.IsDBNull(8))
                    utente.fotografia = reader.GetString(8);
                    utenteList.AddLast(utente);

                }
            }
            catch (SqlException e)
            {

            }
            // Fecha a ligação
            connection.Close();
            return utenteList;
        }
        
                public static Utente selectUtenteByIDConsulta(int IDConsulta)
                {
                    // Comando
                    string commString = "SELECT dbo.Utente.* FROM dbo.Utente INNER JOIN dbo.Consulta ON dbo.Utente.IdUtente = dbo.Consulta.IdUtente where dbo.Consulta.IdConsulta = "+IDConsulta;
                    // Criar Ligacao
                    SqlConnection connection = new SqlConnection(DAL.Default.connectionString);
                    //Enviar comando
                    SqlCommand command = new SqlCommand(commString, connection);
                    // Cria Lista
                    Utente utente = new Utente();
                    try
                    {
                        // Abrir Ligação
                        connection.Open();

                        // Fecha Stream
                        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
               
                
                        while (reader.Read())
                        {
                                
                    // Primeira coluna - 0
                    if (!reader.IsDBNull(0))
                        utente.idUtente = reader.GetInt32(0);
                    if (!reader.IsDBNull(1))
                        utente.idFichaClinica = reader.GetInt32(1);
                    if (!reader.IsDBNull(2))
                        utente.nome = reader.GetString(2);
                    if (!reader.IsDBNull(3))
                        utente.morada = reader.GetString(3);
                    if (!reader.IsDBNull(4))
                    utente.telefone = reader.GetInt32(4);
                    if (!reader.IsDBNull(5))
                    utente.email = reader.GetString(5);
                    if (!reader.IsDBNull(6))
                    utente.dataNascimento = reader.GetDateTime(6);
                    if (!reader.IsDBNull(7))
                    utente.codigoPostal = reader.GetString(7);
				    if (!reader.IsDBNull(8))
                    utente.fotografia = reader.GetString(8);
                         }
                    }
                    catch (SqlException e) 
                    {

                    }
                    // Fecha a ligação
                    connection.Close();
                    return utente;
                
                }
          public static Utente selectUtenteByIDUtente(int idUtente)
        {
            // Comando
            string commString = "SELECT * FROM Utente where idUtente="+idUtente;
            // Criar Ligacao
            SqlConnection connection = new SqlConnection(DAL.Default.connectionString);
            //Enviar comando
            SqlCommand command = new SqlCommand(commString, connection);
            
            Utente utente = new Utente();
            try
            {
                // Abrir Ligação
                connection.Open();

                // Fecha Stream
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);


                while (reader.Read())
                { 
                    // Primeira coluna - 0
                    if (!reader.IsDBNull(0))
                        utente.idUtente = reader.GetInt32(0);
                    if (!reader.IsDBNull(1))
                        utente.idFichaClinica = reader.GetInt32(1);
                    if (!reader.IsDBNull(2))
                        utente.nome = reader.GetString(2);
                    if (!reader.IsDBNull(3))
                        utente.morada = reader.GetString(3);
                    if (!reader.IsDBNull(4))
                        utente.telefone = reader.GetInt32(4);
                    if (!reader.IsDBNull(5))
                        utente.email = reader.GetString(5);
                    if (!reader.IsDBNull(6))
                        utente.dataNascimento = reader.GetDateTime(6);
                    if (!reader.IsDBNull(7))
                        utente.codigoPostal = reader.GetString(7);
					if (!reader.IsDBNull(8))
                        utente.fotografia = reader.GetString(8);
                   

                }
            }
            catch (SqlException e)
            {

            }
            // Fecha a ligação
            connection.Close();
            return utente;
        }
    
    }
}
