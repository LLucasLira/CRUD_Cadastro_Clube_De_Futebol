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
    public class tecnicoRepositorio
    {
        private SqlConnection con;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);
        }

        //ADD
        public bool addTecnico(clsTecnico obj)
        {
            connection();
            SqlCommand com = new SqlCommand("AddNweTecnico", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@qtdTitulos", obj.qtdTitulos);
            com.Parameters.AddWithValue("@qtdTimes", obj.qtdTimes);
            com.Parameters.AddWithValue("@estrategia", obj.estrategia);
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
        public List<clsTecnico> getAllTecnicos()
        {
            connection();
            List<clsTecnico> tecnicoList = new List<clsTecnico>();

            SqlCommand com = new SqlCommand("pGetTecnico", con);
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
                tecnicoList.Add(
                    new clsTecnico
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        qtdTitulos = Convert.ToInt32(dr["qtdTitulos"]),
                        qtdTimes = Convert.ToInt32(dr["qtdTimes"]),
                        estrategia = Convert.ToString(dr["estrategia"]),
                        nome = Convert.ToString(dr["nome"]),
                        time = Convert.ToString(dr["time"]),
                        idade = Convert.ToInt32(dr["idade"])
                    }
                );
            }
            return tecnicoList;
        }

        //UPDATE
        public bool updateTecnico(clsTecnico obj, int id = 0)
        {
            connection();
            SqlCommand com = new SqlCommand("pUpdateTecnico", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", obj.Id);
            com.Parameters.AddWithValue("@qtdTitulos", obj.qtdTitulos);
            com.Parameters.AddWithValue("@qtdTimes", obj.qtdTimes);
            com.Parameters.AddWithValue("@estrategia", obj.estrategia);
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
        public bool deleteTecnico(int id)
        {
            connection();
            SqlCommand com = new SqlCommand("pDeleteTecnico", con);
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