using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaPodataka
{
    public class Baza : IBaza
    {
        private Connection connection = new Connection();
        public List<double> CitanjePodatakaIzBaze(string tabela,string code)
        {

            List<double> list = new List<double>();
            SqlCommand command = new SqlCommand(String.Format("SELECT vrednost FROM {0} " +
                                                              "WHERE code = @code ", tabela), connection.SqlConnection);
            command.Parameters.AddWithValue("@code", code);


            IDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                try
                {
                    list.Add(reader.GetDouble(0));
                }
                catch (Exception e)
                {
                   
                    Console.WriteLine(e.Message);
                }
            }
            reader.Close();
            return list;

        }

        public List<double> citanjePodatakaSaDatumom(string od,string doo,string kod,string tabela)
        {
            List<double> lista = new List<double>();
            SqlCommand komanda = new SqlCommand(String.Format("SELECT vrednost FROM {0} WHERE code = @code AND vreme BETWEEN @od and @do", tabela),connection.SqlConnection);
            komanda.Parameters.AddWithValue("@code", kod);
            komanda.Parameters.AddWithValue("@od", od);
            komanda.Parameters.AddWithValue("@do", doo);


            IDataReader reader = komanda.ExecuteReader();

            while (reader.Read())
            {
                try
                {
                    lista.Add(reader.GetDouble(0));
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
            }
            reader.Close();


            return lista;
        }
 
        public void UpisPodatakaUBazu(string tabela,string code,double vrednost,DateTime vreme)
        {
            SqlCommand command = new SqlCommand(String.Format("INSERT INTO {0} VALUES (@vrednost, @code,@vreme);", tabela), connection.SqlConnection);
            command.Parameters.AddWithValue("@code", code);
            command.Parameters.AddWithValue("@vrednost", vrednost);
            command.Parameters.AddWithValue("@vreme", vreme);
            command.ExecuteNonQuery();

        }
    }
}
