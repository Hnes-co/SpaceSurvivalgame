using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


    class SQL
    {
        

        public static float ReadTemp()
        {
            
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "*********";
                builder.UserID = "*********";
                builder.Password = "*********";
                builder.InitialCatalog = "*********";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    

                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT TOP 1 *");
                    sb.Append("FROM [dbo].[SensorData] ");
                    sb.Append("ORDER BY id desc; ");
                    String sql = sb.ToString();

                

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            decimal des = reader.GetDecimal(2);
                            string str = des.ToString();
                            float.TryParse(str, out float lamp);
                            return lamp;

                        }

                    }
                    }
                
            }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        return 0;
        }

    public static float ReadHumid()
    {

        try
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "*********";
            builder.UserID = "*********";
            builder.Password = "*********";
            builder.InitialCatalog = "*********";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {


                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT TOP 1 *");
                sb.Append("FROM [dbo].[SensorData] ");
                sb.Append("ORDER BY id desc; ");
                String sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        
                        
                            while (reader.Read())
                            {

                                decimal des = reader.GetDecimal(3);
                                string str = des.ToString();
                                float.TryParse(str, out float humid);
                                return humid;

                            }
                        
                    }
                }
            }
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.ToString());
        }
        return 0;
    }

    public static float ReadPress()
    {

        try
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "*********";
            builder.UserID = "*********";
            builder.Password = "*********";
            builder.InitialCatalog = "*********";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {


                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT TOP 1 *");
                sb.Append("FROM [dbo].[SensorData] ");
                sb.Append("ORDER BY id desc; ");
                String sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {  
                        while (reader.Read())
                        {

                            decimal des = reader.GetDecimal(4);
                            string str = des.ToString();
                            float.TryParse(str, out float press);
                            return press;

                        }
                    }
                }
            }
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.ToString());
        }
        return 0;
    }

}
