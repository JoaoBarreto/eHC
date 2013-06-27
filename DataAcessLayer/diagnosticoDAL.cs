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
    public class diagnosticoDAL
    {
        public static LinkedList<Diagnostico> selectDiagnostico()
        {
            // Comando
            string commString = "SELECT * FROM Diagnostico";
            // Criar Ligacao
            SqlConnection connection = new SqlConnection(DAL.Default.connectionString);
            //Enviar comando
            SqlCommand command = new SqlCommand(commString, connection);
            // Cria Lista
            LinkedList<Diagnostico> diagnosticoList = new LinkedList<Diagnostico>();
            try
            {
                // Abrir Ligação
                connection.Open();

                // Fecha Stream
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    Diagnostico diagnostico = new Diagnostico();
                    // Primeira coluna - 0
                    if (!reader.IsDBNull(0))
                        diagnostico.idConsulta = reader.GetInt32(0);
                    if (!reader.IsDBNull(1))
                        diagnostico.idDiagnostico = reader.GetInt32(1);
                    if (!reader.IsDBNull(2))
                        diagnostico.diagnostico = reader.GetString(2);

                    diagnosticoList.AddLast(diagnostico);

                }
            }
            catch (SqlException e)
            {

            }
            // Fecha a ligação
            connection.Close();
            return diagnosticoList;
        }

        public static LinkedList<Diagnostico> selectDiagnosticoByIDUtente(int idUtente)
        {
            // Comando
            string commString = "SELECT dbo.Diagnostico.IdDiagnostico, dbo.Consulta.Data, dbo.Diagnostico.Diagnostico FROM  dbo.Consulta INNER JOIN dbo.Diagnostico ON dbo.Consulta.IdConsulta = dbo.Diagnostico.IdConsulta and Consulta.idUtente=" + idUtente;
            // Criar Ligacao
            SqlConnection connection = new SqlConnection(DAL.Default.connectionString);
            //Enviar comando
            SqlCommand command = new SqlCommand(commString, connection);
            // Cria Lista
            LinkedList<Diagnostico> diagnosticoList = new LinkedList<Diagnostico>();
            try
            {
                // Abrir Ligação
                connection.Open();

                // Fecha Stream
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    Diagnostico diagnostico = new Diagnostico();
                    // Primeira coluna - 0

                    if (!reader.IsDBNull(0))
                        diagnostico.idDiagnostico = reader.GetInt32(0);
                    if (!reader.IsDBNull(1))
                        diagnostico.data = reader.GetDateTime(1);
                    if (!reader.IsDBNull(2))
                        diagnostico.diagnostico = reader.GetString(2);
                    diagnosticoList.AddLast(diagnostico);

                }
            }
            catch (SqlException e)
            {

            }
            // Fecha a ligação
            connection.Close();
            return diagnosticoList;
        }

        public static LinkedList<Diagnostico_Doenca> selectDoencaByDiagnostico(int idDiagnostico)
        {
            // Comando
            string commString = "SELECT dbo.Doenca.descricao FROM dbo.DiagnosticoDoenca INNER JOIN dbo.Diagnostico ON dbo.DiagnosticoDoenca.IdDiagnostico = dbo.Diagnostico.IdDiagnostico INNER JOIN dbo.Doenca ON dbo.DiagnosticoDoenca.IdDoenca = dbo.Doenca.IdDoenca INNER JOIN dbo.Consulta ON dbo.Diagnostico.IdConsulta = dbo.Consulta.IdConsulta and Diagnostico.IdDiagnostico =" + idDiagnostico;

            // Criar Ligacao
            SqlConnection connection = new SqlConnection(DAL.Default.connectionString);
            //Enviar comando
            SqlCommand command = new SqlCommand(commString, connection);
            // Cria Lista
            LinkedList<Diagnostico_Doenca> diagnosticoDoencaList = new LinkedList<Diagnostico_Doenca>();
            try
            {
                // Abrir Ligação
                connection.Open();

                // Fecha Stream
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    Diagnostico_Doenca diagnostico_Doenca = new Diagnostico_Doenca();
                    // Primeira coluna - 0

                    if (!reader.IsDBNull(0))
                        diagnostico_Doenca.doenca = reader.GetString(0);
                    diagnosticoDoencaList.AddLast(diagnostico_Doenca);

                }
            }
            catch (SqlException e)
            {

            }
            // Fecha a ligação
            connection.Close();
            return diagnosticoDoencaList;
        }

        /*
     * Argumentos: MedicoDTO medico - objeto que contém o objeto Medico a inserir na BD
     */
        public static int insertDiagnosticoConsulta(Diagnostico diagnostico)
        {
            /*SqlConnection connection:
             * O construtor do SqlConnection recebe uma string. Neste caso está definida no ficheiro DAL.settings
             */
            SqlConnection connection = new SqlConnection(DAL.Default.connectionString);
            /*string cmdString:
             * String com o comando a executar na base de dados. 
             * Se tiver valores do objeto recebido para inserir na BD (e neste caso tem), devemos colocar os nomes dos atributos antecedidos por uma '@'
             * de forma a que estes sejam substituídos por parametros mais à frente.
             */
            string cmdString = "INSERT INTO Diagnostico (idConsulta, idDiagnostico, idPrescricao, diagnostico)" + " VALUES (@idConsulta, @idDiagnostico, @idPrescricao, @diagnostico)";

            /*SqlCommand command
             *Inclui a String que vai ser corrida no SQL Server (cmdString) e a ligação à base de dados (connection)
             *
             */
            SqlCommand command = new SqlCommand(cmdString, connection);

            /* Número de linhas da tabela afetadas pelo comando SQL:
             * Ao corrermos um comando de INSERT,UPDATE ou DELETE, vai ser retornado o número de linhas da tabela que foram afetadas na tabela
             * Se algo tiver corrido mal o valor será 0
             * No caso específico do eHC, como só inserimos uma linha de cada vez o valor de retorno irá ser 1 (caso tudo corra bem só UMA linha será inserida).
             */
            int nAffectedRows = 0;

            //A partir deste momento poderão ocorrer exceções no módulo do SQL pelo que é necessário colocar seguinte código dentro de um "try catch"
            //    try
            //   {
            //Estabelecer a ligação ao SQL Server
            connection.Open();

            //Estes SqlParameter servem para substituirmos os valores da string do comando (cmdString) pelos valores do objeto recebido
            /*
             * 1) Para cada parâmetro deve ser definida a sua "tag" na string (no caso abaixo: "@nome") e o tipo de dados a ser inserido na base de dados
             * 2) Dever-se-á copiar o valor do objeto recebido para o SqlParameter
             * 3) Tem de se adicionar o parâmetro ao comando SQL (command)
             */
            SqlParameter pIdConsulta = new SqlParameter("@idConsulta", System.Data.SqlDbType.Int);
            pIdConsulta.Value = diagnostico.idConsulta;
            command.Parameters.Add(pIdConsulta);

            SqlParameter pIdDiagnostico = new SqlParameter("@idDiagnostico", System.Data.SqlDbType.Int);
            pIdDiagnostico.Value = diagnostico.idDiagnostico;
            command.Parameters.Add(pIdDiagnostico);

            SqlParameter pIdPrescricao = new SqlParameter("@idPrescricao", System.Data.SqlDbType.Int);
            pIdPrescricao.Value = diagnostico.idPrescricao;
            command.Parameters.Add(pIdPrescricao);

            SqlParameter pDiagnostico = new SqlParameter("@diagnostico", System.Data.SqlDbType.NVarChar);
            pDiagnostico.Value = diagnostico.diagnostico;
            command.Parameters.Add(pDiagnostico);




            /*
             * Para executarmos um comando que não exige retorno de informação das tabelas utilizamos o ExecuteNonQuery()
             * Como referido anteriormente, este método retorna o número de linhas da tabela afetadas pelo comando
             */
            nAffectedRows = command.ExecuteNonQuery();



            //   }
            //   catch (SqlException exception)
            //  {
            //       Console.WriteLine(exception.StackTrace);
            //  }
            connection.Close();
            return nAffectedRows;
        }

        public static int countDiagnosticos()
        {
            string commString = "SELECT COUNT(*) FROM Diagnostico";
            // Criar Ligacao
            SqlConnection connection = new SqlConnection(DAL.Default.connectionString);
            //Enviar comando
            SqlCommand command = new SqlCommand(commString, connection);
            // Cria Lista
            int numeroDiagnosticos = -1;
            try
            {
                // Abrir Ligação
                connection.Open();

                // Fecha Stream
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    Diagnostico_Doenca diagnostico_Doenca = new Diagnostico_Doenca();
                    // Primeira coluna - 0

                    if (!reader.IsDBNull(0))
                        numeroDiagnosticos = reader.GetInt32(0);


                }
            }
            catch (SqlException e)
            {

            }
            // Fecha a ligação
            connection.Close();
            return numeroDiagnosticos;
        }

        public static int insertDiagnosticoDoenca(int idDoenca, int idDiagnostico)
        {
            /*SqlConnection connection:
             * O construtor do SqlConnection recebe uma string. Neste caso está definida no ficheiro DAL.settings
             */
            SqlConnection connection = new SqlConnection(DAL.Default.connectionString);
            /*string cmdString:
             * String com o comando a executar na base de dados. 
             * Se tiver valores do objeto recebido para inserir na BD (e neste caso tem), devemos colocar os nomes dos atributos antecedidos por uma '@'
             * de forma a que estes sejam substituídos por parametros mais à frente.
             */
            string cmdString = "INSERT INTO DiagnosticoDoenca (idDiagnostico, idDoenca)" + " VALUES (@idDiagnostico, @idDoenca)";

            /*SqlCommand command
             *Inclui a String que vai ser corrida no SQL Server (cmdString) e a ligação à base de dados (connection)
             *
             */
            SqlCommand command = new SqlCommand(cmdString, connection);

            /* Número de linhas da tabela afetadas pelo comando SQL:
             * Ao corrermos um comando de INSERT,UPDATE ou DELETE, vai ser retornado o número de linhas da tabela que foram afetadas na tabela
             * Se algo tiver corrido mal o valor será 0
             * No caso específico do eHC, como só inserimos uma linha de cada vez o valor de retorno irá ser 1 (caso tudo corra bem só UMA linha será inserida).
             */
            int nAffectedRows = 0;

            //A partir deste momento poderão ocorrer exceções no módulo do SQL pelo que é necessário colocar seguinte código dentro de um "try catch"
            //    try
            //   {
            //Estabelecer a ligação ao SQL Server
            connection.Open();

            //Estes SqlParameter servem para substituirmos os valores da string do comando (cmdString) pelos valores do objeto recebido
            /*
             * 1) Para cada parâmetro deve ser definida a sua "tag" na string (no caso abaixo: "@nome") e o tipo de dados a ser inserido na base de dados
             * 2) Dever-se-á copiar o valor do objeto recebido para o SqlParameter
             * 3) Tem de se adicionar o parâmetro ao comando SQL (command)
             */
            SqlParameter pIdDiagnostico = new SqlParameter("@idDiagnostico", System.Data.SqlDbType.Int);
            pIdDiagnostico.Value = idDiagnostico;
            command.Parameters.Add(pIdDiagnostico);

            SqlParameter pIdDoenca = new SqlParameter("@idDoenca", System.Data.SqlDbType.Int);
            pIdDoenca.Value = idDoenca;
            command.Parameters.Add(pIdDoenca);

            /*
             * Para executarmos um comando que não exige retorno de informação das tabelas utilizamos o ExecuteNonQuery()
             * Como referido anteriormente, este método retorna o número de linhas da tabela afetadas pelo comando
             */
            nAffectedRows = command.ExecuteNonQuery();



            //   }
            //   catch (SqlException exception)
            //  {
            //       Console.WriteLine(exception.StackTrace);
            //  }
            connection.Close();
            return nAffectedRows;
        }

        public static void apagarDiagnosticoDoenca(int idDiagnostico)
        {
            string commString = "DELETE FROM DiagnosticoDoenca where idDiagnostico=" + idDiagnostico;
            // Criar Ligacao
            SqlConnection connection = new SqlConnection(DAL.Default.connectionString);
            //Enviar comando
            SqlCommand command = new SqlCommand(commString, connection);
            // Cria Lista
            int numeroDiagnosticos = -1;
            try
            {
                // Abrir Ligação
                connection.Open();

                // Fecha Stream
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);


            }
            catch (SqlException e)
            {

            }
            // Fecha a ligação
            connection.Close();

        }

        public static void apagarDiagnostico(int idDiagnostico)
        {
            {
                string commString = "DELETE FROM Diagnostico where idDiagnostico=" + idDiagnostico;
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

        public static Diagnostico selectDiagnosticoByIDConsulta(int idConsulta)
        {
            // Comando
            string commString = "SELECT dbo.Diagnostico.IdDiagnostico, dbo.Consulta.Data, dbo.Diagnostico.Diagnostico FROM  dbo.Consulta INNER JOIN dbo.Diagnostico ON dbo.Consulta.IdConsulta = dbo.Diagnostico.IdConsulta and Consulta.idConsulta=" + idConsulta;
            // Criar Ligacao
            SqlConnection connection = new SqlConnection(DAL.Default.connectionString);
            //Enviar comando
            SqlCommand command = new SqlCommand(commString, connection);
            // Cria Lista
            Diagnostico diagnostico = new Diagnostico();
           
                // Abrir Ligação
                connection.Open();

                // Fecha Stream
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                 
                while (reader.Read())
                {
                   
                    // Primeira coluna - 0

                    if (!reader.IsDBNull(0))
                        diagnostico.idDiagnostico = reader.GetInt32(0);
                    if (!reader.IsDBNull(1))
                        diagnostico.data = reader.GetDateTime(1);
                    if (!reader.IsDBNull(2))
                        diagnostico.diagnostico = reader.GetString(2);
                    
                }
          

            
            // Fecha a ligação
            connection.Close();
            return diagnostico;
        }
        
    }
}
