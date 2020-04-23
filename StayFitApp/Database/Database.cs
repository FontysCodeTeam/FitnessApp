using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFitApp.Database
{
    class Database
    {
        public MySqlConnection Con;
        public Database()
        {
            Connect();
            Disconnect();
        }

        public void Connect()
        {
            Con = new MySqlConnection("Server=149.210.192.120;Database=fhictDB;Uid=FHICTuser;Pwd=fhict_123;");
            Con.Open();
        }

        public void Disconnect()
        {
            Con.Close();
        }

        //Returns DataTable from query result
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

        //Returns the first column of the first row in the result set returned by the query. Additional columns or rows are ignored.
        public string ExecuteScalar(String Query)
        {
            this.Connect();

            MySqlCommand Command = new MySqlCommand(Query, Con);

            string result = Command.ExecuteScalar().ToString();

            this.Disconnect();

            return result;
        }

        //Executes a Transact-SQL statement against the connection and returns the number of rows affected.
        public int ExecuteNonQuery(String Query)
        {
            this.Connect();

            MySqlCommand Command = new MySqlCommand(Query, Con);

            int result = Command.ExecuteNonQuery();

            this.Disconnect();

            return result;
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
