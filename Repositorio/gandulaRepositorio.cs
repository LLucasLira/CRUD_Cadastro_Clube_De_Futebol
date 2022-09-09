using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CADASTRO_DE_CLUBE_DE_FUTEBOL.Models;

namespace CADASTRO_DE_CLUBE_DE_FUTEBOL.Repositorio
{
    public class gandulaRepositorio
    {
        private SqlConnection con;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);
        }

        //ADD
        public bool addGandula(clsGandula obj)
        {
            string peQuenteFrio = string.Empty;

            double calculo = 0.0;

            calculo = (obj.jogosVencidos * 100)/ obj.jogosTrabalhados;

            if(calculo < 60){
                peQuenteFrio = "Azarado";
            }
            else
            {
                peQuenteFrio = "Sortudo";
            }

            connection();
            SqlCommand com = new SqlCommand("pAddNweGandula", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@jogosTrabalhados", obj.jogosTrabalhados);
            com.Parameters.AddWithValue("@jogosVencidos", obj.jogosVencidos);
            com.Parameters.AddWithValue("@peQuenteFrio", peQuenteFrio);
            com.Parameters.AddWithValue("@nome", obj.nome);
            com.Parameters.AddWithValue("@time", obj.time);
            com.Parameters.AddWithValue("@idade", obj.idade);

            con.Open();
            int valida = com.ExecuteNonQuery();
            con.Close();
            if (valida >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //CONSULTAR
        public List<clsGandula> getAllGandulas()
        {
            connection();
            List<clsGandula> gandulapList = new List<clsGandula>();

            SqlCommand com = new SqlCommand("pGetGandula", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            try
            {
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro em: " + ex.Message);
            }

            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                gandulapList.Add(
                    new clsGandula
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        jogosTrabalhados = Convert.ToInt32(dr["jogosTrabalhados"]),
                        jogosVencidos = Convert.ToInt32(dr["jogosVencidos"]),
                        peQuenteFrio = Convert.ToString(dr["peQuenteFrio"]),
                        nome = Convert.ToString(dr["nome"]),
                        time = Convert.ToString(dr["time"]),
                        idade = Convert.ToInt32(dr["idade"])
                    }
                );
            }
            return gandulapList;
        }

        //UPDATE
        public bool updateGandula(clsGandula obj, int id)
        {

            string peQuenteFrio = string.Empty;

            double calculo = 0.0;

            calculo = (obj.jogosVencidos * 100) / obj.jogosTrabalhados;

            if (calculo < 60)
            {
                peQuenteFrio = "Azarado";
            }
            else
            {
                peQuenteFrio = "Sortudo";
            }
            connection();
            SqlCommand com = new SqlCommand("pUpdateGandula", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", obj.Id);
            com.Parameters.AddWithValue("@jogosTrabalhados", obj.jogosTrabalhados);
            com.Parameters.AddWithValue("@jogosVencidos", obj.jogosVencidos);
            com.Parameters.AddWithValue("@peQuenteFrio", peQuenteFrio);
            com.Parameters.AddWithValue("@nome", obj.nome);
            com.Parameters.AddWithValue("@time", obj.time);
            com.Parameters.AddWithValue("@idade", obj.idade);

            con.Open();
            int valida = com.ExecuteNonQuery();
            con.Close();
            if (valida >= 1)
            {
                return true;
            }
            else
            {

                return false;
            }   
        }

        //DELET
        public bool deleteGandula(int id)
        {
            connection();
            SqlCommand com = new SqlCommand("pDeleteGandula", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("Id", id);

            con.Open();
            int valida = com.ExecuteNonQuery();
            con.Close();
            if (valida >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }    
}