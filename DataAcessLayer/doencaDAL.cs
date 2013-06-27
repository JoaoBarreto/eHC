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
    public class doencaDAL
    {
        public static LinkedList<Doenca> selectDoenca()
        {
            // Comando
            string commString = "SELECT * FROM Doenca";
            // Criar Ligacao
            SqlConnection connection = new SqlConnection(DAL.Default.connectionString);
            //Enviar comando
            SqlCommand command = new SqlCommand(commString, connection);
            // Cria Lista
            LinkedList<Doenca> doencaList = new LinkedList<Doenca>();
            try
            {
                // Abrir Ligação
                connection.Open();

                // Fecha Stream
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    Doenca doenca = new Doenca();
                    // Primeira coluna - 0
                    if (!reader.IsDBNull(0))
                        doenca.idDoenca = reader.GetInt32(0);
                    if (!reader.IsDBNull(1))
                        doenca.descricao = reader.GetString(1);
                    if (!reader.IsDBNull(2))
                        doenca.sintomas = reader.GetString(2);

                    doencaList.AddLast(doenca);

                }
            }
            catch (SqlException e)
            {

            }
            // Fecha a ligação
            connection.Close();
            return doencaList;
        }

        public static Doenca selectDoencaByNome(string each)
        {


            // Comando
            string commString = "SELECT * FROM Doenca where descricao='" +each+"'";
            // Criar Ligacao
            SqlConnection connection = new SqlConnection(DAL.Default.connectionString);
            //Enviar comando
            SqlCommand command = new SqlCommand(commString, connection);
            // Cria Lista
            Doenca doenca = new Doenca();

            // Abrir Ligação
            connection.Open();

            // Fecha Stream
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            while (reader.Read())
            {

                // Primeira coluna - 0
                if (!reader.IsDBNull(0))
                    doenca.idDoenca = reader.GetInt32(0);
                if (!reader.IsDBNull(1))
                    doenca.descricao = reader.GetString(1);
                if (!reader.IsDBNull(2))
                    doenca.sintomas = reader.GetString(2);

            }


            // Fecha a ligação
            connection.Close();
            return doenca;


        }
    } 
}
