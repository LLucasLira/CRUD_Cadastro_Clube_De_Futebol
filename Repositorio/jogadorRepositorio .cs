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
    public class jogadorRepositorio
    {
        private SqlConnection con;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);
        }

        //ADD
        public bool addJogador(clsJogador obj)
        {
            connection();
            SqlCommand com = new SqlCommand("pAddNweJogador", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@posicao", obj.posicao);
            com.Parameters.AddWithValue("@numeroCamisa", obj.numeroCamisa);
            com.Parameters.AddWithValue("@golsMarcados", obj.golsMarcados);
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
        public List<clsJogador> getAllJogadores()
        {
            connection();
            List<clsJogador> jogadorList = new List<clsJogador>();

            SqlCommand com = new SqlCommand("pGetJogador", con);
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
                jogadorList.Add(
                    new clsJogador
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        posicao = Convert.ToString(dr["posicao"]),
                        numeroCamisa = Convert.ToInt32(dr["numeroCamisa"]),
                        golsMarcados = Convert.ToInt32(dr["golsMarcados"]),
                        nome = Convert.ToString(dr["nome"]),
                        time = Convert.ToString(dr["time"]),
                        idade = Convert.ToInt32(dr["idade"])
                    }
                );
            }
            return jogadorList;
        }

        //UPDATE
        public bool updateJogador(clsJogador obj, int id)
        {
            connection();
            SqlCommand com = new SqlCommand("pUpdateJogador", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", obj.Id);
            com.Parameters.AddWithValue("@posicao", obj.posicao);
            com.Parameters.AddWithValue("@numeroCamisa", obj.numeroCamisa);
            com.Parameters.AddWithValue("@golsMarcados", obj.golsMarcados);
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
        public bool deleteJogador(int Id)
        {
            connection();
            SqlCommand com = new SqlCommand("pDeleteJogador", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("Id", Id);

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