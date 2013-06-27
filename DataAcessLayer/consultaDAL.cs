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
    public class consultaDAL
    {
        public static LinkedList<Consulta> selectConsulta()
        {
            // Comando
            string commString = "SELECT dbo.Consulta.*, dbo.Medico.*, dbo.Sala.*, dbo.Utente.* FROM dbo.Consulta INNER JOIN dbo.Medico ON dbo.Consulta.IdEmpregado = dbo.Medico.IdEmpregado INNER JOIN dbo.Sala ON dbo.Consulta.IdSala = dbo.Sala.IdSala INNER JOIN dbo.Utente ON dbo.Consulta.IdUtente = dbo.Utente.IdUtente";
            // Criar Ligacao
            SqlConnection connection = new SqlConnection(DAL.Default.connectionString);
            //Enviar comando
            SqlCommand command = new SqlCommand(commString, connection);
            // Cria Lista
            LinkedList<Consulta> consultaList = new LinkedList<Consulta>();
            try
            {
                // Abrir Ligação
                connection.Open();

                // Fecha Stream
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);


                while (reader.Read())
                {
                    Consulta consulta = new Consulta();
                    // Primeira coluna - 0
                    consulta.idConsulta = reader.GetInt32(0);
                    consulta.idSala = reader.GetInt32(2);
                    consulta.idEmpregado = reader.GetInt32(3);
                    consulta.idUtente = reader.GetInt32(1);
                    consulta.estado = reader.GetInt32(4);
                    consulta.observacoes = reader.GetString(5);
                    consulta.data = reader.GetDateTime(6);

                    consultaList.AddLast(consulta);

                }
            }
            catch (SqlException e)
            {

            }
            // Fecha a ligação
            connection.Close();
            return consultaList;
        }

        public static Consulta selectConsultaByIDConsulta(int idConsulta)
        {

            // Comando
            string commString = "SELECT * FROM Consulta where IDConsulta=" + idConsulta;
            // Criar Ligacao
            SqlConnection connection = new SqlConnection(DAL.Default.connectionString);
            //Enviar comando
            SqlCommand command = new SqlCommand(commString, connection);
            // Cria Lista
            Consulta consulta = new Consulta();
            try
            {
                // Abrir Ligação
                connection.Open();

                // Fecha Stream
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    // Primeira coluna - 0   
                    consulta.idConsulta = reader.GetInt32(0);
                    consulta.idSala = reader.GetInt32(2);
                    consulta.idEmpregado = reader.GetInt32(3);
                    consulta.idUtente = reader.GetInt32(1);
                    consulta.estado = reader.GetInt32(4);
                    consulta.observacoes = reader.GetString(5);
                    consulta.data = reader.GetDateTime(6);
                }

            }
            catch (SqlException e)
            {

            }
            // Fecha a ligação
            connection.Close();
            return consulta;
        }

        public static int updateEstadoConsulta(int idConsulta, int estado)
        {

            SqlConnection connection = new SqlConnection(DAL.Default.connectionString);

            string cmdString = "UPDATE Consulta SET estado=" + estado + " WHERE idConsulta = " + idConsulta;

            SqlCommand command = new SqlCommand(cmdString, connection);

            connection.Open();

            int nAffectedRows = command.ExecuteNonQuery();

            connection.Close();
            return nAffectedRows;
        }

        public static LinkedList<Especialidade> selectEspecialidadesComConsultaDoUtente(int idUtente)
        {
            // Comando
            string commString = "SELECT  DISTINCT  Especialidade_1.IdEspecialidade, Especialidade_1.Especialidade FROM dbo.Consulta INNER JOIN dbo.Medico ON dbo.Consulta.IdEmpregado = dbo.Medico.IdEmpregado INNER JOIN dbo.Especialidade AS Especialidade_1 ON dbo.Medico.IdEspecialidade = Especialidade_1.IdEspecialidade where medico.IdEmpregado = consulta.IdEmpregado and consulta.IdUtente=" + idUtente;

            // Criar Ligacao
            SqlConnection connection = new SqlConnection(DAL.Default.connectionString);
            //Enviar comando
            SqlCommand command = new SqlCommand(commString, connection);
            // Cria Lista
            LinkedList<Especialidade> especialidadeList = new LinkedList<Especialidade>();
            try
            {
                // Abrir Ligação
                connection.Open();

                // Fecha Stream
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);


                while (reader.Read())
                {
                    Especialidade especialidade = new Especialidade();
                    // Primeira coluna - 0

                    especialidade.idEspecialidade = reader.GetInt32(0);
                    especialidade.especialidade = reader.GetString(1);


                    especialidadeList.AddLast(especialidade);

                }
            }
            catch (SqlException e)
            {

            }
            // Fecha a ligação
            connection.Close();
            return especialidadeList;
        }

        public static LinkedList<Consulta> selectConsultaByIDUtente(int idUtente)
        {
            // Comando
            string commString = "SELECT dbo.Consulta.IdSala,  dbo.Consulta.IdConsulta, dbo.Medico.IdEmpregado, dbo.Consulta.IdUtente, dbo.Consulta.Estado, dbo.Consulta.Observacoes, dbo.Consulta.Data, dbo.Especialidade.Especialidade, dbo.Sala.Designacao, dbo.Empregado.Nome, dbo.Utente.Nome FROM            dbo.Consulta INNER JOIN  dbo.Medico ON dbo.Consulta.IdEmpregado = dbo.Medico.IdEmpregado INNER JOIN  dbo.Sala ON dbo.Consulta.IdSala = dbo.Sala.IdSala INNER JOIN dbo.Especialidade ON dbo.Medico.IdEspecialidade = dbo.Especialidade.IdEspecialidade INNER JOIN  dbo.Empregado ON dbo.Medico.IdEmpregado = dbo.Empregado.IdEmpregado INNER JOIN dbo.Utente ON dbo.Consulta.IdUtente = dbo.Utente.IdUtente		 where Utente.IdUtente = "+idUtente +" and Consulta.IdEmpregado = Medico.IdEmpregado";
            // Criar Ligacao
            SqlConnection connection = new SqlConnection(DAL.Default.connectionString);
            //Enviar comando
            SqlCommand command = new SqlCommand(commString, connection);
            // Cria Lista
            LinkedList<Consulta> consultaList = new LinkedList<Consulta>();
            try
            {
                // Abrir Ligação
                connection.Open();

                // Fecha Stream
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);


                while (reader.Read())
                {
                    Consulta consulta = new Consulta();
                    // Primeira coluna - 0
                    consulta.idConsulta = reader.GetInt32(1);
                    consulta.idUtente = reader.GetInt32(3);
                    consulta.idSala = reader.GetInt32(0);
                    consulta.idEmpregado = reader.GetInt32(2);
                    consulta.estado = reader.GetInt32(4);
                    consulta.observacoes = reader.GetString(5);
                    consulta.data = reader.GetDateTime(6);
                    consulta.nomeUtente = reader.GetString(10);
                    consulta.nomeEmpregado = reader.GetString(9);
                    consulta.especialidade = reader.GetString(7);
                    consulta.designacaoSala = reader.GetString(8);
                    

                    consultaList.AddLast(consulta);

                }
            }
            catch (SqlException e)
            {

            }
            // Fecha a ligação
            connection.Close();
            return consultaList;
        }

        public static LinkedList<Consulta> selectConsultaByIDMedico(int idMedico)
        {
            // Comando
            string commString = "SELECT dbo.Consulta.IdSala,  dbo.Consulta.IdConsulta, dbo.Medico.IdEmpregado, dbo.Consulta.IdUtente, dbo.Consulta.Estado, dbo.Consulta.Observacoes, dbo.Consulta.Data, dbo.Especialidade.Especialidade, dbo.Sala.Designacao, dbo.Empregado.Nome, dbo.Utente.Nome FROM            dbo.Consulta INNER JOIN  dbo.Medico ON dbo.Consulta.IdEmpregado = dbo.Medico.IdEmpregado INNER JOIN  dbo.Sala ON dbo.Consulta.IdSala = dbo.Sala.IdSala INNER JOIN dbo.Especialidade ON dbo.Medico.IdEspecialidade = dbo.Especialidade.IdEspecialidade INNER JOIN  dbo.Empregado ON dbo.Medico.IdEmpregado = dbo.Empregado.IdEmpregado INNER JOIN dbo.Utente ON dbo.Consulta.IdUtente = dbo.Utente.IdUtente where Consulta.IdEmpregado = Medico.IdEmpregado and Consulta.idEmpregado="+idMedico;
            
            //SELECT * FROM Consulta where idEmpregado=" + idMedico;
            // Criar Ligacao
            SqlConnection connection = new SqlConnection(DAL.Default.connectionString);
            //Enviar comando
            SqlCommand command = new SqlCommand(commString, connection);
            // Cria Lista
            LinkedList<Consulta> consultaList = new LinkedList<Consulta>();
            try
            {
                // Abrir Ligação
                connection.Open();

                // Fecha Stream
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);


                while (reader.Read())
                {
                    Consulta consulta = new Consulta();
                    // Primeira coluna - 0
                    consulta.idConsulta = reader.GetInt32(1);
                    consulta.idSala = reader.GetInt32(0);
                    consulta.idEmpregado = reader.GetInt32(2);
                    consulta.idUtente = reader.GetInt32(3);
                    consulta.estado = reader.GetInt32(4);
                    consulta.observacoes = reader.GetString(5);
                    consulta.data = reader.GetDateTime(6);
                    consulta.nomeUtente = reader.GetString(10);
                    consulta.nomeEmpregado = reader.GetString(9);
                    consulta.especialidade = reader.GetString(7);
                    consulta.designacaoSala = reader.GetString(8);
                    consultaList.AddLast(consulta);

                }
            }
            catch (SqlException e)
            {

            }
            // Fecha a ligação
            connection.Close();
            return consultaList;
        }

    }
}
