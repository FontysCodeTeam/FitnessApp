using StayFitApp.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFitApp.Models
{
   
    public class Queries
    {
        Database db = new Database();

        public DataTable getHistory(int id)
        {
            DataTable dt = db.ExecuteStringQuery($"SELECT * FROM history WHERE userID = '{id}';");

            return dt;
        } 
            
    }
}
