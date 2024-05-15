using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Test.Model
{
    public class ConectionQuerys
    {
        private string Connexion= "Data Source=192.168.10.4;Initial Catalog=TEST_EJEMPLO;User ID=EDUARDO;Password=ABC123;";

        public ConectionQuerys(string Connexion) 
        {
            this.Connexion = Connexion;
        }

        public DataSet QUERYSELECTED(string query)
        {
            DataSet DS = new DataSet();

            try
            {
                using (SqlConnection connection = new SqlConnection(Connexion))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error en la consulta Select: " + ex.Message);
            }

            return DS;
        }

        public int NONQUERY(string query)
        {
            int filasAfectadas = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(Connexion))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    filasAfectadas = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar consulta INSERT, UPDATE o DELETE: " + ex.Message);
            }

            return filasAfectadas;
        }

        public int TotalFilasDevueltas(string query)
        {
            int cantidadFilas = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, Connexion);
                    SqlDataReader RD = command.ExecuteReader();

                    if (RD.HasRows)
                    {
                        while (RD.Read())
                        {
                            cantidadFilas++;
                        }
                    }

                    RD.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error para obtener el total de filas: " + ex.Message);
            }

            return cantidadFilas;
        }

    }
}
