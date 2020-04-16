using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFitApp.Database
{
    class DatabaseConnection
    {
        public MySqlConnection Con;
        public DatabaseConnection()
        {
            Connect();
            Disconnect();
        }

        public void Connect()
        {
            Con = new MySqlConnection("Server=81.207.39.183;Database=FHICTDB;Uid=FHICTuser;Pwd=fhict_123;");
            Con.Open();
        }

        public void Disconnect()
        {
            Con.Close();
        }

        public DataTable ExecuteStringQuery(String Query)
        {
            DataTable Result = new DataTable();

            Connect();

            if (Verify() == true)
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(Query, Con);
                adapter.Fill(Result);
            }
            //MySqlCommand Command = new MySqlCommand(Query, Con);

            Disconnect();

            return Result;
        }

        public bool Verify()
        {
            Console.WriteLine(this.Con.State);
            if (this.Con.State == ConnectionState.Open)
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
