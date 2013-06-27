using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer;
using DataTransferObject;

namespace BusinessLogicLayer
{
    public class consultaBLL
    {
          public static LinkedList<Consulta> selectConsulta()
        {
             return consultaDAL.selectConsulta();
        }

          public static Consulta selectConsultaByIDConsulta(int idConsulta)
          {
              return consultaDAL.selectConsultaByIDConsulta(idConsulta);
          }

          public static int updateEstadoConsulta(int idConsulta, int estado)
          {
             return consultaDAL.updateEstadoConsulta(idConsulta, estado);
          }

          public static LinkedList<Especialidade> selectEspecialidadesComConsultaDoUtente(int idUtente)
          {
              return consultaDAL.selectEspecialidadesComConsultaDoUtente(idUtente);
          }

          public static LinkedList<Consulta> selectConsultaByIDUtente(int idUtente)
          {
              return consultaDAL.selectConsultaByIDUtente(idUtente);
          }

          public static LinkedList<Consulta> selectConsultaByIDMedico(int idMedico)
          {
              return consultaDAL.selectConsultaByIDMedico(idMedico);
          }
    }
}
