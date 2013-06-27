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
    public class prescricaoDAL
    {
        public static int inserirPrescricao(int idPrescricao)
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
            string cmdString = "INSERT INTO PRESCRICAO (idPrescricao)" + " VALUES (@idPrescricao)";

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
            SqlParameter pIdPrescricao = new SqlParameter("@idPrescricao", System.Data.SqlDbType.Int);
            pIdPrescricao.Value = idPrescricao;
            command.Parameters.Add(pIdPrescricao);



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

        public static LinkedList<ElementosPrescritos> selectPrescricaoByIDDiagnostico(int idDiagnostico)
        {
            // Comando
            string commString = "SELECT dbo.ElementosPrescritos.*, dbo.PrescricaoElementosPrescritos.Quantidade FROM dbo.ElementosPrescritos INNER JOIN dbo.PrescricaoElementosPrescritos INNER JOIN dbo.Prescricao ON dbo.PrescricaoElementosPrescritos.IdPrescricao = dbo.Prescricao.IdPrescricao ON  dbo.ElementosPrescritos.IdElemento = dbo.PrescricaoElementosPrescritos.IdElemento INNER JOIN dbo.Diagnostico ON dbo.Prescricao.IdPrescricao = dbo.Diagnostico.IdPrescricao INNER JOIN dbo.Utente INNER JOIN dbo.Consulta ON dbo.Utente.IdUtente = dbo.Consulta.IdUtente ON dbo.Diagnostico.IdConsulta = dbo.Consulta.IdConsulta where Diagnostico.IdDiagnostico = " + idDiagnostico;
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

        public static int inserirPrescricaoElementosPrescritos(PrescricaoElementosPrescritos resultPrescricaoElementosPrescritos)
        {
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
                string cmdString = "INSERT INTO PRESCRICAOELEMENTOSPRESCRITOS (idElemento, idPrescricao, quantidade)" + " VALUES (@idElemento, @idPrescricao, @quantidade)";

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
                SqlParameter pIdElemento = new SqlParameter("@idElemento", System.Data.SqlDbType.Int);
                pIdElemento.Value = resultPrescricaoElementosPrescritos.idElementosPrescritos;
                command.Parameters.Add(pIdElemento);

                SqlParameter pIdPrescricao = new SqlParameter("@idPrescricao", System.Data.SqlDbType.Int);
                pIdPrescricao.Value = resultPrescricaoElementosPrescritos.idPrescricao;
                command.Parameters.Add(pIdPrescricao);

                SqlParameter pQuantidade = new SqlParameter("@quantidade", System.Data.SqlDbType.NVarChar);
                pQuantidade.Value = resultPrescricaoElementosPrescritos.quantidade;
                command.Parameters.Add(pQuantidade);

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
        }

        public static void apagarPrescricaoElementosPrescritos(int idPrescricao)
        {
            string commString = "DELETE FROM PRESCRICAOELEMENTOSPRESCRITOS where idPrescricao="+idPrescricao;
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

        public static void apagarPrescricao(int idPrescricao)
        {
            string commString = "DELETE FROM PRESCRICAO where idPrescricao=" + idPrescricao;
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
