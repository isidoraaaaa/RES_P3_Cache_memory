﻿using Common;
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
                    list.Add(reader.GetFloat(0));
                }
                catch (Exception e)
                {
                    Console.WriteLine("Usao");
                    Console.WriteLine(e.Message);
                }
            }
            reader.Close();
            return list;

        }
        
  


   
        public void UpisPodatakaUBazu(string tabela,string code,double vrednost)
        {
            SqlCommand command = new SqlCommand(String.Format("INSERT INTO {0} VALUES (@code, @vrednost);", tabela), connection.SqlConnection);
            command.Parameters.AddWithValue("@code", code);
            command.Parameters.AddWithValue("@vrednost", vrednost);
            command.ExecuteNonQuery();

            //// command.ExecuteNonQuery();
            //foreach (KeyValuePair<string, double> pair in HistoricalProperty)
            //{
            //    SqlCommand command = new SqlCommand(String.Format("INSERT INTO {0} VALUES (@code, @vrednost);", tabela), connection.SqlConnection);
            //    command.Parameters.AddWithValue("@code", pair.Key);
            //    command.Parameters.AddWithValue("@vrednost", pair.Value);

            //    command.ExecuteNonQuery();

            //}

        }
    }
}